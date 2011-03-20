using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LANdrop.Networking;

namespace LANdrop.UI
{
    public partial class ThroughputTestForm : Form
    {
        private Queue<FileInfo> files;

        private List<long> chunkSizes = new List<long>( );

        private int startTime; // tickCount
        private long bytesRead;

        public ThroughputTestForm( ICollection<FileInfo> files )
        {
            InitializeComponent( );
            this.files = new Queue<FileInfo>( files );
            fileProcessor.RunWorkerAsync( );
        }

        private void fileProcessor_DoWork( object sender, DoWorkEventArgs e )
        {
            startTime = Environment.TickCount;
            int totalFiles = files.Count;
            int numFilesProcessed = 0;
            while ( files.Count > 0 )
            {
                FileInfo file = files.Dequeue( );
                using ( FileStream fileInStream = new FileStream( file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite ) )
                {
                    for ( long i = 0; i < file.Length; )
                    {
                        if ( IsDisposed )
                            return;

                        // Calculate the number of bytes we're about to read.
                        int numBytes = (int) Math.Min( Protocol.TransferChunkSize, file.Length - i );

                        // Read in the chunk from a file, and ignore it.
                        byte[] chunk = new byte[numBytes];
                        fileInStream.Read( chunk, 0, numBytes );
                        bytesRead += numBytes;
                        i += numBytes;
                        chunkSizes.Add( numBytes );
                        if ( chunkSizes.Count > 1000 )
                            chunkSizes.RemoveAt( 0 );

                        if ( !IsDisposed )
                            this.Invoke( new MethodInvoker( delegate
                            {
                                progressBar.Value = (int) ( 100.0 * i / file.Length );

                                lblStatus.Text = String.Format( "{0} of {1}: {2} ({3} of {4})", numFilesProcessed + 1, totalFiles, file.Name,
                                    Util.FormatFileSize( i ), Util.FormatFileSize( file.Length ) );

                                lblTotalTime.Text = (int) Math.Round( ( Environment.TickCount - startTime ) / 1000.0 ) + " seconds";

                                lblChunkSizes.Text = "Average chunk size: " + Util.FormatFileSize( averageChunkSize( ) );

                                if ( Environment.TickCount - startTime > 0 )
                                    lblCurrentSpeed.Text = Util.FormatFileSize( 1000.0 * bytesRead / (double) ( Environment.TickCount - startTime ) ) + "/s";
                            } ) );
                    }
                }

                numFilesProcessed++;
            }

            if ( !IsDisposed )
                this.Invoke( new MethodInvoker( delegate
                {
                    lblStatus.Text = "All done! (" + numFilesProcessed + " files)";
                } ) );
        }

        private long averageChunkSize( )
        {
            if ( chunkSizes.Count == 0 )
                return 0;

            long total = 0;
            chunkSizes.ForEach( size => total += size );
            return total / chunkSizes.Count;
        }

        private void fileProcessor_ProgressChanged( object sender, ProgressChangedEventArgs e )
        {
        }

        private void ThroughputTestForm_FormClosing( object sender, FormClosingEventArgs e )
        {

        }
    }
}
