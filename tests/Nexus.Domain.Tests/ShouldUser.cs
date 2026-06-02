using Nexus.Domain.Entityes.Aggregates.Tenant;
using Xunit.Abstractions;


namespace Nexus.Domain.Tests
{
    public class ShouldUser
    {
        private readonly ITestOutputHelper _output;

        public ShouldUser(ITestOutputHelper output)
        {
            _output = output;
        }
        
        [Fact]
        public void UserShouldCreateCode()
        {
            var restulttenant = Tenant.Create(
                "Nexus Empresa SAS",
                "900123456",
                "NombreComercial",
                "Calle 123",
                "45B",
                "Apto 2",
                "email@email.com",
                "3242893403",
                Enums.EconomicSector.Primary,
                1, 1, 1, 1
            );

            var tenant = restulttenant.Value;
        
            var resultUser = tenant.AddUser(
                "NombreUsuario",
                "ContraSuperSegura123#",
                "Email@superemail.com"
            );

            var user = tenant.Users.First(x => x.IsActive == true);

            var result = user.CreateCode();


            Assert.True(result.IsSuccess, result.IsFailure 
            ? string.Join(" ", result.Error)
            : "");
            _output.WriteLine(result.Value);
        }

        [Fact]
        public void UserShouldAcceptCodeAndChangePassword()
        {
            var restulttenant = Tenant.Create(
                "Nexus Empresa SAS",
                "900123456",
                "NombreComercial",
                "Calle 123",
                "45B",
                "Apto 2",
                "email@email.com",
                "3242893403",
                Nexus.Domain.Enums.EconomicSector.Primary,
                1, 1, 1, 1
            );

            var tenant = restulttenant.Value;
        
            var resultUser = tenant.AddUser(
                "NombreUsuario",
                "ContraSuperSegura123#",
                "Email@superemail.com"
            );

            var user = tenant.Users.First(x => x.IsActive == true);
            
            _output.WriteLine(user.UserPassword.ToString());
            _output.WriteLine("======================\n");
            var code = user.CreateCode();

            var result = user.ResetPassword(code.Value, "NuevaSuperContra142#");

            Assert.True(result.IsSuccess, result.IsFailure 
            ? string.Join(" ", result.Error)
            : "");
            _output.WriteLine(user.UserPassword.ToString());
        }

        [Fact]
        public void UserChangeUsernameShouldWork()
        {
            var restulttenant = Tenant.Create(
                "Nexus Empresa SAS",
                "900123456",
                "NombreComercial",
                "Calle 123",
                "45B",
                "Apto 2",
                "email@email.com",
                "3242893403",
                Nexus.Domain.Enums.EconomicSector.Primary,
                1, 1, 1, 1
            );

            var tenant = restulttenant.Value;
        
            var resultUser = tenant.AddUser(
                "NombreUsuario",
                "ContraSuperSegura123#",
                "Email@superemail.com"
            );

            var user = tenant.Users.First(x => x.IsActive == true);
            
            _output.WriteLine(user.ToString());

            var result = user.ChangeUserName("Elpepesaurio");

            Assert.True(result.IsSuccess, result.IsFailure 
            ? string.Join(" ", result.Error)
            : "");
            _output.WriteLine(user.ToString());
        }

        /*
        Debo ternimar de testear el usuario, pasar a lo que es proyecto y personal
        */

        [Fact]
        public void UserChangeUserEmailShouldWork()
        {
            var restulttenant = Tenant.Create(
                "Nexus Empresa SAS",
                "900123456",
                "NombreComercial",
                "Calle 123",
                "45B",
                "Apto 2",
                "email@email.com",
                "3242893403",
                Enums.EconomicSector.Primary,
                1, 1, 1, 1
            );

            var tenant = restulttenant.Value;
        
            var resultUser = tenant.AddUser(
                "NombreUsuario",
                "ContraSuperSegura123#",
                "Email@superemail.com"
            );

            var user = tenant.Users.First(x => x.IsActive == true);
            
            _output.WriteLine(user.Email.ToString());

            var result = user.ChangeUserEmail("Elpepesaurio@gmail.com");

            Assert.True(result.IsSuccess, result.IsFailure 
            ? string.Join(" ", result.Error)
            : "");
            _output.WriteLine(user.Email.ToString());
        }
    }
}