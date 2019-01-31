using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CAMLTest
{
    [TestClass]
    public class TestScope
    {
        [TestMethod]
        public void Test()
        {
            var caml = CAML.CAML
                .View()
                    .Scope(CAML.ViewScope.RecursiveAll)
                .Query()
                    .Where().NumberField("ID").IsNotNull()
                .ToString();

            string expected = @"<View Scope=""RecursiveAll"">
                <Query>
                    <Where>
                        <IsNotNull>
                            <FieldRef Name=""ID"" />
                        </IsNotNull>
                    </Where>
                </Query>
            </View>";

            Assert.AreEqual(Beautify.Xml(expected), Beautify.Xml(caml));
        }
    }
}
