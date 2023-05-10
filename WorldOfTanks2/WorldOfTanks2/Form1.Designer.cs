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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.healthPlayer1 = new System.Windows.Forms.Label();
            this.fuelPlayer2 = new System.Windows.Forms.Label();
            this.fuelPlayer1 = new System.Windows.Forms.Label();
            this.healthPlayer2 = new System.Windows.Forms.Label();
            this.cooldown1 = new System.Windows.Forms.Label();
            this.cooldown2 = new System.Windows.Forms.Label();
            this.ammunitionPlayer1 = new System.Windows.Forms.Label();
            this.ammunitionPlayer2 = new System.Windows.Forms.Label();
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
            this.glControl1.Location = new System.Drawing.Point(13, 13);
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // healthPlayer1
            // 
            this.healthPlayer1.AutoSize = true;
            this.healthPlayer1.Location = new System.Drawing.Point(23, 643);
            this.healthPlayer1.Name = "healthPlayer1";
            this.healthPlayer1.Size = new System.Drawing.Size(71, 16);
            this.healthPlayer1.TabIndex = 7;
            this.healthPlayer1.Text = "Здоровье";
            // 
            // fuelPlayer2
            // 
            this.fuelPlayer2.AutoSize = true;
            this.fuelPlayer2.Location = new System.Drawing.Point(285, 18);
            this.fuelPlayer2.Name = "fuelPlayer2";
            this.fuelPlayer2.Size = new System.Drawing.Size(105, 16);
            this.fuelPlayer2.TabIndex = 9;
            this.fuelPlayer2.Text = "Запас топлива";
            // 
            // fuelPlayer1
            // 
            this.fuelPlayer1.AutoSize = true;
            this.fuelPlayer1.Location = new System.Drawing.Point(139, 643);
            this.fuelPlayer1.Name = "fuelPlayer1";
            this.fuelPlayer1.Size = new System.Drawing.Size(105, 16);
            this.fuelPlayer1.TabIndex = 10;
            this.fuelPlayer1.Text = "Запас топлива";
            // 
            // healthPlayer2
            // 
            this.healthPlayer2.AutoSize = true;
            this.healthPlayer2.BackColor = System.Drawing.Color.White;
            this.healthPlayer2.Location = new System.Drawing.Point(173, 18);
            this.healthPlayer2.Name = "healthPlayer2";
            this.healthPlayer2.Size = new System.Drawing.Size(71, 16);
            this.healthPlayer2.TabIndex = 11;
            this.healthPlayer2.Text = "Здоровье";
            // 
            // cooldown1
            // 
            this.cooldown1.AutoSize = true;
            this.cooldown1.Location = new System.Drawing.Point(305, 643);
            this.cooldown1.Name = "cooldown1";
            this.cooldown1.Size = new System.Drawing.Size(98, 16);
            this.cooldown1.TabIndex = 13;
            this.cooldown1.Text = "Перезарядка:";
            // 
            // cooldown2
            // 
            this.cooldown2.AutoSize = true;
            this.cooldown2.Location = new System.Drawing.Point(449, 18);
            this.cooldown2.Name = "cooldown2";
            this.cooldown2.Size = new System.Drawing.Size(98, 16);
            this.cooldown2.TabIndex = 14;
            this.cooldown2.Text = "Перезарядка:";
            // 
            // ammunitionPlayer1
            // 
            this.ammunitionPlayer1.AutoSize = true;
            this.ammunitionPlayer1.Location = new System.Drawing.Point(449, 643);
            this.ammunitionPlayer1.Name = "ammunitionPlayer1";
            this.ammunitionPlayer1.Size = new System.Drawing.Size(0, 16);
            this.ammunitionPlayer1.TabIndex = 15;
            // 
            // ammunitionPlayer2
            // 
            this.ammunitionPlayer2.AutoSize = true;
            this.ammunitionPlayer2.Location = new System.Drawing.Point(590, 18);
            this.ammunitionPlayer2.Name = "ammunitionPlayer2";
            this.ammunitionPlayer2.Size = new System.Drawing.Size(0, 16);
            this.ammunitionPlayer2.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 683);
            this.Controls.Add(this.ammunitionPlayer2);
            this.Controls.Add(this.ammunitionPlayer1);
            this.Controls.Add(this.cooldown2);
            this.Controls.Add(this.cooldown1);
            this.Controls.Add(this.healthPlayer2);
            this.Controls.Add(this.fuelPlayer1);
            this.Controls.Add(this.fuelPlayer2);
            this.Controls.Add(this.healthPlayer1);
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
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label healthPlayer1;
        private System.Windows.Forms.Label healthPlayer2;
        private System.Windows.Forms.Label fuelPlayer1;
        private System.Windows.Forms.Label fuelPlayer2;
        private System.Windows.Forms.Label cooldown2;
        private System.Windows.Forms.Label cooldown1;
        private System.Windows.Forms.Label ammunitionPlayer2;
        private System.Windows.Forms.Label ammunitionPlayer1;
    }
}

