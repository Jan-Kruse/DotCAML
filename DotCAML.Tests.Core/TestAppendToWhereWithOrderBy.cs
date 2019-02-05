using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotCAML.Tests.Core
{
    [TestClass]
    public class TestAppendToWhereWithOrderBy
    {
        [TestMethod]
        public void Test()
        {
            var rawQuery = @"<View Scope=""RecursiveAll"">
                <Query>
                    <Where>
                        <Eq>
                            <FieldRef Name=""ID"" />
                            <Value Type=""Number"">10</Value>
                        </Eq>
                    </Where>
                    <OrderBy>
                        <FieldRef Name=""Date"" />
                    </OrderBy>
                </Query>
            </View>";

            var caml = CAML.FromXml(rawQuery).ModifyWhere().AppendOr().TextField("Title").Contains("Summer").ToString();

            string expected = @"<View Scope=""RecursiveAll"">
                <Query>
                    <OrderBy>
                        <FieldRef Name=""Date"" />
                    </OrderBy>
                    <Where>
                        <Or>
                            <Eq>
                                <FieldRef Name=""ID"" />
                                <Value Type=""Number"">10</Value>
                            </Eq>
                            <Contains>
                                <FieldRef Name=""Title"" />
                                <Value Type=""Text"">Summer</Value>
                            </Contains>
                        </Or>
                    </Where>
                </Query>
            </View>";

            Assert.AreEqual(Beautify.Xml(expected), Beautify.Xml(caml));
        }
    }
}
