namespace VisibilityButtons
{
    partial class ImportForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.panelImport = new System.Windows.Forms.Panel();
            this.buttonSubmitImport = new System.Windows.Forms.Button();
            this.buttonAllImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose Import Instances:";
            // 
            // panelImport
            // 
            this.panelImport.AutoScroll = true;
            this.panelImport.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelImport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelImport.Location = new System.Drawing.Point(15, 39);
            this.panelImport.Name = "panelImport";
            this.panelImport.Size = new System.Drawing.Size(415, 175);
            this.panelImport.TabIndex = 1;
            // 
            // buttonSubmitImport
            // 
            this.buttonSubmitImport.Location = new System.Drawing.Point(171, 233);
            this.buttonSubmitImport.Name = "buttonSubmitImport";
            this.buttonSubmitImport.Size = new System.Drawing.Size(93, 35);
            this.buttonSubmitImport.TabIndex = 0;
            this.buttonSubmitImport.Text = "OK";
            this.buttonSubmitImport.UseVisualStyleBackColor = true;
            this.buttonSubmitImport.Click += new System.EventHandler(this.buttonSubmitImport_Click);
            // 
            // buttonAllImport
            // 
            this.buttonAllImport.Location = new System.Drawing.Point(268, 233);
            this.buttonAllImport.Name = "buttonAllImport";
            this.buttonAllImport.Size = new System.Drawing.Size(162, 34);
            this.buttonAllImport.TabIndex = 4;
            this.buttonAllImport.Text = "Hide/Unhide All";
            this.buttonAllImport.UseVisualStyleBackColor = true;
            this.buttonAllImport.Click += new System.EventHandler(this.buttonAllImport_Click);
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 290);
            this.Controls.Add(this.buttonAllImport);
            this.Controls.Add(this.buttonSubmitImport);
            this.Controls.Add(this.panelImport);
            this.Controls.Add(this.label1);
            this.Name = "ImportForm";
            this.Text = "Hide/Unhide Import Instances";
            this.Load += new System.EventHandler(this.ImportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelImport;
        private System.Windows.Forms.Button buttonSubmitImport;
        private System.Windows.Forms.Button buttonAllImport;
    }
}