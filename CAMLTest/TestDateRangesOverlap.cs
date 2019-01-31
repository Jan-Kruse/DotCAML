using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CAMLTest
{
    [TestClass]
    public class TestDateRangesOverlap
    {
        [TestMethod]
        public void Test()
        {
            var caml = CAML.CAML.Expression()
                .All(
                    CAML.CAML.Expression().DateField("BroadcastExpires").GreaterThanOrEqualTo(CAML.CamlValues.Today),
                    CAML.CAML.Expression().Any(
                        CAML.CAML.Expression().UserField("BroadcastTo").IsInCurrentUserGroups(),
                        CAML.CAML.Expression().UserField("BroadcastTo").EqualToCurrentUser()
                    ),
                    CAML.CAML.Expression().DateRangesOverlap(CAML.DateRangesOverlapType.Year, new DateTime().ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"))
                )
                .ToString();

            string expected = @"<And>
                <Geq>
                    <FieldRef Name=""BroadcastExpires"" />
                    <Value Type=""DateTime"">
                        <Today />
                    </Value>
                </Geq>
                <And>
                    <Or>
                        <Membership Type=""CurrentUserGroups"">
                        <FieldRef Name=""BroadcastTo"" />
                        </Membership>
                        <Eq>
                        <FieldRef Name=""BroadcastTo"" LookupId=""True"" />
                        <Value Type=""Integer""><UserID /></Value>
                        </Eq>
                    </Or>
                    <DateRangesOverlap>
                        <FieldRef Name=""EventDate"" />
                        <FieldRef Name=""EndDate"" />
                        <FieldRef Name=""RecurrenceID"" />
                        <Value Type=""DateTime"">
                        <Year />
                        </Value>
                    </DateRangesOverlap>
                </And>
            </And>";

            Assert.AreEqual(Beautify.Xml(expected), Beautify.Xml(caml));
        }
    }
}
