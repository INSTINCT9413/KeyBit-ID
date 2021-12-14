#region Header Block
//  About this Program
//  
//  Programmer:     Jacob Brookhouse
//  Class:          CITP 280 - 70591
//  Application:    KeyBit ID - Password Manager
//  Description:    KeyBit ID is a password manager that allows a user to save sensitive
//                  information, such as passwords and account information.
//
#endregion
#region About this file
//
// This class contains the logic to create a backup as a .zip file, allows the user to backup and restore their account
//
#endregion

using KeyBit_ID.Forms;
using KeyBit_ID.Interfaces;
using MaterialSkin.Controls;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace KeyBit_ID.Classes
{
    class UserBackup : UserIDEncrypt, IAccountOperations
    {
        // get set key
        public string key { get; set; }
        // get set datalocation
        public string dataLocation { get; set; }

        // variable for backup location
        readonly string BackupLocation = DataLocation + @"\backup\";
        public UserBackup()
        {

        }
        // method to get account info
        public void GetAccountInfo()
        {
            // set key to Key
            key = Key;
            // set datalocation to Datalocation
            dataLocation = DataLocation;
        }
        // Method to backup account
        public void AccountBackup()
        {

            // try block
            try
            {
                // if an account file exists
                if (File.Exists(DataLocation + "Account" + key + ".dat"))
                {
                    // get OpenForm of UserAccount
                    var useraccount = Application.OpenForms.OfType<UserAccount>().Single();
                    // dispose the picturebox
                    useraccount.pbAccountImage.Dispose();
                    // close the UserAccount form
                    useraccount.Close();
                    //DirectoryInfo folderInfo = new DirectoryInfo(DataLocation);
                    // while directory does not exist
                    while (!Directory.Exists(BackupLocation))
                    {
                        // create the directory
                        Directory.CreateDirectory(BackupLocation);

                    }
                    // zip files located in dataLocation and save a .zip in the BackupLocation
                    ZipFile.CreateFromDirectory(dataLocation, BackupLocation + @"\" + key + @".zip");
                    // tell user the backup was successful
                    MaterialMessageBox.Show("We Created your account backup!", "Account Backup Successful", MessageBoxButtons.OK, MessageBoxIcon.None, false);

                }
            }
            // all the catch exceptions
            catch (ArgumentException e)
            {
                MaterialMessageBox.Show("Internal Error:\n" + e.Message, "Error: Argument Exception", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
            }
            catch (FileNotFoundException e)
            {
                MaterialMessageBox.Show("Attempts to access a file has failed\n" + e.Message, "Error: File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
            }
            catch (DirectoryNotFoundException e)
            {
                MaterialMessageBox.Show("Attempts to access a directory has failed\n" + e.Message, "Error: Directory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
            }
            catch (IOException e)
            {
                MaterialMessageBox.Show("File access violation\n" + e.Message, "Error: File System Access", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
            }

            catch (UnauthorizedAccessException e)
            {
                MaterialMessageBox.Show("Security violation\n" + e.Message, "Error: File System Access", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
            }
            catch (Exception e)
            {
                MaterialMessageBox.Show("An error has occured\n" + e.Message, "Error: Unknown Exception", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
            }
        }
        // Method to restore account
        public void AccountRestore()
        {
            // call GetAccountInfo()
            GetAccountInfo();
            // try block
            try
            {
                // if backup directory exists
                if (Directory.Exists(BackupLocation))
                {
                    // then check if the backup zip exists
                    if (File.Exists(BackupLocation + @"\" + key + @".zip"))
                    {
                        // create directory info to get info for directory
                        DirectoryInfo folderInfo = new DirectoryInfo(DataLocation);
                        // for each to get all files in directory
                        foreach (FileInfo file in folderInfo.GetFiles())
                        {
                            // delete the files
                            file.Delete();
                        }
                        // extract the .zip to the dataLocataion
                        ZipFile.ExtractToDirectory(BackupLocation + @"\" + key + @".zip", dataLocation);
                        // tell user that the restore was successful
                        MaterialMessageBox.Show("We restored your account backup!", "Resotred Backup Successful", MessageBoxButtons.OK, MessageBoxIcon.None, false);
                    }
                }
            }
            // all the catch exceptions
            catch (ArgumentException e)
            {
                MaterialMessageBox.Show("Internal Error:\n" + e.Message, "Error: Argument Exception", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
            }
            catch (FileNotFoundException e)
            {
                MaterialMessageBox.Show("Attempts to access a file has failed\n" + e.Message, "Error: File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
            }
            catch (DirectoryNotFoundException e)
            {
                MaterialMessageBox.Show("Attempts to access a directory has failed\n" + e.Message, "Error: Directory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
            }
            catch (IOException e)
            {
                MaterialMessageBox.Show("File access violation\n" + e.Message, "Error: File System Access", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
            }

            catch (UnauthorizedAccessException e)
            {
                MaterialMessageBox.Show("Security violation\n" + e.Message, "Error: File System Access", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
            }
            catch (Exception e)
            {
                MaterialMessageBox.Show("An error has occured\n" + e.Message, "Error: Unknown Exception", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
            }

        }

        void IAccountOperations.AccountDelete()
        {
            throw new NotImplementedException();
        }
    }
}
