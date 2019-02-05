using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotCAML.Tests
{
    [TestClass]
    public class TestJoins
    {
        [TestMethod]
        public void Test()
        {
            var caml = CAML
                .View(new string[] { "Title", "Country", "Population" })
                    .LeftJoin("Country", "Country").Select("y4r6", "Population")
                .Query()
                    .Where().NumberField("Population").LessThan(10)
                .ToString();

            string expected = @"<View>
                <ViewFields>
                    <FieldRef Name=""Title"" />
                    <FieldRef Name=""Country"" />
                    <FieldRef Name=""Population"" />
                </ViewFields>
                <Joins>
                    <Join Type=""LEFT"" ListAlias=""Country"">
                        <Eq>
                            <FieldRef Name=""Country"" RefType=""ID"" />
                            <FieldRef Name=""ID"" List=""Country"" />
                        </Eq>
                    </Join>
                </Joins>
                <ProjectedFields>
                    <Field ShowField=""y4r6"" Type=""Lookup"" Name=""Population"" List=""Country"" />
                </ProjectedFields>
                <Query>
                    <Where>
                        <Lt>
                            <FieldRef Name=""Population"" />
                            <Value Type=""Number"">10</Value>
                        </Lt>
                    </Where>
                </Query>
            </View>";

            Assert.AreEqual(Beautify.Xml(expected), Beautify.Xml(caml));
        }
    }
}