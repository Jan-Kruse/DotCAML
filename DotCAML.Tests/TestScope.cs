using NUnit.Framework;

namespace DotCAML.Tests
{
    [TestFixture]
    public class TestScope
    {
        [Test]
        public void Test()
        {
            var caml = CAML
                .View()
                    .Scope(ViewScope.RecursiveAll)
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