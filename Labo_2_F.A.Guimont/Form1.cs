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

        public Form1()
        {
            Control ctrlSuivant;
            Control ctrlSuivant2;
            int prixTemp = 0;
            InitializeComponent();

            m_objAffichage = new Lcd4Lignes();
            ctrlSuivant = panel2;
            ctrlSuivant2 = panel1;
            m_Clavier = new Button[NBCOLONNE];
            m_PriceBtn = new Button[NBBTNPRIX];
            m_tabInventaire = new ItemInventaire[NBRANGEE, NBCOLONNE];

            for (int i = 0; i < NBCOLONNE; i++)
            {
                ctrlSuivant = GetNextControl(ctrlSuivant, true);
                m_Clavier[i] = (Button)ctrlSuivant;
            }

            for (int i = 0; i < NBBTNPRIX; i++)
            {
                ctrlSuivant2 = GetNextControl(ctrlSuivant2, true);
                m_PriceBtn[i] = (Button)ctrlSuivant2;
            }

            for (int i = 0; i < NBRANGEE; i++)
                for (int j = 0; j < NBCOLONNE; j++)
                {
                    prixTemp = (prixTemp + i + j + 25) * 5;

                    if (prixTemp >= 300)
                    {
                        prixTemp = (25 + j) * 5;
                        m_tabInventaire[i, j] = new ItemInventaire(prixTemp, 2);
                        prixTemp = 0;
                    }

                    else
                        m_tabInventaire[i, j] = new ItemInventaire(prixTemp, 2);
                }

            m_indexColonne = 255;
            m_indexRangee = 255;
            PriceTextB.Text = m_tabInventaire[0, 0].prix.ToString();
            QuantityTextB.Text = m_tabInventaire[0, 0].quantite.ToString();
            LcdScreen_SelectedIndexChanged();
            setClavierLettre();
        }

        /// <summary>
        /// les boutons du clavier a droite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn9ToF(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            char choice = btn.Text.ToCharArray()[0];

            if (choice >= 65 && choice <= 70)
            {
                m_indexRangee = (int)choice-65;
                setClavierChiffre();
                LcdScreen_SelectedIndexChanged();
            }
            
            else if (choice >= 48 && choice <= 57)
            {
                m_indexColonne = (int)choice-48;
                m_prixCourant = m_tabInventaire[m_indexRangee, m_indexColonne].prix;
                if (m_tabInventaire[m_indexRangee, m_indexColonne].quantite == 0)
                {
                    m_qteZero = true;
                    timer1.Enabled = true;
                }
                barreClavier();
                LcdScreen_SelectedIndexChanged();
            }

            else
            {
            }
        }

        /// <summary>
        /// Va mettre sur le clavier de droite sur 6 boutons des lettre de A à F  et le reste des espaces
        /// </summary>
        public void setClavierLettre()
        {
            int i = 0;
            foreach (Button btn in m_Clavier)
            {
                if (i < 6)
                {
                    btn.ForeColor = Color.Blue;
                    btn.Font = new Font(btn.Font, FontStyle.Bold);
                    btn.Text = ((char)(i + 65)).ToString();
                    i++;
                }

                else
                {
                    btn.Text = " ";
                    i++;
                }

                btn.BackColor = Color.White;
                btn.Enabled = true;
            }
        }

        /// <summary>
        /// Va mettre sur le clavier de droite sur tout les boutons des chiffre de 1 à 10 
        /// </summary>
        public void setClavierChiffre()
        {
            int i = 9;

            foreach (Button btn in m_Clavier)
            {
                btn.Text = i.ToString();
                btn.ForeColor = Color.Blue;
                btn.Font = new Font(btn.Font, FontStyle.Bold);
                i--;
            }
        }

        /// <summary>
        /// va barrer le clavier de droite 
        /// </summary>
        public void barreClavier()
        {

            foreach (Button btn in m_Clavier)
            {
                btn.Enabled = false;
            }
        }

        /// <summary>
        /// va débarrer le clavier de droite
        /// </summary>
        public void debarreClavier()
        {
            foreach (Button btn in m_Clavier)
            {
                btn.BackColor = Color.White;
                btn.Enabled = true;
            }

            foreach (Button btn in m_PriceBtn)
            {
                btn.BackColor = Color.White;
                btn.Enabled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void barreClavierPrix()
        {
            foreach (Button btn in m_PriceBtn)
            {
                btn.Enabled = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void debarreClavierPrix()
        {
            foreach (Button btn in m_PriceBtn)
            {
                btn.Enabled = true;
            }
        }

        /// <summary>
        /// Va prendre le prix du bouton choisi pour le m_credit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrice(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string price = btn.Text.Trim('$').Replace(".", string.Empty);
            int priceInt = Convert.ToInt32(price);

            m_credit = m_credit + priceInt;
            LcdScreen_SelectedIndexChanged();
        }

        /// <summary>
        /// Affiche dans le LCD 
        /// </summary>
        private void LcdScreen_SelectedIndexChanged()
        {
            if (true == m_objAffichage.genererAffichage(m_indexRangee, m_indexColonne, m_credit, m_retourCredit, m_prixCourant, m_distributionActive, m_manqueCredit, m_annulationVente, m_qteZero))
            {
                // on rafraichit l'affichage
                LcdScreen.Items.Clear();
                for (int i = 0; i < 4; i++)
                {
                    LcdScreen.Items.Add(m_objAffichage.lignesAffichage[i]);
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
            m_indexRangee=255;
            m_indexColonne=255;
            m_retourCredit = m_credit;
            m_annulationVente = true;
            timer1.Enabled = true;
            barreClavierPrix();
            barreClavier();
            LcdScreen_SelectedIndexChanged();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnter_Click(object sender, EventArgs e)
        {
            barreClavierPrix();

            if (m_indexColonne != 255)
            {
                if(m_prixCourant > m_credit)
                {
                    m_manqueCredit = true;
                    timer1.Enabled = true;
                }
                    

                else if(m_prixCourant <= m_credit)
                {
                    m_distributionActive = true;
                    m_retourCredit = m_credit - m_prixCourant;
                    timer1.Enabled = true;
                }
            }
            LcdScreen_SelectedIndexChanged();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            if (m_manqueCredit)
            {
                debarreClavierPrix();
                m_manqueCredit = false;
            }


            else if (m_annulationVente)
            {
                m_credit = 0;
                m_annulationVente = false;
                m_prixCourant = 0;
                m_retourCredit = 0;
                m_indexRangee = 255;
                m_indexColonne = 255;
                debarreClavier();
                debarreClavierPrix();
                setClavierLettre();
            }

            else if (m_qteZero)
            {
                m_qteZero = false;
                m_indexRangee = 255;
                m_indexColonne = 255;
                debarreClavier();
                debarreClavierPrix();
                setClavierLettre();
            }

            else if (m_distributionActive == true)
            {
                m_distributionActive = false;
                m_tabInventaire[m_indexRangee, m_indexColonne].diminuerInventaire();
                m_indexRangee = 255;
                m_indexColonne = 255;
                m_prixCourant = 0;
                m_credit = 0;
                m_retourCredit = 0;
                debarreClavier();
                debarreClavierPrix();
                setClavierLettre();
            }

            LcdScreen_SelectedIndexChanged();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyInventory_Click(object sender, EventArgs e)
        {
            int i = rangee.SelectedIndex;
            int j = colonne.SelectedIndex;
            int price = m_tabInventaire[i, j].prix;
            int quantity = m_tabInventaire[i, j].quantite;



            if (m_tabInventaire[i, j].modifierInventaire(Convert.ToInt32(PriceTextB.Text.Any(val => char.IsDigit(val))), Convert.ToInt32(QuantityTextB.Text.Any(val => char.IsDigit(val)))))
                m_tabInventaire[i, j] = new ItemInventaire(Convert.ToInt32(PriceTextB.Text), Convert.ToInt32(QuantityTextB.Text));

            else
                MessageBox.Show("Error: prix ou Quantité invalide !");

            PriceTextB.Text = m_tabInventaire[i, j].prix.ToString();
            QuantityTextB.Text = m_tabInventaire[i, j].quantite.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = rangee.SelectedIndex;
            int j = colonne.SelectedIndex;
            int price = m_tabInventaire[i, j].prix;
            int quantity = m_tabInventaire[i, j].quantite;

            PriceTextB.Text = price.ToString();
            QuantityTextB.Text = quantity.ToString();
        }
    }
}
