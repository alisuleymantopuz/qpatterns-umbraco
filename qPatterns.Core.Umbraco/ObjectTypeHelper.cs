using qPatterns.Core.Umbraco.Common;
using System;

namespace qPatterns.Core.Umbraco
{   public static class  ObjectTypeHelper
    {
        public static Guid GetGuid(ObjectTypes umbracoObjectType)
        {
            var fieldInfo = umbracoObjectType.GetType().GetField(umbracoObjectType.ToString());

            var guidAttributes = (GuidAttribute[])fieldInfo.GetCustomAttributes(typeof(GuidAttribute), false);

            return (guidAttributes.Length > 0) ? new Guid(guidAttributes[0].ToString()) : Guid.Empty;
        }

        public static string GetName(ObjectTypes umbracoObjectType)
        {
            return Enum.GetName(typeof(ObjectTypes), umbracoObjectType);
        }

        public static string GetFriendlyName(ObjectTypes umbracoObjectType)
        {
            var fieldInfo = umbracoObjectType.GetType().GetField(umbracoObjectType.ToString());

            var friendlyNames = (FriendlyNameAttribute[])fieldInfo.GetCustomAttributes(typeof(FriendlyNameAttribute), false);

            return (friendlyNames.Length > 0) ? friendlyNames[0].ToString() : string.Empty;
        }

        public static ObjectTypes GetUmbracoObjectType(string name)
        {
            return (ObjectTypes)Enum.Parse(typeof(ObjectTypes), name, false);
        }

        public static ObjectTypes GetUmbracoObjectType(Guid guid)
        {
            var umbracoObjectType = ObjectTypes.Unknown;

            for (var index = 0; index < Enum.GetNames(typeof(ObjectTypes)).Length; index++)
            {
                var name = Enum.GetNames(typeof(ObjectTypes))[index];

                if (GetGuid(GetUmbracoObjectType(name)) == guid)
                    umbracoObjectType = GetUmbracoObjectType(name);
            }

            return umbracoObjectType;
        }
    }
}
