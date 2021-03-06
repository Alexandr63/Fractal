
namespace LSystemDesigner
{
    partial class LoadLSystemDialog
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
            this._loadButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._lSystemsListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // _loadButton
            // 
            this._loadButton.Location = new System.Drawing.Point(632, 415);
            this._loadButton.Name = "_loadButton";
            this._loadButton.Size = new System.Drawing.Size(75, 23);
            this._loadButton.TabIndex = 0;
            this._loadButton.Text = "Загрузить";
            this._loadButton.UseVisualStyleBackColor = true;
            this._loadButton.Click += new System.EventHandler(this.LoadButtonClickEventHandler);
            // 
            // _cancelButton
            // 
            this._cancelButton.Location = new System.Drawing.Point(713, 415);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(75, 23);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "Отмена";
            this._cancelButton.UseVisualStyleBackColor = true;
            this._cancelButton.Click += new System.EventHandler(this.CancelButtonClickEventHandler);
            // 
            // _lSystemsListBox
            // 
            this._lSystemsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._lSystemsListBox.FormattingEnabled = true;
            this._lSystemsListBox.Location = new System.Drawing.Point(12, 12);
            this._lSystemsListBox.Name = "_lSystemsListBox";
            this._lSystemsListBox.Size = new System.Drawing.Size(776, 394);
            this._lSystemsListBox.TabIndex = 2;
            // 
            // LoadLSystemDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._lSystemsListBox);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._loadButton);
            this.Name = "LoadLSystemDialog";
            this.Text = "Загрузить L-систему";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _loadButton;
        private System.Windows.Forms.Button _cancelButton;
        private System.Windows.Forms.ListBox _lSystemsListBox;
    }
}