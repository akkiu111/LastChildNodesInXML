using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LastChildNodeXMLValues
{
    class Program
    {
        static void Main(string[] args)
        {

            //1) Read the XML File using a File Read or XML Parser
            var filename = "Sample.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var SampleFilepath = Path.Combine(currentDirectory, filename);

            //2) For each of the parent , find the last child node.
            var xmlDoc = XDocument.Load(SampleFilepath);
            var lastElements = xmlDoc.Root.Descendants("name").Where(node => node.NextNode == null).Select( lastNode => lastNode.Value).ToList();

            //3) Store each of the child node values in a file
            var outputFile = Path.Combine(currentDirectory, filename.Substring(0, filename.IndexOf('.')) + "OutputList");
            if (File.Exists(outputFile))
            {
                File.Delete(outputFile);
            }
            using (StreamWriter writer = new StreamWriter(outputFile))
            {
                foreach (string lastElement in lastElements)
                {
                    writer.WriteLine(lastElement);
                }
            }

        }
    }
}
