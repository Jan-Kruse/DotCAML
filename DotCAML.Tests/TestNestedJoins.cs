using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotCAML.Tests
{
    [TestClass]
    public class TestNestedJoins
    {
        [TestMethod]
        public void Test()
        {
            var caml = CAML
                .View(new string[] { "Title", "CustomerCity" })
                    .LeftJoin("CustomerName", "customers")
                    .LeftJoin("CityName", "customerCities", "customers")
                    .Select("Title", "CustomerCity")
                .Query()
                .ToString();

            string expected = @"<View>
                <ViewFields>
                    <FieldRef Name=""Title"" />
                    <FieldRef Name=""CustomerCity"" />
                </ViewFields>
                <Joins>
                  <Join Type=""LEFT"" ListAlias=""customers"">
                    <Eq>
                      <FieldRef Name=""CustomerName"" RefType=""ID"" />
                      <FieldRef Name=""ID"" List=""customers"" />
                    </Eq>
                  </Join>
                  <Join Type=""LEFT"" ListAlias=""customerCities"">
                    <Eq>
                      <FieldRef Name=""CityName"" RefType=""ID"" List=""customers"" />
                      <FieldRef Name=""ID"" List=""customerCities"" />
                    </Eq>
                  </Join>
                </Joins>
                <ProjectedFields>
                    <Field ShowField=""Title"" Type=""Lookup"" Name=""CustomerCity"" List=""customerCities"" />
                </ProjectedFields>
                <Query />
            </View>";

            Assert.AreEqual(Beautify.Xml(expected), Beautify.Xml(caml));

            caml = CAML
                .View(new string[] { "Title", "CustomerName", "CustomerCity" })
                    .LeftJoin("CustomerName", "customers")
                    .Select("Title", "CustomerName")
                    .LeftJoin("CityName", "customerCities", "customers")
                    .Select("Title", "CustomerCity")
                .Query()
                .ToString();

            expected = @"<View>
                <ViewFields>
                    <FieldRef Name=""Title"" />
                    <FieldRef Name=""CustomerName"" />
                    <FieldRef Name=""CustomerCity"" />
                </ViewFields>
                <Joins>
                  <Join Type=""LEFT"" ListAlias=""customers"">
                    <Eq>
                      <FieldRef Name=""CustomerName"" RefType=""ID"" />
                      <FieldRef Name=""ID"" List=""customers"" />
                    </Eq>
                  </Join>
                  <Join Type=""LEFT"" ListAlias=""customerCities"">
                    <Eq>
                      <FieldRef Name=""CityName"" RefType=""ID"" List=""customers"" />
                      <FieldRef Name=""ID"" List=""customerCities"" />
                    </Eq>
                  </Join>
                </Joins>
                <ProjectedFields>
                    <Field ShowField=""Title"" Type=""Lookup"" Name=""CustomerName"" List=""customers"" />
                    <Field ShowField=""Title"" Type=""Lookup"" Name=""CustomerCity"" List=""customerCities"" />
                </ProjectedFields>
                <Query />
            </View>";

            Assert.AreEqual(Beautify.Xml(expected), Beautify.Xml(caml));
        }
    }
}