namespace WfGameProject
{
    partial class FormOptions
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tbFullFileName = new System.Windows.Forms.TextBox();
            this.tbCharacterTextTrash = new System.Windows.Forms.TextBox();
            this.labCharacterTextTrash = new System.Windows.Forms.Label();
            this.tbCharacterTextFish = new System.Windows.Forms.TextBox();
            this.labCharacterTextFish = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.labUnderCharacterTextFish = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labUnderCharacterTextTrash = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.RosyBrown;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F);
            this.button1.Location = new System.Drawing.Point(670, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 41);
            this.button1.TabIndex = 4;
            this.button1.Text = "Назад";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.RosyBrown;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Основные настройки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Snow;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(349, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Месторасположение файла для сохранения рекордов";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(410, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 20);
            this.button2.TabIndex = 8;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // tbFullFileName
            // 
            this.tbFullFileName.Font = new System.Drawing.Font("Comic Sans MS", 8.25F);
            this.tbFullFileName.Location = new System.Drawing.Point(15, 83);
            this.tbFullFileName.Name = "tbFullFileName";
            this.tbFullFileName.ReadOnly = true;
            this.tbFullFileName.Size = new System.Drawing.Size(389, 23);
            this.tbFullFileName.TabIndex = 9;
            // 
            // tbCharacterTextTrash
            // 
            this.tbCharacterTextTrash.Font = new System.Drawing.Font("Comic Sans MS", 8.25F);
            this.tbCharacterTextTrash.Location = new System.Drawing.Point(17, 281);
            this.tbCharacterTextTrash.Name = "tbCharacterTextTrash";
            this.tbCharacterTextTrash.Size = new System.Drawing.Size(387, 23);
            this.tbCharacterTextTrash.TabIndex = 11;
            this.tbCharacterTextTrash.TextChanged += new System.EventHandler(this.TbCharacterTextTrash_TextChanged);
            // 
            // labCharacterTextTrash
            // 
            this.labCharacterTextTrash.AutoSize = true;
            this.labCharacterTextTrash.BackColor = System.Drawing.Color.Snow;
            this.labCharacterTextTrash.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.labCharacterTextTrash.Location = new System.Drawing.Point(15, 258);
            this.labCharacterTextTrash.Name = "labCharacterTextTrash";
            this.labCharacterTextTrash.Size = new System.Drawing.Size(255, 18);
            this.labCharacterTextTrash.TabIndex = 10;
            this.labCharacterTextTrash.Text = "Фраза персонажа при поднятии мусора";
            // 
            // tbCharacterTextFish
            // 
            this.tbCharacterTextFish.Font = new System.Drawing.Font("Comic Sans MS", 8.25F);
            this.tbCharacterTextFish.Location = new System.Drawing.Point(15, 196);
            this.tbCharacterTextFish.Name = "tbCharacterTextFish";
            this.tbCharacterTextFish.Size = new System.Drawing.Size(389, 23);
            this.tbCharacterTextFish.TabIndex = 13;
            this.tbCharacterTextFish.TextChanged += new System.EventHandler(this.TbCharacterTextFish_TextChanged);
            // 
            // labCharacterTextFish
            // 
            this.labCharacterTextFish.AutoSize = true;
            this.labCharacterTextFish.BackColor = System.Drawing.Color.Snow;
            this.labCharacterTextFish.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.labCharacterTextFish.Location = new System.Drawing.Point(15, 173);
            this.labCharacterTextFish.Name = "labCharacterTextFish";
            this.labCharacterTextFish.Size = new System.Drawing.Size(243, 18);
            this.labCharacterTextFish.TabIndex = 12;
            this.labCharacterTextFish.Text = "Фраза персонажа при поднятии рыбы";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.RosyBrown;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 15.75F);
            this.label5.Location = new System.Drawing.Point(13, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(281, 29);
            this.label5.TabIndex = 14;
            this.label5.Text = "Настройки первого уровня";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.RosyBrown;
            this.btnReset.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnReset.Location = new System.Drawing.Point(19, 368);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(143, 54);
            this.btnReset.TabIndex = 17;
            this.btnReset.Text = "По умолчанию";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // labUnderCharacterTextFish
            // 
            this.labUnderCharacterTextFish.AutoSize = true;
            this.labUnderCharacterTextFish.BackColor = System.Drawing.Color.Transparent;
            this.labUnderCharacterTextFish.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.labUnderCharacterTextFish.ForeColor = System.Drawing.Color.Red;
            this.labUnderCharacterTextFish.Location = new System.Drawing.Point(15, 219);
            this.labUnderCharacterTextFish.Name = "labUnderCharacterTextFish";
            this.labUnderCharacterTextFish.Size = new System.Drawing.Size(16, 18);
            this.labUnderCharacterTextFish.TabIndex = 18;
            this.labUnderCharacterTextFish.Text = "  ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Snow;
            this.label4.Font = new System.Drawing.Font("Segoe Script", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(400, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 19;
            // 
            // labUnderCharacterTextTrash
            // 
            this.labUnderCharacterTextTrash.AutoSize = true;
            this.labUnderCharacterTextTrash.BackColor = System.Drawing.Color.Transparent;
            this.labUnderCharacterTextTrash.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
            this.labUnderCharacterTextTrash.ForeColor = System.Drawing.Color.Red;
            this.labUnderCharacterTextTrash.Location = new System.Drawing.Point(15, 304);
            this.labUnderCharacterTextTrash.Name = "labUnderCharacterTextTrash";
            this.labUnderCharacterTextTrash.Size = new System.Drawing.Size(16, 18);
            this.labUnderCharacterTextTrash.TabIndex = 20;
            this.labUnderCharacterTextTrash.Text = "  ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::WfGameProject.Properties.Resources._1631474786_9_papik_pro_p_peizazhi_genshina_10;
            this.pictureBox2.Location = new System.Drawing.Point(465, 96);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(323, 180);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.MistyRose;
            this.pictureBox1.Location = new System.Drawing.Point(1, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 447);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labUnderCharacterTextTrash);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labUnderCharacterTextFish);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbCharacterTextFish);
            this.Controls.Add(this.labCharacterTextFish);
            this.Controls.Add(this.tbCharacterTextTrash);
            this.Controls.Add(this.labCharacterTextTrash);
            this.Controls.Add(this.tbFullFileName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormOptions";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormOptions_FormClosed);
            this.Load += new System.EventHandler(this.FormOptions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbFullFileName;
        private System.Windows.Forms.TextBox tbCharacterTextTrash;
        private System.Windows.Forms.Label labCharacterTextTrash;
        private System.Windows.Forms.TextBox tbCharacterTextFish;
        private System.Windows.Forms.Label labCharacterTextFish;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label labUnderCharacterTextFish;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labUnderCharacterTextTrash;
    }
}