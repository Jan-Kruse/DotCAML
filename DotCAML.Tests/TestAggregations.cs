using NUnit.Framework;

namespace DotCAML.Tests
{
    [TestFixture]
    public class TestAggregations
    {
        [Test]
        public void Test()
        {
            var caml = CAML
                .View(new string[] { "Category" }, (AggregationType.Count, "ID"), (AggregationType.Sum, "Amount"))
                .Query()
                    .GroupBy("Category", true, 100)
                .ToString();

            string expected = @"<View>
                <ViewFields>
                    <FieldRef Name=""Category"" />
                </ViewFields>
                <Aggregations Value=""On"">
                    <FieldRef Name=""ID"" Type=""COUNT"" />
                    <FieldRef Name=""Amount"" Type=""SUM"" />
                </Aggregations>
                <Query>
                    <GroupBy Collapse=""TRUE"" GroupLimit=""100"">
						<FieldRef Name=""Category"" />
                    </GroupBy>
                </Query>
            </View>";

            Assert.AreEqual(Beautify.Xml(expected), Beautify.Xml(caml));
        }
    }
}