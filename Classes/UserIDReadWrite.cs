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
//  This class contains the main logic for reading and writing 
//  the users account information. This class inherits the
//  UserIDEncrypt class. This class contains two methods
//  WriteAccount() writes account contents to disk
//  ReadAccount() reads account contents from disk
//
#endregion
using KeyBit_ID.Structs;
using MaterialSkin.Controls;
using System;
using System.IO;
using System.Windows.Forms;

namespace KeyBit_ID.Classes
{
    // inheritance of the UserUDEncrypt class
    class UserIDReadWrite : UserIDEncrypt
    {
        // instantiate a new Wait()
        readonly Wait wait = new Wait();
        public UserIDReadWrite()
        {

        }

        // Method WriteAccount()
        public void WriteAccount()
        {
            // check if director exists
            // uses a public string from UserIDEncrypt class (DataLocation)
            if (Directory.Exists(DataLocation))
            {
                // try catch
                try
                {
                    // using a UserIDEncrypt method to get a unique ID based on the machine motherboard
                    this.GetHWID();
                    // assign variables using the UserID class get set
                    ID = UserID.ID;
                    FirstName = UserID.FirstName;
                    LastName = UserID.LastName;
                    Email = UserID.Email;
                    Password = UserID.Password;
                    MasterPassword = UserID.MasterPassword;
                    // instantiate a new StreamWriter
                    StreamWriter accountWriter = new StreamWriter(DataLocation + "Account" + Key + ".dat");
                    // write the contents of the file
                    accountWriter.WriteLine(ID);
                    accountWriter.WriteLine(Key);
                    accountWriter.WriteLine(FirstName);
                    accountWriter.WriteLine(LastName);
                    accountWriter.WriteLine(Email);
                    accountWriter.WriteLine(Password);
                    accountWriter.WriteLine(MasterPassword);

                    // close the StreamWriter
                    accountWriter.Close();


                    // using a UserIDEncrypt method, encrypts the account file
                    EncryptFile(DataLocation + "Account" + Key + ".dat", KEY);
                    /* This block is under construction not needed right now
                    if (!File.Exists(DataLocation + "Account" + Key + "Remembered.dat"))
                    {
                        if (Settings.Default.RememberCredentials == true)
                        {
                            StreamWriter rememberedWriter = new StreamWriter(DataLocation + "Account" + Key + "Remembered.dat");
                            rememberedWriter.WriteLine(Email);
                            rememberedWriter.WriteLine(Password);
                            rememberedWriter.Close();
                            EncryptFile(DataLocation + "Account" + Key + "Remembered.dat", KEY);
                        }
                    }
                    */

                }
                // any standard exception
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
            else
            {

            }
        }
        // Method ReadAccount()
        public void ReadAccount()
        {
            // try catch
            try
            {
                // using a UserIDEncrypt method to get a unique ID based on the machine motherboard
                this.GetHWID();
                // fist thing is to decrypt the file so we can read it
                // using UserIDEncrypt method, decrypts the file
                DecryptFile(DataLocation + "Account" + Key + ".dat", KEY);
                /* This block is under construction not needed right now
                if (!File.Exists(DataLocation + "Account" + Key + "Remembered.dat"))
                {
                    if (Settings.Default.RememberCredentials == true)
                    {
                        StreamWriter rememberedWriter = new StreamWriter(DataLocation + "Account" + Key + "Remembered.dat");
                        rememberedWriter.WriteLine(Email);
                        rememberedWriter.WriteLine(Password);
                        rememberedWriter.Close();
                        EncryptFile(DataLocation + "Account" + Key + "Remembered.dat", KEY);
                    }
                }
                else
                {
                    if (Settings.Default.RememberCredentials == true)
                    {
                        DecryptFile(DataLocation + "Account" + Key + "Remembered.dat", KEY);
                    }
                }
                */

                // create an array and make it equal to the files contents
                string[] accountdetails = File.ReadAllLines(DataLocation + "Account" + Key + ".dat");

                // assign variables from the accountdetails array
                ID = Convert.ToInt32(accountdetails.GetValue(0));
                Key = (string)accountdetails.GetValue(1);
                FirstName = (string)accountdetails.GetValue(2);
                LastName = (string)accountdetails.GetValue(3);
                Email = (string)accountdetails.GetValue(4);
                Password = (string)accountdetails.GetValue(5);
                MasterPassword = (string)accountdetails.GetValue(6);

                // use the Time method and wait for 1 second
                // to be sure the assigning of values completes
                wait.Time(1);
                // similar to the WriteAccount() assignments
                // it is now backwards and since we are reading
                // values from the account file we want to
                // make the UserID class vales equal to logged in user.
                UserID.ID = ID;
                UserID.FirstName = FirstName;
                UserID.LastName = LastName;
                UserID.Email = Email;
                UserID.Password = Password;
                UserID.MasterPassword = MasterPassword;
                // now that we get the users info we want to call the EncryptFile method
                // to encrypt the file account file to keep it safe
                EncryptFile(DataLocation + "Account" + Key + ".dat", KEY);
                /* Another block that is under construction
                if (Settings.Default.RememberCredentials == true)
                {
                    EncryptFile(DataLocation + "Account" + Key + "Remembered.dat", KEY);
                }
                */
            }
            // any standard exception
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
    }
}
