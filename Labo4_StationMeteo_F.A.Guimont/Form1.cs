using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Labo4_StationMeteo_F.A.Guimont
{
    public partial class Form1 : Form
    {
        public delegate void monProtoDelegate(string ligneRecu); //étape #1: définir prototype de fonction... paramètres d'entrée et de retour
        monProtoDelegate objDelegate;  //étape #2: on se déclare un objet delegate. (i.e. un pointeur de fonction ayant ce prototype)
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        List<byte> m_lstTrameRx;
        const Byte SOH = 0x01;

        public Form1()
        {
            InitializeComponent();
            objDelegate = methodeDelegeAffiche; //avoir les threads
            serialPort.Encoding = Encoding.GetEncoding(28591);    //pour avoir les accents

            affiche_Com();
        }

        private void port_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int count = 13;

            while(serialPort.BytesToRead > 0)
            {
                try
                {

                }
                serialPort.Close();
                for (int i = 0; i < serialPort.BytesToRead; i++)
                    serialPort.Read(m_lstTrameRx, i, count);
            }
        }

        private void methodeDelegeAffiche(string stLigne)
        {

        }

        private void affiche_Com()
        {
            if (serialPort.IsOpen) // si le port est ouvert
            {
                toolStripStatusLabel1.Text = serialPort.PortName + ':' + serialPort.BaudRate + ',' + serialPort.Parity + ',' + serialPort.DataBits + ',' + serialPort.StopBits;   //affiche les informations importantes du port 
                toolStripStatusLabel2.Text = "Open";    // affiche qu'il est ouvert
                toolStripStatusLabel2.ForeColor = Color.Green;  // met le mot Open en Vert
            }

            else    // si le port n'est pas ouvert
            {
                toolStripStatusLabel1.Text = serialPort.PortName + ':' + serialPort.BaudRate + ',' + serialPort.Parity + ',' + serialPort.DataBits + ',' + serialPort.StopBits;
                toolStripStatusLabel2.Text = "Close";   // affiche qu'il est fermer
                toolStripStatusLabel2.ForeColor = Color.Red;    // met le mot close en rouge
            }

        }

        private void portToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serialPort.Close();   // ferme le port
            affiche_Com();  // rafraichit l'affichage de l'état du port

            frmConfigPort fConfig = new frmConfigPort(serialPort.PortName, serialPort.BaudRate, serialPort.DataBits, serialPort.Parity, (int)serialPort.StopBits);    // crée une variable instancie vers frmConfigPort

            if (fConfig.ShowDialog() == DialogResult.OK) //Note: La propriété DialogResult du bouton ok doit être à OK.
            {
                //On récupère les informations de configurations et on les assignent à au port série
                if (!(fConfig.m_nom == null))       // s'il y a un port choisi
                    serialPort.PortName = fConfig.m_nom;  // met le nom du port dans port.PortName

                else    //s'il n'y a pas de port choisi
                    MessageBox.Show("aucun com à été choisi");

                serialPort.BaudRate = fConfig.m_vitesse;  // met la vitesse dans le baudrate 
                serialPort.DataBits = fConfig.m_nbBit;    // met le nombre de bits dans le dataBits 
                serialPort.Parity = fConfig.m_parite; // met la parité dans le parity 
                serialPort.StopBits = (System.IO.Ports.StopBits)fConfig.m_stopBit;   // met le stop bits dans une variable 

                try
                {
                    serialPort.Open();    // ouvre le port
                    affiche_Com();
                }

                catch
                {
                    MessageBox.Show("Ne peux pas ouvrir " + serialPort.PortName);  // affiche un message si nous pouvons pas ouvrir sur le port
                }
            }
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void enregistrerSousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            enregistrerSousToolStripMenuItem.PerformClick();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            portToolStripMenuItem.PerformClick();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
