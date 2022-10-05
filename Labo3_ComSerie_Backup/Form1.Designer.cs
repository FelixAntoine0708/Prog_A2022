namespace Labo3_ComSerie
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.senderTxt = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnTx = new System.Windows.Forms.Button();
            this.Configuration = new System.Windows.Forms.GroupBox();
            this.comboStpBits = new System.Windows.Forms.ComboBox();
            this.comboNbBits = new System.Windows.Forms.ComboBox();
            this.comboParite = new System.Windows.Forms.ComboBox();
            this.comboVitesse = new System.Windows.Forms.ComboBox();
            this.comboPort = new System.Windows.Forms.ComboBox();
            this.btnConfigOpen = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.port = new System.IO.Ports.SerialPort(this.components);
            this.Configuration.SuspendLayout();
            this.SuspendLayout();
            // 
            // senderTxt
            // 
            this.senderTxt.Location = new System.Drawing.Point(42, 36);
            this.senderTxt.Name = "senderTxt";
            this.senderTxt.Size = new System.Drawing.Size(289, 20);
            this.senderTxt.TabIndex = 0;
            this.senderTxt.Text = "Vivre C#";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(42, 150);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(289, 20);
            this.textBox2.TabIndex = 1;
            // 
            // btnTx
            // 
            this.btnTx.Location = new System.Drawing.Point(42, 62);
            this.btnTx.Name = "btnTx";
            this.btnTx.Size = new System.Drawing.Size(75, 23);
            this.btnTx.TabIndex = 2;
            this.btnTx.Text = "TX";
            this.btnTx.UseVisualStyleBackColor = true;
            this.btnTx.Click += new System.EventHandler(this.button1_Click);
            // 
            // Configuration
            // 
            this.Configuration.Controls.Add(this.comboStpBits);
            this.Configuration.Controls.Add(this.comboNbBits);
            this.Configuration.Controls.Add(this.comboParite);
            this.Configuration.Controls.Add(this.comboVitesse);
            this.Configuration.Controls.Add(this.comboPort);
            this.Configuration.Controls.Add(this.btnConfigOpen);
            this.Configuration.Controls.Add(this.label5);
            this.Configuration.Controls.Add(this.label4);
            this.Configuration.Controls.Add(this.label3);
            this.Configuration.Controls.Add(this.label2);
            this.Configuration.Controls.Add(this.label1);
            this.Configuration.Location = new System.Drawing.Point(443, 13);
            this.Configuration.Name = "Configuration";
            this.Configuration.Size = new System.Drawing.Size(318, 425);
            this.Configuration.TabIndex = 3;
            this.Configuration.TabStop = false;
            this.Configuration.Text = "Configuration";
            // 
            // comboStpBits
            // 
            this.comboStpBits.FormattingEnabled = true;
            this.comboStpBits.Location = new System.Drawing.Point(138, 325);
            this.comboStpBits.Name = "comboStpBits";
            this.comboStpBits.Size = new System.Drawing.Size(161, 21);
            this.comboStpBits.TabIndex = 15;
            // 
            // comboNbBits
            // 
            this.comboNbBits.FormattingEnabled = true;
            this.comboNbBits.Location = new System.Drawing.Point(138, 251);
            this.comboNbBits.Name = "comboNbBits";
            this.comboNbBits.Size = new System.Drawing.Size(161, 21);
            this.comboNbBits.TabIndex = 14;
            // 
            // comboParite
            // 
            this.comboParite.FormattingEnabled = true;
            this.comboParite.Location = new System.Drawing.Point(138, 179);
            this.comboParite.Name = "comboParite";
            this.comboParite.Size = new System.Drawing.Size(161, 21);
            this.comboParite.TabIndex = 13;
            // 
            // comboVitesse
            // 
            this.comboVitesse.FormattingEnabled = true;
            this.comboVitesse.Location = new System.Drawing.Point(138, 108);
            this.comboVitesse.Name = "comboVitesse";
            this.comboVitesse.Size = new System.Drawing.Size(161, 21);
            this.comboVitesse.TabIndex = 12;
            // 
            // comboPort
            // 
            this.comboPort.FormattingEnabled = true;
            this.comboPort.Location = new System.Drawing.Point(138, 45);
            this.comboPort.Name = "comboPort";
            this.comboPort.Size = new System.Drawing.Size(161, 21);
            this.comboPort.TabIndex = 11;
            // 
            // btnConfigOpen
            // 
            this.btnConfigOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigOpen.Location = new System.Drawing.Point(138, 396);
            this.btnConfigOpen.Name = "btnConfigOpen";
            this.btnConfigOpen.Size = new System.Drawing.Size(161, 23);
            this.btnConfigOpen.TabIndex = 10;
            this.btnConfigOpen.Text = "configurer et ouvert";
            this.btnConfigOpen.UseVisualStyleBackColor = true;
            this.btnConfigOpen.Click += new System.EventHandler(this.btnConfigOpen_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 325);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Stop Bits";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nb Bits";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Parité";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vitesse";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Réception:";
            // 
            // port
            // 
            this.port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.port_DataReceived);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 450);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Configuration);
            this.Controls.Add(this.btnTx);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.senderTxt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Configuration.ResumeLayout(false);
            this.Configuration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox senderTxt;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnTx;
        private System.Windows.Forms.GroupBox Configuration;
        private System.Windows.Forms.Button btnConfigOpen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboStpBits;
        private System.Windows.Forms.ComboBox comboNbBits;
        private System.Windows.Forms.ComboBox comboParite;
        private System.Windows.Forms.ComboBox comboVitesse;
        private System.Windows.Forms.ComboBox comboPort;
        private System.IO.Ports.SerialPort port;
    }
}

