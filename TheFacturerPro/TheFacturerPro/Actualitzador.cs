using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFacturerPro
{
    class Actualitzador
    {
        public  DataSet UpdateBindingNavigator()
        {
            MySqlDataAdapter datapterClients;
            MySqlDataAdapter datapterProductes;
            MySqlDataAdapter datapterFactura;
            MySqlDataAdapter datapterFacturaDetall;
            DataSet dset;
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            /*const string DB_CONN_STR = "Server=localhost;Uid=root;Pwd=root;Database=pcground;";
            MySqlConnection cn = new MySqlConnection(DB_CONN_STR);*/
            myConnectionString = "Database = pcground; Password = root; Port = 3307; Server = localhost; User = root";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            datapterClients = new MySqlDataAdapter("SELECT * FROM clients", conn);
            datapterProductes = new MySqlDataAdapter("SELECT * FROM productes", conn);
            datapterFactura = new MySqlDataAdapter("SELECT * FROM factura", conn);
            datapterFacturaDetall = new MySqlDataAdapter("SELECT * FROM factura_detall", conn);
            dset = new DataSet();
            datapterClients.Fill(dset, "clients");
            datapterProductes.Fill(dset, "productes");
            datapterFactura.Fill(dset, "factura");
            datapterFacturaDetall.Fill(dset, "factura_detall");
            //Console.WriteLine(dset.Tables["factura"]);
            //Form1.getGrid().DataSource = dset.Tables[0];
            //ShowDataSet(dset);
            //BindingSource1.DataSource = dset.Tables[0];

            return dset;
        }
    }
}
