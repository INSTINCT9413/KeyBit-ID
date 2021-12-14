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
// This class contains the logic to delete the users account and backups, as well as the Key Store file
//
#endregion
using KeyBit_ID.Forms;
using KeyBit_ID.Interfaces;
using MaterialSkin.Controls;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KeyBit_ID.Classes
{
    class UserDelete : UserIDEncrypt, IAccountOperations
    {
        // get set key
        public string key { get; set; }
        // get set dataLocation
        public string dataLocation { get; set; }
        // variable for backup location
        readonly string BackupLocation = DataLocation + @"\backup\";
        public UserDelete()
        {

        }
        // method to get account info
        public void GetAccountInfo()
        {
            // set key to Key
            key = Key;
            // set dataLocation to DataLocation
            dataLocation = DataLocation;
        }
        // method to delete account
        public void AccountDelete()
        {
            // call GetACcountInfo()
            GetAccountInfo();
            // display message about deleting the account
            var mess = MaterialMessageBox.Show("You are about to delete your account!\n\nThis can not be un-done. " +
                "To continue deleting your account please click \"YES\", to abort click \"NO\" ",
                "Are you sure you want to continue?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, false);
            // if the messagebox 'yes' button is clicked
            if (mess == DialogResult.Yes)
            {
                //try block
                try
                {
                    // if the account file exists
                    if (File.Exists(DataLocation + "Account" + key + ".dat"))
                    {
                        // delete the account file
                        File.Delete(DataLocation + "Account" + key + ".dat");
                    }
                    // if backup directory exists
                    if (Directory.Exists(BackupLocation))
                    {
                        // check if the backup file is there
                        if (File.Exists(BackupLocation + key + ".zip"))
                        {
                            // delete the .zip
                            File.Delete(BackupLocation + key + ".zip");
                        }
                        else
                        {
                            MaterialMessageBox.Show("KeyBit ID can not delete a backup file and folder!\n\n" +
                                "There may not be a file present or missing account ID, manually delete the backup folder!", "Access Error", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
                        }
                        // delete the backup folder
                        Directory.Delete(BackupLocation);
                    }
                    // if Key Store exists
                    if (File.Exists(Application.StartupPath + @"\KeyStore.accdb"))
                    {
                        // delete the Key Store
                        File.Delete(Application.StartupPath + @"\KeyStore.accdb");
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
                finally
                {

                }
                try
                {
                    // get OpenForm of type UserAccount
                    var useraccount = Application.OpenForms.OfType<UserAccount>().Single();
                    // dispose the picturebox
                    useraccount.pbAccountImage.Dispose();
                    // close the form
                    useraccount.Close();
                    // create directory info to get directory info
                    DirectoryInfo folderInfo = new DirectoryInfo(DataLocation);
                    // get files in the directory
                    foreach (FileInfo file in folderInfo.GetFiles())
                    {
                        // delete the files
                        file.Delete();
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
                finally
                {
                    MaterialMessageBox.Show("We deleted your account! You must restart KeyBit ID to continue", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.None, false);
                    System.Diagnostics.Process.Start(Application.StartupPath + @"\KeyBit ID.exe");
                    Application.Exit();
                }
            }
            // else if the messagebox 'np' was clicked 
            else if (mess == DialogResult.No)
            {
                // tell the user the delete process was aborted
                MaterialMessageBox.Show("We aborted deleting your account!", "Deletion Aborted Successful", MessageBoxButtons.OK, MessageBoxIcon.None, false);
            }
        }
        void IAccountOperations.AccountBackup()
        {
            throw new NotImplementedException();
        }
        void IAccountOperations.AccountRestore()
        {
            throw new NotImplementedException();
        }
    }
}
