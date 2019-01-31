using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CAMLTest
{
    [TestClass]
    public class TestAny
    {
        [TestMethod]
        public void Test()
        {
            string caml = CAML.CAML.Where()
                .Any(
                    CAML.CAML.Expression().TextField("Email").EqualTo("support@google.com"),
                    CAML.CAML.Expression().TextField("Email").EqualTo("plus@google.com"),
                    CAML.CAML.Expression().TextField("Title").BeginsWith("[Google]"),
                    CAML.CAML.Expression().TextField("Content").Contains("Google")
                )
                .ToString();

            string expected = @"<Where>
                    <Or>
                        <Eq><FieldRef Name=""Email"" /><Value Type=""Text"">support@google.com</Value></Eq>
                        <Or>
                            <Eq><FieldRef Name=""Email"" /><Value Type=""Text"">plus@google.com</Value></Eq>
                            <Or>
                                <BeginsWith><FieldRef Name=""Title"" /><Value Type=""Text"">[Google]</Value></BeginsWith>
                                <Contains><FieldRef Name=""Content"" /><Value Type=""Text"">Google</Value></Contains>
                            </Or>
                        </Or>
                    </Or>
                </Where>";

            Assert.AreEqual(Beautify.Xml(expected), Beautify.Xml(caml));
        }
    }
}
