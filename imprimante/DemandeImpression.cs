using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imprimante
{
    internal class DemandeImpression
    {

        public string? NomClient { get; set; }
        public string? Document { get; set; }
        public int NombreCopies { get; set; }
        public bool Imprimee { get; set; }

    }
}
