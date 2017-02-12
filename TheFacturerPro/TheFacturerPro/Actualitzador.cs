using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFacturerPro
{
    //Classe per actualitzar el dataset.
    class Actualitzador
    {
        //Retorna un dataset amb els nous registres.
        public  DataSet UpdateBindingNavigator()
        {
            MySqlDataAdapter datapterClients;
            MySqlDataAdapter datapterProductes;
            MySqlDataAdapter datapterFactura;
            MySqlDataAdapter datapterFacturaDetall;
            DataSet dset;
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;
            
            myConnectionString = ConfigurationManager.ConnectionStrings["TheFacturerPro.Properties.Settings.pcgroundConnectionString"].ConnectionString;

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
            
            return dset;
        }
    }
}
