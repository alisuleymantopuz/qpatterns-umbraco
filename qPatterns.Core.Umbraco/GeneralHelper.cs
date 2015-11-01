using System.Text;
using System.Xml;
using umbraco.presentation.nodeFactory;

namespace qPatterns.Core.Umbraco
{
    public static class GeneralHelper
    {
        public static XmlDocument GetPublishedXml(ObjectTypes umbracoObjectType)
        {
            var xmlDocument = new XmlDocument();

            switch (umbracoObjectType)
            {
                case ObjectTypes.Media: xmlDocument.AppendChild(xmlDocument.CreateElement("Media")); break;
                case ObjectTypes.Member: xmlDocument.AppendChild(xmlDocument.CreateElement("Members")); break;
                default: xmlDocument.AppendChild(xmlDocument.CreateElement("Nodes")); break;
            }

            var xmlRecordsReader = SqlHelper.SqlObject.ExecuteReader("SELECT * FROM cmsContentXml WHERE nodeId IN (SELECT id FROM umbracoNode WHERE nodeObjectType = @nodeObjectType)",
                SqlHelper.SqlObject.CreateParameter("@nodeObjectType", ObjectTypeHelper.GetGuid(umbracoObjectType)));

            if (!xmlRecordsReader.HasRecords) 
                return xmlDocument;

            var stringBuilder = new StringBuilder();

            while (xmlRecordsReader.Read())
            {
                stringBuilder.Append(xmlRecordsReader.GetObject("xml"));
            }

            xmlDocument.FirstChild.InnerXml = stringBuilder.ToString();

            return xmlDocument;
        }


        public static bool IsYes(string value)
        {
            var isYes = value == "1";

            return isYes;
        }

        public static string[] GetCsvIds(string csv)
        {
            string[] ids = null;

            if (!string.IsNullOrEmpty(csv)) { ids = csv.Split(','); }

            return ids;
        }

        public static bool IsCurrentNodeAvailable()
        {
            var currentNodeAvailable = false;
            
            try
            {
                if (Node.GetCurrent() != null)
                    currentNodeAvailable = true;
            }
            catch { currentNodeAvailable = false; }

            return currentNodeAvailable;
        }
    }
}
