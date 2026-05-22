using Nexus.Domain.Common.Result;
using Nexus.Domain.Entityes.Common;
using Nexus.Domain.Enums;
using Nexus.Domain.Errors;
using Nexus.Domain.ValueObjects.Adresses;
using Nexus.Domain.ValueObjects.Common;
using Nexus.Domain.ValueObjects.IDs;
using Nexus.Domain.ValueObjects.Names;

namespace Nexus.Domain.Entityes.Aggregates.Tenant
{
    public class Tenant : AuditableEntity
    {
        public TenantLegalName LegalName {get; private set;}
        public TIN TaxID {get; private set;}
        public Name TenantComercialName {get; private set;}
        public Street StreetName {get; private set;}
        public AdressNumber AdressNumber {get; private set;}
        public Name Complement {get; private set;}
        public Email TenantEmail {get; private set;}
        public TelephoneNumber TelephoneNumber {get; private set;}
        public bool IsActive {get; private set;} = true;

        //Foreing Keys - Enum Properties

        public EconomicSector EconomicSector {get; private set;}
        public int IDType {get; private set;}

        
        //Child Entities - User

        private readonly List<User> _users = new List<User>();

        public IReadOnlyCollection<User> Users => _users.AsReadOnly();

        private Tenant(
            TenantLegalName tenantLegalName,
            TIN taxID,
            Name tenantComercialName,
            Street streetName,
            AdressNumber adressNumber,
            Name complement,
            Email tenantEmail,
            TelephoneNumber telephoneNumber,
            EconomicSector economicSector,
            int idType)
        {
            LegalName = tenantLegalName;
            TaxID = taxID;
            TenantComercialName = tenantComercialName;
            StreetName = streetName;
            AdressNumber = adressNumber;
            Complement = complement;
            TenantEmail = tenantEmail;
            TelephoneNumber = telephoneNumber;
            EconomicSector = economicSector;
            IDType = idType;
        }
        internal Tenant() {}

        //Tenant Own methods

        public Result<Tenant> Create(
            string tenantLegalName,
            string taxID,
            string tenantComercialName,
            string streetName,
            string adressNumber,
            string complement,
            string tenantEmail,
            string telephoneNumber,
            EconomicSector economicSector,
            int idType)
        {
            var legalName = TenantLegalName.Create(tenantLegalName);
            var taxid = TIN.Create(taxID);
            var comercialName = Name.Create(tenantComercialName);
            var streetname = Street.Create(streetName);
            var adressnumber = AdressNumber.Create(adressNumber);
            var complemen = Name.Create(complement);
            var tenantemail = Email.Create(tenantEmail);
            var telephonenumber = TelephoneNumber.Create(telephoneNumber);

            var results = new Result[] {legalName, taxid,comercialName,streetname, adressnumber,complemen,tenantemail,telephonenumber};

            if(results.Any(r => r.IsFailure))
            {
                var fallidos = results.Where(r => r.IsFailure).Select(r => r.Error);
                return Result<Tenant>.Failure(fallidos);
            }
            Tenant tenant = new Tenant
                            (
                             legalName.Value,
                             taxid.Value,
                             comercialName.Value,
                             streetname.Value,
                             adressnumber.Value,
                             complemen.Value,
                             tenantemail.Value,
                             telephonenumber.Value,
                             economicSector,
                             idType
                            );
            return Result<Tenant>.Success(tenant);
        }  

        //Method for changing almost every property
        public Result<Tenant> ChangePropertyes(
            string tenantLegalName,
            string tenantComercialName,
            string streetName,
            string adressNumber,
            string complement,
            string tenantEmail,
            string telephoneNumber,
            EconomicSector economicSector
            )
        {
            var legalName = TenantLegalName.Create(tenantLegalName);
            var comercialName = Name.Create(tenantComercialName);
            var streetname = Street.Create(streetName);
            var adressnumber = AdressNumber.Create(adressNumber);
            var complemen = Name.Create(complement);
            var tenantemail = Email.Create(tenantEmail);
            var telephonenumber = TelephoneNumber.Create(telephoneNumber);

            var results = new Result[] {legalName,comercialName, streetname, adressnumber, complemen, tenantemail, telephonenumber};

            if(results.Any(r => r.IsFailure))
            {
                var fallidos = results.Where(r => r.IsFailure).Select(r => r.Error);
                return Result<Tenant>.Failure(fallidos);
            }  

            bool hasChanges =
                legalName.Value       != LegalName             ||
                comercialName.Value   != TenantComercialName   ||
                streetname.Value      != StreetName            ||
                adressnumber.Value    != AdressNumber          ||
                complemen.Value       != Complement            ||
                tenantemail.Value     != TenantEmail           ||
                telephonenumber.Value != TelephoneNumber       ||
                economicSector        != EconomicSector;

            if (!hasChanges)
                return Result<Tenant>.NoChanges(this);          
            
            LegalName = legalName.Value;
            TenantComercialName = comercialName.Value;
            StreetName = streetname.Value;
            AdressNumber = adressnumber.Value;
            Complement = complemen.Value;
            TenantEmail = tenantemail.Value;
            TelephoneNumber = telephonenumber.Value;
            EconomicSector = economicSector;

            Update();
            return Result<Tenant>.Success(this);
        }

        //Method for the soft delete of a Tenant

        public void DeActivate()
        {
            foreach (var user in _users)
            {
                user.Deactivate();
            }
            Update();
            IsActive = false;
        }

        //Methods for child entities

        public Result AddUser(string username, string password, string email)
        {
            var user = User.Create(username, password, Id, email);
            
            if(user.IsFailure)
                return user.Error;
            if(_users.Any(u => u.Email == user.Value.Email))
                return Result.Failure(new Error("Usuario.Duplicado","Ya existe un usuario con este email para este tenant"));
                
            _users.Add(user.Value);
            return Result.Success();
        }

        public Result DeleteUser(Guid id)
        {
            var user = _users.FirstOrDefault(u => Id == id);
            if(user == null)
                return Result.Failure(new Error("Usuario.NoEncontrado","El usuario no existe para este tenant"));
            
            user.Deactivate();
            return Result.Success();
        }
    }
}