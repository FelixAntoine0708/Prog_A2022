/*
 * Fait par Félix-Antoine Guimont
 * Date : 15 septembre 2022
 * 
 * brief:
 * Pour ce laboratoire, le but est de faire une machine distributrice. Dans ce code, vous allez retrouver
 * les boutons pour choisir l’article, les boutons pour mettre un prix et l’affichage pour vous montrer ce 
 * que vous avez choisi. Pour les boutons  de choix, nous avons deux claviers en  un. Il y en a un qui 
 * affiche les rangées de A à F et l’autre est celui qui affiche les colonnes de 0 à 9. Ensuite, le clavier
 * des prix a cinq boutons  qui affiche 0.05 dollars, 0.10 dollars, 0.25 dollars, 1.00 dollars, 2.00 dollars.
 * Par la suite, il y a un affichage qui vous montre le prix, l’élément sélectionné, les crédits que vous
 * avez mis et l’état de la machine. Pour finir, il y a un deuxième onglet qui vous permet de changer le 
 * prix et le nombre de l’article dans la case.
 * 
 * 
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labo_2_F.A.Guimont
{
    public partial class Form1 : Form
    {
        /********* constantes ***********/
        public const int NBRANGEE = 6;
        public const int NBCOLONNE = 10;
        public const int NBBTNPRIX = 5;

        /********** variables membres ***********/
        private Lcd4Lignes m_objAffichage;
        private ItemInventaire[,] m_tabInventaire;  //tableau contenant l'inventaire
        private Button[] m_Clavier; //tableau contenant les objets (Button) du clavier
        private Button[] m_PriceBtn;    //tableau contenant les objet (Button) du clavier crédit

        /*** Les variables ci-dessous sont utilisées par m_objAffichage pour générer l'affichage ***/
        private int m_prixCourant;
        private int m_credit;
        private int m_retourCredit;
        private int m_indexRangee;
        private int m_indexColonne;
        private Boolean m_manqueCredit;
        private Boolean m_annulationVente;
        private Boolean m_distributionActive;
        private Boolean m_qteZero;
        private string nomItem_;

        public Form1()
        {
            Control ctrlSuivant;
            Control ctrlSuivant2;
            int prixTemp = 0, food = 0; 
            InitializeComponent();

            m_objAffichage = new Lcd4Lignes(); //met la classe Lcd4Lignes dans la variable m_objAffichage  
            ctrlSuivant = panel2;   //met dans la variable ctrlSuivant1 le panneau du clavier
            ctrlSuivant2 = panel1;  //met dans la variable ctrlSuivant2 le panneau de bouton des prix
            m_Clavier = new Button[NBCOLONNE];  //met les boutons dans la variable m_Clavier
            m_PriceBtn = new Button[NBBTNPRIX];  //met les boutons dans la variable m_PriceBtn
            m_tabInventaire = new ItemInventaire[NBRANGEE, NBCOLONNE];  //met la classe ItemInventaire dans la variable m_tabInventaire

            for (int i = 0; i < NBCOLONNE; i++) //met les texte dans les bouton du panel du clavier
            {
                ctrlSuivant = GetNextControl(ctrlSuivant, true);
                m_Clavier[i] = (Button)ctrlSuivant;
            }

            for (int i = 0; i < NBBTNPRIX; i++) //met les texte dans les bouton du panel des prix
            {
                ctrlSuivant2 = GetNextControl(ctrlSuivant2, true);
                m_PriceBtn[i] = (Button)ctrlSuivant2;
            }

            for (int i = 0; i < NBRANGEE; i++)  // boucle qui va incrémenter les rangées de la machine distributrice
                for (int j = 0; j < NBCOLONNE; j++)     // boucle qui va incrémenter les colonnes de la machine distributrice
                {
                    prixTemp = (prixTemp + i + j + 25) * 5;

                    if (food == 19) // BONUS: si la variable se rend au maximum du tableau dans ItemInventaire
                        food = 0;   //remet a zéro

                    if (prixTemp >= 300)    // si le prix dépasse 3$
                    {
                        prixTemp = (25 + j) * 5;    //formule pour entrer le prix 
                        m_tabInventaire[i, j] = new ItemInventaire(prixTemp, 2, food);  //met le prix, la quantité et le nom de la friandise dans la machine
                        food++; //incrément le nom de la nourriture 
                        prixTemp = 0;   //remet le prix a zéro
                    }

                    else    //si le prix ne dépasse pas 3$
                    {
                        m_tabInventaire[i, j] = new ItemInventaire(prixTemp, 2, food);  //met le prix, la quantité et le nom de la friandise dans la machine
                        food++; //incrémente le nom de la nourriture
                    }
                        
                }

            m_indexColonne = 255;   // met le maximum pour que la page affiche la page du début
            m_indexRangee = 255;    // met le maximum pour que la page affiche la page du début
            rangee.Text = "A";  // met le texte pour qu'il affiche dans la case de l'inventaire au début
            colonne.Text = "0"; // met le texte pour qu'il affiche dans la case de l'inventaire au début
            PriceTextB.Text = m_tabInventaire[0, 0].prix.ToString();    //met le prix du première article dans sa case au début
            QuantityTextB.Text = m_tabInventaire[0, 0].quantite.ToString(); //met la quantité du première article dans sa case au début
            LcdScreen_SelectedIndexChanged();   // affiche dans le listBox 
            setClavierLettre(); //met le clavier en mode Lettre
        }

        /// <summary>
        /// les boutons du clavier a droite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn9ToF(object sender, EventArgs e)
        {
            Button btn = (Button)sender;    // prend les caractéristique du bouton pour le mettre dans la variable bouton que nous avons fait
            char choice = btn.Text.ToCharArray()[0];   // prend le le texte du bouton appuyer et le met dans une variable char  

            if (choice >= 65 && choice <= 70)   // si le choix est entre A et F 
            {
                m_indexRangee = (int)choice-65; // met dans index de rangée le choix
                setClavierChiffre();    // met le clavier en mode chiffre
                LcdScreen_SelectedIndexChanged();   // affiche la modification dans la listBox
            }
            
            else if (choice >= 48 && choice <= 57)  // si le choix est entre 0 et 9 
            {
                m_indexColonne = (int)choice-48;   // met dans index de colonne le choix 
                nomItem_ = m_tabInventaire[m_indexRangee, m_indexColonne].getNomAliment();  //BONUS : prend le nom de l'item choisie
                m_prixCourant = m_tabInventaire[m_indexRangee, m_indexColonne].prix;    // met dans la variable le prix de l'article
                if (m_tabInventaire[m_indexRangee, m_indexColonne].quantite == 0)   // s'il en reste plus dans la case
                {
                    m_qteZero = true;   // variable de l'affichage quantité zéro
                    timer1.Enabled = true;  // part un timer de 1 secondes
                }
                barreClavier(); //barre le clavier pour pas que le 
                LcdScreen_SelectedIndexChanged();    
            }
        }

        /// <summary>
        /// Va mettre sur le clavier de droite sur 6 boutons des lettre de A à F  et le reste des espaces
        /// </summary>
        public void setClavierLettre()
        {
            int i = 0;
            foreach (Button btn in m_Clavier)   // va incrémenter pour chaque bouton du clavier 
            {
                if (i < 6)  // s'il est plus petit que 6
                {
                    btn.ForeColor = Color.Blue; // met le texte en couleur Bleu
                    btn.Font = new Font(btn.Font, FontStyle.Bold);  // met le texte en gras
                    btn.Text = ((char)(i + 65)).ToString(); //met les lettres dans le bouton
                    i++;    // incrémente pour le prochain bouton
                }

                else // plus grand que 6
                {
                    btn.Text = " "; //met un espace dans le bouton
                    i++;    // incrémente pour le prochain bouton
                }

                btn.BackColor = Color.White;    // met le fond en couleur blanche
                btn.Enabled = true; // met le bouton fonctionnel
            }
        }

        /// <summary>
        /// Va mettre sur le clavier de droite sur tout les boutons des chiffre de 1 à 10 
        /// </summary>
        public void setClavierChiffre()
        {
            int i = 9;

            foreach (Button btn in m_Clavier) // pour chaque bouton dans le clavier
            {
                btn.Text = i.ToString();    // incrit le numéro dans le bouton
                btn.ForeColor = Color.Blue; // met la couleur des chiffres en bleu 
                btn.Font = new Font(btn.Font, FontStyle.Bold);  // met les chiffres en gras
                i--;    // décrement le bouton
            }
        }

        /// <summary>
        /// va barrer le clavier de droite 
        /// </summary>
        public void barreClavier()
        {
            foreach (Button btn in m_Clavier)   // pour chaque bouton dans le clavier 
            {
                btn.Enabled = false;    // bouton non fonctionnel
            }
        }

        /// <summary>
        /// va débarrer le clavier de droite
        /// </summary>
        public void debarreClavier()
        {
            foreach (Button btn in m_Clavier)   // pour chaque bouton dans le clavier 
            {
                btn.BackColor = Color.White;    // met la couleur de fond en blanc
                btn.Enabled = true; // rend le bouton fonctionnel
            }

            foreach (Button btn in m_PriceBtn)  // pour chaque bouton dans le crédit 
            {
                btn.BackColor = Color.White;   
                btn.Enabled = true;
            }
        }

        /// <summary>
        /// Barre le clavier de crédit
        /// </summary>
        public void barreClavierPrix()
        {
            foreach (Button btn in m_PriceBtn)  // pour chaque bouton dans crédit
            {
                btn.BackColor = Color.White;    // met la couleur de fond en blanc
                btn.Enabled = false;    // rend le bouton non fonctionnel
            }
        }

        /// <summary>
        /// Débarre le clavier de crédit
        /// </summary>
        public void debarreClavierPrix()
        {
            foreach (Button btn in m_PriceBtn)  // pour chaque bouton dans crédit
            {
                btn.Enabled = true; // rend le bouton fonctionnel
            }
        }

        /// <summary>
        /// Va prendre le prix du bouton choisi pour le m_credit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrice(object sender, EventArgs e)
        {
            Button btn = (Button)sender;    // prend les caractéristique du bouton pour le mettre dans la variable bouton que nous avons fait
            string price = btn.Text.Trim('$').Replace(".", string.Empty);   //enlève le "." et le "$" dans la string bouton appuyer 
            int priceInt = Convert.ToInt32(price);  // met le prix en int

            m_credit = m_credit + priceInt; // calcul pour accumulé le prix
            LcdScreen_SelectedIndexChanged();   // affiche le changement
        }

        /// <summary>
        /// Affiche dans le LCD 
        /// </summary>
        private void LcdScreen_SelectedIndexChanged()
        {
            if (true == m_objAffichage.genererAffichage(m_indexRangee, m_indexColonne, m_credit, m_retourCredit, m_prixCourant, m_distributionActive, m_manqueCredit, m_annulationVente, m_qteZero, nomItem_))
            {
                // on rafraichit l'affichage
                LcdScreen.Items.Clear();
                for (int i = 0; i < 4; i++)
                {
                    LcdScreen.Items.Add(m_objAffichage.lignesAffichage[i]); // affiche dans le listBox
                }
            }
        }

        /// <summary>
        /// Va redonner l'argent et retourne au début
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnClear_Click(object sender, EventArgs e)
        {
            m_indexRangee=255;  // remet la rangée au début
            m_indexColonne=255; // remet la colonne au début
            m_retourCredit = m_credit;  // le crédit que l'utilisateur a mis
            m_annulationVente = true;   // affiche l'anulation de l'achat
            timer1.Enabled = true;  // débute le timer de 1 secondes
            barreClavierPrix(); // barre le clavier des crédit
            barreClavier(); //barre le clavier
            LcdScreen_SelectedIndexChanged();   // affiche les modification
        }

        /// <summary>
        /// quand nous appuyons sur le bouton Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnter_Click(object sender, EventArgs e)
        {
            barreClavierPrix(); // barre le clavier des crédit

            if (m_indexColonne != 255)  //si la colonne vaut 255
            {
                if(m_prixCourant > m_credit)    //si le crédit est plus bas que le prix
                {
                    m_manqueCredit = true;  // affiche maque de crédit
                    timer1.Enabled = true;  // début du timer de 1 secondes
                }
                    

                else if(m_prixCourant <= m_credit)  //si le crédit est plus haut ou égale que le prix
                {
                    m_distributionActive = true;    // affiche la distribution fait 
                    m_retourCredit = m_credit - m_prixCourant;  // calcul de crédit de retour
                    timer1.Enabled = true;  
                }
            }
            LcdScreen_SelectedIndexChanged();   // affiche la modification
        }

        /// <summary>
        /// le timer de 1 secondes dépendant de ce que l'utilisateur a fait
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false; // ferme le timer

            if (m_manqueCredit) //s'il manque de cédit
            {
                debarreClavierPrix();   // débarre le clavier de prix
                m_manqueCredit = false; //met a faux le manque de crédit
            }


            else if (m_annulationVente) //si annulation de la vente
            {
                m_credit = 0;   //crédit a zéro
                m_annulationVente = false;  //met a faux l'annulation
                m_prixCourant = 0;  //prix a zéro
                m_retourCredit = 0; //retour de crédit a zéro
                m_indexRangee = 255;    // rangée au début
                m_indexColonne = 255;   // colonne au début
                debarreClavier();   // débarre le clavier
                debarreClavierPrix();
                setClavierLettre(); // met le clavier au lettre
            }

            else if (m_qteZero) //si la quantité a zéro
            {
                m_qteZero = false;  //met a faux la quantité zéro
                m_indexRangee = 255;
                m_indexColonne = 255;
                debarreClavier();
                debarreClavierPrix();
                setClavierLettre();
            }

            else if (m_distributionActive == true)
            {
                m_distributionActive = false;   //met a faux la distribution
                m_tabInventaire[m_indexRangee, m_indexColonne].diminuerInventaire();    // diminue l'inventaire de 1 
                PriceTextB.Text = m_tabInventaire[m_indexRangee, m_indexColonne].prix.ToString(); // dans l'onglet inventaire affiche le prix
                QuantityTextB.Text = m_tabInventaire[m_indexRangee, m_indexColonne].quantite.ToString();    // dans l'onglet inventaire affiche la quantité
                m_indexRangee = 255;
                m_indexColonne = 255;
                m_prixCourant = 0;
                m_credit = 0;
                m_retourCredit = 0;
                debarreClavier();
                debarreClavierPrix();
                setClavierLettre();
            }

            LcdScreen_SelectedIndexChanged();   // affiche les modifications
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyInventory_Click(object sender, EventArgs e)
        {
            int i = rangee.SelectedIndex;   //rangée selectionner dans l'onglet inventaire
            int j = rangee.SelectedIndex;   //colonne selectionner dans l'onglet inventaire
            int price = m_tabInventaire[i, j].prix; // prix de l'article choisi
            int quantity = m_tabInventaire[i, j].quantite;  // quantité de l'article choisi
            int priceText = Convert.ToInt32(PriceTextB.Text.Trim('$').Replace(".", string.Empty));  //enlève le "." et le "$" dans la string bouton appuyer
            int quantityText = Convert.ToInt32(QuantityTextB.Text); // converti la quantité en int 



            if (m_tabInventaire[i, j].modifierInventaire(priceText, quantityText))  // si la modification de l'inventaire est bien fait
                m_tabInventaire[i, j] = new ItemInventaire(Convert.ToInt32(PriceTextB.Text.Trim('$').Replace(".", string.Empty)), Convert.ToInt32(QuantityTextB.Text),1);   //modifie l'inventaire

            else
                MessageBox.Show("Error: prix ou Quantité invalide !");  //pop-up affiche le message

            PriceTextB.Text = m_tabInventaire[i, j].prix.ToString();    //affiche le nouveau prix
            QuantityTextB.Text = m_tabInventaire[i, j].quantite.ToString(); // affiche la nouvelle quantité
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = rangee.SelectedIndex;   //rangée selectionner dans l'onglet inventaire
            int j = rangee.SelectedIndex;   //colonne selectionner dans l'onglet inventaire
            int price = m_tabInventaire[i, j].prix; // prix de l'article choisi
            int quantity = m_tabInventaire[i, j].quantite;  // quantité de l'article choisi

            PriceTextB.Text = price.ToString(); //affiche le nouveau prix
            QuantityTextB.Text = quantity.ToString();// affiche la nouvelle quantité
        }
    }
}
