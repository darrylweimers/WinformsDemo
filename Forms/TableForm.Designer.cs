namespace Template.Forms
{
    partial class TableForm
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
            this.listViewTransmit = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listViewTransmit
            // 
            this.listViewTransmit.Location = new System.Drawing.Point(12, 12);
            this.listViewTransmit.Name = "listViewTransmit";
            this.listViewTransmit.Size = new System.Drawing.Size(480, 457);
            this.listViewTransmit.TabIndex = 0;
            this.listViewTransmit.UseCompatibleStateImageBehavior = false;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 481);
            this.Controls.Add(this.listViewTransmit);
            this.Name = "TableForm";
            this.Text = "TableForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TableForm_FormClosing);
            this.Load += new System.EventHandler(this.TableForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewTransmit;

    }
}