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
        private TenantLegalName _legalName;
        private TIN _taxID;
        private Name _tenantComercialName;
        private Street _streetName;
        private AdressNumber _adressNumber;
        private Name _complement;
        private Email _tenantEmail;
        private TelephoneNumber _telephoneNumber;
        public bool IsActive {get; private set;} = true;

        //Foreing Keys - Enum Properties

        public EconomicSector EconomicSector {get; private set;}
        public int IDType {get; private set;}

        //Sets

        public TenantLegalName LegalName
        {
            get => _legalName;

            private set
            {
                if(_legalName != value)
                {
                    _legalName = value;
                }
            }
        }
        public TIN TaxID
        {
            get => _taxID;

            private set
            {
                if(_taxID != value)
                {
                    _taxID = value;
                }
            }
        }
        public Name TenantComercialName
        {
            get => _tenantComercialName;

            private set
            {
                if(_tenantComercialName != value)
                {
                    _tenantComercialName = value;
                }
            }
        }
        public Street StreetName
        {
            get => _streetName;

            private set
            {
                if(_streetName != value)
                {
                    _streetName = value;
                }
            }
        }
        public AdressNumber AdressNumber
        {
            get => _adressNumber;

            private set
            {
                if(_adressNumber != value)
                {
                    _adressNumber = value;
                }
            }
        }
        public Name Complement
        {
            get => _complement;

            private set
            {
                if(_complement != value)
                {
                    _complement = value;
                }
            }
        }
        public Email TenantEmail
        {
            get => _tenantEmail;

            private set
            {
                if(_tenantEmail != value)
                {
                    _tenantEmail = value;
                }
            }
        }
        public TelephoneNumber TelephoneNumber
        {
            get => _telephoneNumber;

            private set
            {
                if(_telephoneNumber != value)
                {
                    _telephoneNumber = value;
                }
            }
        }
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
            TelephoneNumber telephoneNumber)
        {
            LegalName = tenantLegalName;
            TaxID = taxID;
            TenantComercialName = tenantComercialName;
            StreetName = streetName;
            AdressNumber = adressNumber;
            Complement = complement;
            TenantEmail = tenantEmail;
            TelephoneNumber = telephoneNumber;
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
                            {
                             LegalName = legalName.Value,
                             TaxID = taxid.Value,
                             TenantComercialName = comercialName.Value,
                             StreetName = streetname.Value,
                             AdressNumber = adressnumber.Value,
                             Complement = complemen.Value,
                             TenantEmail = tenantemail.Value,
                             TelephoneNumber = telephonenumber.Value,
                             EconomicSector = economicSector,
                             IDType = idType
                            };
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