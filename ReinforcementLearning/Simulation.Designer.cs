namespace ReinforcementLearning
{
    partial class Simulation
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.runFullSimulation = new System.Windows.Forms.Button();
            this.mapPictureBox = new System.Windows.Forms.PictureBox();
            this.runNextStepButton = new System.Windows.Forms.Button();
            this.runNextScenarioButton = new System.Windows.Forms.Button();
            this.qTableDataGrid = new System.Windows.Forms.DataGridView();
            this.Origin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Target = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reward = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qTableDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // runFullSimulation
            // 
            this.runFullSimulation.Location = new System.Drawing.Point(11, 12);
            this.runFullSimulation.Name = "runFullSimulation";
            this.runFullSimulation.Size = new System.Drawing.Size(143, 29);
            this.runFullSimulation.TabIndex = 0;
            this.runFullSimulation.Text = "Run Full Simulation";
            this.runFullSimulation.UseVisualStyleBackColor = true;
            this.runFullSimulation.Click += new System.EventHandler(this.runFullSimulation_Click);
            // 
            // mapPictureBox
            // 
            this.mapPictureBox.Location = new System.Drawing.Point(11, 47);
            this.mapPictureBox.Name = "mapPictureBox";
            this.mapPictureBox.Size = new System.Drawing.Size(773, 741);
            this.mapPictureBox.TabIndex = 2;
            this.mapPictureBox.TabStop = false;
            this.mapPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mapPictureBox_Paint);
            // 
            // runNextStepButton
            // 
            this.runNextStepButton.Location = new System.Drawing.Point(161, 12);
            this.runNextStepButton.Name = "runNextStepButton";
            this.runNextStepButton.Size = new System.Drawing.Size(143, 29);
            this.runNextStepButton.TabIndex = 3;
            this.runNextStepButton.Text = "Run Next Step";
            this.runNextStepButton.UseVisualStyleBackColor = true;
            this.runNextStepButton.Click += new System.EventHandler(this.runNextStepButton_Click);
            // 
            // runNextScenarioButton
            // 
            this.runNextScenarioButton.Location = new System.Drawing.Point(311, 12);
            this.runNextScenarioButton.Name = "runNextScenarioButton";
            this.runNextScenarioButton.Size = new System.Drawing.Size(143, 29);
            this.runNextScenarioButton.TabIndex = 4;
            this.runNextScenarioButton.Text = "Run Next Scenario";
            this.runNextScenarioButton.UseVisualStyleBackColor = true;
            this.runNextScenarioButton.Click += new System.EventHandler(this.runNextScenarioButton_Click);
            // 
            // qTableDataGrid
            // 
            this.qTableDataGrid.AllowUserToAddRows = false;
            this.qTableDataGrid.AllowUserToDeleteRows = false;
            this.qTableDataGrid.AllowUserToOrderColumns = true;
            this.qTableDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.qTableDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Origin,
            this.Target,
            this.Reward});
            this.qTableDataGrid.Location = new System.Drawing.Point(791, 47);
            this.qTableDataGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.qTableDataGrid.Name = "qTableDataGrid";
            this.qTableDataGrid.ReadOnly = true;
            this.qTableDataGrid.RowHeadersWidth = 51;
            this.qTableDataGrid.RowTemplate.Height = 25;
            this.qTableDataGrid.Size = new System.Drawing.Size(385, 740);
            this.qTableDataGrid.TabIndex = 5;
            // 
            // Origin
            // 
            this.Origin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Origin.DataPropertyName = "OriginalPositionCoordenates";
            this.Origin.HeaderText = "Origin";
            this.Origin.MinimumWidth = 6;
            this.Origin.Name = "Origin";
            this.Origin.ReadOnly = true;
            this.Origin.Width = 79;
            // 
            // Target
            // 
            this.Target.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Target.DataPropertyName = "TargetPositionCoordenates";
            this.Target.HeaderText = "Target";
            this.Target.MinimumWidth = 6;
            this.Target.Name = "Target";
            this.Target.ReadOnly = true;
            this.Target.Width = 79;
            // 
            // Reward
            // 
            this.Reward.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Reward.DataPropertyName = "Reward";
            this.Reward.HeaderText = "Reward";
            this.Reward.MinimumWidth = 6;
            this.Reward.Name = "Reward";
            this.Reward.ReadOnly = true;
            // 
            // Simulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 803);
            this.Controls.Add(this.qTableDataGrid);
            this.Controls.Add(this.runNextScenarioButton);
            this.Controls.Add(this.runNextStepButton);
            this.Controls.Add(this.mapPictureBox);
            this.Controls.Add(this.runFullSimulation);
            this.Name = "Simulation";
            this.Text = "Reinforcement Learning";
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qTableDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button runFullSimulation;
        private PictureBox mapPictureBox;
        private Button runNextStepButton;
        private Button runNextScenarioButton;
        private DataGridView qTableDataGrid;
        private DataGridViewTextBoxColumn Origin;
        private DataGridViewTextBoxColumn Target;
        private DataGridViewTextBoxColumn Reward;
    }
}