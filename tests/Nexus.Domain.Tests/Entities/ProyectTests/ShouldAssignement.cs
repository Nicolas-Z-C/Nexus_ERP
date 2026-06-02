
using Nexus.Domain.Entityes.Aggregates.Proyect;
using Xunit.Abstractions;

namespace Nexus.Domain.Tests.Entities.ProyectTests
{
    public class ShouldAssignement
    {
        private readonly ITestOutputHelper _output;

        public ShouldAssignement(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void RepogramAssignementShouldWork()
        {
            var proyect = Proyect.Create(
                "proyecto1",
                100000000,
                50000000,
                3,
                DateTime.Now.AddDays(3),
                Guid.NewGuid(),
                Enums.Currency.EUR
            );


            var assignementResult = proyect.Value.AddAssignements(
                "Tarea1",
                DateOnly.FromDateTime(proyect.Value.DateOfStart.AddDays(5)),
                Enums.Priority.High,
                Guid.NewGuid()
            );

            var task = proyect.Value.Assignements.FirstOrDefault(x => x.TaskStatus == Enums.Task_status.OnGoing);

            _output.WriteLine(task.ToString());

            var result = task.Reprogram(task.DeadLine.AddDays(2));
            
            Assert.True(result.IsSuccess, result.IsFailure 
            ? string.Join(" ", result.Error)
            : "");
            
            _output.WriteLine(result.Value.ToString());
            Assert.True(true);
        }
    }
}