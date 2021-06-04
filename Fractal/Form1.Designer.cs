namespace Fractal
{
    partial class SimpleFractalsForm
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
            this._nextStepButton = new System.Windows.Forms.Button();
            this._drawPanel = new System.Windows.Forms.Panel();
            this._stepLabel = new System.Windows.Forms.Label();
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
            // _nextStepButton
            // 
            this._nextStepButton.Location = new System.Drawing.Point(95, 13);
            this._nextStepButton.Name = "_nextStepButton";
            this._nextStepButton.Size = new System.Drawing.Size(75, 23);
            this._nextStepButton.TabIndex = 2;
            this._nextStepButton.Text = "Следующий шаг";
            this._nextStepButton.UseVisualStyleBackColor = true;
            this._nextStepButton.Click += new System.EventHandler(this.NextStepButtonClickEventHandler);
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
            // _stepLabel
            // 
            this._stepLabel.AutoSize = true;
            this._stepLabel.Location = new System.Drawing.Point(213, 18);
            this._stepLabel.Name = "_stepLabel";
            this._stepLabel.Size = new System.Drawing.Size(27, 13);
            this._stepLabel.TabIndex = 4;
            this._stepLabel.Text = "step";
            // 
            // SimpleFractalsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._stepLabel);
            this.Controls.Add(this._drawPanel);
            this.Controls.Add(this._nextStepButton);
            this.Controls.Add(this._resetButton);
            this.Name = "SimpleFractalsForm";
            this.Text = "Фракталы";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button _resetButton;
        private System.Windows.Forms.Button _nextStepButton;
        private System.Windows.Forms.Panel _drawPanel;
        private System.Windows.Forms.Label _stepLabel;
    }
}

