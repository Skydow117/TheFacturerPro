using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TheFacturerPro.utilitatXML
{
    class EscriureXML
    {
        private DataSet dataset;
        private String xmlFileName;

        public EscriureXML(DataSet dataset, String xmlFileName) {
            this.dataset = dataset;
            this.xmlFileName = xmlFileName;
        }

        public void exportarFitxer() {
            try
            {
                using (FileStream fsWriterStream = new FileStream(xmlFileName, FileMode.Create))
                {
                    using (XmlTextWriter xmlWriter = new XmlTextWriter(fsWriterStream, Encoding.Unicode))
                    {
                        dataset.WriteXml(xmlWriter, XmlWriteMode.WriteSchema);
                        Console.WriteLine("Write {0} to the File {1}.", dataset.DataSetName, xmlFileName);
                        Console.WriteLine();
                    }
                }
                MessageBox.Show("Xml correctament guardat.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Quelcom ha anat malament!");
            }
        }
    }
}
