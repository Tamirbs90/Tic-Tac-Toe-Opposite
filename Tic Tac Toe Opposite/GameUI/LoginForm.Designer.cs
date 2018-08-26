namespace GameUI
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.PlayersLabel = new System.Windows.Forms.Label();
            this.Player1Label = new System.Windows.Forms.Label();
            this.Player1TextBox = new System.Windows.Forms.TextBox();
            this.Player2Label = new System.Windows.Forms.Label();
            this.Player2CheckBox = new System.Windows.Forms.CheckBox();
            this.Player2TextBox = new System.Windows.Forms.TextBox();
            this.BoardLabel = new System.Windows.Forms.Label();
            this.RowsLabel = new System.Windows.Forms.Label();
            this.NudRows = new System.Windows.Forms.NumericUpDown();
            this.ColsLabel = new System.Windows.Forms.Label();
            this.NudCols = new System.Windows.Forms.NumericUpDown();
            this.StartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NudRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCols)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayersLabel
            // 
            resources.ApplyResources(this.PlayersLabel, "PlayersLabel");
            this.PlayersLabel.Name = "PlayersLabel";
            // 
            // Player1Label
            // 
            resources.ApplyResources(this.Player1Label, "Player1Label");
            this.Player1Label.Name = "Player1Label";
            // 
            // Player1TextBox
            // 
            resources.ApplyResources(this.Player1TextBox, "Player1TextBox");
            this.Player1TextBox.Name = "Player1TextBox";
            // 
            // Player2Label
            // 
            resources.ApplyResources(this.Player2Label, "Player2Label");
            this.Player2Label.Name = "Player2Label";
            // 
            // Player2CheckBox
            // 
            resources.ApplyResources(this.Player2CheckBox, "Player2CheckBox");
            this.Player2CheckBox.Name = "Player2CheckBox";
            this.Player2CheckBox.UseVisualStyleBackColor = true;
            this.Player2CheckBox.CheckedChanged += new System.EventHandler(this.player2CheckBox_click);
            // 
            // Player2TextBox
            // 
            resources.ApplyResources(this.Player2TextBox, "Player2TextBox");
            this.Player2TextBox.Name = "Player2TextBox";
            // 
            // BoardLabel
            // 
            resources.ApplyResources(this.BoardLabel, "BoardLabel");
            this.BoardLabel.Name = "BoardLabel";
            // 
            // RowsLabel
            // 
            resources.ApplyResources(this.RowsLabel, "RowsLabel");
            this.RowsLabel.Name = "RowsLabel";
            // 
            // NudRows
            // 
            resources.ApplyResources(this.NudRows, "NudRows");
            this.NudRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NudRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NudRows.Name = "NudRows";
            this.NudRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NudRows.ValueChanged += new System.EventHandler(this.NudRows_ValueChanged);
            // 
            // ColsLabel
            // 
            resources.ApplyResources(this.ColsLabel, "ColsLabel");
            this.ColsLabel.Name = "ColsLabel";
            // 
            // NudCols
            // 
            resources.ApplyResources(this.NudCols, "NudCols");
            this.NudCols.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NudCols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NudCols.Name = "NudCols";
            this.NudCols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NudCols.ValueChanged += new System.EventHandler(this.NudCols_ValueChanged);
            // 
            // startButton
            // 
            resources.ApplyResources(this.StartButton, "startButton");
            this.StartButton.Name = "startButton";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // LoginForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.NudCols);
            this.Controls.Add(this.ColsLabel);
            this.Controls.Add(this.NudRows);
            this.Controls.Add(this.RowsLabel);
            this.Controls.Add(this.BoardLabel);
            this.Controls.Add(this.Player2TextBox);
            this.Controls.Add(this.Player2CheckBox);
            this.Controls.Add(this.Player2Label);
            this.Controls.Add(this.Player1TextBox);
            this.Controls.Add(this.Player1Label);
            this.Controls.Add(this.PlayersLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NudRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PlayersLabel;
        private System.Windows.Forms.Label Player1Label;
        private System.Windows.Forms.TextBox Player1TextBox;
        private System.Windows.Forms.Label Player2Label;
        private System.Windows.Forms.CheckBox Player2CheckBox;
        private System.Windows.Forms.TextBox Player2TextBox;
        private System.Windows.Forms.Label BoardLabel;
        private System.Windows.Forms.Label RowsLabel;
        private System.Windows.Forms.NumericUpDown NudRows;
        private System.Windows.Forms.Label ColsLabel;
        private System.Windows.Forms.NumericUpDown NudCols;
        private System.Windows.Forms.Button StartButton;
    }
}

