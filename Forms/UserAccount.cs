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
// This form allows you to see some details about the logged in account
// also allows the user to set a profile picture for their account
//
#endregion
using KeyBit_ID.Classes;
using KeyBit_ID.Interfaces;
using KeyBit_ID.Properties;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KeyBit_ID.Forms
{
    public partial class UserAccount : MaterialForm
    {
        // create string
        string extension;

        // create string and set it to accountpath with the account file name set to Account + UserIDEncrypt.Key
        // so file names would appear as Account(motherboard serial number)
        readonly string AccountPath = Application.StartupPath + @"\data\accounts\Account" + UserIDEncrypt.Key;
        readonly string imageSafePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Dominion_Studios_Ltd\KeyBit_ID.exe_Url_4tc1szh3vhavsl0tvvldeen1eevck0dz\" + UserIDEncrypt.Key;
        // implement the interface object
        readonly IAccountOperations UD = new UserDelete();
        readonly IAccountOperations UB = new UserBackup();

        public UserAccount()
        {
            InitializeComponent();

        }

        private void UserAccount_Load(object sender, EventArgs e)
        {

            // call LoadAccountData method
            LoadAccountData();

        }

        private void MaterialButton4_Click(object sender, EventArgs e)
        {
            // close this form
            this.Close();
        }

        private void MaterialFloatingActionButton1_Click(object sender, EventArgs e)
        {
            // call ChangeAccountImage method
            ChangeAccountImage();
        }
        // method to set account data to the controls
        void LoadAccountData()
        {
            // set the account data to each control
            mlblID.Text = "ID: " + UserID.ID;
            mlblName.Text = "Name: " + UserID.FirstName + " " + UserID.LastName;
            mlblPassword.Text = "Password: **********";
            // try catch
            try
            {
                if (Settings.Default.AccountImage != null)
                {
                    // set picturebox image from the AccountImage setting (this is a file path)
                    pbAccountImage.Image = new Bitmap(Image.FromFile(Settings.Default.AccountImage));

                }
                else
                {
                    pbAccountImage.Image = new Bitmap(Resources.user_account_96px);
                }
            }
            catch (Exception e)
            {
                MaterialMessageBox.Show("We could not load your profile picture because you need to set one. Please do this now!\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, false);
            }
            finally
            {
                // set picturebox size mode to zoom image
                pbAccountImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }
        // method that allows the user to select an image for their account
        void ChangeAccountImage()
        {
            // instantiate a new OpenFileDialog()
            OpenFileDialog imageLoader = new OpenFileDialog
            {
                // set properties of the new OpenFileDialog()
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), // open the file dialog to the users pictures folder
                Filter = "Image Files(*.png; *.jpg; *.jpeg; *.gif; *.bmp)|*.png; *.jpg; *.jpeg; *.gif; *.bmp", // set the types of files the dialog can see and open
                FilterIndex = 1 // select the first filter (this case *.png files)
            };
            // show dialog and when you click OK 
            if (imageLoader.ShowDialog() == DialogResult.OK)
            {
                // try catch
                try
                {
                    if (pbAccountImage.Image != null)
                    {

                        pbAccountImage.Image.Dispose();
                        // set picturebox size mode to zoom
                        pbAccountImage.SizeMode = PictureBoxSizeMode.Zoom;
                        // load picturebox image from the selected OpenFileDialog file
                        pbAccountImage.Image = new Bitmap(imageLoader.FileName);
                        // set the variable to get the extension of the selected file
                        extension = Path.GetExtension(imageLoader.FileName);
                        // copy the file of the selected file and append the file name
                        // and save it under the account path so the program has a copy
                        // of the selected image
                        File.Delete(AccountPath + extension);
                        File.Copy(imageLoader.FileName, AccountPath + extension, true);
                        File.Delete(imageSafePath + extension);
                        File.Copy(imageLoader.FileName, imageSafePath + extension, true);
                        // set the AccountImage setting to the image saved under the
                        // account directory
                        Settings.Default.AccountImage = imageSafePath + extension;
                        // save setting
                        Settings.Default.Save();
                    }

                }
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
                    // dispose the OpenFileDialog()
                    imageLoader.Dispose();
                }
            }

        }

        private void MaterialButton1_Click(object sender, EventArgs e)
        {
            // show message warning about deleting account
            DialogResult message = MaterialMessageBox.Show("You are about to delete your " + Application.ProductName +
                " account!\n\nDeleting your account will remove any data associated with your account, including any saved ID's and can not be recovered after deletion.\n\n" +
                "If you do not want to continue, please click 'NO' to safely stop deletion.\n\nIf you understand and want to continue with deleting your account, " +
                "please Click 'YES'", "Warning: Please Read Carefully!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, false);
            // if click YES
            if (message == DialogResult.Yes)
            {
                // call GetAccountInfo()
                UB.GetAccountInfo();
                UD.AccountDelete();
            }
            // else if click NO
            else if (message == DialogResult.No)
            {

            }
        }

        private void MaterialButton2_Click(object sender, EventArgs e)
        {

            if (!File.Exists(Application.StartupPath + @"\backup" + UserIDEncrypt.Key + ".zip"))
            {
                // call GetAccountInfo()
                UB.GetAccountInfo();
                UB.AccountBackup();
            }
        }

        private void MaterialButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(Application.StartupPath + @"\backup" + UserIDEncrypt.Key + ".zip"))
                {
                    // call GetAccountInfo()
                    UB.GetAccountInfo();
                    UB.AccountRestore();
                }
            }
            catch (ArgumentException ex)
            {
                MaterialMessageBox.Show("Internal Error:\n" + ex.Message, "Error: Argument Exception", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
            }
            catch (FileNotFoundException ex)
            {
                MaterialMessageBox.Show("Attempts to access a file has failed\n" + ex.Message, "Error: File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
            }
            catch (DirectoryNotFoundException ex)
            {
                MaterialMessageBox.Show("Attempts to access a directory has failed\n" + ex.Message, "Error: Directory Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
            }
            catch (IOException ex)
            {
                MaterialMessageBox.Show("File access violation\n" + ex.Message, "Error: File System Access", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
            }

            catch (UnauthorizedAccessException ex)
            {
                MaterialMessageBox.Show("Security violation\n" + ex.Message, "Error: File System Access", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
            }
            catch (Exception ex)
            {
                MaterialMessageBox.Show("An error has occured\n" + ex.Message, "Error: Unknown Exception", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
            }
            finally
            {

            }
        }
    }
}
