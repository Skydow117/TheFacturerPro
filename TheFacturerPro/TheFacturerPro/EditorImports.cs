using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheFacturerPro.utilitatXML;

namespace TheFacturerPro
{
    public partial class EditorImports : Form
    {
        public DataSet datasetImportatEditar;
        public DataSet datasetTemporal= new DataSet();

        //Inicia i centra el formulari
        public EditorImports()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }
      
        //Valida i guardar el contingut de les taules al dataset.
        private void clientsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clientsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pcgroundDataSet);

        }

        //Plena les taules amb la taula corresponent del dataset.
        private void Form2_Load(object sender, EventArgs e)
        {
            this.factura_detallTableAdapter.Fill(this.pcgroundDataSet.factura_detall);
            this.facturaTableAdapter.Fill(this.pcgroundDataSet.factura);
            this.productesTableAdapter.Fill(this.pcgroundDataSet.productes);
            this.clientsTableAdapter.Fill(this.pcgroundDataSet.clients);

        }

        //Canvia el BindingSource del navegador a la taula correcte quan canviem de pestanya.
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    clientsBindingNavigator.BindingSource = clientsBindingSource;
                    break;
                case 1:
                    clientsBindingNavigator.BindingSource = productesBindingSource;
                    break;
                case 2:
                    clientsBindingNavigator.BindingSource = facturaBindingSource;
                    break;
                case 3:
                    clientsBindingNavigator.BindingSource = factura_detallBindingSource;
                    break;
            }
        }

        //Canvia el contingut de les taules per el de les importades.
        public void setDataset(DataSet datasetImportatEditarD) {
            this.datasetImportatEditar = datasetImportatEditarD;
            clientsDataGridView.DataSource = datasetImportatEditar.Tables[0];
            productesDataGridView.DataSource = datasetImportatEditar.Tables[1];
            facturaDataGridView.DataSource = datasetImportatEditar.Tables[2];
            factura_detallDataGridView.DataSource = datasetImportatEditar.Tables[3];
        }

        //Inserta les taules d'aquest formulari a les de la base de dades i la pagina principal.
        private void button1_Click(object sender, EventArgs e)
        {
            

            if (checkBox1.Checked) {
                LlegirXML lector = new LlegirXML();
                lector.borrarDadesTaules();                
            }

            DataTable cs = clientsDataGridView.DataSource as DataTable;
            DataTable ps = productesDataGridView.DataSource as DataTable;
            DataTable fs = facturaDataGridView.DataSource as DataTable;
            DataTable fds = factura_detallDataGridView.DataSource as DataTable;

            ShowDataTable(cs, "clients");
            ShowDataTable(ps, "productes");
            ShowDataTable(fs, "factura");
            ShowDataTable(fds, "factura_detall");
        }

        
        // Llista les columnes de cada taula del dataset i fa els corresponents inserts.
        private static void ShowDataTable(DataTable table,string id)
        {
           
            Console.WriteLine("{0,-14}", "");

            foreach (DataRow row in table.Rows)
            {
                List<string> list = new List<string>();
                if (row.RowState == DataRowState.Deleted)
                {
                    foreach (DataColumn col in table.Columns)
                    {
                        if (col.DataType.Equals(typeof(DateTime)))
                        {
                            Console.Write("{0,-14:d}", row[col, DataRowVersion.Original]);
                        }
                        else if (col.DataType.Equals(typeof(Decimal)))
                        {
                            Console.Write("{0,-14:C}", row[col, DataRowVersion.Original]);
                        }
                        else
                        {
                            Console.Write("{0,-14}", row[col, DataRowVersion.Original]);
                        }
                    }
                }
                else
                {
                    foreach (DataColumn col in table.Columns)
                    {
                        if (col.DataType.Equals(typeof(DateTime)))
                        {
                            var value=String.Format("{0,-14:d}", row[col]);
                            list.Add(value);
                        }
                        else if (col.DataType.Equals(typeof(Decimal)))
                        {
                            var value = String.Format("{0,-14:C}", row[col]);
                            list.Add(value);
                        }
                        else
                        {
                            var value = String.Format("{0,-14}", row[col]);
                            list.Add(value);
                        }
                    }
                }

                insertRegister(list, id);

                Console.WriteLine("{0,-14}", "");
            }            
        }

        //Crea les consultes amb els inserts i les llança a la base de dades.
        public static void insertRegister(List<string> list, string id) {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            myConnectionString = "Database = pcground; Password = root; Port = 3307; Server = localhost; User = root";
            switch (id) {
                case "clients":
                    try
                    {
                       
                        conn = new MySql.Data.MySqlClient.MySqlConnection();
                        conn.ConnectionString = myConnectionString;
                        MySqlCommand command = conn.CreateCommand();

                        command.CommandText = "INSERT INTO clients (id_Client,Nom,Cognom1,Cognom2,Adreça,Codi_Postal,Població,Província,Telèfon,Fax,Email) VALUES (?id_Client,?Nom,?Cognom1,?Cognom2,?Adreça,?Codi_Postal,?Població,?Província,?Telèfon,?Fax,?Email)";
                        command.Parameters.AddWithValue("?id_Client", list[0]);
                        command.Parameters.AddWithValue("?Nom", list[1]);
                        command.Parameters.AddWithValue("?Cognom1", list[2]);
                        command.Parameters.AddWithValue("?Cognom2", list[3]);
                        command.Parameters.AddWithValue("?Adreça", list[4]);
                        command.Parameters.AddWithValue("?Codi_Postal", list[5]);
                        command.Parameters.AddWithValue("?Població", list[6]);
                        command.Parameters.AddWithValue("?Província", list[7]);
                        command.Parameters.AddWithValue("?Telèfon", list[8]);
                        command.Parameters.AddWithValue("?Fax", list[9]);
                        command.Parameters.AddWithValue("?Email", list[10]);
                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "productes":
                    try
                    {
                        conn = new MySql.Data.MySqlClient.MySqlConnection();
                        conn.ConnectionString = myConnectionString;
                        MySqlCommand command = conn.CreateCommand();
                        command.CommandText = "INSERT INTO productes (id_Producte,Producte,Preu) VALUES (?id,?Producte,?Preu)";
                        command.Parameters.AddWithValue("?id", list[0]);
                        command.Parameters.AddWithValue("?Producte", list[1]);
                        command.Parameters.AddWithValue("?Preu", list[2]);
                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "factura":
                    try
                    {
                        conn = new MySql.Data.MySqlClient.MySqlConnection();
                        conn.ConnectionString = myConnectionString;
                        MySqlCommand command = conn.CreateCommand();
                        command.CommandText = "INSERT INTO factura (n_Factura,id_Client,Data,Descompte,IVA) VALUES (?n_Factura,?id_Client,?Data,?Descompte,?IVA)";
                        command.Parameters.AddWithValue("?n_Factura", list[0]);
                        command.Parameters.AddWithValue("?id_Client", list[1]);
                        command.Parameters.AddWithValue("?Data", list[2]);
                        command.Parameters.AddWithValue("?Descompte", list[3]);
                        command.Parameters.AddWithValue("?IVA", list[4]);
                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case "factura_detall":
                    try
                    {
                        conn = new MySql.Data.MySqlClient.MySqlConnection();
                        conn.ConnectionString = myConnectionString;
                        MySqlCommand command = conn.CreateCommand();
                        command.CommandText = "INSERT INTO factura_detall (n_Factura,id_Producte,Quantitat) VALUES (?n_Factura,?id_Producte,?Quantitat)";
                        command.Parameters.AddWithValue("?n_Factura", list[0]);
                        command.Parameters.AddWithValue("?id_Producte", list[1]);
                        command.Parameters.AddWithValue("?Quantitat", list[2]);
                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;

            }
        }
    }
}
