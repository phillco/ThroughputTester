namespace LANdrop.UI
{
    partial class ThroughputTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ThroughputTestForm ) );
            this.progressBar = new System.Windows.Forms.ProgressBar( );
            this.lblStatus = new System.Windows.Forms.Label( );
            this.fileProcessor = new System.ComponentModel.BackgroundWorker( );
            this.lblCurrentSpeed = new System.Windows.Forms.Label( );
            this.lblTotalTime = new System.Windows.Forms.Label( );
            this.lblChunkSizes = new System.Windows.Forms.Label( );
            this.SuspendLayout( );
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point( 12, 12 );
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size( 382, 23 );
            this.progressBar.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point( 12, 45 );
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size( 38, 13 );
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Ready";
            // 
            // fileProcessor
            // 
            this.fileProcessor.DoWork += new System.ComponentModel.DoWorkEventHandler( this.fileProcessor_DoWork );
            this.fileProcessor.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler( this.fileProcessor_ProgressChanged );
            // 
            // lblCurrentSpeed
            // 
            this.lblCurrentSpeed.AutoSize = true;
            this.lblCurrentSpeed.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCurrentSpeed.Location = new System.Drawing.Point( 12, 67 );
            this.lblCurrentSpeed.Name = "lblCurrentSpeed";
            this.lblCurrentSpeed.Size = new System.Drawing.Size( 39, 13 );
            this.lblCurrentSpeed.TabIndex = 2;
            this.lblCurrentSpeed.Text = "0 MB/s";
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.AutoSize = true;
            this.lblTotalTime.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblTotalTime.Location = new System.Drawing.Point( 9, 84 );
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size( 74, 13 );
            this.lblTotalTime.TabIndex = 3;
            this.lblTotalTime.Text = "32 min in total";
            // 
            // lblChunkSizes
            // 
            this.lblChunkSizes.AutoSize = true;
            this.lblChunkSizes.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblChunkSizes.Location = new System.Drawing.Point( 9, 101 );
            this.lblChunkSizes.Name = "lblChunkSizes";
            this.lblChunkSizes.Size = new System.Drawing.Size( 128, 13 );
            this.lblChunkSizes.TabIndex = 4;
            this.lblChunkSizes.Text = "Average chunk size: 0 KB";
            // 
            // ThroughputTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 406, 147 );
            this.Controls.Add( this.lblChunkSizes );
            this.Controls.Add( this.lblTotalTime );
            this.Controls.Add( this.lblCurrentSpeed );
            this.Controls.Add( this.lblStatus );
            this.Controls.Add( this.progressBar );
            this.Font = new System.Drawing.Font( "Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
            this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
            this.MaximizeBox = false;
            this.Name = "ThroughputTestForm";
            this.Text = "Simulated read throughput";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.ThroughputTestForm_FormClosing );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.ComponentModel.BackgroundWorker fileProcessor;
        private System.Windows.Forms.Label lblCurrentSpeed;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Label lblChunkSizes;
    }
}