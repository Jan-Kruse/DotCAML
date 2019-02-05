using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotCAML.Tests.Core
{
    [TestClass]
    public class TestIdInValues
    {
        [TestMethod]
        public void Test()
        {
            var caml = CAML.Where().CounterField("ID").In(new int[] { 1, 2, 3 }).ToString();

            string expected = @"<Where>
                <In>
                    <FieldRef Name=""ID"" />
                    <Values>
                        <Value Type=""Counter"">1</Value>
                        <Value Type=""Counter"">2</Value>
                        <Value Type=""Counter"">3</Value>
                    </Values>
                </In>
            </Where>";

            Assert.AreEqual(Beautify.Xml(expected), Beautify.Xml(caml));
        }
    }
}