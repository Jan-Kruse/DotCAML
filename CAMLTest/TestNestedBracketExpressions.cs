using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CAMLTest
{
    [TestClass]
    public class TestNestedBracketExpressions
    {
        [TestMethod]
        public void Test()
        {
            var caml = CAML.CAML.Where()
                .All(
                    CAML.CAML.Expression().All(
                        CAML.CAML.Expression().BooleanField("Enabled").IsTrue(),
                        CAML.CAML.Expression().UserMultiField("TargetAudience").IncludesSuchItemThat().ValueAsText().EqualTo("55").Or().UserMultiField("TargetAudience").IncludesSuchItemThat().ValueAsText().EqualTo("66")
                        ),
                    CAML.CAML.Expression().Any(
                        CAML.CAML.Expression().TextField("NotificationScope").EqualTo("77"),
                        CAML.CAML.Expression().TextField("NotificationScope").EqualTo("88").And().TextField("ScopeWebRelativeUrl").EqualTo("99")
                        )
                )
                .ToString();

            string expected = @"<Where>
                    <And>
                        <And>
                            <Eq><FieldRef Name=""Enabled"" /><Value Type=""Integer"">1</Value></Eq>
                            <Or>
                                <Eq><FieldRef Name=""TargetAudience"" /><Value Type=""Text"">55</Value></Eq>
                                <Eq><FieldRef Name=""TargetAudience"" /><Value Type=""Text"">66</Value></Eq>
                            </Or>
                        </And>
                        <Or>
                            <Eq><FieldRef Name=""NotificationScope"" /><Value Type=""Text"">77</Value></Eq>
                            <And>
                                <Eq><FieldRef Name=""NotificationScope"" /><Value Type=""Text"">88</Value></Eq>
                                <Eq><FieldRef Name=""ScopeWebRelativeUrl"" /><Value Type=""Text"">99</Value></Eq>
                            </And>
                        </Or>
                    </And>
                </Where>";

            Assert.AreEqual(Beautify.Xml(expected), Beautify.Xml(caml));
        }
    }
}
