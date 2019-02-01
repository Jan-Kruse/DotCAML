using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotCAML.Tests
{
    [TestClass]
    public class TestViewWithExpression
    {
        [TestMethod]
        public void Test()
        {
            var expression = CAML.Expression().BooleanField("Enabled").IsTrue();

            var caml = CAML.View().Query().Where().All(expression).OrderBy("Priority").ToString();

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