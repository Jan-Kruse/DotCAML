using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DotCAML.Tests.Core
{
    [TestClass]
    public class TestDateRangesOverlap
    {
        [TestMethod]
        public void Test()
        {
            var caml = CAML.Expression()
                .All(
                    CAML.Expression().DateField("BroadcastExpires").GreaterThanOrEqualTo(CamlValues.Today),
                    CAML.Expression().Any(
                        CAML.Expression().UserField("BroadcastTo").IsInCurrentUserGroups(),
                        CAML.Expression().UserField("BroadcastTo").EqualToCurrentUser()
                    ),
                    CAML.Expression().DateRangesOverlap(DateRangesOverlapType.Year, new DateTime().ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ"))
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