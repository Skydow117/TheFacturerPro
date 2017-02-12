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
    //Exporta un XML amb la informació de les taules de la base de dades.
    class EscriureXML
    {
        private DataSet dataset;
        private String xmlFileName;

        //Contructor on li passem un dataset i el nom que tindrà el fitser xml.
        public EscriureXML(DataSet dataset, String xmlFileName) {
            this.dataset = dataset;
            this.xmlFileName = xmlFileName;
        }

        //Crea un fitxer XML amb el seu XMLScheme basat en el dataSet de la classe.
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
