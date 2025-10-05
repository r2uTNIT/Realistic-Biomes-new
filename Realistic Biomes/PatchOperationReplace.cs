using System.Linq;
using System.Xml;
using Verse;

// *
namespace RimworldPlusPlus.RealisticBiomes{
	public class PatchOperationReplace : PatchOperationPathed{
		private XmlContainer value;

		protected override bool ApplyWorker(XmlDocument xml){
            XmlNode node = value.node;
			
            bool result = false;
			
            if(true){
                XmlNode[] array = xml.SelectNodes(xpath).Cast<XmlNode>().ToArray();

                foreach (XmlNode xmlNode in array){
				    result = true;
				
                    XmlNode parentNode = xmlNode.ParentNode;
				
                    foreach (XmlNode childNode in node.ChildNodes){
					    parentNode.InsertBefore(parentNode.OwnerDocument.ImportNode(childNode, deep: true), xmlNode);
				    }
				    parentNode.RemoveChild(xmlNode);
			    }
            }
			return result;
		}
	}
}