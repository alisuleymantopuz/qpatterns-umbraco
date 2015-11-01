using System;
using System.Collections.Generic;
using umbraco.cms.businesslogic.member;

namespace qPatterns.Core.Umbraco
{
    public static class MembersHelper
    {
        public static Member GetMember(string memberId)
        {
            int id;

            if (!int.TryParse(memberId, out id)) 
                return null;

            try
            {
                return new Member(id);
            }
            catch
            {
                throw new Exception("Unable to create Member with id = " + id);
            }
        }

        public static List<Member> GetMembersFromXpath(string xPath)
        {
            var members = new List<Member>();

            var xmlDocument = GeneralHelper.GetPublishedXml(ObjectTypes.Member);
            var xPathNavigator = xmlDocument.CreateNavigator();
            var xPathNodeIterator = xPathNavigator.Select(xPath);

            Member member = null;

            while (xPathNodeIterator.MoveNext())
            {
                var o = xPathNodeIterator.Current.Evaluate("string(@id)");
                if (o != null)
                    member = GetMember(o.ToString());

                if (member != null)
                    members.Add(member);
            }

            return members;
        }
    }
}
