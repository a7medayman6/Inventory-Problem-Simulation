namespace InventorySimulation
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
            this.shortageavg_t = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.endingavg_t = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.simulate = new System.Windows.Forms.Button();
            this.numberofdays_t = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.startorderq_t = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.startleaddays_t = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.startinventoryq_t = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reviewperiod_t = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.orderupto_t = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.simulation_dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.simulation_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // shortageavg_t
            // 
            this.shortageavg_t.Location = new System.Drawing.Point(806, 582);
            this.shortageavg_t.Name = "shortageavg_t";
            this.shortageavg_t.Size = new System.Drawing.Size(100, 20);
            this.shortageavg_t.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(582, 582);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(205, 17);
            this.label7.TabIndex = 34;
            this.label7.Text = "Shortage Quantity Average";
            // 
            // endingavg_t
            // 
            this.endingavg_t.Location = new System.Drawing.Point(405, 586);
            this.endingavg_t.Name = "endingavg_t";
            this.endingavg_t.Size = new System.Drawing.Size(100, 20);
            this.endingavg_t.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(182, 586);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(195, 17);
            this.label8.TabIndex = 32;
            this.label8.Text = "Ending Inventory Average";
            // 
            // simulate
            // 
            this.simulate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simulate.Location = new System.Drawing.Point(977, 534);
            this.simulate.Name = "simulate";
            this.simulate.Size = new System.Drawing.Size(161, 41);
            this.simulate.TabIndex = 31;
            this.simulate.Text = "Start Simulation";
            this.simulate.UseVisualStyleBackColor = true;
            this.simulate.Click += new System.EventHandler(this.simulate_Click_1);
            // 
            // numberofdays_t
            // 
            this.numberofdays_t.Location = new System.Drawing.Point(845, 542);
            this.numberofdays_t.Name = "numberofdays_t";
            this.numberofdays_t.Size = new System.Drawing.Size(100, 20);
            this.numberofdays_t.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(652, 542);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "Number of Days";
            // 
            // startorderq_t
            // 
            this.startorderq_t.Location = new System.Drawing.Point(845, 503);
            this.startorderq_t.Name = "startorderq_t";
            this.startorderq_t.Size = new System.Drawing.Size(100, 20);
            this.startorderq_t.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(652, 503);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "Start Order Quantity";
            // 
            // startleaddays_t
            // 
            this.startleaddays_t.Location = new System.Drawing.Point(504, 542);
            this.startleaddays_t.Name = "startleaddays_t";
            this.startleaddays_t.Size = new System.Drawing.Size(100, 20);
            this.startleaddays_t.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(296, 546);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Start Lead Days";
            // 
            // startinventoryq_t
            // 
            this.startinventoryq_t.Location = new System.Drawing.Point(504, 503);
            this.startinventoryq_t.Name = "startinventoryq_t";
            this.startinventoryq_t.Size = new System.Drawing.Size(100, 20);
            this.startinventoryq_t.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(296, 503);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Start Inventory Quantity";
            // 
            // reviewperiod_t
            // 
            this.reviewperiod_t.Location = new System.Drawing.Point(134, 546);
            this.reviewperiod_t.Name = "reviewperiod_t";
            this.reviewperiod_t.Size = new System.Drawing.Size(100, 20);
            this.reviewperiod_t.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(14, 546);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Review Period";
            // 
            // orderupto_t
            // 
            this.orderupto_t.Location = new System.Drawing.Point(134, 503);
            this.orderupto_t.Name = "orderupto_t";
            this.orderupto_t.Size = new System.Drawing.Size(100, 20);
            this.orderupto_t.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(14, 503);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "Order Up To";
            // 
            // simulation_dgv
            // 
            this.simulation_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.simulation_dgv.Location = new System.Drawing.Point(14, 20);
            this.simulation_dgv.Name = "simulation_dgv";
            this.simulation_dgv.Size = new System.Drawing.Size(1270, 467);
            this.simulation_dgv.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 613);
            this.Controls.Add(this.shortageavg_t);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.endingavg_t);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.simulate);
            this.Controls.Add(this.numberofdays_t);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.startorderq_t);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.startleaddays_t);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.startinventoryq_t);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reviewperiod_t);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.orderupto_t);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.simulation_dgv);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.simulation_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox shortageavg_t;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox endingavg_t;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button simulate;
        private System.Windows.Forms.TextBox numberofdays_t;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox startorderq_t;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox startleaddays_t;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox startinventoryq_t;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox reviewperiod_t;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox orderupto_t;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView simulation_dgv;
    }
}

