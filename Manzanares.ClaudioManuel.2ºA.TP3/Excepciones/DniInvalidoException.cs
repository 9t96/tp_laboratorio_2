using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException:Exception
    {
        private string mesajeBase;

        public DniInvalidoException()
            : base()
        {

        }

        public DniInvalidoException(Exception e)
            : base(null,e)
        {
            
        }

        public DniInvalidoException(string message)
            : base(message,null)
        {

        }

        public DniInvalidoException(string message, Exception e)
            : base(message, e)
        {
            this.mesajeBase = message;
        }
    }
}
