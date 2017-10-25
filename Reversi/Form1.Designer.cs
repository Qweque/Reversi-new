namespace Reversi
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

        
        public void InitializeComponent()
        {
            this.Reset = new System.Windows.Forms.Button();
            this.Help = new System.Windows.Forms.Button();
            this.speelveld = new System.Windows.Forms.Panel();
            this.keer = new System.Windows.Forms.Label();
            this.x_veld = new System.Windows.Forms.TextBox();
            this.y_veld = new System.Windows.Forms.TextBox();
            this.max = new System.Windows.Forms.Label();
            this.Error = new System.Windows.Forms.Label();
            this.Playercounter = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Reset
            // 
            this.Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset.Location = new System.Drawing.Point(50, 30);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(150, 30);
            this.Reset.TabIndex = 0;
            this.Reset.Text = "Start spel";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Nieuw_Spel);
            // 
            // Help
            // 
            this.Help.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Help.Location = new System.Drawing.Point(550, 30);
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(150, 30);
            this.Help.TabIndex = 1;
            this.Help.Text = "Help";
            this.Help.UseVisualStyleBackColor = true;
            this.Help.Click += new System.EventHandler(this.Help_Click);
            // 
            // speelveld
            // 
            this.speelveld.Location = new System.Drawing.Point(20, 100);
            this.speelveld.Name = "speelveld";
            this.speelveld.Size = new System.Drawing.Size(5000, 5000);
            this.speelveld.TabIndex = 2;
            this.speelveld.Paint += new System.Windows.Forms.PaintEventHandler(this.Tekenspeelveld);
            this.speelveld.MouseClick += new System.Windows.Forms.MouseEventHandler(this.speelveld_MouseClick);
            // 
            // keer
            // 
            this.keer.AutoSize = true;
            this.keer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keer.Location = new System.Drawing.Point(425, 35);
            this.keer.Name = "keer";
            this.keer.Size = new System.Drawing.Size(17, 20);
            this.keer.TabIndex = 3;
            this.keer.Text = "x";
            // 
            // x_veld
            // 
            this.x_veld.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.x_veld.Location = new System.Drawing.Point(350, 32);
            this.x_veld.Name = "x_veld";
            this.x_veld.Size = new System.Drawing.Size(50, 27);
            this.x_veld.TabIndex = 4;
            // 
            // y_veld
            // 
            this.y_veld.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.y_veld.Location = new System.Drawing.Point(470, 32);
            this.y_veld.Name = "y_veld";
            this.y_veld.Size = new System.Drawing.Size(50, 27);
            this.y_veld.TabIndex = 5;
            // 
            // max
            // 
            this.max.AutoSize = true;
            this.max.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.max.Location = new System.Drawing.Point(230, 35);
            this.max.Name = "max";
            this.max.Size = new System.Drawing.Size(95, 20);
            this.max.TabIndex = 6;
            this.max.Text = "max: 15 x 8";
            // 
            // Error
            // 
            this.Error.AutoSize = true;
            this.Error.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error.Location = new System.Drawing.Point(346, 68);
            this.Error.Name = "Error";
            this.Error.Size = new System.Drawing.Size(0, 20);
            this.Error.TabIndex = 7;
            // 
            // Playercounter
            // 
            this.Playercounter.AutoSize = true;
            this.Playercounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Playercounter.Location = new System.Drawing.Point(747, 38);
            this.Playercounter.Name = "Playercounter";
            this.Playercounter.Size = new System.Drawing.Size(0, 20);
            this.Playercounter.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 610);
            this.Controls.Add(this.Playercounter);
            this.Controls.Add(this.Error);
            this.Controls.Add(this.max);
            this.Controls.Add(this.y_veld);
            this.Controls.Add(this.x_veld);
            this.Controls.Add(this.keer);
            this.Controls.Add(this.speelveld);
            this.Controls.Add(this.Help);
            this.Controls.Add(this.Reset);
            this.Name = "Form1";
            this.Text = "Reversi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
            #endregion


        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Help;
        private System.Windows.Forms.Panel speelveld;
        private System.Windows.Forms.Label keer;
        private System.Windows.Forms.TextBox x_veld;
        private System.Windows.Forms.TextBox y_veld;
        private System.Windows.Forms.Label max;
        private System.Windows.Forms.Label Error;
        private System.Windows.Forms.Label Playercounter;
    }

}

