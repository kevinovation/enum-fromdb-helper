using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    /// <summary>
    /// Custom attribute to regsiter enum libelle
    /// </summary>
    public class EnumLibelleAttribute : Attribute
    {
        /// <summary>
        /// To register the enum's libelle
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Constructor with the libelle
        /// </summary>
        public EnumLibelleAttribute(string pstrLibelle)
        {
            Libelle = pstrLibelle;
        }

    }
}
