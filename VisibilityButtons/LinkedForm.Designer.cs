namespace VisibilityButtons
{
    partial class LinkedForm
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
            this.panelLinked = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.submitButtonLink = new System.Windows.Forms.Button();
            this.buttonAllLinked = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelLinked
            // 
            this.panelLinked.AutoScroll = true;
            this.panelLinked.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelLinked.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLinked.Location = new System.Drawing.Point(12, 43);
            this.panelLinked.Name = "panelLinked";
            this.panelLinked.Size = new System.Drawing.Size(424, 182);
            this.panelLinked.TabIndex = 0;
            this.panelLinked.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLinked_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose Linked Models:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // submitButtonLink
            // 
            this.submitButtonLink.Location = new System.Drawing.Point(172, 248);
            this.submitButtonLink.Name = "submitButtonLink";
            this.submitButtonLink.Size = new System.Drawing.Size(98, 34);
            this.submitButtonLink.TabIndex = 2;
            this.submitButtonLink.Text = "OK";
            this.submitButtonLink.UseVisualStyleBackColor = true;
            this.submitButtonLink.Click += new System.EventHandler(this.submitButtonLink_Click);
            // 
            // buttonAllLinked
            // 
            this.buttonAllLinked.Location = new System.Drawing.Point(276, 248);
            this.buttonAllLinked.Name = "buttonAllLinked";
            this.buttonAllLinked.Size = new System.Drawing.Size(162, 34);
            this.buttonAllLinked.TabIndex = 3;
            this.buttonAllLinked.Text = "Hide/Unhide All";
            this.buttonAllLinked.UseVisualStyleBackColor = true;
            this.buttonAllLinked.Click += new System.EventHandler(this.buttonAllLinked_Click);
            // 
            // LinkedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 304);
            this.Controls.Add(this.buttonAllLinked);
            this.Controls.Add(this.submitButtonLink);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelLinked);
            this.Name = "LinkedForm";
            this.Text = "Hide/Unhide Linked Models";
            this.Load += new System.EventHandler(this.LinkedForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLinked;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submitButtonLink;
        private System.Windows.Forms.Button buttonAllLinked;
    }
}