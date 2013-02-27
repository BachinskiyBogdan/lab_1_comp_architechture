namespace NotePad_test
{
    partial class FindForm
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
            this.Search_btn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Down_rb = new System.Windows.Forms.RadioButton();
            this.Up_rb = new System.Windows.Forms.RadioButton();
            this.Case_chkb = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Search_btn
            // 
            this.Search_btn.Location = new System.Drawing.Point(349, 12);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(75, 23);
            this.Search_btn.TabIndex = 0;
            this.Search_btn.Text = "Find Next";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(349, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Find What?";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(249, 20);
            this.textBox1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Down_rb);
            this.groupBox1.Controls.Add(this.Up_rb);
            this.groupBox1.Location = new System.Drawing.Point(215, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 54);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Direction";
            // 
            // Down_rb
            // 
            this.Down_rb.AutoSize = true;
            this.Down_rb.Checked = true;
            this.Down_rb.Location = new System.Drawing.Point(61, 30);
            this.Down_rb.Name = "Down_rb";
            this.Down_rb.Size = new System.Drawing.Size(53, 17);
            this.Down_rb.TabIndex = 0;
            this.Down_rb.TabStop = true;
            this.Down_rb.Text = "Down";
            this.Down_rb.UseVisualStyleBackColor = true;
            // 
            // Up_rb
            // 
            this.Up_rb.AutoSize = true;
            this.Up_rb.Location = new System.Drawing.Point(6, 30);
            this.Up_rb.Name = "Up_rb";
            this.Up_rb.Size = new System.Drawing.Size(39, 17);
            this.Up_rb.TabIndex = 0;
            this.Up_rb.Text = "Up";
            this.Up_rb.UseVisualStyleBackColor = true;
            // 
            // Case_chkb
            // 
            this.Case_chkb.AutoSize = true;
            this.Case_chkb.Location = new System.Drawing.Point(15, 116);
            this.Case_chkb.Name = "Case_chkb";
            this.Case_chkb.Size = new System.Drawing.Size(82, 17);
            this.Case_chkb.TabIndex = 5;
            this.Case_chkb.Text = "Match case";
            this.Case_chkb.UseVisualStyleBackColor = true;
            // 
            // FindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 145);
            this.Controls.Add(this.Case_chkb);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Search_btn);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(452, 183);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(452, 183);
            this.Name = "FindForm";
            this.Text = "Find";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Down_rb;
        private System.Windows.Forms.RadioButton Up_rb;
        private System.Windows.Forms.CheckBox Case_chkb;
    }
}