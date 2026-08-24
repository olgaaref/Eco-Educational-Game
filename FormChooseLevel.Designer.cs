namespace WfGameProject
{
    partial class FormChooseLevel
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tbPlayerName = new System.Windows.Forms.TextBox();
            this.labPlayerName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RosyBrown;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 20.25F);
            this.button1.Location = new System.Drawing.Point(48, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 103);
            this.button1.TabIndex = 1;
            this.button1.Text = "Уровень 1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.RosyBrown;
            this.button2.Font = new System.Drawing.Font("Comic Sans MS", 20.25F);
            this.button2.Location = new System.Drawing.Point(312, 134);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 103);
            this.button2.TabIndex = 2;
            this.button2.Text = "Уровень 2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.RosyBrown;
            this.button3.Font = new System.Drawing.Font("Comic Sans MS", 20.25F);
            this.button3.Location = new System.Drawing.Point(572, 134);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(175, 103);
            this.button3.TabIndex = 3;
            this.button3.Text = "Уровень 3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.RosyBrown;
            this.button4.Font = new System.Drawing.Font("Comic Sans MS", 14.25F);
            this.button4.Location = new System.Drawing.Point(22, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 39);
            this.button4.TabIndex = 4;
            this.button4.Text = "Назад";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // tbPlayerName
            // 
            this.tbPlayerName.Font = new System.Drawing.Font("Comic Sans MS", 8.25F);
            this.tbPlayerName.Location = new System.Drawing.Point(510, 40);
            this.tbPlayerName.Name = "tbPlayerName";
            this.tbPlayerName.Size = new System.Drawing.Size(300, 23);
            this.tbPlayerName.TabIndex = 8;
            this.tbPlayerName.TextChanged += new System.EventHandler(this.TbPlayerName_TextChanged);
            // 
            // labPlayerName
            // 
            this.labPlayerName.AutoSize = true;
            this.labPlayerName.BackColor = System.Drawing.Color.Snow;
            this.labPlayerName.Font = new System.Drawing.Font("Comic Sans MS", 12F);
            this.labPlayerName.Location = new System.Drawing.Point(506, 9);
            this.labPlayerName.Name = "labPlayerName";
            this.labPlayerName.Size = new System.Drawing.Size(304, 23);
            this.labPlayerName.TabIndex = 7;
            this.labPlayerName.Text = "Введите Ваше имя и выберете уровень";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.MistyRose;
            this.pictureBox1.Location = new System.Drawing.Point(2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(819, 432);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormChooseLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 437);
            this.Controls.Add(this.tbPlayerName);
            this.Controls.Add(this.labPlayerName);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormChooseLevel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormChooseLevel";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChooseLevel_FormClosed);
            this.Load += new System.EventHandler(this.FormChooseLevel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tbPlayerName;
        private System.Windows.Forms.Label labPlayerName;
    }
}