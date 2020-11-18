
namespace br.com.teczilla.datasus.view.controls
{
    partial class FormProgress
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
            this.customProgress1 = new br.com.teczilla.datasus.view.controls.CustomProgress();
            this.SuspendLayout();
            // 
            // customProgress1
            // 
            this.customProgress1.Location = new System.Drawing.Point(7, 12);
            this.customProgress1.Name = "customProgress1";
            this.customProgress1.Size = new System.Drawing.Size(588, 86);
            this.customProgress1.TabIndex = 0;
            // 
            // FormProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 117);
            this.ControlBox = false;
            this.Controls.Add(this.customProgress1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(623, 133);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(623, 133);
            this.Name = "FormProgress";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private CustomProgress customProgress1;
    }
}