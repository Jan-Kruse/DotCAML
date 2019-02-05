using System;
using NUnit.Framework;

namespace DotCAML.Tests
{
    [TestFixture]
    public class TestAppendToWhere
    {
        [Test]
        public void Test()
        {
            var rawQuery = @"<View Scope=""RecursiveAll"">
                <Query>
                    <Where>
                        <IsNotNull>
                            <FieldRef Name=""ID"" />
                        </IsNotNull>
                    </Where>
                </Query>
            </View>";

            var caml = CAML.FromXml(rawQuery).ModifyWhere().AppendAnd().TextField("Title").IsNotNull().ToString();

            string expected = @"<View Scope=""RecursiveAll"">
                <Query>
                    <Where>
                        <And>
                            <IsNotNull>
                                <FieldRef Name=""ID"" />
                            </IsNotNull>
                            <IsNotNull>
                                <FieldRef Name=""Title"" />
                            </IsNotNull>
                        </And>
                    </Where>
                </Query>
            </View>";

            Assert.AreEqual(Beautify.Xml(expected), Beautify.Xml(caml));
        }
    }
}
