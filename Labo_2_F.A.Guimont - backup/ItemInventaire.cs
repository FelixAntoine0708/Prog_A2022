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
        private string[] nomAliment = {"Chip BBQ" ,"arachides" ,"Hersey's" ,"M&M" ,"Mars" ,"Fritos" ,"Cheez-it" ,"Pepsi" ,"Jus de Pomme" ,"Jus d'orange" ,"Sprite" ,"Dr. Pepper" ,"Bubble Gum" ,"Welch's" ,"Coca-Cola" ,"eau" ,"Pringles" ,"Jolly Rancher" ,"Nounours en Jujube" ,"Brownie" };
        private int m_indexFood;

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
        public ItemInventaire(int prixItem, int qteItem, int nameFood)
        {

            m_prix = prixItem;
            m_quantite = qteItem;
            m_indexFood = nameFood;
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

            if (oQuantite >= 1 && oQuantite <= 9)   //si la quantité est entre 1 et 9 
            {
                quant = 1;  // met l'affirmation que la quantité est bon
                if (oPrix >= 25 && oPrix <= 300)    //si le prix est entre 0.25$ et 3$
                {
                    if ((oPrix % 5)==0) //si le prix est un multiple de 5
                        price = 1;  // met l'affirmation que le prix est bon
                }
            }
            result = quant + price; //regarde les deux affirmation


            if (result == 2)    //si les deux affirmation son bonne
                return true;    //retourne vrai
                
            else
                return false;   //retourne faux

        }

        /// <summary>
        /// Moins un sur la qte si > 0
        /// </summary>
        public void diminuerInventaire()
        {
            if(m_quantite > 0)  //si la quantité est plus grand que zéro
                m_quantite--;   //diminue la quantité

            else
                m_quantite = 0; // la quantité est a zéro
        }

        /// <summary>
        /// BONUS: retourne le nom de l'aliment
        /// </summary>
        /// <returns></returns>
        public string getNomAliment()
        {
            return nomAliment[m_indexFood];     //retourne le nom de l'aliment
        }
    }
}
