using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheFacturerPro.utilitatXML;

namespace TheFacturerPro
{
    public partial class Form1 : Form
    {
        public DataSet datasetImportat;
        public DataSet datasetImportatEditar;
        public Form1()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            //hola
        }

        private void clientsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.clientsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pcgroundDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;
            this.productesTableAdapter.Fill(this.pcgroundDataSet.productes);
            this.factura_detallTableAdapter.Fill(this.pcgroundDataSet.factura_detall);
            this.facturaTableAdapter.Fill(this.pcgroundDataSet.factura);
            this.factura_detallTableAdapter.Fill(this.pcgroundDataSet.factura_detall);
            this.facturaTableAdapter.Fill(this.pcgroundDataSet.factura);
            this.clientsTableAdapter.Fill(this.pcgroundDataSet.clients);

        }

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

        private void bExportar_Click(object sender, EventArgs e)
        {
           
            DataSet dataSet = this.pcgroundDataSet;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "XML Files (*.xml)|*.xml";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)

            {

                string fullPath = Path.GetFullPath(saveFileDialog1.FileName);
                Console.WriteLine(fullPath);
                EscriureXML escriptor = new EscriureXML(dataSet, fullPath);
                escriptor.exportarFitxer();
            }
        }

        private void bImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "XML Files (*.xml)|*.xml";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)

            {
                DialogResult dialogResult = MessageBox.Show("Si acceptes borraràs les dades actuals que conté la base de dades i afegiràs les noves. En càs contrari, simplement s'afegiràn aquelles entrades que no hi siguin ja.", "Borrar les dades actuals?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Console.WriteLine("Yes");

                    string sFileName = choofdlog.FileName;
                    DataSet dataSet = this.pcgroundDataSet;
                    LlegirXML lector = new LlegirXML(dataSet, sFileName);
                    lector.llegirFitxer(true);
                    Actualitzador updater = new Actualitzador();
                    datasetImportat = updater.UpdateBindingNavigator();
                    clientsDataGridView.DataSource = datasetImportat.Tables[0];
                    productesDataGridView.DataSource = datasetImportat.Tables[1];
                    facturaDataGridView.DataSource = datasetImportat.Tables[2];
                    factura_detallDataGridView.DataSource = datasetImportat.Tables[3];

                }
                else if (dialogResult == DialogResult.No)
                {
                    Console.WriteLine("No");

                    string sFileName = choofdlog.FileName;
                    DataSet dataSet = this.pcgroundDataSet;
                    LlegirXML lector = new LlegirXML(dataSet, sFileName);
                    lector.llegirFitxer(false);
                    Actualitzador updater = new Actualitzador();
                    datasetImportat = updater.UpdateBindingNavigator();
                    clientsDataGridView.DataSource = datasetImportat.Tables[0];
                    productesDataGridView.DataSource = datasetImportat.Tables[1];
                    facturaDataGridView.DataSource = datasetImportat.Tables[2];
                    factura_detallDataGridView.DataSource = datasetImportat.Tables[3];

                }
               
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Ajuda ajuda = new TheFacturerPro.Ajuda();
            //ajuda.Show();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            //Form2 form2 = new Form2();
            //form2.Show();
            Ajuda ajuda = new Ajuda();
            ajuda.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog choof2dlog = new OpenFileDialog();
            choof2dlog.Filter = "XML Files (*.xml)|*.xml";
            choof2dlog.FilterIndex = 1;
            choof2dlog.Multiselect = true;

            if (choof2dlog.ShowDialog() == DialogResult.OK)
            {
                string sFileNamed = choof2dlog.FileName;
                LlegirXML lector2 = new LlegirXML(datasetImportatEditar, sFileNamed);
                datasetImportatEditar = lector2.ReadXmlIntoDataSet();

                Form2 form2 = new Form2();
                form2.setDataset(datasetImportatEditar);
                form2.Show();
                /*Actualitzador updater = new Actualitzador();
                datasetImportat = updater.UpdateBindingNavigator();*/
                /* clientsDataGridView.DataSource = datasetImportat.Tables[0];
                 productesDataGridView.DataSource = datasetImportat.Tables[1];
                 facturaDataGridView.DataSource = datasetImportat.Tables[2];
                 factura_detallDataGridView.DataSource = datasetImportat.Tables[3];*/
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
