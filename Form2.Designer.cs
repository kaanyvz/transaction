namespace transaction
{
    partial class Form2
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
            if (disposing && (components!= null))
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
            this.buttonStartSimulation = new System.Windows.Forms.Button();
            this.textBoxTypeAUsers = new System.Windows.Forms.TextBox();
            this.textBoxTypeBUsers = new System.Windows.Forms.TextBox();
            this.comboBoxIsolationLevel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonStartSimulation
            // 
            this.buttonStartSimulation.Location = new System.Drawing.Point(12, 104);
            this.buttonStartSimulation.Name = "buttonStartSimulation";
            this.buttonStartSimulation.Size = new System.Drawing.Size(120, 23);
            this.buttonStartSimulation.TabIndex = 0;
            this.buttonStartSimulation.Text = "Start Simulation";
            this.buttonStartSimulation.UseVisualStyleBackColor = true;
            this.buttonStartSimulation.Click += new System.EventHandler(this.buttonStartSimulation_Click);
            // 
            // textBoxTypeAUsers
            // 
            this.textBoxTypeAUsers.Location = new System.Drawing.Point(12, 29);
            this.textBoxTypeAUsers.Name = "textBoxTypeAUsers";
            this.textBoxTypeAUsers.Size = new System.Drawing.Size(120, 20);
            this.textBoxTypeAUsers.TabIndex = 1;
            // 
            // textBoxTypeBUsers
            // 
            this.textBoxTypeBUsers.Location = new System.Drawing.Point(12, 55);
            this.textBoxTypeBUsers.Name = "textBoxTypeBUsers";
            this.textBoxTypeBUsers.Size = new System.Drawing.Size(120, 20);
            this.textBoxTypeBUsers.TabIndex = 2;
            // 
            // comboBoxIsolationLevel
            // 
            this.comboBoxIsolationLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIsolationLevel.FormattingEnabled = true;
            this.comboBoxIsolationLevel.Items.AddRange(new object[] {
            "ReadUncommitted",
            "ReadCommitted",
            "RepeatableRead",
            "Serializable",
            "Snapshot"});
            this.comboBoxIsolationLevel.Location = new System.Drawing.Point(12, 77);
            this.comboBoxIsolationLevel.Name = "comboBoxIsolationLevel";
            this.comboBoxIsolationLevel.Size = new System.Drawing.Size(120, 21);
            this.comboBoxIsolationLevel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Type A Users:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Type B Users:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Isolation Level:";
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Location = new System.Drawing.Point(12, 133);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.ReadOnly = true;
            this.richTextBoxOutput.Size = new System.Drawing.Size(360, 240);
            this.richTextBoxOutput.TabIndex = 7;
            this.richTextBoxOutput.Text = "";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 385);
            this.Controls.Add(this.richTextBoxOutput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxIsolationLevel);
            this.Controls.Add(this.textBoxTypeBUsers);
            this.Controls.Add(this.textBoxTypeAUsers);
            this.Controls.Add(this.buttonStartSimulation);
            this.Name = "Form2";
            this.Text = "Transaction Simulation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartSimulation;
        private System.Windows.Forms.TextBox textBoxTypeAUsers;
        private System.Windows.Forms.TextBox textBoxTypeBUsers;
        private System.Windows.Forms.ComboBox comboBoxIsolationLevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
    }
}