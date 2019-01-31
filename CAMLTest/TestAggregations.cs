using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CAMLTest
{
    [TestClass]
    public class TestAggregations
    {
        [TestMethod]
        public void Test()
        {
            var caml = CAML.CAML
                .View(new string[] { "Category" }, new CAML.Aggregation[] {
                    new CAML.Aggregation { Type = CAML.AggregationType.Count, Name = "ID" },
                    new CAML.Aggregation { Type = CAML.AggregationType.Sum, Name = "Amount" }})
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
