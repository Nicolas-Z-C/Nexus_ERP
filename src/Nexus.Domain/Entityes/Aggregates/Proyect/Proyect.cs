using System.ComponentModel;
using Nexus.Domain.Common.Result;
using Nexus.Domain.Entityes.Common;
using Nexus.Domain.Enums;
using Nexus.Domain.Errors;
using Nexus.Domain.Interfaces.Common;
using Nexus.Domain.ValueObjects.Names;

namespace Nexus.Domain.Entityes.Aggregates.Proyect
{
    public class Proyect : AuditableEntity, Itenant
    {
        public ProyectName ProyectName {get; private set;}
        public decimal Budget {get; private set;}
        public decimal ContractPrice {get; private set;}
        public decimal EstimatedProffit {get; private set;}
        public int EstimatedDurationDays {get; private set;}
        public DateTime DateOfStart {get; private set;}
        public DateTime EstimatedDateOfRelease {get; private set;}
        public DateTime? RealDateOfRelease {get; private set;}
        public bool IsDelayed {get; private set;} = false;

        //This flag is made to ensure that a user cannot go back to a planning stage once it has steped out of it
        public bool HasLeftPlanningStage  {get; private set;} = false;
        //FKs - enums

        public Currency Currency {get; private set;}
        public ProyectStatus ProyectState {get; private set;} = ProyectStatus.StandBy;
        public Guid TenantId {get; set;}

        //Child entities

        private readonly List<Assignement> _assignements = new List<Assignement>();

        public IReadOnlyCollection<Assignement> Assignements => _assignements.AsReadOnly();

        //Constructors

        internal Proyect() {}

        private Proyect(
            ProyectName proyectName,
            decimal budget,
            decimal contractPrice,
            decimal estimatedProffit,
            int estimatedDurationDays,
            DateTime dateStart,
            DateTime dateReleaseEst,
            Guid tenantId,
            Currency currency
        )
        {
            ProyectName = proyectName;
            Budget = budget;
            ContractPrice = contractPrice;
            EstimatedProffit = estimatedProffit;
            EstimatedDurationDays = estimatedDurationDays;
            DateOfStart = dateStart;
            EstimatedDateOfRelease = dateReleaseEst;
            TenantId = tenantId;
            Currency = currency;
        }

        //Own Methods

        public static Result<Proyect> Create(
            string proyectName,
            decimal budget,
            decimal contractPrice,
            int estimatedDurationDays,
            DateTime dateStart,
            Guid tenantId,
            Currency currency
        )
        {
            var result = ProyectName.Create(proyectName);

            if(result.IsFailure)
                return result.Error;
            
            if(budget <= 0)
                return Result<Proyect>.Failure(new Error("Proyecto.Valores","El presupuesto no puede esar vacio o ser igual a cero"));

            if(contractPrice < 0)
                return Result<Proyect>.Failure(new Error("Proyecto.Valores","El precio del contrato no puede ser menor a cero"));
            
            if(dateStart < DateTime.Now)
                return Result<Proyect>.Failure(new Error("Proyecto.Valores","La fecha de inicio del proyecto no puede se anterior a hoy"));

            var Proyect = new Proyect(
                result.Value,
                budget,
                contractPrice,
                contractPrice-budget,
                estimatedDurationDays,
                dateStart,
                dateStart.AddDays(estimatedDurationDays),
                tenantId,
                currency
            );

            return Result<Proyect>.Success(Proyect);            
        }

        public Result<Proyect> ChangeStatus(ProyectStatus newStatus)
        {
            if(newStatus == ProyectStatus.Cancelled || newStatus == ProyectStatus.Finished)
                return Result<Proyect>.Failure(new Error("Proyecto.Status","El proyecto no puede ser eliminado ni cancelado desde esta ventana"));

            if(newStatus == ProyectStatus.Planning && HasLeftPlanningStage )
                return Result<Proyect>.Failure(new Error($"Proyecto.Estado","El estado actual es superior al propuesto"));    

            if(newStatus == ProyectStatus.Planning)
            {
                HasLeftPlanningStage  = true;
                ProyectState = newStatus;
                return Result<Proyect>.Success(this);
            }

            if(newStatus == ProyectState)
                return Result<Proyect>.NoChanges(this);        

            var check = StatusCheck();
            if(check.IsFailure)
                return Result<Proyect>.Failure(check.Error);
            
            ProyectState = newStatus;
            Update();
            return Result<Proyect>.Success(this);
        } 

        public Result<Proyect> FinishProyect()
        {
            var check = StatusCheck();
            if(check.IsFailure)
                return Result<Proyect>.Failure(check.Error);

            if(_assignements.Any(a => a.TaskStatus == Task_status.Finished || a.TaskStatus == Task_status.Cancelled))
                return Result<Proyect>.Failure(new Error("Proyecto.Finalizar","El proyecto aun tiene tareas pendientes, porfavor resuelva estas primero"));

            ProyectState = ProyectStatus.Finished;
            RealDateOfRelease = DateTime.Now;
            Update();
            return Result<Proyect>.Success(this);
        }

        public Result<Proyect> CancelProyect()
        {
            var check = StatusCheck();
            if(check.IsFailure)
                return Result<Proyect>.Failure(check.Error);
            
            ProyectState = ProyectStatus.Cancelled;
            foreach (var assignement in _assignements)
            {
                assignement.Cancel();
            }
            Update();
            return Result<Proyect>.Success(this);
        }

        public Result<Proyect> ChangeBudget(decimal newBudget)
        {
            var check = StatusCheck();
            if(check.IsFailure)
                return Result<Proyect>.Failure(check.Error);

            if(newBudget <= 0)
                return Result<Proyect>.Failure(new Error("Proyecto.Valores","El presupuesto no puede esar vacio o ser igual a cero"));

            Budget = newBudget;
            Update();
            return Result<Proyect>.Success(this);
        } 

        private Result StatusCheck()
        {
            if(ProyectState == ProyectStatus.Cancelled || ProyectState == ProyectStatus.Finished)
                return Result.Failure(new Error("Proyecto.Inmutable",$"El proyecto actual ya se encuentra finalizado o cancelado {ProyectState.ToString()}"));
            
            return Result.Success();
        }

        public void IsDelayedCheck()
        {
            if(EstimatedDateOfRelease < DateTime.Now)
                IsDelayed = true;
        }

        //Methods for child entities

        public Result AddAssignements(
            string taskName,
            DateOnly deadLine,
            Priority priority,
            Guid StaffID
        )
        {
            var result = Assignement.Create(taskName,deadLine,TenantId,Id,StaffID, priority);

            if(result.IsFailure)
                return result.Error;
            
            _assignements.Add(result.Value);
            Update();
            return Result.Success();
        }
    }
}