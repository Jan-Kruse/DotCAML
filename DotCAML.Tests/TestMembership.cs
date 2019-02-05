using System;
using NUnit.Framework;

namespace DotCAML.Tests
{
    [TestFixture]
    public class TestMembership
    {
        [Test]
        public void Test()
        {
            var caml = CAML.Where()
                .UserField("AssignedTo").EqualToCurrentUser()
                .Or()
                .UserField("AssignedTo").IsInCurrentUserGroups()
                .GroupBy("Category")
                .OrderBy("Priority").ThenBy("Title")
                .ToString();

            string expected = @"<Where>
                    <Or>
                        <Eq><FieldRef Name=""AssignedTo"" LookupId=""True"" /><Value Type=""Integer""><UserID /></Value></Eq>
                        <Membership Type=""CurrentUserGroups""><FieldRef Name=""AssignedTo"" /></Membership>
                    </Or>
                </Where>
                <GroupBy>
                    <FieldRef Name=""Category"" />
                </GroupBy>
                <OrderBy>
                    <FieldRef Name=""Priority"" /><FieldRef Name=""Title"" />
                </OrderBy>";

            Assert.AreEqual(Beautify.Xml(expected), Beautify.Xml(caml));
        }
    }
}
