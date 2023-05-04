namespace WorldOfTanks2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.glControl1 = new OpenTK.GLControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.health1 = new System.Windows.Forms.ProgressBar();
            this.health2 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.fuelRsrf1 = new System.Windows.Forms.ProgressBar();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.fuelRsrf2 = new System.Windows.Forms.ProgressBar();
            this.healthPlayer1 = new System.Windows.Forms.Label();
            this.fuelPlayer2 = new System.Windows.Forms.Label();
            this.fuelPlayer1 = new System.Windows.Forms.Label();
            this.healthPlayer2 = new System.Windows.Forms.Label();
            this.Player1 = new System.Windows.Forms.Label();
            this.cooldown1 = new System.Windows.Forms.Label();
            this.cooldown2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // glControl1
            // 
            this.glControl1.AutoScroll = true;
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(13, 147);
            this.glControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(740, 660);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // health1
            // 
            this.health1.Location = new System.Drawing.Point(12, 40);
            this.health1.Name = "health1";
            this.health1.Size = new System.Drawing.Size(155, 23);
            this.health1.TabIndex = 1;
            // 
            // health2
            // 
            this.health2.Location = new System.Drawing.Point(588, 38);
            this.health2.Name = "health2";
            this.health2.Size = new System.Drawing.Size(155, 25);
            this.health2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(594, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Игрок 2";
            // 
            // fuelRsrf1
            // 
            this.fuelRsrf1.Location = new System.Drawing.Point(12, 90);
            this.fuelRsrf1.Maximum = 1500;
            this.fuelRsrf1.Name = "fuelRsrf1";
            this.fuelRsrf1.Size = new System.Drawing.Size(180, 25);
            this.fuelRsrf1.TabIndex = 5;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // fuelRsrf2
            // 
            this.fuelRsrf2.Location = new System.Drawing.Point(563, 90);
            this.fuelRsrf2.Maximum = 1500;
            this.fuelRsrf2.Name = "fuelRsrf2";
            this.fuelRsrf2.Size = new System.Drawing.Size(180, 25);
            this.fuelRsrf2.TabIndex = 6;
            // 
            // healthPlayer1
            // 
            this.healthPlayer1.AutoSize = true;
            this.healthPlayer1.Location = new System.Drawing.Point(10, 21);
            this.healthPlayer1.Name = "healthPlayer1";
            this.healthPlayer1.Size = new System.Drawing.Size(71, 16);
            this.healthPlayer1.TabIndex = 7;
            this.healthPlayer1.Text = "Здоровье";
            // 
            // fuelPlayer2
            // 
            this.fuelPlayer2.AutoSize = true;
            this.fuelPlayer2.Location = new System.Drawing.Point(648, 71);
            this.fuelPlayer2.Name = "fuelPlayer2";
            this.fuelPlayer2.Size = new System.Drawing.Size(105, 16);
            this.fuelPlayer2.TabIndex = 9;
            this.fuelPlayer2.Text = "Запас топлива";
            // 
            // fuelPlayer1
            // 
            this.fuelPlayer1.AutoSize = true;
            this.fuelPlayer1.Location = new System.Drawing.Point(10, 71);
            this.fuelPlayer1.Name = "fuelPlayer1";
            this.fuelPlayer1.Size = new System.Drawing.Size(105, 16);
            this.fuelPlayer1.TabIndex = 10;
            this.fuelPlayer1.Text = "Запас топлива";
            // 
            // healthPlayer2
            // 
            this.healthPlayer2.AutoSize = true;
            this.healthPlayer2.Location = new System.Drawing.Point(682, 21);
            this.healthPlayer2.Name = "healthPlayer2";
            this.healthPlayer2.Size = new System.Drawing.Size(71, 16);
            this.healthPlayer2.TabIndex = 11;
            this.healthPlayer2.Text = "Здоровье";
            // 
            // Player1
            // 
            this.Player1.AutoSize = true;
            this.Player1.Location = new System.Drawing.Point(114, 9);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(53, 16);
            this.Player1.TabIndex = 12;
            this.Player1.Text = "Игрок1";
            // 
            // cooldown1
            // 
            this.cooldown1.AutoSize = true;
            this.cooldown1.Location = new System.Drawing.Point(10, 118);
            this.cooldown1.Name = "cooldown1";
            this.cooldown1.Size = new System.Drawing.Size(98, 16);
            this.cooldown1.TabIndex = 13;
            this.cooldown1.Text = "Перезарядка:";
            // 
            // cooldown2
            // 
            this.cooldown2.AutoSize = true;
            this.cooldown2.Location = new System.Drawing.Point(629, 118);
            this.cooldown2.Name = "cooldown2";
            this.cooldown2.Size = new System.Drawing.Size(98, 16);
            this.cooldown2.TabIndex = 14;
            this.cooldown2.Text = "Перезарядка:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 833);
            this.Controls.Add(this.cooldown2);
            this.Controls.Add(this.cooldown1);
            this.Controls.Add(this.Player1);
            this.Controls.Add(this.healthPlayer2);
            this.Controls.Add(this.fuelPlayer1);
            this.Controls.Add(this.fuelPlayer2);
            this.Controls.Add(this.healthPlayer1);
            this.Controls.Add(this.fuelRsrf2);
            this.Controls.Add(this.fuelRsrf1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.health2);
            this.Controls.Add(this.health1);
            this.Controls.Add(this.glControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar health1;
        private System.Windows.Forms.ProgressBar health2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar fuelRsrf1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ProgressBar fuelRsrf2;
        private System.Windows.Forms.Label healthPlayer1;
        private System.Windows.Forms.Label healthPlayer2;
        private System.Windows.Forms.Label fuelPlayer1;
        private System.Windows.Forms.Label fuelPlayer2;
        private System.Windows.Forms.Label Player1;
        private System.Windows.Forms.Label cooldown2;
        private System.Windows.Forms.Label cooldown1;
    }
}

