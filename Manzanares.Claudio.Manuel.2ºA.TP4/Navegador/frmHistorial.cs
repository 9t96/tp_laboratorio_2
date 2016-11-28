using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";

        public frmHistorial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga el formularion con las url de la paginas visitadas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
            List<string> historial;

            try
            {
                if (archivos.leer(out historial))
                {
                    foreach (String item in historial)
                    {
                        this.lstHistorial.Items.Add(item);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
