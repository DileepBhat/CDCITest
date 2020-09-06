using ArithematicAPIService.v1;
using ArithematicAPIService.v1.Controllers;
using NUnit.Framework;

namespace Arithematic.Service.v1.Tests
{
    public class Tests
    {
        [Test]
        public void GivenAnArithematicController_WhenCallingAddMethod_SumShouldBeReturned()
        {
            var controller = new ArithematicController();

            var additionRequest = new ArithematicAdditionRequest
            {
                A = 10,
                B = 20
            };

            Assert.That(controller.Add(additionRequest) == 30, "Sum returned by API is not as expected");
        }
    }
}