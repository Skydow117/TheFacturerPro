using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;

namespace TheFacturerPro.utilitatXML
{
    class LlegirXML
    {
        private DataSet dataset;
        private String xmlFileName;
        public DataSet newdataset;

        public LlegirXML(DataSet dataset, String xmlFileName)
        {
            this.dataset = dataset;
            this.xmlFileName = xmlFileName;
        }

        public void llegirFitxer()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(this.xmlFileName);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("/descendant-or-self::node()");
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            myConnectionString = "Database = pcground; Password = root; Port = 3307; Server = localhost; User = root";

            //List<string> parts = new List<string>();
            foreach (XmlNode node in nodes)
            {
                switch (node.Name)
                {

                    case "clients":
                        XmlNodeList childones03 = node.ChildNodes;
                        List<string> clients = new List<string>();
                        foreach (XmlNode node01 in childones03)
                        {
                            //Console.WriteLine(node01.Name + " -> " + node01.InnerText);
                            clients.Add(node01.InnerText);
                        }
                        try
                        {
                            conn = new MySql.Data.MySqlClient.MySqlConnection();
                            conn.ConnectionString = myConnectionString;
                            MySqlCommand command = conn.CreateCommand();
                            command.CommandText = "INSERT INTO clients (id_Client,Nom,Cognom1,Cognom2,Adreça,Codi_Postal,Població,Província,Telèfon,Fax,Email) VALUES (?id_Client,?Nom,?Cognom1,?Cognom2,?Adreça,?Codi_Postal,?Població,?Província,?Telèfon,?Fax,?Email)";
                            //command.CommandText = "INSERT INTO clients (id_Client,Nom,Cognom1,Cognom2,Adreça,Codi_Postal,Població,Província,Telèfon,Fax) VALUES (?id_Client,?Nom,?Cognom1,?Cognom2,?Adreça,?Codi_Postal,?Població,?Província,?Telèfon,?Fax)";
                            command.Parameters.AddWithValue("?id_Client", clients[0]);
                            command.Parameters.AddWithValue("?Nom", clients[1]);
                            command.Parameters.AddWithValue("?Cognom1", clients[2]);
                            command.Parameters.AddWithValue("?Cognom2", clients[3]);
                            command.Parameters.AddWithValue("?Adreça", clients[4]);
                            command.Parameters.AddWithValue("?Codi_Postal", clients[5]);
                            command.Parameters.AddWithValue("?Població", clients[6]);
                            command.Parameters.AddWithValue("?Província", clients[7]);
                            command.Parameters.AddWithValue("?Telèfon", clients[8]);
                            command.Parameters.AddWithValue("?Fax", clients[9]);
                            command.Parameters.AddWithValue("?Email", clients[10]);
                            conn.Open();
                            command.ExecuteNonQuery();
                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        Console.WriteLine();
                        break;

                    case "factura":
                        XmlNodeList childones01 = node.ChildNodes;
                        List<string> factures = new List<string>();
                        foreach (XmlNode node01 in childones01)
                        {
                            //Console.WriteLine(node01.Name + " -> " + node01.InnerText);
                            factures.Add(node01.InnerText);
                        }
                        try
                        {
                            conn = new MySql.Data.MySqlClient.MySqlConnection();
                            conn.ConnectionString = myConnectionString;
                            MySqlCommand command = conn.CreateCommand();
                            command.CommandText = "INSERT INTO factura (n_Factura,id_Client,Data,Descompte,IVA) VALUES (?n_Factura,?id_Client,?Data,?Descompte,?IVA)";
                            command.Parameters.AddWithValue("?n_Factura", factures[0]);
                            command.Parameters.AddWithValue("?id_Client", factures[1]);
                            command.Parameters.AddWithValue("?Data", factures[2]);
                            command.Parameters.AddWithValue("?Descompte", factures[3]);
                            command.Parameters.AddWithValue("?IVA", factures[4]);
                            conn.Open();
                            command.ExecuteNonQuery();
                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        Console.WriteLine();
                        break;

                    case "productes":
                        XmlNodeList childones02 = node.ChildNodes;
                        List<string> productes = new List<string>();
                        foreach (XmlNode node01 in childones02)
                        {
                            //Console.WriteLine(node01.Name + " -> " + node01.InnerText);
                            productes.Add(node01.InnerText);
                        }
                        try
                        {
                            conn = new MySql.Data.MySqlClient.MySqlConnection();
                            conn.ConnectionString = myConnectionString;
                            MySqlCommand command = conn.CreateCommand();
                            command.CommandText = "INSERT INTO productes (id_Producte,Producte,Preu) VALUES (?id,?Producte,?Preu)";
                            command.Parameters.AddWithValue("?id", productes[0]);
                            command.Parameters.AddWithValue("?Producte", productes[1]);
                            command.Parameters.AddWithValue("?Preu", productes[2]);
                            conn.Open();
                            command.ExecuteNonQuery();
                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        Console.WriteLine();
                        break;



                    case "factura_detall":
                        XmlNodeList childones04 = node.ChildNodes;
                        List<string> facturesDetall = new List<string>();
                        foreach (XmlNode node01 in childones04)
                        {
                            //Console.WriteLine(node01.Name + " -> " + node01.InnerText);
                            facturesDetall.Add(node01.InnerText);
                        }
                        try
                        {
                            conn = new MySql.Data.MySqlClient.MySqlConnection();
                            conn.ConnectionString = myConnectionString;
                            MySqlCommand command = conn.CreateCommand();
                            command.CommandText = "INSERT INTO factura_detall (n_Factura,id_Producte,Quantitat) VALUES (?n_Factura,?id_Producte,?Quantitat)";
                            command.Parameters.AddWithValue("?n_Factura", facturesDetall[0]);
                            command.Parameters.AddWithValue("?id_Producte", facturesDetall[1]);
                            command.Parameters.AddWithValue("?Quantitat", facturesDetall[2]);
                            conn.Open();
                            command.ExecuteNonQuery();
                        }
                        catch (MySql.Data.MySqlClient.MySqlException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        Console.WriteLine();
                        break;
                }
            }
        }

        public DataSet ReadXmlIntoDataSet()
        {
            using (FileStream fsReaderStream = new FileStream(this.xmlFileName, FileMode.Open))
            {
                using (XmlTextReader xmlReader = new XmlTextReader(fsReaderStream))
                {
                    this.newdataset.ReadXml(xmlReader, XmlReadMode.ReadSchema);
                }
            }
            return newdataset;
        }
    }

}
