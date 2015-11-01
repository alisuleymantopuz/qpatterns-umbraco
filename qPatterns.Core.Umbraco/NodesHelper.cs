using System.Collections.Generic;
using System.Linq;
using umbraco.presentation.nodeFactory;

namespace qPatterns.Core.Umbraco
{   
    public static class NodesHelper
    {
        public static Node FindRootNode()
        {
            return FindRootNode(Node.GetCurrent());
        }

        public static Node FindRootNode(Node currentNode)
        {
            while (true)
            {
                if (currentNode.Parent == null)
                    return currentNode;
                currentNode = currentNode.Parent;
            }
        }

        public static Node GetNode(string nodeId)
        {
            int id;

            return int.TryParse(nodeId, out id) ? new Node(id) : null;
        }

        public static Node GetChildNodeByName(string nodeName)
        {
            return GetChildNodeByName(nodeName, Node.GetCurrent());
        }

        public static Node GetChildNodeByName(string nodeName, int parentNodeId)
        {
            return GetChildNodeByName(nodeName, new Node(parentNodeId));
        }

        public static Node GetChildNodeByName(string nodeName, Node parentNode)
        {
            return parentNode.Children.Cast<Node>().FirstOrDefault(childNode => childNode.Name == nodeName);
        }

        public static List<Node> GetNodesByName(string nodeName, bool global)
        {
            var nodes = new List<Node>();

            if (global)
            {
                foreach (Node childNode in new Node(-1).Children)
                    GetNodesByName(nodeName, ref nodes, childNode);
            }
            else GetNodesByName(nodeName, ref nodes, FindRootNode());

            return nodes;
        }

        private static void GetNodesByName(string nodeName, ref List<Node> nodes, Node currentNode)
        {
            var node = GetChildNodeByName(nodeName, currentNode);

            if (node != null)
                if (nodes != null)
                    nodes.Add(node);

            foreach (Node childNode in currentNode.Children)
                GetNodesByName(nodeName, ref nodes, childNode);
        }

        public static List<Node> GetNodesFromCsv(string csv)
        {
            var nodes = new List<Node>();

            var vars = GeneralHelper.GetCsvIds(csv);

            if (vars == null) return nodes;

            nodes.AddRange(vars.Select(GetNode).Where(node => node != null));

            return nodes;
        }

        public static List<Node> GetNodesFromXpath(string xPath)
        {
            var nodes = new List<Node>();

            if (GeneralHelper.IsCurrentNodeAvailable())
            {
                xPath = xPath.Replace("$currentPage", "descendant::node[@id='" + Node.GetCurrent().Id + "']");
            }

            var xPathNavigator = umbraco.content.Instance.XmlContent.CreateNavigator();
            var xPathNodeIterator = xPathNavigator.Select(xPath);

            while (xPathNodeIterator.MoveNext())
            {
                var o = xPathNodeIterator.Current.Evaluate("string(@id)");
                if (o == null) continue;

                var node = GetNode(o.ToString());

                if (node != null) nodes.Add(node);
            }

            return nodes;
        }

        public static string GetNodeProperty(string propertyName)
        {
            return GetNodeProperty(propertyName, Node.GetCurrent());
        }

        public static string GetNodeProperty(string propertyName, int nodeId)
        {
            return GetNodeProperty(propertyName, new Node(nodeId));
        }

        public static string GetNodeProperty(string propertyName, Node node)
        {
            var propertyValue = string.Empty;

            if (node != null && node.GetProperty(propertyName) != null)
                propertyValue = node.GetProperty(propertyName).Value;

            return propertyValue;
        }
    }
}
