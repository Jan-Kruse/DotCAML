using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CAMLTest
{
    [TestClass]
    public class TestJsDateFormat
    {
        [TestMethod]
        public void Test()
        {
            var caml = CAML.CAML.Where().DateTimeField("Created").GreaterThan(new DateTime(2013, 1, 1, 0, 0, 0, DateTimeKind.Utc)).ToString();

            string expected = @"<Where>
                <Gt>
                    <FieldRef Name=""Created"" />
                    <Value IncludeTimeValue=""True"" Type=""DateTime"">2013-01-01T00:00:00.000Z</Value>
                </Gt>
            </Where>";

            Assert.AreEqual(Beautify.Xml(expected), Beautify.Xml(caml));
        }
    }
}
