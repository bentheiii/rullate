﻿namespace Rulatte
{
    partial class LaborControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.laborNameLabel = new System.Windows.Forms.Label();
            this.weightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.enabledCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.weightNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // laborNameLabel
            // 
            this.laborNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.laborNameLabel.Location = new System.Drawing.Point(3, 0);
            this.laborNameLabel.Name = "laborNameLabel";
            this.laborNameLabel.Size = new System.Drawing.Size(120, 55);
            this.laborNameLabel.TabIndex = 0;
            this.laborNameLabel.Text = "???";
            this.laborNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.laborNameLabel.Click += new System.EventHandler(this.laborNameLabel_Click);
            // 
            // weightNumericUpDown
            // 
            this.weightNumericUpDown.DecimalPlaces = 1;
            this.weightNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.weightNumericUpDown.Location = new System.Drawing.Point(129, 9);
            this.weightNumericUpDown.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.weightNumericUpDown.Name = "weightNumericUpDown";
            this.weightNumericUpDown.Size = new System.Drawing.Size(36, 20);
            this.weightNumericUpDown.TabIndex = 1;
            this.weightNumericUpDown.ValueChanged += new System.EventHandler(this.weightNumericUpDown_ValueChanged);
            // 
            // enabledCheckBox
            // 
            this.enabledCheckBox.AutoSize = true;
            this.enabledCheckBox.Location = new System.Drawing.Point(157, 35);
            this.enabledCheckBox.Name = "enabledCheckBox";
            this.enabledCheckBox.Size = new System.Drawing.Size(64, 17);
            this.enabledCheckBox.TabIndex = 2;
            this.enabledCheckBox.Text = "enabled";
            this.enabledCheckBox.UseVisualStyleBackColor = true;
            this.enabledCheckBox.CheckedChanged += new System.EventHandler(this.enabledCheckBox_CheckedChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(171, 6);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(91, 23);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Remove";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // LaborControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.enabledCheckBox);
            this.Controls.Add(this.weightNumericUpDown);
            this.Controls.Add(this.laborNameLabel);
            this.Name = "LaborControl";
            this.Size = new System.Drawing.Size(265, 55);
            this.Load += new System.EventHandler(this.LaborControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.weightNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label laborNameLabel;
        private System.Windows.Forms.NumericUpDown weightNumericUpDown;
        private System.Windows.Forms.CheckBox enabledCheckBox;
        private System.Windows.Forms.Button deleteButton;
    }
}
