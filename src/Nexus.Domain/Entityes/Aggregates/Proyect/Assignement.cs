using Nexus.Domain.Common.Result;
using Nexus.Domain.Entityes.Common;
using Nexus.Domain.Enums;
using Nexus.Domain.Errors;
using Nexus.Domain.Interfaces.Common;
using Nexus.Domain.ValueObjects.Names;

namespace Nexus.Domain.Entityes.Aggregates.Proyect
{
    public class Assignement : AuditableEntity, Itenant
    {
        public Name TaskName {get; private set;}
        public DateOnly DeadLine {get; private set;}

        //Flags 

        public bool? ReprogrammedFlag {get; private set;} = false;
        public bool? OverdueFlag {get; private set;} = false;

        //FK - enums

        public Guid TenantId {get; set;}
        public Task_status TaskStatus {get; private set;} = Task_status.OnGoing;
        public Guid ProyectID {get; private set;}
        public Priority Priority {get; private set;}
        public Guid StaffAssigned {get; private set;}

        //Ef and private constructor

        internal Assignement() {}

        private Assignement(
            Name taskName,
            DateOnly deadLine,
            Guid tenant,
            Guid proyect,
            Guid staff,
            Priority priority
        )
        {
            TaskName = taskName;
            DeadLine = deadLine;
            TenantId = tenant;
            ProyectID = proyect;
            Priority = priority;
            StaffAssigned = staff;
        }

        //Own Methods

        internal static Result<Assignement> Create(
            string taskName,
            DateOnly deadLine,
            Guid tenant,
            Guid proyect,
            Guid staff,
            Priority priority
        )
        {
            var name = Name.Create(taskName);
            if(name.IsFailure)
                return name.Error;
            
            if(deadLine <= DateOnly.FromDateTime(DateTime.Now))
                return Result<Assignement>.Failure(new Error("Tarea.Deadline","La fecha limite no puede ser igual o menor a la actual"));
            
            Assignement assignement = new (name.Value,deadLine,tenant,proyect,staff,priority);
            return Result<Assignement>.Success(assignement);
        }

        public Result<Assignement> Reprogram(DateOnly newDeadline)
        {
            if(TaskStatus == Task_status.Cancelled || TaskStatus == Task_status.Finished)
                return Result<Assignement>.Failure(new Error("Tarea.Reprogramacion",$"No se puede repgrogramar una tarea ya terminada o cancelad, estado actual: {TaskStatus.ToString()}"));

            if(DeadLine > newDeadline || newDeadline > DateOnly.FromDateTime(DateTime.Today))
                return Result<Assignement>.Failure(new Error("Tarea.DeadLine","La nueva fecha limite no puede ser anterior a la antes estipulada ni anterior al dia de hoy"));
            
            DeadLine = newDeadline;
            ReprogrammedFlag = true;

            if(TaskStatus == Task_status.Overdue)
            {
                TaskStatus = Task_status.OnGoing;
                OverdueFlag = false; 
            }
            
            Update();
            return Result<Assignement>.Success(this);
        }

        /*
        I need to add a way to call the staff if any of the below are called
        */
        public Result<Assignement> Cancel()
        {
            TaskStatus = Task_status.Cancelled;
            Update();
            return Result<Assignement>.Success(this);
        }

        public Result<Assignement> Finish()
        {
            TaskStatus = Task_status.Cancelled;
            Update();
            return Result<Assignement>.Success(this);
        }
        
        public Assignement IsOverdue()
        {
            if(DateOnly.FromDateTime(DateTime.Now) > DeadLine)
            {
                TaskStatus = Task_status.Overdue;
                OverdueFlag = true;
                Update();
                return this;
            }
            
            return this;
        }
        //Hacer los metodos que faltan para assignements y proyects 
        /*
        agregar desde proyecto, eliminar desde aca, re-programar y la flag de reprogramacion
        */
    }
}