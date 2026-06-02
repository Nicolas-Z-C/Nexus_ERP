using Nexus.Domain.Entityes.Aggregates.Personal;
using Xunit.Abstractions;

namespace Nexus.Domain.Tests.Entities.PersonelTests
{
    public class ShouldStaff
    {

        private readonly ITestOutputHelper _output;

        public ShouldStaff(ITestOutputHelper output)
        {
            _output = output;
        }
        [Fact]
        public void CreateStaffShouldWork()
        {
            var result = Staff.Create(
                "NombrePersonal",
                "ABCD123",
                "Calle 1",
                "35R",
                "Complemento",
                "SuperE@email.com",
                "1234567890",
                Guid.NewGuid(),
                1,2,3,4,5
            );
            Assert.True(result.IsSuccess, result.IsFailure 
            ? string.Join(" ", result.Errors)
            : "");
            _output.WriteLine(result.Value.ToString());
        }

         [Fact]
        public void ChangePropsStaffShouldWork()
        {
            var staff = Staff.Create(
                "NombrePersonal",
                "ABCD123",
                "Calle 1",
                "35R",
                "Complemento",
                "SuperE@email.com",
                "1234567890",
                Guid.NewGuid(),
                1,2,3,4,5
            );

            var result = staff.Value.ChangePropertyes(
               "Calle 1",
                "35Rr",
                "Complemento",
                "Emailnuevo@gmail.ff",
                "5959595959",
                1,2,3
            );

            _output.WriteLine(staff.Value.ToString());
            Assert.True(result.IsSuccess, result.IsFailure 
            ? string.Join(" ", result.Errors)
            : "");
            _output.WriteLine(result.Value.ToString());
        }

        [Fact] 
        public void ChangePositionStaffShouldWork()
        {
            var staff = Staff.Create(
                "NombrePersonal",
                "ABCD123",
                "Calle 1",
                "35R",
                "Complemento",
                "SuperE@email.com",
                "1234567890",
                Guid.NewGuid(),
                1,2,3,4,5
            );

            var result = staff.Value.ChangePosition(4,5);
            Assert.True(result.IsSuccess, result.IsFailure 
            ? string.Join(" ", result.Errors)
            : "");
            _output.WriteLine(result.Value.ToString());
        }

        [Fact] 
        public void ChangeStatusStaffShouldWork()
        {
            var staff = Staff.Create(
                "NombrePersonal",
                "ABCD123",
                "Calle 1",
                "35R",
                "Complemento",
                "SuperE@email.com",
                "1234567890",
                Guid.NewGuid(),
                1,2,3,4,5
            );

            var result = staff.Value.ChangeStatus(Enums.PersonalStatus.Inactive);
            Assert.True(result.IsSuccess, result.IsFailure 
            ? string.Join(" ", result.Errors)
            : "");
            _output.WriteLine(result.Value.ToString());
        }
    }
}