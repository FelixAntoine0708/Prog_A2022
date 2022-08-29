//Fait par: Félix-Antoine Guimont
//29 aout 2022 - A2022
//
//Ce laboratoire nous fait apprendre comment utiliser les caractères en C#. Dans ce dernier, 
//il faut faire une fenêtre de Windows qui va afficher deux cases de texte. Une des cases 
//peut recevoir du texte et l’autre ne fait que de le montrer à l’utilisateur. Par la suite, 
//il y a 12 boutons qui font différentes choses. Par exemple : Retire espace, Inverse Car qui 
//inverse les caractères comme si nous lisons de droite à gauche, Saute Un Car qui saute un 
//caractère et qui écrit le prochain, Maj et min qui écrit une lettre en Majuscule et l’autre
//en minuscule, un seul espace qui efface les doubles espaces et/ou les espaces au début et la
//fin de la phrase, Inverse mot, compte mot, Rotation qui prend la dernière lettre et la met 
//au début, ASCII qui change tous les caractères en code ASCII respectif, Mot de Passe qui 
//regard si le texte écrit est un bon mot de passe ou non, puis il y a quitté. 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labo_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ce Bouton va effacer tout les espace dans la phrase 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveSpace_Click(object sender, EventArgs e)
        {
            string noSpace = textBox1.Text.Replace(" ", "");    // remplace l'espace pour rien donc cela fait l'effet de pu avoir l'espace
            textBox2.Text = ""; // efface tout ce qu'il y a dans textBox2
            foreach (char c in noSpace)
                textBox2.Text = textBox2.Text + c;  // recopie le textBox1.text dans textBox2.Text  un par un
        }

        /// <summary>
        /// Ce Bouton va inverser tout les lettres de la phrase comme si on lisait de gauche a droite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInverseCar_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            foreach (char c in textBox1.Text)
                textBox2.Text = c + textBox2.Text;  // recopie le textBox1.text dans textBox2.Text un par un à l'inverse
        }

        /// <summary>
        /// Ce bouton double tout les lettres dans la phrase 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDoubleCar_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            foreach (char c in textBox1.Text)
                textBox2.Text = textBox2.Text + c + c;  // recopie le textBox1.text en double dans textBox2.Text
        }

        /// <summary>
        /// Ce bouton va sauter une lettre sur deux 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJumpCar_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string jump = "";

            for (int i = 0; i < textBox1.Text.Length; i++)  // va passer tout les lettre de la case textBox1
            {
                textBox2.Text = textBox2.Text + textBox1.Text[i].ToString();    // écrit dans textBox2 le premier caractère
                i++;    //incrémente pour la prochaine caractère 
                textBox2.Text = textBox2.Text + jump;   //saute le caractère 
            }
        }

        /// <summary>
        /// Ce bouton va mettre une lettre sur deux en Majuscule et l'autre moitier en minuscule 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMajMin_Click(object sender, EventArgs e)
        {
            bool minCap = false;
            textBox2.Text = "";

            foreach (char c in textBox1.Text)   // va s'incrémenter à chaque lettre dans textBox1
            {
                if (minCap == false)    //quand il est rendu a le mettre en Majuscule 
                {
                    textBox2.Text = textBox2.Text + c.ToString().ToUpper(); //met le caractère en majuscule 
                    minCap = true;  // met la variable en true pour dire de mettre la prochaine en minuscule 
                }

                else    //quand il est rendu a le mettre en minuscule
                {
                    textBox2.Text = textBox2.Text + c.ToString().ToLower(); //met le caractère en minuscule
                    minCap = false; // met la variable en false pour dire de mettre la prochaine en majuscule
                }
            }
        }

        /// <summary>
        /// Ce Bouton va effacer tout les espace en surplus et va remettre la phrase avec un espace entre chaque mot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOneSpace_Click(object sender, EventArgs e)
        {
            string oneSpace = textBox1.Text.Replace("  ", " ").Trim();    // remplace la double espaces pour une seul espace 
            textBox2.Text = "";

            foreach (char c in oneSpace)
                textBox2.Text = textBox2.Text + c;  // recopie le textBox1.text dans textBox2.Text  un par un
        }

        /// <summary>
        /// Ce bouton va inverser tout les mots de la phrase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInverseWrd_Click(object sender, EventArgs e)
        {
            char separate = ' ';    // dit qu'est ce qui split les mots
            btnOneSpace.PerformClick(); // enleve les espaces de surplus
            textBox2.Text = ""; // efface tout dans le textBox2
            string[] wrd = textBox1.Text.Split(separate);   //sépare tout les mots et les met dans wrd 

            foreach (string s in wrd)   // s'incrémente pour chaque mot dans wrd
                textBox2.Text = s + " " + textBox2.Text;  // écrit le mot dans textBox2  
        }

        /// <summary>
        /// Ce bouton va compter le nombre de mot dans la phrase 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNbWord_Click(object sender, EventArgs e)                                            
        {
            char separate = ' ';    // dit qu'est ce qui split les mots
            btnOneSpace.PerformClick(); // enleve les espaces de surplus
            string[] wrd = textBox2.Text.Split(separate);   //sépare tout les mots et les met dans wrd
            int i = 0;

            foreach (string s in wrd)   //pour chauqe mot dans la string wrd
            {
                if (string.IsNullOrEmpty(textBox2.Text))    // si la boite est vide 
                    i = 0;  // les mot sont a zéro

                else
                    i++;    // incrémentation des mots

            }

            textBox2.Text = "le nombre de mot: " + i.ToString(); // affiche le nombre de mot qu'il y a 
        }

        /// <summary>
        /// Ce bouton va partir un Timer qui va faire tourner la phrase sur la ligne de Résultat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (btnRotate.Text == "Rotation")
            {
                if(string.IsNullOrEmpty(textBox1.Text)) //si la case textBox1 est vide on ne fait rien 
                    return;

                else
                {
                    btnRotate.Text = "Stop Rotation";   //change text du bouton pour Stop Rotation 
                    textBox2.Text = textBox1.Text;  //met le texte de texBox1 dans TextBox2 
                    timer1.Enabled = true;  //début du Timer 
                }   
            }

            else if(btnRotate.Text == "Stop Rotation")  //si le bouton indique Stop Rotation 
            {
                btnRotate.Text = "Rotation";    //change text du bouton pour Rotation 
                timer1.Enabled=false;   //fin  le Timer
            }
        }

        /// <summary>
        /// Ce bouton va mettre dans la case Résultat tout les caractère en Ascii
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAscii_Click(object sender, EventArgs e)
        {
            btnOneSpace.PerformClick();
            textBox2.Text = ""; // efface tout dans le textBox2

            foreach (char c in textBox1.Text)
                textBox2.Text = textBox2.Text + System.Convert.ToInt32(c);  //system.Convert.ToInt32 va prendre le caractère et le convertie au nombre qui est équivalent en integer de 32 bit 
        }

        /// <summary>
        /// Ce bouton va nous dire si la case Saisie est un bon Mot de passe 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPassWrd_Click(object sender, EventArgs e)
        {
            bool verif = true;
            int  min = 0, cap = 0, number = 0, autre = 0, total=0;
            string[] force = { "faible", "moyen", "fort", "très fort" };


            if(textBox1.Text.Length < 8)    //vérifie si le mdp a plus de 8 caractères
                verif = false;
            else
            {
                foreach (char c in textBox1.Text)   //vérifie tous les caractères du mdp 
                {
                    if (c > 127 || c == ' ')    //vérifie s'il y a une espace 
                        verif = false;

                    else if (c >= 'a' && c <= 'z')  //vérifie s'il y a une lettre minuscule 
                        min = 1;

                    else if (c >= 'A' && c <= 'Z')  //vérifie s'il y a une lettre Majuscule 
                        cap = 1;

                    else if (c >= '0' && c <= '9')  //vérifie s'il y a un chiffre 
                        number = 1;

                    else if (c >= 33 || c <= 47)    //vérifie s'il y a un caractère spécial
                        if (c >= 58 || c <= 96)
                            autre = 1;
                }
            }

            if (verif == true)  //si le mdp est valide 
            {
                total = min + cap + number + autre; //calcul si le pa force du mdp 
                textBox2.Text = force[total-1];     // écrit la force du mdp 
            }

            else //si le mdp a pas respecter une règle il écrit qu'il est invalide
                textBox2.Text = "invalide";
        }

        /// <summary>
        /// Ce bouton nous fait sortir de l'application 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // fati sortir de l'application 
        }

        /// <summary>
        /// Timer qui fait tourner la phrase dans la case de Saisie 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text.Substring(textBox2.Text.Length - 1) + textBox2.Text.Remove(textBox2.Text.Length - 1); //prend et met le dernier caractère en premier et tu supprime lui que tu viens de prendre 
        }
    }
}
