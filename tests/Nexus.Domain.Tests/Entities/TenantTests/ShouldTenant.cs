using Nexus.Domain.Entityes.Aggregates.Tenant;
using Xunit.Abstractions;

namespace Nexus.Domain.Tests.Entities.TenantTests
{
    public class ShouldTenant
    {

         private readonly ITestOutputHelper _output;

        public ShouldTenant(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void CreateTenant_WithValidData_ShouldSucceed()
        {
            var result = Tenant.Create(
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

            Assert.True(result.IsSuccess, result.IsFailure 
            ? string.Join(", ", result.Errors)
            : "");

            var tenant = result.Value;
            Assert.NotNull(tenant);
            _output.WriteLine(tenant.ToString());
        }
            
        [Fact]
        public void ModifyTenantShouldSucceed()
        {
            var result = Tenant.Create(
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

            var tenant = result.Value;
            _output.WriteLine(tenant.ToString());

            var resultt = tenant.ChangePropertyes(
                "Nexus Empresa SAS",
                "NombreComercial",
                "Calle 94",
                "45A",
                "Casa 2",
                "email@email.com",
                "321321321",
                Enums.EconomicSector.Primary,
                1,2
            );

            Assert.True(resultt.IsSuccess, resultt.IsFailure 
            ? string.Join(", ", resultt.Errors)
            : "");
            _output.WriteLine(resultt.Value.ToString());

        }

        [Fact]
        public void AddUserShouldSucceed()
        {
            var result = Tenant.Create(
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

            var tenant = result.Value;
        
            var resultUser = tenant.AddUser(
                "NombreUsuario",
                "ContraSuperSegura123#",
                "Email@superemail.com"
            );

            Assert.NotNull(resultUser);
            Assert.True(resultUser.IsSuccess, resultUser.IsFailure 
            ? string.Join(" ", resultUser.Error)
            : "");

            _output.WriteLine(tenant.ToString());
        }


        [Fact]
        public void DeleteUserShouldSucceed()
        {
            var result = Tenant.Create(
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

            var tenant = result.Value;
        
            tenant.AddUser(
                "NombreUsuario",
                "ContraSuperSegura123#",
                "Email@superemail.com"
            );
            
            var user = tenant.Users.First(x => x.IsActive == true);

            _output.WriteLine(tenant.ToString());

            var ResultDelete = tenant.DeleteUser(user.Id);

            Assert.True(ResultDelete.IsSuccess, ResultDelete.IsFailure 
            ? string.Join(" ", ResultDelete.Error)
            : "");
            
            _output.WriteLine(tenant.ToString());
        }

         [Fact]
        public void DeleteTenantShouldSuceed()
        {

            var result = Tenant.Create(
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

            var tenant = result.Value;
           
            Thread.Sleep(2000);
            
            tenant.DeActivate();

            Assert.True(tenant.IsActive == false);

            _output.WriteLine(tenant.ToString());
        }
    }
}

