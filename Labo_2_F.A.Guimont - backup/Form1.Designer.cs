namespace Labo_2_F.A.Guimont
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Achat = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn2Dollar = new System.Windows.Forms.Button();
            this.btn1Dollar = new System.Windows.Forms.Button();
            this.btn25Cent = new System.Windows.Forms.Button();
            this.btn10Cent = new System.Windows.Forms.Button();
            this.btn5Cent = new System.Windows.Forms.Button();
            this.LcdScreen = new System.Windows.Forms.ListBox();
            this.Inventaire = new System.Windows.Forms.TabPage();
            this.QuantityTextB = new System.Windows.Forms.TextBox();
            this.PriceTextB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnModifyInventory = new System.Windows.Forms.Button();
            this.colonne = new System.Windows.Forms.ComboBox();
            this.rangee = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.Achat.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Inventaire.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Achat);
            this.tabControl1.Controls.Add(this.Inventaire);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(798, 449);
            this.tabControl1.TabIndex = 0;
            // 
            // Achat
            // 
            this.Achat.BackColor = System.Drawing.Color.Gray;
            this.Achat.Controls.Add(this.panel2);
            this.Achat.Controls.Add(this.panel1);
            this.Achat.Controls.Add(this.LcdScreen);
            this.Achat.Location = new System.Drawing.Point(4, 22);
            this.Achat.Name = "Achat";
            this.Achat.Padding = new System.Windows.Forms.Padding(3);
            this.Achat.Size = new System.Drawing.Size(790, 423);
            this.Achat.TabIndex = 0;
            this.Achat.Text = "Achat";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnEnter);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(258, 159);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(242, 241);
            this.panel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 31);
            this.label2.TabIndex = 12;
            this.label2.Text = "CLAVIER:";
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(164, 203);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 11;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(3, 203);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(83, 203);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 9;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.btn9ToF);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(164, 164);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 8;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.btn9ToF);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(84, 164);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 7;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.btn9ToF);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(3, 164);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 6;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.btn9ToF);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(164, 124);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 5;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btn9ToF);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(83, 124);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btn9ToF);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(3, 124);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btn9ToF);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(164, 85);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btn9ToF);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(83, 85);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn9ToF);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn9ToF);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn2Dollar);
            this.panel1.Controls.Add(this.btn1Dollar);
            this.panel1.Controls.Add(this.btn25Cent);
            this.panel1.Controls.Add(this.btn10Cent);
            this.panel1.Controls.Add(this.btn5Cent);
            this.panel1.Location = new System.Drawing.Point(8, 159);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 175);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "CRÉDIT ($)";
            // 
            // btn2Dollar
            // 
            this.btn2Dollar.Location = new System.Drawing.Point(84, 111);
            this.btn2Dollar.Name = "btn2Dollar";
            this.btn2Dollar.Size = new System.Drawing.Size(75, 23);
            this.btn2Dollar.TabIndex = 4;
            this.btn2Dollar.Text = "2.00$";
            this.btn2Dollar.UseVisualStyleBackColor = true;
            this.btn2Dollar.Click += new System.EventHandler(this.btnPrice);
            // 
            // btn1Dollar
            // 
            this.btn1Dollar.Location = new System.Drawing.Point(3, 111);
            this.btn1Dollar.Name = "btn1Dollar";
            this.btn1Dollar.Size = new System.Drawing.Size(75, 23);
            this.btn1Dollar.TabIndex = 3;
            this.btn1Dollar.Text = "1.00$";
            this.btn1Dollar.UseVisualStyleBackColor = true;
            this.btn1Dollar.Click += new System.EventHandler(this.btnPrice);
            // 
            // btn25Cent
            // 
            this.btn25Cent.Location = new System.Drawing.Point(165, 66);
            this.btn25Cent.Name = "btn25Cent";
            this.btn25Cent.Size = new System.Drawing.Size(75, 23);
            this.btn25Cent.TabIndex = 2;
            this.btn25Cent.Text = "0.25$";
            this.btn25Cent.UseVisualStyleBackColor = true;
            this.btn25Cent.Click += new System.EventHandler(this.btnPrice);
            // 
            // btn10Cent
            // 
            this.btn10Cent.Location = new System.Drawing.Point(84, 66);
            this.btn10Cent.Name = "btn10Cent";
            this.btn10Cent.Size = new System.Drawing.Size(75, 23);
            this.btn10Cent.TabIndex = 1;
            this.btn10Cent.Text = "0.10$";
            this.btn10Cent.UseVisualStyleBackColor = true;
            this.btn10Cent.Click += new System.EventHandler(this.btnPrice);
            // 
            // btn5Cent
            // 
            this.btn5Cent.Location = new System.Drawing.Point(3, 66);
            this.btn5Cent.Name = "btn5Cent";
            this.btn5Cent.Size = new System.Drawing.Size(75, 23);
            this.btn5Cent.TabIndex = 0;
            this.btn5Cent.Text = "0.05$";
            this.btn5Cent.UseVisualStyleBackColor = true;
            this.btn5Cent.Click += new System.EventHandler(this.btnPrice);
            // 
            // LcdScreen
            // 
            this.LcdScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LcdScreen.FormattingEnabled = true;
            this.LcdScreen.ItemHeight = 20;
            this.LcdScreen.Location = new System.Drawing.Point(8, 6);
            this.LcdScreen.Name = "LcdScreen";
            this.LcdScreen.Size = new System.Drawing.Size(492, 84);
            this.LcdScreen.TabIndex = 1;
            // 
            // Inventaire
            // 
            this.Inventaire.BackColor = System.Drawing.Color.Silver;
            this.Inventaire.Controls.Add(this.QuantityTextB);
            this.Inventaire.Controls.Add(this.PriceTextB);
            this.Inventaire.Controls.Add(this.label6);
            this.Inventaire.Controls.Add(this.label5);
            this.Inventaire.Controls.Add(this.label4);
            this.Inventaire.Controls.Add(this.label3);
            this.Inventaire.Controls.Add(this.btnModifyInventory);
            this.Inventaire.Controls.Add(this.colonne);
            this.Inventaire.Controls.Add(this.rangee);
            this.Inventaire.Location = new System.Drawing.Point(4, 22);
            this.Inventaire.Name = "Inventaire";
            this.Inventaire.Padding = new System.Windows.Forms.Padding(3);
            this.Inventaire.Size = new System.Drawing.Size(790, 423);
            this.Inventaire.TabIndex = 1;
            this.Inventaire.Text = "Inventaire";
            // 
            // QuantityTextB
            // 
            this.QuantityTextB.Location = new System.Drawing.Point(366, 93);
            this.QuantityTextB.Name = "QuantityTextB";
            this.QuantityTextB.Size = new System.Drawing.Size(134, 20);
            this.QuantityTextB.TabIndex = 10;
            // 
            // PriceTextB
            // 
            this.PriceTextB.Location = new System.Drawing.Point(366, 55);
            this.PriceTextB.Name = "PriceTextB";
            this.PriceTextB.Size = new System.Drawing.Size(134, 20);
            this.PriceTextB.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(256, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Quantité";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(276, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Prix";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Colonne";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Rangée";
            // 
            // btnModifyInventory
            // 
            this.btnModifyInventory.BackColor = System.Drawing.Color.Gainsboro;
            this.btnModifyInventory.Location = new System.Drawing.Point(259, 136);
            this.btnModifyInventory.Name = "btnModifyInventory";
            this.btnModifyInventory.Size = new System.Drawing.Size(179, 29);
            this.btnModifyInventory.TabIndex = 4;
            this.btnModifyInventory.Text = "Modifier Inventaire";
            this.btnModifyInventory.UseVisualStyleBackColor = false;
            this.btnModifyInventory.Click += new System.EventHandler(this.btnModifyInventory_Click);
            // 
            // colonne
            // 
            this.colonne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.colonne.FormattingEnabled = true;
            this.colonne.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.colonne.Location = new System.Drawing.Point(78, 92);
            this.colonne.Name = "colonne";
            this.colonne.Size = new System.Drawing.Size(121, 21);
            this.colonne.TabIndex = 3;
            this.colonne.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // rangee
            // 
            this.rangee.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.rangee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rangee.FormattingEnabled = true;
            this.rangee.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F"});
            this.rangee.Location = new System.Drawing.Point(78, 54);
            this.rangee.Name = "rangee";
            this.rangee.Size = new System.Drawing.Size(121, 21);
            this.rangee.TabIndex = 0;
            this.rangee.TabStop = false;
            this.rangee.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 450);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = " ";
            this.tabControl1.ResumeLayout(false);
            this.Achat.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Inventaire.ResumeLayout(false);
            this.Inventaire.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Achat;
        private System.Windows.Forms.TabPage Inventaire;
        private System.Windows.Forms.ListBox LcdScreen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnModifyInventory;
        private System.Windows.Forms.ComboBox colonne;
        private System.Windows.Forms.Button btn2Dollar;
        private System.Windows.Forms.Button btn1Dollar;
        private System.Windows.Forms.Button btn25Cent;
        private System.Windows.Forms.Button btn10Cent;
        private System.Windows.Forms.Button btn5Cent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox QuantityTextB;
        private System.Windows.Forms.TextBox PriceTextB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox rangee;
    }
}

