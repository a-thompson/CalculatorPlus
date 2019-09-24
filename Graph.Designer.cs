namespace Calc
{
    partial class Graph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graph));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.functionLbl = new System.Windows.Forms.Label();
            this.eq1Combo = new System.Windows.Forms.ComboBox();
            this.graphBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(241, 12);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(845, 639);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // functionLbl
            // 
            this.functionLbl.AutoSize = true;
            this.functionLbl.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.functionLbl.Location = new System.Drawing.Point(52, 14);
            this.functionLbl.Name = "functionLbl";
            this.functionLbl.Size = new System.Drawing.Size(126, 33);
            this.functionLbl.TabIndex = 5;
            this.functionLbl.Text = "Functions";
            // 
            // eq1Combo
            // 
            this.eq1Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eq1Combo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eq1Combo.FormattingEnabled = true;
            this.eq1Combo.Location = new System.Drawing.Point(12, 54);
            this.eq1Combo.Name = "eq1Combo";
            this.eq1Combo.Size = new System.Drawing.Size(213, 35);
            this.eq1Combo.TabIndex = 6;
            // 
            // graphBtn
            // 
            this.graphBtn.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphBtn.Location = new System.Drawing.Point(12, 95);
            this.graphBtn.Name = "graphBtn";
            this.graphBtn.Size = new System.Drawing.Size(100, 35);
            this.graphBtn.TabIndex = 34;
            this.graphBtn.Text = "Graph";
            this.graphBtn.UseVisualStyleBackColor = true;
            this.graphBtn.Click += new System.EventHandler(this.graphBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.Location = new System.Drawing.Point(125, 95);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(100, 35);
            this.clearBtn.TabIndex = 35;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 663);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.graphBtn);
            this.Controls.Add(this.eq1Combo);
            this.Controls.Add(this.functionLbl);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Graph";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Graph";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label functionLbl;
        public System.Windows.Forms.ComboBox eq1Combo;
        private System.Windows.Forms.Button graphBtn;
        private System.Windows.Forms.Button clearBtn;
    }
}