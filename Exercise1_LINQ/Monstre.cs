using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise1_LINQ
{
    internal class Monstre
    {
        public string name { get; set; }
        public DateTime mutationDate { get; set; }
        public int nbrArms { get; set; }
        public int nbrHeads { get; set; }
        public int nbrLegs { get; set; }

        // Permet d'afficher la classe/struct plus facilement (en un coup, sans besoin de specifier tout les get/set)
        public override string? ToString()
        {
            return $"Nom: {name,-15} MutationDate: {mutationDate,-15} NbrArms: {nbrArms,-4} NbrHeads: {nbrHeads,-4} NbrLegs: {nbrLegs,-4}";
        }
    }
}
