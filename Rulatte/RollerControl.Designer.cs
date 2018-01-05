namespace Rulatte
{
    partial class RollerControl
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
            this.components = new System.ComponentModel.Container();
            this.ProfileNameLinkLabel = new System.Windows.Forms.LinkLabel();
            this.laborListFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.rollButton = new System.Windows.Forms.Button();
            this.newLaborButton = new System.Windows.Forms.Button();
            this.saveTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // ProfileNameLinkLabel
            // 
            this.ProfileNameLinkLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProfileNameLinkLabel.AutoSize = true;
            this.ProfileNameLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ProfileNameLinkLabel.Location = new System.Drawing.Point(178, 0);
            this.ProfileNameLinkLabel.Name = "ProfileNameLinkLabel";
            this.ProfileNameLinkLabel.Size = new System.Drawing.Size(110, 25);
            this.ProfileNameLinkLabel.TabIndex = 1;
            this.ProfileNameLinkLabel.TabStop = true;
            this.ProfileNameLinkLabel.Text = "linkLabel1";
            this.ProfileNameLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ProfileNameLinkLabel_LinkClicked);
            // 
            // laborListFlowLayoutPanel
            // 
            this.laborListFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.laborListFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.laborListFlowLayoutPanel.Location = new System.Drawing.Point(0, 72);
            this.laborListFlowLayoutPanel.Name = "laborListFlowLayoutPanel";
            this.laborListFlowLayoutPanel.Size = new System.Drawing.Size(466, 250);
            this.laborListFlowLayoutPanel.TabIndex = 2;
            // 
            // saveAsButton
            // 
            this.saveAsButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.saveAsButton.Location = new System.Drawing.Point(294, 0);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(75, 23);
            this.saveAsButton.TabIndex = 3;
            this.saveAsButton.Text = "save as";
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.saveAsButton_Click);
            // 
            // rollButton
            // 
            this.rollButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rollButton.Location = new System.Drawing.Point(148, 39);
            this.rollButton.Name = "rollButton";
            this.rollButton.Size = new System.Drawing.Size(74, 27);
            this.rollButton.TabIndex = 5;
            this.rollButton.Text = "Go!";
            this.rollButton.UseVisualStyleBackColor = true;
            this.rollButton.Click += new System.EventHandler(this.rollButton_Click);
            // 
            // newLaborButton
            // 
            this.newLaborButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.newLaborButton.Location = new System.Drawing.Point(245, 39);
            this.newLaborButton.Name = "newLaborButton";
            this.newLaborButton.Size = new System.Drawing.Size(74, 27);
            this.newLaborButton.TabIndex = 7;
            this.newLaborButton.Text = "Add";
            this.newLaborButton.UseVisualStyleBackColor = true;
            this.newLaborButton.Click += new System.EventHandler(this.newLaborButton_Click);
            // 
            // saveTimer
            // 
            this.saveTimer.Interval = 1000;
            this.saveTimer.Tick += new System.EventHandler(this.saveTimer_Tick);
            // 
            // RollerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.newLaborButton);
            this.Controls.Add(this.rollButton);
            this.Controls.Add(this.saveAsButton);
            this.Controls.Add(this.laborListFlowLayoutPanel);
            this.Controls.Add(this.ProfileNameLinkLabel);
            this.Name = "RollerControl";
            this.Size = new System.Drawing.Size(466, 322);
            this.Load += new System.EventHandler(this.RollerControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel ProfileNameLinkLabel;
        private System.Windows.Forms.FlowLayoutPanel laborListFlowLayoutPanel;
        private System.Windows.Forms.Button saveAsButton;
        private System.Windows.Forms.Button rollButton;
        private System.Windows.Forms.Button newLaborButton;
        private System.Windows.Forms.Timer saveTimer;
    }
}
