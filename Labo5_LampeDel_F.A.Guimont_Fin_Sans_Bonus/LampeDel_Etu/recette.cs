using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LampeDel_Etu
{
    internal class recette
    {
        public List<int> del { get; set; } //listes d'intensités des DEL
        public bool pointEnr { get; set; } //on veut savoir si cette recette a été enregistrée pour l'usager

        /// <summary>
        /// Constructeur. Construit la liste des DEL. Met à 0 l'intensité de chaque DEL.
        /// Met à false pointEnr 
        /// </summary>
        /// <param name="nb"> nombre de del pour cette recette</param>
        public recette(int nb)
        {
            del = new List<int>();

            for (int i = 0; i < nb; i++)
                del.Add(0);

            pointEnr = false;
        }
    }
}
