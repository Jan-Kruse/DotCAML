using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotCAML.Tests
{
    [TestClass]
    public class TestReplaceWhere
    {
        [TestMethod]
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

            var caml = CAML.FromXml(rawQuery).ReplaceWhere().TextField("Title").IsNotNull().ToString();

            string expected = @"<View Scope=""RecursiveAll"">
                <Query>
                    <Where>
                        <IsNotNull>
                            <FieldRef Name=""Title"" />
                        </IsNotNull>
                    </Where>
                </Query>
            </View>";

            Assert.AreEqual(Beautify.Xml(expected), Beautify.Xml(caml));
        }
    }
}
