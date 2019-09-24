namespace Calc
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.piBox = new System.Windows.Forms.CheckBox();
            this.flipBox = new System.Windows.Forms.CheckBox();
            this.factBox = new System.Windows.Forms.CheckBox();
            this.powBox = new System.Windows.Forms.CheckBox();
            this.squareBox = new System.Windows.Forms.CheckBox();
            this.rootBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // piBox
            // 
            this.piBox.AutoSize = true;
            this.piBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.piBox.Location = new System.Drawing.Point(101, 26);
            this.piBox.Name = "piBox";
            this.piBox.Size = new System.Drawing.Size(50, 31);
            this.piBox.TabIndex = 0;
            this.piBox.Text = "π";
            this.piBox.UseVisualStyleBackColor = true;
            // 
            // flipBox
            // 
            this.flipBox.AutoSize = true;
            this.flipBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flipBox.Location = new System.Drawing.Point(12, 26);
            this.flipBox.Name = "flipBox";
            this.flipBox.Size = new System.Drawing.Size(61, 26);
            this.flipBox.TabIndex = 2;
            this.flipBox.Text = "1/x";
            this.flipBox.UseVisualStyleBackColor = true;
            // 
            // factBox
            // 
            this.factBox.AutoSize = true;
            this.factBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.factBox.Location = new System.Drawing.Point(101, 61);
            this.factBox.Name = "factBox";
            this.factBox.Size = new System.Drawing.Size(42, 26);
            this.factBox.TabIndex = 3;
            this.factBox.Text = "!";
            this.factBox.UseVisualStyleBackColor = true;
            // 
            // powBox
            // 
            this.powBox.AutoSize = true;
            this.powBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.powBox.Location = new System.Drawing.Point(12, 61);
            this.powBox.Name = "powBox";
            this.powBox.Size = new System.Drawing.Size(62, 26);
            this.powBox.TabIndex = 4;
            this.powBox.Text = "x^y";
            this.powBox.UseVisualStyleBackColor = true;
            // 
            // squareBox
            // 
            this.squareBox.AutoSize = true;
            this.squareBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.squareBox.Location = new System.Drawing.Point(12, 96);
            this.squareBox.Name = "squareBox";
            this.squareBox.Size = new System.Drawing.Size(63, 26);
            this.squareBox.TabIndex = 5;
            this.squareBox.Text = "x^2";
            this.squareBox.UseVisualStyleBackColor = true;
            // 
            // rootBox
            // 
            this.rootBox.AutoSize = true;
            this.rootBox.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rootBox.Location = new System.Drawing.Point(12, 131);
            this.rootBox.Name = "rootBox";
            this.rootBox.Size = new System.Drawing.Size(47, 26);
            this.rootBox.TabIndex = 6;
            this.rootBox.Text = "√";
            this.rootBox.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(163, 172);
            this.Controls.Add(this.rootBox);
            this.Controls.Add(this.squareBox);
            this.Controls.Add(this.powBox);
            this.Controls.Add(this.factBox);
            this.Controls.Add(this.flipBox);
            this.Controls.Add(this.piBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox piBox;
        public System.Windows.Forms.CheckBox flipBox;
        public System.Windows.Forms.CheckBox factBox;
        public System.Windows.Forms.CheckBox powBox;
        public System.Windows.Forms.CheckBox squareBox;
        public System.Windows.Forms.CheckBox rootBox;
    }
}