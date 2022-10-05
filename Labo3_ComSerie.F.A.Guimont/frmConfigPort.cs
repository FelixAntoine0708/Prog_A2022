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

namespace Labo3_ComSerie
{
    public partial class frmConfigPort : Form
    {
        // variable membres de la classe frmConfigPort
        public string m_nom { get; set; }   
        public int m_vitesse { get; set; }
        public int m_nbBit { get; set; }
        public Parity m_parite { get; set; }
        public int m_stopBit { get; set; }

        public frmConfigPort(string PortName, int BaudRate, int DataBits, Parity parity, int StopBits)
        {
            InitializeComponent();

            comboPort.DataSource = (System.IO.Ports.SerialPort.GetPortNames()); //met tout les port dans les items de la comboBox
            comboPort.SelectedItem = PortName;  // affiche celui qui a été importer
            comboPort.DropDownStyle = ComboBoxStyle.DropDownList;   // met la comboBox en dropDownList

            comboVitesse.DataSource = new int[] { 2400, 4800, 9600, 14400, 19200, 38400, 56000, 57600, 115200, 128000, 256000 };    // met les vitesse dans les items du comboBox
            comboVitesse.SelectedItem = BaudRate;   // affiche celui qui a été importer
            comboVitesse.DropDownStyle = ComboBoxStyle.DropDownList;    // met la comboBox en dropDownList

            comboNbBits.DataSource = new int[] { 7, 8 };    // met les nombres de bits dans les items du comboBox
            comboNbBits.SelectedItem = DataBits;    // affiche celui qui a été importer
            comboNbBits.DropDownStyle = ComboBoxStyle.DropDownList; // met la comboBox en dropDownList

            comboParite.DataSource = Enum.GetValues(typeof(Parity));    // met la parité dans les items du comboBox
            comboParite.SelectedItem = parity;  // affiche celui qui a été importer
            comboParite.DropDownStyle = ComboBoxStyle.DropDownList; // met la comboBox en dropDownList

            comboStpBits.DataSource = new int[] { 1, 2 };   // met le stop bits dans les items du comboBox
            comboStpBits.SelectedItem = StopBits;   // affiche celui qui a été importer
            comboStpBits.DropDownStyle = ComboBoxStyle.DropDownList;    // met la comboBox en dropDownList
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            m_nom = (string) comboPort.SelectedValue;   // envoie la valeur du port dans la vartiable public de la classe
            m_vitesse = (int) comboVitesse.SelectedValue;   // envoie la valeur de la vitesse dans la vartiable public de la classe
            m_nbBit = (int) comboNbBits.SelectedValue;  // envoie la valeur de nombre de bits dans la vartiable public de la classe
            m_parite = (Parity) comboParite.SelectedValue;  // envoie la valeur de la parité dans la vartiable public de la classe
            m_stopBit = (int) comboStpBits.SelectedValue;   // envoie la valeur du stop bits dans la vartiable public de la classe
        }
    }
}
