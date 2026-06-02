using Nexus.Domain.Entityes.Aggregates.Proyect;
using Xunit.Abstractions;

namespace Nexus.Domain.Tests
{
    public class ShouldProyect
    {
        private readonly ITestOutputHelper _output;

        public ShouldProyect(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void CreateProyectShouldWork()
        {

            var result = Proyect.Create(
                "proyecto1",
                100000000,
                50000000,
                3,
                DateTime.Now.AddDays(1),
                Guid.NewGuid(),
                Enums.Currency.EUR
            );



            Assert.True(result.IsSuccess, result.IsFailure 
            ? string.Join(" ", result.Error)
            : "");
            _output.WriteLine(result.Value.ToString());
        }


        [Fact]
        public void ChangeStatusProyectShouldWork()
        {

            var proyect = Proyect.Create(
                "proyecto1",
                100000000,
                50000000,
                3,
                DateTime.Now.AddDays(1),
                Guid.NewGuid(),
                Enums.Currency.EUR
            );

            _output.WriteLine(proyect.Value.ToString());

            proyect.Value.ChangeStatus(Enums.ProyectStatus.Planning);

            _output.WriteLine(proyect.Value.ToString());

            var result = proyect.Value.ChangeStatus(Enums.ProyectStatus.Developing);

            Assert.True(result.IsSuccess, result.IsFailure 
            ? string.Join(" ", result.Error)
            : "");
            _output.WriteLine(proyect.Value.ToString());
        }

        [Fact]
        public void ChangeBudgetProyectShouldWork()
        {

            var proyect = Proyect.Create(
                "proyecto1",
                100000000,
                50000000,
                3,
                DateTime.Now.AddDays(1),
                Guid.NewGuid(),
                Enums.Currency.EUR
            );

            _output.WriteLine(proyect.Value.ToString());

            var result = proyect.Value.ChangeBudget(200000000);

            Assert.True(result.IsSuccess, result.IsFailure 
            ? string.Join(" ", result.Error)
            : "");

            _output.WriteLine(proyect.Value.ToString());
        }
    }
}