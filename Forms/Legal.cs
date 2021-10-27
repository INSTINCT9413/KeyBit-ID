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
//  This form shows the Legal docs and license
//
#endregion
using KeyBit_ID.Properties;
using MaterialSkin.Controls;
using System;

namespace KeyBit_ID.Forms
{
    public partial class Legal : MaterialForm
    {
        // instantiate a MainWindow form
        readonly MainWindow Main = new MainWindow();

        // instantiate a Login form
#pragma warning disable IDE0052 // Remove unread private members
        readonly Login login = new Login();
#pragma warning restore IDE0052 // Remove unread private members
        public Legal()
        {
            InitializeComponent();

        }

        private void MaterialButton1_Click(object sender, EventArgs e)
        {
            // select the tabpage2
            tcLegal.SelectedTab = tabPage2;
        }

        private void MaterialButton2_Click(object sender, EventArgs e)
        {
            // selecte tabpage3
            tcLegal.SelectedTab = tabPage3;
        }

        private void MaterialButton3_Click(object sender, EventArgs e)
        {

            // if not first run 
            if (!Settings.Default.RunFirstTime == false)
            {
                // set setting accpeted license to true
                Settings.Default.AcceptedLicense = true;
                // save setting
                Settings.Default.Save();

                // hid this form
                this.Hide();
            }
            else
            {
                // set setting accpeted license to true
                Settings.Default.AcceptedLicense = true;
                // set setting run for first time to true
                Settings.Default.RunFirstTime = true;
                // save settings
                Settings.Default.Save();
                // show the MainWindow form
                Main.Show();
                // hide this form
                this.Hide();
            }
        }


    }
}
