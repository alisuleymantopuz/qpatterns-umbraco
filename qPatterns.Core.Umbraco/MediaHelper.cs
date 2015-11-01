using System;
using System.Collections.Generic;
using System.Linq;
using umbraco.cms.businesslogic.media;

namespace qPatterns.Core.Umbraco
{
    public static class MediaHelper
    {
        public static Media GetMediaItem(string mediaId)
        {
            int id;
            if (!int.TryParse(mediaId, out id)) 
                return null;

            try
            {
                return new Media(id);
            }
            catch
            {
                throw new Exception("Unable to create Media Item with id = " + id);
            }
        }
        public static List<Media> GetMediaFromXpath(string xPath)
        {
            var media = new List<Media>();

            var xmlDocument = GeneralHelper.GetPublishedXml(ObjectTypes.Media);

            var xPathNavigator = xmlDocument.CreateNavigator();

            var xPathNodeIterator = xPathNavigator.Select(xPath);

            Media mediaItem = null;

            while (xPathNodeIterator.MoveNext())
            {
                var o = xPathNodeIterator.Current.Evaluate("string(@id)");
                if (o != null)
                    mediaItem = GetMediaItem(o.ToString());

                if (mediaItem != null)
                    media.Add(mediaItem);
            }

            return media;
        }

        public static List<Media> GetMediaFromCsv(string csv)
        {
            var media = new List<Media>();

            var vars = GeneralHelper.GetCsvIds(csv);

            if (vars == null) return media;

            media.AddRange(vars.Select(GetMediaItem).Where(mediaItem => mediaItem != null));

            return media;
        }

        public static string GetMediaProperty(string propertyName, int mediaId)
        {
            return GetMediaProperty(propertyName, GetMediaItem(mediaId.ToString()));
        }

        public static string GetMediaProperty(string propertyName, Media media)
        {
            var propertyValue = string.Empty;

            if (media == null || media.getProperty(propertyName) == null)
                return propertyValue;

            propertyValue = media.getProperty(propertyName).Value.ToString();

            return propertyValue;
        }
    }
}
