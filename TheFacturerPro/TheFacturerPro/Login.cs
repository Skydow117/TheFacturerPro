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
    //Clase per iniciar sessió amb l'usuari i la contrassenya de la BD.
    public partial class Login : Form
    {
        string connectionString;
        string[] strSeparatPuntComa; 

        //Constructor que prepara el camp de la contrassenya i inicia el connectionString.
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

        //Obté la contrassenya del connectionString.
        private string obtenirPass() {

            string[] strPassSeparat = strSeparatPuntComa[1].Split('=');
           
            return strPassSeparat[1];
        }

        //Obté l'usuari del connectionString.
        private string obtenirUsuari()
        {

            string[] strPassSeparat = strSeparatPuntComa[4].Split('=');

            return strPassSeparat[1];
        }

        //Mètode del botó validar al fer click.
        private void btnValidar_Click(object sender, EventArgs e)
        {

            Validar();

        }

        //Mètode que comproba la correctesa de l'usuari i la contrassenya.
        //I executa la barra de progrès que donarà lloc posteriorment al formulari principal.
        private void Validar() {
            if (textBox1.Text.Equals(obtenirUsuari()) && textBox2.Text.Equals(obtenirPass()))
            {
                (new Thread(CloseIt)).Start();
                MessageBox.Show("Validació correcte");
                this.Hide();
                Progres progresForm = new Progres();
                progresForm.Closed += (s, args) => this.Close();
                progresForm.Show();
                progresForm.Loaded();

            }
            else
            {

                MessageBox.Show("Usuari o contrassenya incorrectes.\nSiusplau torna-ho a provar.");

            };
        }

        //Utilitzat per un message box que apareixi nomès uns segons.
        public void CloseIt()
        {
            Thread.Sleep(500);
            Microsoft.VisualBasic.Interaction.AppActivate(
                 System.Diagnostics.Process.GetCurrentProcess().Id);
            System.Windows.Forms.SendKeys.SendWait(" ");
        }

        //Utilitzat per validar en càs que pressionem la tecla enter en qualsevol dels dos textbox.
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
