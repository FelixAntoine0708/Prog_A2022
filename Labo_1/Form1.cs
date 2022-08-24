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

        private void recieve(object sender, EventArgs e)
        {

        }

        private void result(object sender, EventArgs e)
        {
            
        }


        private void btnRemoveSpace(object sender, EventArgs e)
        {
            
            string noSpace = textBox1.Text.Replace(" ", "");    // remplace l'espace pour rien donc cela fait l'effet de pu avoir l'espace
            textBox2.Text = "";
            foreach (char c in noSpace)
                textBox2.Text = textBox2.Text + c;  // recopie le textBox1.text dans textBox2.Text  un par un
        }

        private void btnInverseCar(object sender, EventArgs e)
        {
            textBox2.Text = "";
            foreach (char c in textBox1.Text)
                textBox2.Text = c + textBox2.Text;  // recopie le textBox1.text dans textBox2.Text un par un à l'inverse
        }

        private void btnDoubleCar(object sender, EventArgs e)
        {
            textBox2.Text = "";
            foreach (char c in textBox1.Text)
                textBox2.Text = textBox2.Text + c + c;  // recopie le textBox1.text en double dans textBox2.Text
        }
    

        private void btnJumpOneCar(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string jump = "";
            string recieve = textBox1.Text;

            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                textBox2.Text = textBox2.Text + textBox1.Text[i].ToString();
                i++;
                textBox2.Text = textBox2.Text + jump;
            }


           

        }

        private void btnCapMin(object sender, EventArgs e)
        {
            bool minCap = false;
            textBox2.Text = "";

            foreach (char c in textBox1.Text)
            {
                if (minCap == false)
                {
                    textBox2.Text = textBox2.Text + c.ToString().ToUpper();
                    minCap = true;
                }

                else
                {
                    textBox2.Text = textBox2.Text + c.ToString().ToLower();
                    minCap = false;
                }
            }
                
                    
        }

        private void btnOneSpace(object sender, EventArgs e)
        {

        }

        private void btnInverseWord(object sender, EventArgs e)
        {

        }

        private void btnNbWord(object sender, EventArgs e)
        {

        }

        private void btnRotate(object sender, EventArgs e)
        {

        }

        private void btnAscii(object sender, EventArgs e)
        {

        }

        private void btnPASSWD(object sender, EventArgs e)
        {

        }

        private void btnQuit(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
