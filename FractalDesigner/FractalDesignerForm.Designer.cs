
namespace FractalDesigner
{
    partial class FractalDesignerForm
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
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._editFractalToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._loadToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._resetToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._nextGenerationToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._generationToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this._drawPanel = new System.Windows.Forms.Panel();
            this._toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _toolStrip
            // 
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._editFractalToolStripButton,
            this._loadToolStripButton,
            this.toolStripSeparator1,
            this._resetToolStripButton,
            this._nextGenerationToolStripButton,
            this.toolStripSeparator2,
            this._generationToolStripLabel});
            this._toolStrip.Location = new System.Drawing.Point(0, 0);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(812, 25);
            this._toolStrip.TabIndex = 4;
            this._toolStrip.Text = "toolStrip1";
            // 
            // _editFractalToolStripButton
            // 
            this._editFractalToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._editFractalToolStripButton.Image = global::FractalDesigner.Properties.Resources.Edit;
            this._editFractalToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._editFractalToolStripButton.Name = "_editFractalToolStripButton";
            this._editFractalToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._editFractalToolStripButton.Text = "Редактировать фрактал";
            this._editFractalToolStripButton.Click += new System.EventHandler(this.EdtiFractalToolStripButtonClickEventHandler);
            // 
            // _loadToolStripButton
            // 
            this._loadToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._loadToolStripButton.Image = global::FractalDesigner.Properties.Resources.Load;
            this._loadToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._loadToolStripButton.Name = "_loadToolStripButton";
            this._loadToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._loadToolStripButton.Text = "Загрузить фрактал";
            this._loadToolStripButton.Click += new System.EventHandler(this.LoadToolStripButtonClickEventHandler);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _resetToolStripButton
            // 
            this._resetToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._resetToolStripButton.Image = global::FractalDesigner.Properties.Resources.Reset;
            this._resetToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._resetToolStripButton.Name = "_resetToolStripButton";
            this._resetToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._resetToolStripButton.Text = "Сбросить поколения в 0";
            this._resetToolStripButton.Click += new System.EventHandler(this.ResetToolStripButtonClickEventHandler);
            // 
            // _nextGenerationToolStripButton
            // 
            this._nextGenerationToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._nextGenerationToolStripButton.Image = global::FractalDesigner.Properties.Resources.NextGeneration;
            this._nextGenerationToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._nextGenerationToolStripButton.Name = "_nextGenerationToolStripButton";
            this._nextGenerationToolStripButton.Size = new System.Drawing.Size(23, 22);
            this._nextGenerationToolStripButton.Text = "Следующее поколение";
            this._nextGenerationToolStripButton.Click += new System.EventHandler(this.NextGenerationToolStripButtonClickEventHandler);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _generationToolStripLabel
            // 
            this._generationToolStripLabel.Name = "_generationToolStripLabel";
            this._generationToolStripLabel.Size = new System.Drawing.Size(65, 22);
            this._generationToolStripLabel.Text = "Generation";
            // 
            // _drawPanel
            // 
            this._drawPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._drawPanel.Location = new System.Drawing.Point(0, 28);
            this._drawPanel.Name = "_drawPanel";
            this._drawPanel.Size = new System.Drawing.Size(812, 416);
            this._drawPanel.TabIndex = 5;
            this._drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPanelPaintEventHandler);
            // 
            // FractalDesignerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 445);
            this.Controls.Add(this._drawPanel);
            this.Controls.Add(this._toolStrip);
            this.Name = "FractalDesignerForm";
            this.Text = "Дизайнер фракталов";
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripButton _editFractalToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _resetToolStripButton;
        private System.Windows.Forms.ToolStripButton _nextGenerationToolStripButton;
        private System.Windows.Forms.ToolStripLabel _generationToolStripLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel _drawPanel;
        private System.Windows.Forms.ToolStripButton _loadToolStripButton;
    }
}

