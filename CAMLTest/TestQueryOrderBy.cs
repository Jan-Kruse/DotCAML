using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CAMLTest
{
    [TestClass]
    public class TestQueryOrderBy
    {

        [TestMethod]
        public void Test()
        {
            var caml = CAML.CAML
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
