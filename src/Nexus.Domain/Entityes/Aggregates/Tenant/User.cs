using Nexus.Domain.Common.Result;
using Nexus.Domain.Entityes.Common;
using Nexus.Domain.Errors;
using Nexus.Domain.Interfaces.Common;
using Nexus.Domain.ValueObjects.Common;
using Nexus.Domain.ValueObjects.Names;

namespace Nexus.Domain.Entityes.Aggregates.Tenant
{
    public class User : AuditableEntity, Itenant
    {
        //Properties

        public Name UserName {get; private set;}
        public Password UserPassword {get; private set;}
        public ResetToken? ResetToken { get; private set; }
        public Email Email;

        public bool IsActive {get; private set;} = true;

        //TenantID

        public Guid TenantId {get; set;}

        //Constructor

        public User(Name username, Password password, Guid tenantID, Email email)
        {
            UserName = username;
            UserPassword = password;
            TenantId = tenantID;
            Email = email;
        }


        //ef

        internal User() {}

        //Own Methods 

        protected internal static Result<User> Create(string username, string password, Guid tenantID, string email)
        {
            var user = Name.Create(username);
            var passwd = Password.Create(password);
            var emaill = Email.Create(email);

            if(user.IsFailure)
                return user.Error;
            
            if(passwd.IsFailure)
                return passwd.Error;
            
            if(emaill.IsFailure)
                return user.Error;
            
            return Result<User>.Success(new (user.Value, passwd.Value, tenantID, emaill.Value));
        }

        public Result<string> CreateCode()
        {
            var random = new Random();
            string code = random.Next(1000, 9999).ToString();
            var resetCode = ResetToken.Create(code);  

            if(resetCode.IsFailure)
                return resetCode.Error;  
            
            ResetToken = resetCode.Value;
            return Result<string>.Success(code);
        }

        public Result ResetPassword(string code, Password newPassword)
        {
            if(ResetToken == null)
                return Result.Failure(new Error("Error.Validacion","No se ha solicitado un codigo de cambio de contraseña"));
            
            var validacion = ResetToken.ValidateCode(code, DateTime.UtcNow);

            if(validacion.IsFailure)
                return validacion.Error;
            
            UserPassword = newPassword;
            ResetToken = null;
            Update();
            return Result.Success();
        }

        public Result ChangeUserName(string newUserName)
        {
            var result = Name.Create(newUserName);

            if(result.IsFailure)
                return result.Error;
            
            UserName = result.Value;
            Update();
            return Result.Success();
        }

        public Result ChangeUserEmail(string newEmail)
        {
            var result = Email.Create(newEmail);

            if(result.IsFailure)
                return result.Error;
            
            Email = result.Value;
            Update();
            return Result.Success();
        }

        protected internal void Deactivate()
        {
            IsActive = false;
            Update();
        }
    }
}