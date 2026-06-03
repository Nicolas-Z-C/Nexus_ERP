using Nexus.Domain.Common.Result;
using Nexus.Domain.Entityes.Common;
using Nexus.Domain.Enums;
using Nexus.Domain.Errors;
using Nexus.Domain.Interfaces.Common;
using Nexus.Domain.ValueObjects.Adresses;
using Nexus.Domain.ValueObjects.Common;
using Nexus.Domain.ValueObjects.IDs;
using Nexus.Domain.ValueObjects.Names;

namespace Nexus.Domain.Entityes.Aggregates.Personel
{
    public class Staff : AuditableEntity, Itenant
    {
        public Name LegalName {get; private set;}

        //Pin that is used to recrd work hours
        public PersonelID StaffID {get; private set;} 
        public Street StreetName {get; private set;}
        public AdressNumber AdressNumber {get; private set;}
        public Name Complement {get; private set;}
        public Email Email {get; private set;}
        public TelephoneNumber TelephoneNumber {get; private set;}
        public DateTime DateOfJoining {get; init;} = DateTime.UtcNow;
        public int WorkedHoursTotal {get; private set;} = 0;
        public int WeeklyWorkdedHours {get; private set;} = 0;
        public int MontlyWorkdedHours {get; private set;} = 0;

        //FK - enums

        public Guid TenantId {get; set;}
        public int StaffStatusID {get; private set;} = (int)PersonalStatus.Active;
        public PersonalStatus StaffStatus => (PersonalStatus)StaffStatusID;
        public int PositionID {get; private set;}
        public int ContractID {get; private set;}
        public int CityID {get; private set;}
        public int RegionID {get; private set;}
        public int CountryID {get; private set;}  

        //Flags

        public bool IsFired {get; private set;} = false;  
        public bool IsReEmployed {get; private set;} = false;


        //Ef - constructor

        private Staff(
            Name legalName,
            PersonelID staffid,
            Street street,
            AdressNumber adressNumber,
            Name complement,
            Email email,
            TelephoneNumber telephoneNumber,
            Guid tenant,
            int position,
            int contract,
            int city,
            int region,
            int country
        )
        {
            LegalName = legalName;
            StaffID = staffid;
            StreetName = street;
            AdressNumber = adressNumber;
            Complement = complement;
            Email = email;
            TelephoneNumber = telephoneNumber;
            TenantId = tenant;
            PositionID = position;
            ContractID = contract;
            CityID = city;
            RegionID = region;
            CountryID = country;
        }

        internal Staff () {}

        //Staff own methods 

        public static Result<Staff> Create(
            string legalName,
            string staffid,
            string street,
            string adressnumber,
            string complement,
            string mail,
            string telephoneNumber,
            Guid tenant,
            int position,
            int contract,
            int city,
            int region,
            int country
        )
        {
            var name = Name.Create(legalName);
            var staffId = PersonelID.Create(staffid);
            var streetName = Street.Create(street);
            var adressNumber = AdressNumber.Create(adressnumber);
            var complemen = Name.Create(complement);
            var email = Email.Create(mail);
            var telephone = TelephoneNumber.Create(telephoneNumber);

            var results = new Result[] {name, staffId, streetName, adressNumber, complemen, email, telephone};

            if(results.Any(r => r.IsFailure))
            {
                var failed = results.Where(r => r.IsFailure).Select(r => r.Error);
                return Result<Staff>.Failure(failed);
            }
            Staff staff = new Staff
            (
                name.Value,
                staffId.Value,
                streetName.Value,
                adressNumber.Value,
                complemen.Value,
                email.Value,
                telephone.Value,
                tenant,
                position,
                contract,
                city,
                region,
                country
            );

            return Result<Staff>.Success(staff);
        }

