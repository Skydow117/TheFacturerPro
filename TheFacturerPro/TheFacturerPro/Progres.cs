using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheFacturerPro
{
    //Classe que simula una barra de càrrega.
    //No serveix per res, ja que es de mentira, pero no podem negar que mola.
    public partial class Progres : Form
    {
        //Centra la finestra e l'inicialitza.
        public Progres()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

          
        }
        
        //Simula la càrrega i despres crida al formulari principal.
        public void Loaded() {

            for (int i = 0; i < 100; i++)
            {

                progressBar1.Value = i;
                Thread.Sleep(5);

            }

            Form1 formulari = new Form1();
            formulari.Closed += (s, args) => this.Close();
            formulari.Show();
        }

    }
}
