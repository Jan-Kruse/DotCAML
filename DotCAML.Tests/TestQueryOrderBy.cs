using NUnit.Framework;

namespace DotCAML.Tests
{
    [TestFixture]
    public class TestQueryOrderBy
    {
        [Test]
        public void Test()
        {
            var caml = CAML
                .View()
                .Query()
                    .OrderBy("ID")
                .ToString();

            string expected = @"<View>
                <Query>
                    <OrderBy>
						<FieldRef Name=""ID"" />
                    </OrderBy>
                </Query>
            </View>";

            Assert.AreEqual(Beautify.Xml(expected), Beautify.Xml(caml));
        }
    }
}