using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CAMLTest
{
    [TestClass]
    public class TestViewWithExpression
    {
        [TestMethod]
        public void Test()
        {
            var expression = CAML.CAML.Expression().BooleanField("Enabled").IsTrue();

            var caml = CAML.CAML.View().Query().Where().All(expression).OrderBy("Priority").ToString();

            string expected = @"<View>
                    <Query>
                        <Where>
                            <Eq><FieldRef Name=""Enabled"" /><Value Type=""Integer"">1</Value></Eq>
                        </Where>
                        <OrderBy>
                            <FieldRef Name=""Priority"" />
                        </OrderBy>
                    </Query>
                </View>";

            Assert.AreEqual(Beautify.Xml(expected), Beautify.Xml(caml));
        }
    }
}
