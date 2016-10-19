/*--
 *  Author: michel.petrovic@roche.com
 *
 *  Copyright 2016 by F. Hoffmann-La Roche Ltd
 *
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace MascotBigFile
{
    /// <summary>
    /// Purpose: handling all the operation related to the Mascot Generic File format
    /// This is the full implementation of the Mascot Tip of the month published in Febrary 2016 
    /// </summary>
    /// <see cref="http://www.matrixscience.com/nl/201602/newsletter.html"/>
    class MascotManager
    {
        /// <summary>
        /// Build the today Mascot data folder like it is available on the Server running Mascot Server
        /// </summary>
        /// <example>C:\inetpub\mascot\data\20160915</example>
        /// <returns>path as a string</returns>
        public static string SetTodayMascotDataFolder()
        {
            string todayFolder = DateTime.Now.ToString("yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            string mascotDataFolder = Properties.Settings.Default.mascotDataFolder;

            return Path.Combine(mascotDataFolder, todayFolder);
        }

        /// <summary>
        /// Refactor the big MGF file by adding the search parameters as header & footer and deleting temporary files
        /// </summary>
        /// <param name="bigMgf">original MGF full filename</param>
        /// <param name="mascotInpFile">Mascot INP full filename</param>
        /// <returns>refactored MGF full file name</returns>
        public static string RefactorMgf(string bigMgf, string mascotInpFile)
        {
            string newMgfFileName = "new_" + Path.GetFileName(bigMgf);
            newMgfFileName = newMgfFileName.Replace(".mgf", ".tempmgf");

            string destinationFolder = Path.GetDirectoryName(bigMgf);
            string header = GenerateHeader(mascotInpFile, destinationFolder, newMgfFileName);
            string footer = GenerateFooter(mascotInpFile, destinationFolder, newMgfFileName);

            MergeFiles(destinationFolder, newMgfFileName, header, bigMgf, footer);

            DeleteTempFiles(header, footer);

            return Path.Combine(destinationFolder, newMgfFileName);
        }

        /// <summary>
        /// Submit the Mascot search by calling nph-mascot.exe
        /// </summary>
        /// <param name="refactoredMgfFile">refactored MGF file</param>
        public static void ResubmitToMascot(string refactoredMgfFile)
        {
            string mascotCgiFolder = Properties.Settings.Default.mascotCgiFolder;
            string nphMascot = Path.Combine(mascotCgiFolder, "nph-mascot.exe");

            string cmd1 = String.Format("cd \"{0}\"", Properties.Settings.Default.mascotCgiFolder);
            string cmd2 = String.Format("{0} 1 < \"{1}\"", nphMascot, refactoredMgfFile);

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "cmd.exe";
 
            startInfo.Arguments = String.Format("/C {0}&{1}", cmd1, cmd2);

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    WriteEventViewer(String.Format("{0} {1}", nphMascot, cmd2));

                    exeProcess.WaitForExit();

                    File.Delete(refactoredMgfFile);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }

        }

        /// <summary>
        /// Generate the MGF header
        /// </summary>
        /// <param name="mascotInpFile">Mascot INP full filename</param>
        /// <param name="destinationFolder">destination folder</param>
        /// <param name="newMgfFileName">new MGF full filename</param>
        /// <returns>header filename with prefix "header_"</returns>
        private static string GenerateHeader(string mascotInpFile, string destinationFolder, string newMgfFileName)
        {
            string header = FormatFileName(newMgfFileName, "header_", destinationFolder);

            using (System.IO.StreamReader reader = new System.IO.StreamReader(mascotInpFile))
            {
                string mascotBookmark1 = Properties.Settings.Default.mascotBookmark1;
                string mascotBookmark2 = Properties.Settings.Default.mascotBookmark2;

                System.IO.StreamWriter writer = new StreamWriter(header);
                string line;
                bool stop = false;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(mascotBookmark1))
                    {
                        line = String.Format("{0}{1}\"", mascotBookmark1, newMgfFileName);
                    }

                    if (line.Contains(mascotBookmark2))
                    {
                        stop = true;
                    }

                    writer.WriteLine(line);

                    if (stop)
                    {
                        writer.WriteLine();

                        break;
                    }
                }

                writer.Close();

            }

            return header;
        }

        /// <summary>
        /// Generate the MGF footer
        /// </summary>
        /// <param name="mascotInpFile">light Mascot INP full filename</param>
        /// <param name="destinationFolder">destination folder</param>
        /// <param name="newMgfFileName">new MGF filename</param>
        /// <returns>footer filename with refix "footer_"</returns>
        private static string GenerateFooter(string mascotInpFile, string destinationFolder, string newMgfFileName)
        {
            string footer = FormatFileName(newMgfFileName, "footer_", destinationFolder);

            using (System.IO.StreamReader reader = new System.IO.StreamReader(mascotInpFile))
            {
                string mascotBookmark2 = Properties.Settings.Default.mascotBookmark2;

                System.IO.StreamWriter writer = new StreamWriter(footer);
                string line;
                bool startWriting = false;

                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(mascotBookmark2))
                    {
                        startWriting = true;
                    }

                    if (startWriting && !line.Contains(mascotBookmark2))
                        writer.WriteLine(line);
                }

                writer.Close();
            }

            return footer;
        }

        /// <summary>
        /// Build the new MGF full filename by taking the reference MGF file, adding to it a prefix, renaming it to txt
        /// </summary>
        /// <param name="referenceFileName">reference MGF filename</param>
        /// <param name="prefix">prefix tag</param>
        /// <param name="destinationFolder">location of the new MGF file</param>
        /// <returns>new MGF full filename</returns>
        private static string FormatFileName(string referenceFileName, string prefix, string destinationFolder)
        {
            string fileName = Path.GetFileName(referenceFileName);
            fileName = prefix + fileName;

            fileName.Replace("mgf", "txt");

            return Path.Combine(destinationFolder, fileName);
        }

        /// <summary>
        /// Merging header, MGF and footer files together
        /// </summary>
        /// <param name="destinationFolder">destination folder</param>
        /// <param name="newMgfFileName">final MGF filename</param>
        /// <param name="header">header full filename</param>
        /// <param name="bigMgf">MGF full filename</param>
        /// <param name="footer">footer full filename</param>
        private static void MergeFiles(string destinationFolder, string newMgfFileName, string header, string bigMgf, string footer)
        {
            // copy head.txt+big.mgf+foot.txt input.txt
            string finalMgfFile = Path.Combine(destinationFolder, newMgfFileName);
            string cmd = String.Format("/C copy /b \"{0}\"+\"{1}\"+\"{2}\" \"{3}\"", header, bigMgf, footer, finalMgfFile);

            Process proc = Process.Start("cmd.exe", cmd);

            proc.WaitForExit();
        }

        /// <summary>
        /// Delete temporary files with prefix "header_" and "footer_"
        /// </summary>
        /// <param name="header">header full filename</param>
        /// <param name="footer">footer full filename</param>
        private static void DeleteTempFiles(string header, string footer)
        {
            File.Delete(header);
            File.Delete(footer);
        }

        /// <summary>
        /// Add information to the Microsoft EventLog viewer
        /// </summary>
        /// <param name="info">information to save</param>
        private static void WriteEventViewer(string info)
        {
            string sSource;
            string sLog;

            sSource = "MascotBigFile";
            sLog = "Application";

            if (!EventLog.SourceExists(sSource))
                EventLog.CreateEventSource(sSource, sLog);

            EventLog.WriteEntry(sSource, info, EventLogEntryType.Warning, 234);
        }

    }
}
