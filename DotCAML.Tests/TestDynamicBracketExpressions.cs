using NUnit.Framework;
using System.Collections.Generic;

namespace DotCAML.Tests
{
    [TestFixture]
    public class TestDynamicBracketExpressions
    {
        [Test]
        public void Test()
        {
            var categories = new List<string>() { "Platform Support", "Research and Strategy" };
            var purposes = new List<string>() { "Application and User Lists", "How To", "Support Information" };

            var categoriesExpressions = new List<IExpression>();

            foreach (var category in categories)
            {
                categoriesExpressions.Add(CAML.Expression().TextField("ContentCategory").EqualTo(category));
            }

            var purposesExpressions = new List<IExpression>();

            foreach (var purpose in purposes)
            {
                purposesExpressions.Add(CAML.Expression().TextField("ContentPurpose").EqualTo(purpose));
            }

            var caml = CAML.Where()
                .All(
                    CAML.Expression().Any(categoriesExpressions.ToArray()),
                    CAML.Expression().Any(purposesExpressions.ToArray())
                )
                .ToString();

            string expected = @"<Where>
                    <And>
                        <Or>
                            <Eq>
                                <FieldRef Name=""ContentCategory"" />
                                <Value Type=""Text"">Platform Support</Value>
                            </Eq>
                            <Eq>
                                <FieldRef Name=""ContentCategory"" />
                                <Value Type=""Text"">Research and Strategy</Value>
                            </Eq>
                        </Or>
                        <Or>
                            <Eq>
                                <FieldRef Name=""ContentPurpose"" />
                                <Value Type=""Text"">Application and User Lists</Value>
                            </Eq>
                            <Or>
                                <Eq>
                                    <FieldRef Name=""ContentPurpose"" />
                                    <Value Type=""Text"">How To</Value>
                                </Eq>
                                <Eq>
                                    <FieldRef Name=""ContentPurpose"" />
                                    <Value Type=""Text"">Support Information</Value>
                                </Eq>
                            </Or>
                        </Or>
                    </And>
                </Where>";

            Assert.AreEqual(Beautify.Xml(expected), Beautify.Xml(caml));
        }
    }
}