         public Result<Staff> ChangePropertyes(
            string street,
            string adressnumber,
            string complement,
            string mail,
            string telephoneNumber,
            int city,
            int region,
            int country
            )
        {
            var check = StatusCheck();

            if(check.IsFailure)
                return check.Error;

            var streetName = Street.Create(street);
            var adressNumber = AdressNumber.Create(adressnumber);
            var complemen = Name.Create(complement);
            var email = Email.Create(mail);
            var telephone = TelephoneNumber.Create(telephoneNumber);

            var results = new Result[] {streetName, adressNumber, complemen, email, telephone};

            if(results.Any(r => r.IsFailure))
            {
                var failed = results.Where(r => r.IsFailure).Select(r => r.Error);
                return Result<Staff>.Failure(failed);
            }

            bool hasChanges =
                streetName.Value      != StreetName            ||
                adressNumber.Value    != AdressNumber          ||
                complemen.Value       != Complement            ||
                email.Value           != Email                 ||
                telephone.Value       != TelephoneNumber       ||
                city                  != CityID                ||
                country               != CountryID             ||
                region                != RegionID;

            if (!hasChanges)
                return Result<Staff>.NoChanges(this);          
            
            StreetName = streetName.Value;
            AdressNumber = adressNumber.Value;
            Complement = complemen.Value;
            Email = email.Value;
            TelephoneNumber = telephone.Value;
            CityID = city;
            CountryID = country;
            RegionID = region;

            Update();
            return Result<Staff>.Success(this);
        }

        public Result<Staff> ChangePosition(
            int newPosition,
            int newContract
        )
        {   
            var check = StatusCheck();

            if(check.IsFailure)
                return check.Error;

            if(newPosition == PositionID || newContract == ContractID)
                return Result<Staff>.NoChanges(this);
            
            PositionID = newPosition;
            ContractID = newContract;

            Update();
            return Result<Staff>.Success(this);
        }

        public Result<Staff> ChangeStatus(PersonalStatus newStatus)
        {
            var check = StatusCheck();

            if(check.IsFailure)
                return check.Error;

            if(newStatus == StaffStatus)
                return Result<Staff>.NoChanges(this);
            
            if(newStatus == PersonalStatus.Fired)
                IsFired = true;

            StaffStatusID = (int)newStatus;
            Update();
            return Result<Staff>.Success(this);
        }

        public Result<Staff> ReEmploy()
        {
            if(StaffStatus != PersonalStatus.Fired && IsFired != true)
                return Result<Staff>.Failure(new Error("Empleado.Recontratacion","El empleado ya se encuentra empleado"));
            
            IsFired = false;
            StaffStatusID = (int)PersonalStatus.Active;
            IsReEmployed = true;

            Update();
            return Result<Staff>.Success(this);
        }

        public Result AddWorkHours(int hours)
        {
            if(hours < 0)
                return Result.Failure(new Error("Agregar.Horas","Las horas de trabajo no pueden ser menores a 0"));
        
            WeeklyWorkdedHours += hours;
            MontlyWorkdedHours += hours;
            WorkedHoursTotal += hours;
            return Result.Success();
        }

        public void ResetWeeklyhours()
        {
            WeeklyWorkdedHours = 0;
        }

        public void ResetMontlyhours()
        {
            MontlyWorkdedHours = 0;
        }


        private Result StatusCheck()
        {
            if(StaffStatus == PersonalStatus.Fired && IsFired == true)
                return Result<Staff>.Failure(new Error("Empleado.Despedido","No se puede realizar esta accion, el empleado se encuentra despedido"));
            
            return Result.Success();
        }

        public override string ToString()
        {
            string result = @$"Nombre legal: {LegalName.ToString()}
                               StaffID: {StaffID.ToString()}
                               Direccion: {StreetName.ToString()} {AdressNumber.ToString()} {Complement.ToString()}
                               Email: {Email.ToString()}
                               Numero Telefonico: {TelephoneNumber.ToString()}
                               Puesto: {PositionID}
                               Ha sido recontratado: {IsReEmployed}
                               Contrato: {ContractID}
                               Ciudad: {CityID}
                               Pais: {CountryID}
                               Region: {RegionID}
                               Estado: {StaffStatus}
                               Creado: {CreatedAt}
                               Modificado en: {UpdatedAt}";
            return result;
        }
    }
}