namespace Fractal
{
    partial class TestFractalsForm
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
            this._resetButton = new System.Windows.Forms.Button();
            this._nextGenerationButton = new System.Windows.Forms.Button();
            this._drawPanel = new System.Windows.Forms.Panel();
            this._generationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _resetButton
            // 
            this._resetButton.Location = new System.Drawing.Point(13, 13);
            this._resetButton.Name = "_resetButton";
            this._resetButton.Size = new System.Drawing.Size(75, 23);
            this._resetButton.TabIndex = 1;
            this._resetButton.Text = "Сбросить";
            this._resetButton.UseVisualStyleBackColor = true;
            this._resetButton.Click += new System.EventHandler(this.ResetButtonClickEventHandler);
            // 
            // _nextGenerationButton
            // 
            this._nextGenerationButton.Location = new System.Drawing.Point(94, 13);
            this._nextGenerationButton.Name = "_nextGenerationButton";
            this._nextGenerationButton.Size = new System.Drawing.Size(149, 23);
            this._nextGenerationButton.TabIndex = 2;
            this._nextGenerationButton.Text = "Следующее поколение";
            this._nextGenerationButton.UseVisualStyleBackColor = true;
            this._nextGenerationButton.Click += new System.EventHandler(this.NextGenerationButtonClickEventHandler);
            // 
            // _drawPanel
            // 
            this._drawPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._drawPanel.Location = new System.Drawing.Point(13, 43);
            this._drawPanel.Name = "_drawPanel";
            this._drawPanel.Size = new System.Drawing.Size(775, 395);
            this._drawPanel.TabIndex = 3;
            this._drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawPanelPaintEventHandler);
            // 
            // _generationLabel
            // 
            this._generationLabel.AutoSize = true;
            this._generationLabel.Location = new System.Drawing.Point(249, 18);
            this._generationLabel.Name = "_generationLabel";
            this._generationLabel.Size = new System.Drawing.Size(27, 13);
            this._generationLabel.TabIndex = 4;
            this._generationLabel.Text = "step";
            // 
            // TestFractalsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._generationLabel);
            this.Controls.Add(this._drawPanel);
            this.Controls.Add(this._nextGenerationButton);
            this.Controls.Add(this._resetButton);
            this.Name = "TestFractalsForm";
            this.Text = "Фракталы";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _resetButton;
        private System.Windows.Forms.Button _nextGenerationButton;
        private System.Windows.Forms.Panel _drawPanel;
        private System.Windows.Forms.Label _generationLabel;
    }
}

