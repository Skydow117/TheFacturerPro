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
    //Classe principal. Amb les taules i els botons dels imports i exports.
    public partial class Principal : Form
    {
        public DataSet datasetImportat;
        public DataSet datasetImportatEditar;

        //Constructor que centra el formulari a la pantalla.
        public Principal()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        //Mètode que guarda els canvis de les taules a la BD.
        private void clientsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try { 
                this.Validate();
                this.clientsBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.pcgroundDataSet);
            }catch(Exception) {
                MessageBox.Show("Quelcom ha sortit malament. Si segueix sense funcionar li preguem tanqui i torni a engegar el programa. Gràcies");
            }

        }

        //Mètode que emplena les taules amb els corresponents datasets quan el formulari es carrega.
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

        //Exporta les taules en format xml alli on li diguis amb el nom que vulguis.
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

        //Importa un fitxer xml i el posa directament a les taules. Sense edició. Després 
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

        //Mostra el formulari d'ajuda.
        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Ajuda ajuda = new Ajuda();
            ajuda.Show();

        }

        //Importa un fitxer xml i el posa a les taules passant abans per un formulari d'edicció.
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

                

                EditorImports formulari = new EditorImports();
                formulari.setDataset(datasetImportatEditar);
                formulari.Show();
            }
        }
   
    }
}
