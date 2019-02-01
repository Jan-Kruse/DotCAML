using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotCAML.Tests
{
    [TestClass]
    public class TestLookupIdAndOrderBy
    {
        [TestMethod]
        public void Test()
        {
            var caml = CAML.Where()
                .LookupField("Category").Id().In(new int[] { 2, 3, 10 })
                .And()
                .DateField("ExpirationDate").GreaterThan(CamlValues.Now)
                .OrderBy("ExpirationDate")
                .ToString();

            string expected = @"<Where>
                  <And>
                    <In>
                      <FieldRef Name=""Category"" LookupId=""True"" />
                      <Values>
                        <Value Type=""Integer"">2</Value>
                        <Value Type=""Integer"">3</Value>
                        <Value Type=""Integer"">10</Value>
                      </Values>
                    </In>
                    <Gt>
                      <FieldRef Name=""ExpirationDate"" />
                      <Value Type=""DateTime"">
                        <Now />
                      </Value>
                    </Gt>
                  </And>
                </Where>
                <OrderBy>
                  <FieldRef Name=""ExpirationDate"" />
                </OrderBy>";

            Assert.AreEqual(Beautify.Xml(expected), Beautify.Xml(caml));
        }
    }
}
