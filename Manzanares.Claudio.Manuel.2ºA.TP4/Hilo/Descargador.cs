using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        public Descargador(Uri direccion)
        {
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public delegate void FinDescargaEventHandler(string html);
        public event FinDescargaEventHandler DescargaFinalizada;

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (ProgresoDescarga != null)
                ProgresoDescarga(e.ProgressPercentage);
        }

        public delegate void ProgresoDescargaEventHandler(int progreso);
        public event ProgresoDescargaEventHandler ProgresoDescarga;

        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {

                this.html = e.Result;
            }
            catch (Exception ex)
            {

                this.html = ex.InnerException.Message;
            }
            finally
            {

                this.DescargaFinalizada(this.html);
            }
        }
    }
}
