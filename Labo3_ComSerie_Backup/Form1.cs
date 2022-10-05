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
        private const int NB_CBBOX = 5;
        public delegate void monProtoDelegate(string ligneRecu); //étape #1: définir prototype de fonction... paramètres d'entrée et de retour
        monProtoDelegate objDelegate;  //étape #2: on se déclare un objet delegate. (i.e. un pointeur de fonction ayant ce prototype)

        public Form1()
        {
            InitializeComponent();
            objDelegate = methodeDelegeAffiche;
            port.Encoding = Encoding.GetEncoding(28591);

            comboPort.DataSource = (System.IO.Ports.SerialPort.GetPortNames());
            comboPort.DropDownStyle = ComboBoxStyle.DropDownList;
            comboVitesse.DataSource = new int[] { 2400, 4800, 9600, 14400, 19200, 38400, 56000, 57600, 115200, 128000, 256000 };
            comboVitesse.DropDownStyle = ComboBoxStyle.DropDownList;
            comboParite.DataSource = Enum.GetValues(typeof(Parity));
            comboParite.DropDownStyle = ComboBoxStyle.DropDownList;
            comboNbBits.DataSource = new int[] { 7, 8 };
            comboNbBits.DropDownStyle = ComboBoxStyle.DropDownList;
            comboStpBits.DataSource = new int[] { 1, 2 };
            comboStpBits.DropDownStyle = ComboBoxStyle.DropDownList;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                port.WriteLine(senderTxt.Text + "\n\r");
            }
                
            catch
            {
                MessageBox.Show(comboPort.SelectedItem.ToString() + " isn't open");
            }


        }

        private void btnConfigOpen_Click(object sender, EventArgs e)
        {
            if (port.IsOpen)
                port.Close();

            port.PortName = (comboPort.SelectedItem).ToString();
            port.BaudRate = Convert.ToInt32((comboVitesse.SelectedItem).ToString());
            port.Parity = (Parity)comboParite.SelectedIndex;
            port.DataBits = Convert.ToInt32((comboNbBits.SelectedItem).ToString());
            port.StopBits = (StopBits)comboStpBits.SelectedIndex+1;

            try
            {
                port.Open();
            }

            catch
            {
                MessageBox.Show(comboPort.SelectedItem.ToString() + " is already use choose another port");
            }
            
            btnTx.Enabled = true;

        }

        private void port_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string sRx = port.ReadLine();

            BeginInvoke(objDelegate, sRx);
        }

        private void methodeDelegeAffiche(string stLigne)
        {
            textBox2.Text = stLigne; //on affiche
        }


    }
}
