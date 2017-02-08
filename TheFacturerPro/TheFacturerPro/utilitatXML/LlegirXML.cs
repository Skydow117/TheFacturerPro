using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFacturerPro.utilitatXML
{
    class LlegirXML
    {
        private DataSet dataset;
        private String xmlFileName;

        public LlegirXML(DataSet dataset, String xmlFileName)
        {
            this.dataset = dataset;
            this.xmlFileName = xmlFileName;
        }

        public void llegirFitxer()
        {

        }
    }
}
