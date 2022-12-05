using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LampeDel_Etu
{
    public partial class Form1 : Form
    {
        const int NB_DEL = 11;
        const int NB_DEMI_HRE = 48;
        const int ERASE = 99;
        TrackBar[] m_LumTrackBar = new TrackBar[NB_DEL];  // Tableau de TrackBar pour les lumières (DEL et Halogènes)
        TextBox[] m_LumTextBox = new TextBox[NB_DEL];     // Tableau de TextBox pour les lumières (DEL et Halogènes)
        List<recette> objRecette = new List<recette>(); //on devra instancier 48 objets recettes. 
        string filePath = string.Empty;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        List<string> m_listVerif = new List<string>();

        public Form1()
        {
            InitializeComponent();
            initTrackAndTextBox();
            initTableau();

            for (int i = 0; i < NB_DEMI_HRE; i++)
            {
                objRecette.Add(new recette(NB_DEL));
            }

            tempsTrackBar.Value = NB_DEMI_HRE - 1;
        }

        #region initialise

        /// <summary>
        /// initie tout les TrackBars et les TextBoxs dans la Form
        /// </summary>
        private void initTrackAndTextBox()
        {
            int i = 0;

            foreach (TrackBar track in lumierePanel.Controls.OfType<TrackBar>())
            {
                i = Convert.ToInt16(track.Tag);
                m_LumTrackBar[i] = track;
            }

            foreach (TextBox t in lumierePanel.Controls.OfType<TextBox>())
            {
                i = Convert.ToInt16(t.Tag);
                m_LumTextBox[i] = t;
            }

            for (i = 0; i < NB_DEL; i++)
                m_LumTextBox[i].Text = "0";
        }

        /// <summary>
        /// intialise le tableau 
        /// </summary>
        private void initTableau()
        {
            for (int i = 0; i < NB_DEMI_HRE; i++)
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                if((i%2)==0)
                {
                    row.Cells[0].Value = i/2 + "H00";
                    for (int j = 1; j < NB_DEL+1; j++)
                    {
                        row.Cells[j].Value = 0;
                    }
                }

                else
                {
                    row.Cells[0].Value = i / 2 + "H30";
                    for (int j = 1; j < NB_DEL+1; j++)
                    {
                        row.Cells[j].Value = 0;
                    }
                }

                dataGridView1.Rows.Add(row);
            }
            
        }

        /// <summary>
        /// initialise le graphique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Add("Recette pour chaque DEL");
            chart1.ChartAreas.Add("recette");
            chart1.ChartAreas["recette"].AxisX.Minimum = 0;
            chart1.ChartAreas["recette"].AxisX.Title = "Point de contrôle aux 30 minutes";
            chart1.ChartAreas["recette"].AxisY.Title = "Intensité des DEL";
            chart1.ChartAreas["recette"].AxisX.Interval = 4;

            for (int i = 0; i < NB_DEL; i++)
            {
                if(i < 10)
                    chart1.Series.Add("Del"+(i+1));
                else
                    chart1.Series.Add("Halo");

                chart1.Series[i].ChartType = SeriesChartType.Line;
            }

            chart1.ChartAreas["recette"].AxisX.Minimum = 0;
            chart1.ChartAreas["recette"].AxisX.Maximum = 48;
            chart1.ChartAreas["recette"].AxisY.Minimum = 0;
            chart1.ChartAreas["recette"].AxisY.Maximum = 100;

            for (int i = 0; i < NB_DEMI_HRE; i++)
                for (int j = 0; j < NB_DEL; j++)
                chart1.Series[j].Points.AddXY(i,objRecette[i].del[j]);

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        /// <summary>
        /// change le texte en dessus pour tout les trackBars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slider_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < NB_DEL; i++)
            {
                m_LumTextBox[i].Text = m_LumTrackBar[i].Value.ToString();
            }
        }

        /// <summary>
        /// bloque les charactères sur dans le textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lumTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != (char)Keys.Back && !char.IsDigit(e.KeyChar);
        }

        /// <summary>
        /// change le text dans les textbox quand il est changer par le slider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lum1TextBox_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < NB_DEL; i++)
            {
                if(m_LumTextBox[i].Text == null)
                    m_LumTextBox[i].Text = "0";

                if (m_LumTextBox[i].Text == "")
                    m_LumTextBox[i].Text = "0";

                else if (Convert.ToInt32(m_LumTextBox[i].Text) >= 100)
                    m_LumTextBox[i].Text = "100";

                m_LumTrackBar[i].Value = Convert.ToInt32(m_LumTextBox[i].Text);
            }
        }

        /// <summary>
        /// augmente de 10 tout les trackBars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addValeurLumiere_Click(object sender, EventArgs e)
        {
            int value = 0;
            for (int i = 0; i < NB_DEL; i++)
            {
                if ((m_LumTrackBar[i].Value + 10) >= 100)
                    m_LumTrackBar[i].Value = 100;

                else if (m_LumTrackBar[i].Value < 100)
                {
                    value = m_LumTrackBar[i].Value + 10;
                }
            }

            for (int i = 0; i < NB_DEL; i++)
            {
                if(m_LumTrackBar[i].Value < 100)
                    m_LumTrackBar[i].Value = m_LumTrackBar[i].Value + 10;
            }
        }

        /// <summary>
        /// descend de 10 tout les trackBars
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sousValeurLumiere_Click(object sender, EventArgs e)
        {
            int value = 0;
            for (int i = 0; i < NB_DEL; i++)
            {
                if (m_LumTrackBar[i].Value != 0)
                {
                    value = m_LumTrackBar[i].Value - 10;
                }
            }

            for (int i = 0; i < NB_DEL; i++)
            {
                if (m_LumTrackBar[i].Value < 10)
                    m_LumTrackBar[i].Value = 0;

                else if(m_LumTrackBar[i].Value != 0)
                    m_LumTrackBar[i].Value = m_LumTrackBar[i].Value - 10;
            }
        }

        /// <summary>
        /// met tout a zéro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void razDelsButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < NB_DEL; i++)
            {
                m_LumTrackBar[i].Value = 0;
                m_LumTextBox[i].Text = "0";
            }
        }

        /// <summary>
        /// modifie les trackBars en dépend du temps
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tempsTrackBar_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < NB_DEL; i++)
            {
                m_LumTrackBar[i].Value = objRecette[tempsTrackBar.Value].del[i];
            }

            if ((tempsTrackBar.Value % 2) == 0)
            {
                tempsConsigneTexteLabel.Text = "Temps de consigne:";
                tempsConsigneTexteLabel.Text = tempsConsigneTexteLabel.Text + tempsTrackBar.Value / 2 + "H00";
            }

            else
            {
                tempsConsigneTexteLabel.Text = "Temps de consigne:";
                tempsConsigneTexteLabel.Text = tempsConsigneTexteLabel.Text + tempsTrackBar.Value / 2 + "H30";
            }
        }

        /// <summary>
        /// quitte l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        /// <summary>
        /// enregistre les trackBars par rapport au temps
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enregistrerButton_Click(object sender, EventArgs e)
        {
            objRecette[tempsTrackBar.Value].del.Clear();
            objRecette[tempsTrackBar.Value].pointEnr = true;
            for (int i = 0; i < NB_DEL; i++)
                objRecette[tempsTrackBar.Value].del.Add(m_LumTrackBar[i].Value);
            tableauChange(tempsTrackBar.Value);
        }

        /// <summary>
        /// lis se qu'il y a dans le fichier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] ligne = new string[NB_DEMI_HRE+2];
            StreamReader sr = null;
            bool verif=false;
            openFileDialog.InitialDirectory = "C:\\Users\\Utilisateur\\Documents\\22A\\Prog\\exemple_lab\\Lab5LampeDEL\\Lab5\\Fichiers tests lab 5";
            openFileDialog.Filter = "Text files (*.csv;*.txt)|*.csv;*.txt";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            string test = "";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileDialog.FileName;
                sr = new StreamReader(filePath);


                tableauChange(ERASE);

                //Read the contents of the file into a stream
                for (int i = 0; i < NB_DEMI_HRE+2; i++)
                {
                    try
                    {
                        test = sr.ReadLine();
                        if(test == null)
                        {
                            throw (new Exception());
                        }
                        ligne = test.Split(';');
                        verif = verifRecieve(ligne, i);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("fichier illisible", "Erreur de lecture");
                    }

                    if(verif)
                    {
                        try
                        {
                            if (ligne[1] == "Del 1")
                            {
                                m_listVerif.Clear();
                            }

                            else if (ligne[1] == "" && i == 1)
                            {
                                m_listVerif.Clear();
                            }

                            else if (ligne[1] == "" && i > 1)
                            {
                                for (int j = 0; j < NB_DEL; j++)
                                    objRecette[i - 2].del[j] = Convert.ToInt32(m_listVerif[j]);

                                objRecette[i - 2].pointEnr = false;
                                tableauChange(i - 2);
                                m_listVerif.Clear();
                            }

                            else
                            {
                                for (int j = 0; j < NB_DEL; j++)
                                    objRecette[i - 2].del[j] = Convert.ToInt32(m_listVerif[j]);

                                objRecette[i - 2].pointEnr = true;
                                tableauChange(i - 2);
                                m_listVerif.Clear();
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("fichier illisible"+ ex, "Erreur de lecture");
                            break;
                        }
                    }

                    else if(!verif)
                    {
                        for (int j = 0; j < NB_DEMI_HRE; j++)
                        {
                            for (int k = 0; k < NB_DEL; k++)
                            {
                                objRecette[j].del[k] = 0;
                            }
                        }
                        tableauChange(ERASE);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// verifie si on lie des bonne intencité
        /// </summary>
        /// <param name="recieve"></param>
        /// <param name="nbLigne"></param>
        /// <returns></returns>
        private bool verifRecieve(string[] recieve, int nbLigne)
        {
            for (int i = 1; i < NB_DEL+1; i++)
            { 
                try
                {
                    if (nbLigne >= 2)
                    {
                        if (recieve[i] == "")
                        {
                            m_listVerif.Add("0");
                        }

                        else if (Convert.ToInt32(recieve[i]) > 100 || Convert.ToInt32(recieve[i]) < 0 || recieve[i].All(char.IsLetter))
                        {
                            throw (new Exception());
                        }

                        else
                        {
                            m_listVerif.Add(recieve[i]);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Valeur invalide" ,"Erreur de lecture");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// modifie le tableau a la guise
        /// </summary>
        /// <param name="nbligne"></param>
        private void tableauChange(int nbligne)
        {
            if (nbligne == 99)
            {
                for (int i = 0; i < NB_DEMI_HRE ; i++)
                {
                    for (int j = 1; j < NB_DEL + 1; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = 0;
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        chartChange();
                    }
                }
            }

            else if (objRecette[nbligne].pointEnr)
            {
                for (int i = 1; i < NB_DEL+1; i++)
                {
                    dataGridView1.Rows[nbligne].Cells[i].Value = objRecette[nbligne].del[i - 1];
                }
                dataGridView1.Rows[nbligne].DefaultCellStyle.BackColor = Color.Orange;
                chartChange();
            }

            else if (!objRecette[nbligne].pointEnr)
            {
                for (int i = 1; i < NB_DEL + 1; i++)
                {
                    dataGridView1.Rows[nbligne].Cells[i].Value = objRecette[nbligne].del[i - 1];
                }
            }
        }

        private void chartChange()
        {
            for (int i = 0; i < NB_DEL; i++)
                chart1.Series[i].Points.Clear();

            for (int i = 0; i < NB_DEMI_HRE; i++)
                for (int j = 0; j < NB_DEL; j++)
                    chart1.Series[j].Points.AddXY(i,objRecette[i].del[j]);                             
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Unchecked)
                {
                    chart1.Series[i].Points.Clear();
                }

                else if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    for (int j = 0; j < NB_DEMI_HRE; j++)
                        for (int k = 0; k < NB_DEL; k++)
                            chart1.Series[k].Points.AddXY(j, objRecette[j].del[k]);
                }
            }
            
        }
    }
}
