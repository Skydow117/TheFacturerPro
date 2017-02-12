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
    public partial class Progres : Form
    {
        public Progres()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

            /*for (int i = 0; i < 100; i++)
            {

                progressBar1.Value = i;
                Thread.Sleep(2000);

            }*/
            
        }

        public void Loaded() {

            for (int i = 0; i < 100; i++)
            {

                progressBar1.Value = i;
                Thread.Sleep(5);

            }

            this.Close();
        }

    }
}
