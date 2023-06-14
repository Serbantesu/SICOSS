using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class SuperDigito
    {
        public int IdSuperDigito { get; set; }
        public string Numero { get; set; }
        public int Resultado { get; set; }
        public DateTime FechaHora { get; set; }
        public List<object> SuperDigitos { get; set; }
        public ML.Usuario Usuario { get; set; }

    }
}
