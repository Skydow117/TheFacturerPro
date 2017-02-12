using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;

namespace TheFacturerPro
{
    public partial class Login : Form
    {
        string connectionString;
        string[] strSeparatPuntComa; 

        public Login()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            textBox1.MaxLength = 8;
            textBox2.PasswordChar = '*';
            textBox2.MaxLength = 8;

            connectionString = ConfigurationManager.ConnectionStrings["TheFacturerPro.Properties.Settings.pcgroundConnectionString"].ConnectionString;
            strSeparatPuntComa = connectionString.Split(';'); 

        }

        private string obtenirPass() {

            string[] strPassSeparat = strSeparatPuntComa[1].Split('=');
           
            return strPassSeparat[1];
        }

        private string obtenirUsuari()
        {

            string[] strPassSeparat = strSeparatPuntComa[4].Split('=');

            return strPassSeparat[1];
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {

            Validar();

        }

        private void Validar() {
            if (textBox1.Text.Equals(obtenirUsuari()) && textBox2.Text.Equals(obtenirPass()))
            {
                (new Thread(CloseIt)).Start();
                MessageBox.Show("Validació correcte");
                this.Hide();
                Progres progresForm = new Progres();
                progresForm.Show();
                progresForm.Loaded();

                Form1 formulari = new Form1();
                formulari.Closed += (s, args) => this.Close();
                formulari.Show();
            }
            else
            {

                MessageBox.Show("Usuari o contrassenya incorrectes.\nSiusplau torna-ho a provar.");

            };
        }

        public void CloseIt()
        {
            Thread.Sleep(500);
            Microsoft.VisualBasic.Interaction.AppActivate(
                 System.Diagnostics.Process.GetCurrentProcess().Id);
            System.Windows.Forms.SendKeys.SendWait(" ");
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Validar();
            }
        }
    }
}
