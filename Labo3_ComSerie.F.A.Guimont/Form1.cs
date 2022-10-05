using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Labo3_ComSerie
{
    public partial class Form1 : Form
    {
        private const int NB_CBBOX = 5; // le nombre de combobox
        public delegate void monProtoDelegate(string ligneRecu); //étape #1: définir prototype de fonction... paramètres d'entrée et de retour
        monProtoDelegate objDelegate;  //étape #2: on se déclare un objet delegate. (i.e. un pointeur de fonction ayant ce prototype)



        public Form1()
        {
            InitializeComponent();
            objDelegate = methodeDelegeAffiche; //avoir les threads
            port.Encoding = Encoding.GetEncoding(28591);    //pour avoir les accents

            toolStripStatusLabel1.Text = port.PortName + ':' + port.BaudRate + ',' + port.Parity + ',' + port.DataBits + ',' + port.StopBits;   //affiche les information du port de communication
            toolStripStatusLabel2.Text = "Close";   // quand le port est fermé
            toolStripStatusLabel2.ForeColor = Color.Red;    // met le mot fermer en rouge

            btnTx.Enabled = false;  //désactive le port
        }

        private void btnTx_Click(object sender, EventArgs e)
        {
            try
            {
                port.WriteLine(senderTxt.Text + "\n\r");    // envoie le message et un change de ligne
            }

            catch
            {
                MessageBox.Show(port.PortName.ToString() + " isn't open");  // nous disons que le port n'est pas ouvert
            }
        }

        private void port_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string sRx = port.ReadLine();   //reçoit la ligne qu'on enovie du terminal

            BeginInvoke(objDelegate, sRx);  //ouvre un autre threads pour l'ouvrir
        }

        private void methodeDelegeAffiche(string stLigne)
        {
            textBox2.Text = stLigne; //on affiche la ligne
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            port.Close();   // ferme le port
            affiche_Com();  // rafraichit l'affichage de l'état du port

            frmConfigPort fConfig = new frmConfigPort(port.PortName, port.BaudRate, port.DataBits, port.Parity, (int)port.StopBits);    // crée une variable instancie vers frmConfigPort

            //Ouvre la fenêtre de config et attend que l'usager la ferme par le bouton OK ou Annuler
            if (fConfig.ShowDialog() == DialogResult.OK) //Note: La propriété DialogResult du bouton ok doit être à OK.
            {
                //On récupère les informations de configurations et on les assignent à au port série
                if (!(fConfig.m_nom == null))       // s'il y a un port choisi
                    port.PortName = fConfig.m_nom;  // met le nom du port dans port.PortName

                else    //s'il n'y a pas de port choisi
                    MessageBox.Show("aucun com à été choisi");

                port.BaudRate = fConfig.m_vitesse;  // met la vitesse dans le baudrate 
                port.DataBits = fConfig.m_nbBit;    // met le nombre de bits dans le dataBits 
                port.Parity = fConfig.m_parite; // met la parité dans le parity 
                port.StopBits = (System.IO.Ports.StopBits) fConfig.m_stopBit;   // met le stop bits dans une variable 

                btnOpen.PerformClick(); // fait un similie click sur la methode btnOpen
            }


        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(port.IsOpen) // si le port est ouvert
            {
                port.Close();   // ferme le port
                affiche_Com();  // rafraichie le détail du port
            }

            else if (!(port.IsOpen))    // si le port n'est pas ouvert
            {
                try
                {
                    port.Open();    // ouvre le port
                    affiche_Com();
                }

                catch
                {
                    MessageBox.Show("Ne peux pas ouvrir "+ port.PortName);  // affiche un message si nous pouvons pas ouvrir sur le port
                }
            }
        }
            

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // pour sortir du port 
        }

        private void affiche_Com()
        {
            if(port.IsOpen) // si le port est ouvert
            {
                toolStripStatusLabel1.Text = port.PortName + ':' + port.BaudRate + ',' + port.Parity + ',' + port.DataBits + ',' + port.StopBits;   //affiche les informations importantes du port 
                toolStripStatusLabel2.Text = "Open";    // affiche qu'il est ouvert
                toolStripStatusLabel2.ForeColor = Color.Green;  // met le mot Open en Vert


                btnOpen.Text = "Fermer";    // met le bouton en mode Ouvert
                btnTx.Enabled = true;   // active la permission d'écrire sur un port 

            }

            else    // si le port n'est pas ouvert
            {
                toolStripStatusLabel1.Text = port.PortName + ':' + port.BaudRate + ',' + port.Parity + ',' + port.DataBits + ',' + port.StopBits;
                toolStripStatusLabel2.Text = "Close";   // affiche qu'il est fermer
                toolStripStatusLabel2.ForeColor = Color.Red;    // met le mot close en rouge

                btnOpen.Text = "Ouvrir";    // met le bouton en mode fermer
                btnTx.Enabled = false;  // désactive la permission d'écrire sur un port 
            }
            
        }
    }
}
