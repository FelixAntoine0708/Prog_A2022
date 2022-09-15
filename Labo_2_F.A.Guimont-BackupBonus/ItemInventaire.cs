using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labo_2_F.A.Guimont
{
    class ItemInventaire
    {
        private int m_prix;
        private int m_quantite;
        private string[] nomAliment = { "chips BBQ", "arachides", "Skittle", "Smarties", "Barre Mars", "Brownie", "Ruffles à l'anethe", "Lays au Cornichon", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" };

        //Création des propriétés prix et quantite et des méthodes get permettant de lire les variables privées 
        //m_prix et m_quantite.
        //Aucune méthode set, car on protège nos variables privées. L'usager devra utiliser les méthodes
        //modifierInventaire et diminuerInventaire pour modifier les variables
        public int prix
        {
            get
            {
                return m_prix;
            }
        }

        public int quantite
        {
            get
            {
                return m_quantite;
            }
        }


        /// <summary>
        /// Constructeur. Doit utiliser la méthode modifierInventaire pour assigner les prix et quantite
        /// </summary>
        /// <param name="prixItem"> on reçoit le prix de l'item lors de sa création</param>
        /// <param name="qteItem"> on reçoit la quantité de l'item lors de sa création<</param>
        public ItemInventaire(int prixItem, int qteItem)
        {

            m_prix = prixItem;
            m_quantite = qteItem;

        }



        /// <summary>
        /// Permet de modifier le prix et la quantité d'un item de l'inventaire s'ils sont valides
        /// </summary>
        /// <param name="oPrix">Doit être entre 0.25$ et 3.00$ et un multiple de 5 cents</param>
        /// <param name="oQuantite">Doit être entre 1 et 9 inclusivement</param>
        /// <returns>Vrai si la modification a réussi. Faux si non.</returns>
        public bool modifierInventaire(int oPrix, int oQuantite)
        {
            int quant = 0;
            int price = 0;
            int result = 0;

            if (oQuantite >= 1 && oQuantite <= 9)
            {
                quant = 1;
                if (oPrix >= 25 && oPrix <= 300)
                {
                    if ((oPrix % 5)==0)
                        price = 1;
                }
            }
            result = quant + price;


            if (result == 2)
                return true;
                
            else
                return false;
                
        }

        /// <summary>
        /// Moins un sur la qte si > 0
        /// </summary>
        public void diminuerInventaire()
        {
            if(m_quantite > 0)
                m_quantite--;

            else
                m_quantite = 0;
        }
    }
}
