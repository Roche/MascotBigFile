/*--
 *  Author: michel.petrovic@roche.com
 *
 *  Copyright 2016 by F. Hoffmann-La Roche Ltd
 *
*/
using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace MascotBigFile
{
    /// <summary>
    /// Form used to select the Mascot INP and Mascot MGF filename in order to merge them and to submit them to Mascot Server
    /// </summary>
    public partial class Submit : Form
    {
        public Submit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Submit a  Mascot Search to Mascot Server knowing the MGF and INP files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            this.buttonSubmit.Enabled = false;

            string refactoredMgfFile = MascotManager.RefactorMgf(this.textBoxBigMgf.Text, this.textBoxSearchParameters.Text);
            MascotManager.ResubmitToMascot(refactoredMgfFile);

            this.buttonSubmit.Enabled = true;
        }

        /// <summary>
        /// Open the Mascot Search Log web page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMascot_Click(object sender, EventArgs e)
        {
            String searchLog = Properties.Settings.Default.mascotSearchLog;
            searchLog = searchLog.Replace("computer_name", System.Environment.MachineName);
            System.Diagnostics.Process.Start(searchLog);
        }

        /// <summary>
        /// File browser for selecting the Mascot MGF file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBigMgf_Click(object sender, EventArgs e)
        {
            this.textBoxBigMgf.Text = SelectFile("", "MGF Files (.mgf)|*.mgf");
            ActivateSubmit(textBoxBigMgf.Text, textBoxSearchParameters.Text);
        }

        /// <summary>
        /// File browser for selecting the Mascot INP file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonInpFile_Click(object sender, EventArgs e)
        {
            string mascotParametersFile;

            string mascotTodayFolder = MascotManager.SetTodayMascotDataFolder();

            mascotParametersFile = SelectFile(mascotTodayFolder, "Mascot Search (.inp)|*.inp");

            if (mascotParametersFile.Length == 0)
                return;

            FileInfo info = new FileInfo(mascotParametersFile);

            if (info.Length < Properties.Settings.Default.searchParametersFileSizeInBytesMax)
            {
                this.textBoxSearchParameters.Text = mascotParametersFile;
                ActivateSubmit(textBoxBigMgf.Text, textBoxSearchParameters.Text);
            }
            else
                MessageBox.Show(@Properties.Settings.Default.searchPamameterFileInfo, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Open the file browser with a default file filter
        /// </summary>
        /// <param name="defaultFolder"></param>
        /// <param name="filter"></param>
        /// <returns>full filename</returns>
        private string SelectFile(string defaultFolder, string filter)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (defaultFolder.Length>0)
                openFileDialog1.InitialDirectory = defaultFolder;

            // Set filter options and filter index.
            openFileDialog1.Filter = filter;
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = (openFileDialog1.ShowDialog() == DialogResult.OK);

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                return openFileDialog1.FileName;
            }
            return "";
        }

        /// <summary>
        /// Activate the Submit button if Mascot MGF and INP files have been provided by the user
        /// </summary>
        /// <param name="bigMgfFile"></param>
        /// <param name="mascotInpFile"></param>
        private void ActivateSubmit(string bigMgfFile, string mascotInpFile)
        {
            buttonSubmit.Enabled = (File.Exists(bigMgfFile) && File.Exists(mascotInpFile));
        }

        /// <summary>
        /// Initiate the URL link for the Matrix Science Web article from February 2016 behind the "Mascot tip of the month"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Submit_Load(object sender, EventArgs e)
        {
            // Add a link to the LinkLabel.
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "http://www.matrixscience.com/nl/201602/newsletter.html";

            MascotTipOfTheMonth.Links.Add(link);

        }

        /// <summary>
        /// Open the Mascot tip of the month
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MascotTipOfTheMonth_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }
    }
}
