using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cfcal.Generique.Metier.Attributes
{
    public class EnumLibelleAttribute : Attribute
    {
        public string Libelle { get; set; }

        public EnumLibelleAttribute(string pstrLibelle)
        {
            Libelle = pstrLibelle;
        }

    }
}
