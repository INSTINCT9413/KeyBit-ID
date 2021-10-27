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
// The Changelog form is a form that loads the program changelog
//
#endregion
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace KeyBit_ID.Forms
{
    public partial class Changelog : MaterialForm
    {
        public Changelog()
        {
            InitializeComponent();
        }

        private async void Changelog_Load(object sender, EventArgs e)
        {
            // create a string and set it to the application version
            string versionNumber = Application.ProductVersion;
            // Initialize the Edge web client
            changelogBrowser.InitializeLifetimeService();
            // await the browsers background initialization tasks (default environment)
            await changelogBrowser.EnsureCoreWebView2Async(null);
            // navigate to the changelog html file
            changelogBrowser.CoreWebView2.Navigate("https://jacobbrookhouse.me/downloads/server2/product/keybitid/data/changelog.html");
            // print version number to text of a control
            txtVersion.Text = "(Installed Version: " + versionNumber + ")";
        }
    }
}
