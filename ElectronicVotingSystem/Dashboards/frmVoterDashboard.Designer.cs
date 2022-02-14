namespace ElectronicVotingSystem.Dashboards
{
    partial class frmVoterDashboard
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
            this.components = new System.ComponentModel.Container();
            this.lblElections = new System.Windows.Forms.Label();
            this.chklbVotes = new System.Windows.Forms.CheckedListBox();
            this.lblVote = new System.Windows.Forms.Label();
            this.lblHello = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lsbxElections = new System.Windows.Forms.ListBox();
            this.btnCastVote = new System.Windows.Forms.Button();
            this.electionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.electionBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.electionBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.electionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.electionBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.electionBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblElections
            // 
            this.lblElections.AutoSize = true;
            this.lblElections.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElections.Location = new System.Drawing.Point(97, 81);
            this.lblElections.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblElections.Name = "lblElections";
            this.lblElections.Size = new System.Drawing.Size(144, 36);
            this.lblElections.TabIndex = 1;
            this.lblElections.Text = "Elections:";
            // 
            // chklbVotes
            // 
            this.chklbVotes.CheckOnClick = true;
            this.chklbVotes.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chklbVotes.FormattingEnabled = true;
            this.chklbVotes.Location = new System.Drawing.Point(345, 132);
            this.chklbVotes.Margin = new System.Windows.Forms.Padding(4);
            this.chklbVotes.Name = "chklbVotes";
            this.chklbVotes.Size = new System.Drawing.Size(320, 384);
            this.chklbVotes.TabIndex = 2;
            this.chklbVotes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklbVotes_ItemCheck);
            // 
            // lblVote
            // 
            this.lblVote.AutoSize = true;
            this.lblVote.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVote.Location = new System.Drawing.Point(455, 81);
            this.lblVote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVote.Name = "lblVote";
            this.lblVote.Size = new System.Drawing.Size(87, 36);
            this.lblVote.TabIndex = 3;
            this.lblVote.Text = "Vote:";
            // 
            // lblHello
            // 
            this.lblHello.AutoSize = true;
            this.lblHello.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHello.Location = new System.Drawing.Point(16, 27);
            this.lblHello.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(103, 36);
            this.lblHello.TabIndex = 4;
            this.lblHello.Text = "Hello: ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(129, 27);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(97, 36);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name";
            // 
            // lsbxElections
            // 
            this.lsbxElections.Font = new System.Drawing.Font("Microsoft YaHei UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbxElections.FormattingEnabled = true;
            this.lsbxElections.ItemHeight = 20;
            this.lsbxElections.Location = new System.Drawing.Point(16, 132);
            this.lsbxElections.Margin = new System.Windows.Forms.Padding(4);
            this.lsbxElections.Name = "lsbxElections";
            this.lsbxElections.Size = new System.Drawing.Size(320, 384);
            this.lsbxElections.TabIndex = 6;
            this.lsbxElections.SelectedIndexChanged += new System.EventHandler(this.lsbxElections_SelectedIndexChanged);
            // 
            // btnCastVote
            // 
            this.btnCastVote.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCastVote.Location = new System.Drawing.Point(675, 274);
            this.btnCastVote.Margin = new System.Windows.Forms.Padding(4);
            this.btnCastVote.Name = "btnCastVote";
            this.btnCastVote.Size = new System.Drawing.Size(188, 95);
            this.btnCastVote.TabIndex = 7;
            this.btnCastVote.Text = "CAST VOTE";
            this.btnCastVote.UseVisualStyleBackColor = true;
            this.btnCastVote.Click += new System.EventHandler(this.btnCastVote_Click);
            // 
            // electionBindingSource
            // 
            this.electionBindingSource.DataSource = typeof(ElectronicVotingSystemService.Data_Models.Election);
            // 
            // electionBindingSource1
            // 
            this.electionBindingSource1.DataSource = typeof(ElectronicVotingSystemService.Data_Models.Election);
            // 
            // electionBindingSource2
            // 
            this.electionBindingSource2.DataSource = typeof(ElectronicVotingSystemService.Data_Models.Election);
            // 
            // frmVoterDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 554);
            this.Controls.Add(this.btnCastVote);
            this.Controls.Add(this.lsbxElections);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblHello);
            this.Controls.Add(this.lblVote);
            this.Controls.Add(this.chklbVotes);
            this.Controls.Add(this.lblElections);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(890, 601);
            this.MinimumSize = new System.Drawing.Size(890, 601);
            this.Name = "frmVoterDashboard";
            this.Text = "Vote";
            ((System.ComponentModel.ISupportInitialize)(this.electionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.electionBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.electionBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblElections;
        private System.Windows.Forms.CheckedListBox chklbVotes;
        private System.Windows.Forms.Label lblVote;
        private System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ListBox lsbxElections;
        private System.Windows.Forms.BindingSource electionBindingSource;
        private System.Windows.Forms.BindingSource electionBindingSource1;
        private System.Windows.Forms.BindingSource electionBindingSource2;
        private System.Windows.Forms.Button btnCastVote;
    }
}