using NUnit.Framework;
using ArithematicLibrary;

namespace ArithematicLibraryTests
{
    public class ArithematicTest
    {
        [Test]
        public void GivenTwoIntegers_AddThemUsingArithematic_ShouldReturnSum()
        {
            Assert.That(Arithematic.Add(10, 20) == 30, "Addition is not as expected");
        }
    }
}