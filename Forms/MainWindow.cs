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
//  This is the main form of the program that allows the user to add new 
//   passwords and other data to be saved to the KeyStore database
//
#endregion
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraSplashScreen;
using KeyBit_ID.Classes;
using KeyBit_ID.Properties;
using KeyBit_ID.Structs;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace KeyBit_ID.Forms
{
    public partial class MainWindow : MaterialForm
    {
        // instanatiate a new Wait()
        readonly Wait thread = new Wait();

        QueryOperations QO = new QueryOperations();

        // create a string and set it to the updater path
        // this is a program that is created in Advanced Installer program (NOT INCLUDED)
        readonly string updater = Application.StartupPath + @"\Updater.exe";
        // variable to store a string array of different sizes
        static readonly string[] SizeSuffixes = { "b", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public MainWindow()
        {
            // Show a splashscreen.
            FluentSplashScreenOptions op = new FluentSplashScreenOptions
            {
                Title = "KeyBit ID",
                Subtitle = "Password Manager",
                RightFooter = "Starting...",
                LeftFooter = "Copyright © 2021 Dominion Studios Ltd." + Environment.NewLine + "All Rights reserved.",
                LoadingIndicatorType = FluentLoadingIndicatorType.Dots,
                OpacityColor = Color.FromArgb(50, 50, 50),
                Opacity = 130
            };
            op.LogoImageOptions.Image = Resources.key_100px;



            DevExpress.XtraSplashScreen.SplashScreenManager.ShowFluentSplashScreen(
                op,
                parentForm: this,
                useFadeIn: true,
                useFadeOut: true,
                throwExceptionIfAlreadyOpened: true
            );
            // wait for 1 second
            thread.Time(1);

            InitializeComponent();

            if (!File.Exists(Application.StartupPath + @"\KeyStore.accdb"))
            {
                if (File.Exists(Application.StartupPath + @"\KSaccdb.bak"))
                {
                    File.Copy(Application.StartupPath + @"\KSaccdb.bak", Application.StartupPath + @"\KeyStore.accdb");
                }
                else
                {
                    MaterialMessageBox.Show("KeyBit ID can not continue because the Key Store could not be found", "Critical Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            // create variable and make a new materialskinmanager instance
            var materialSkinManager = MaterialSkinManager.Instance;
            // add which form to manage for the skin manager
            materialSkinManager.AddFormToManage(this);
            // choose theme (DARK or LIGHT)
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.Purple800, Primary.BlueGrey900, Primary.Purple500, Accent.Purple100, TextShade.WHITE);
            // set color of the skin manager, which controls the color scheme of the program
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.BlueGrey900, Primary.Blue300, Accent.Blue400, TextShade.WHITE);
            // set table adapters to the database and what table 
            this.websitesTableAdapter.Fill(this.keyStoreDataSet.Websites);
            this.banksTableAdapter.Fill(this.keyStoreDataSet.Banks);
            this.cardsTableAdapter.Fill(this.keyStoreDataSet.Cards);
            this.otherTableAdapter.Fill(this.keyStoreDataSet.Other);


            // call InitializeProgram method
            IntitializeProgram();
            // wait for 1 second
            thread.Time(1);
            //Close the splashscreen
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {


            // instantiate a new Login
            Login login = new Login();
            // show login form
            login.Show();
            // make the table control invisible
            materialTabControl3.Visible = false;
            this.BringToFront();


        }
        private void MainWindow_Closing(object sender, FormClosingEventArgs e)
        {
            // if the form is closing because of the uer 
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // completely exit the program
                Environment.Exit(0);
            }

        }
        private void IntitializeProgram()

        {
            // set text of controls 
            mlblSoftwareDev.Text = "" + Application.CompanyName; // set company name equal to application meta
            mlblSoftwareVersion.Text = "Version: " + Application.ProductVersion; // set version equal to application meta
            mlblSoftwareName.Text = "Name: " + Application.ProductName; // set name equal to application meta


        }

        private void MaterialButton1_Click(object sender, EventArgs e)
        {
            /* Deprecated
            AddWebsite addweb = new AddWebsite();
            addweb.TopLevel = true;
            addweb.ShowDialog(this);
            */
        }

        private void MaterialButton2_Click(object sender, EventArgs e)
        {
            /* Deprecated
            AddCardBank addbank = new AddCardBank();
            addbank.TopLevel = true;
            addbank.ShowDialog(this);
            */
        }

        private void MaterialButton3_Click(object sender, EventArgs e)
        {
            /* Deprecated
            AddOther addOther = new AddOther();
            addOther.TopLevel = true;
            addOther.ShowDialog(this);
            */
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // instanatiate a new OpenLink()
            OpenLink OL = new OpenLink
            {
                // set the URI
                URI = llblMaterialSkin.Tag.ToString()
            };
            // call the OpenURL method
            OL.OpenURL();
        }

        private void LinkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // instantiate a new OpenLink()
            OpenLink OL = new OpenLink
            {
                // set the URI
                URI = llblMySQL.Tag.ToString()
            };
            // call the OpenURL method
            OL.OpenURL();
        }

        private void MaterialButton4_Click(object sender, EventArgs e)
        {
            // if successful login
            if (Settings.Default.SuccessfulLogin == true)
            {
                // instantiate a new UserAccount Form
                UserAccount userAccount = new UserAccount
                {
                    // show on top
                    TopLevel = true
                };
                // show form and assign it a child of this form
                userAccount.ShowDialog(this);
            }
            else
            {
                // show message box warning no login
                MaterialMessageBox.Show("Error no successful login!", "Error", false);
            }
        }

        private void MaterialButton6_Click(object sender, EventArgs e)
        {
            // instantiate a new Changelog form
            Changelog changelog = new Changelog();
            // show form and assign it a child of this form
            changelog.Show(this);
        }

        private void MaterialButton7_Click(object sender, EventArgs e)
        {
            // instantiate a new Legal Form
            Legal legal = new Legal();
            // show form and assign it a child of this form
            legal.Show(this);
        }

        private void MaterialButton5_Click(object sender, EventArgs e)
        {
            // check to see if the updater file exits (Advanced Installer updater)
            if (File.Exists(updater))
            {
                // if exists run the updater
                System.Diagnostics.Process.Start(updater);
            }
            else
            {
                // new message box saying there is an error
                MaterialMessageBox.Show(this, Application.ProductName + " can not check for updates at this time!\n\nError: Access Violation at:\n" + "'" + updater + "'\n\nNo such file found.\n", "Error: Access Violation", MessageBoxButtons.OK, MessageBoxIcon.Error, false);
                // show message box saying there is an error
                //MessageBox.Show(Application.ProductName + " can not check for updates at this time!\n\nError: Access Violation\nat\n" + "'" + updater + "'\n\nNo such file found.","Error: Access Violation",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void MaterialButton8_Click(object sender, EventArgs e)
        {
            // instantiate a new Column view and make it equal to the focused column view
            ColumnView view = gridControl1.FocusedView as ColumnView;
            // close the active view editor
            view.CloseEditor();
            // if columnview is updated
            if (view.UpdateCurrentRow())
            {
                // write to the database and corresponding tables
                websitesTableAdapter.Update(keyStoreDataSet.Websites);
                banksTableAdapter.Update(keyStoreDataSet.Banks);
                cardsTableAdapter.Update(keyStoreDataSet.Cards);
                otherTableAdapter.Update(keyStoreDataSet.Other);
            }
            // call all this to make sure that all counts are recalculated
            DataTable websites = this.keyStoreDataSet.Tables["Websites"];
            QO.queryWebCount(this.keyStoreDataSet, websites);
            DataTable banks = this.keyStoreDataSet.Tables["Banks"];
            QO.queryBankCount(this.keyStoreDataSet, banks);
            DataTable cards = this.keyStoreDataSet.Tables["Cards"];
            QO.queryCardCount(this.keyStoreDataSet, cards);
            DataTable other = this.keyStoreDataSet.Tables["Other"];
            QO.queryOtherCount(this.keyStoreDataSet, other);
            // then assign values to the UI
            websiteTotal.Text = "Website Records: " + QO.webCount;
            bankTotal.Text = "Bank Records: " + QO.bankCount;
            cardTotal.Text = "Card Records: " + QO.cardCount;
            otherTotal.Text = "Other Records: " + QO.otherCount;
            totalCounts.Text = "Total Records in vault: " + QO.TotalCount();
        }

        private void MaterialButton9_Click(object sender, EventArgs e)
        {
            // set the current view
            gridControl1.MainView = gridView1;
            // set the focused view
            gridControl1.FocusedView = gridView1;
            // set the KeyStore database binding source to the websites table
            keyStoreDataSetBindingSource.DataMember = "Websites";
        }

        private void MaterialButton10_Click(object sender, EventArgs e)
        {
            // set the current view
            gridControl1.MainView = gridView2;
            // set the focused view
            gridControl1.FocusedView = gridView2;
            // set the KeyStore database binding source to the banks table
            keyStoreDataSetBindingSource.DataMember = "Banks";
        }

        private void MaterialButton11_Click(object sender, EventArgs e)
        {
            // set the current view
            gridControl1.MainView = gridView3;
            // set the focused view
            gridControl1.FocusedView = gridView3;
            // set the KeyStore database binding source to the cards table
            keyStoreDataSetBindingSource.DataMember = "Cards";
        }

        private void MaterialButton12_Click(object sender, EventArgs e)
        {
            // set the current view
            gridControl1.MainView = gridView4;
            // set the focused view
            gridControl1.FocusedView = gridView4;
            // set the KeyStore database binding source to the other table
            keyStoreDataSetBindingSource.DataMember = "Other";
        }

        private void BtnMaster_Click(object sender, EventArgs e)
        {
            // if textbox text matches UserID masterpassowrd
            if (tbMaster.Text == UserID.MasterPassword)
            {
                // show the tabcontrol
                materialTabControl3.Visible = true;
                // change selected tabe page
                // materialTabControl1.SelectedTab = tabPage2;
                panel2.Visible = true;
                // make the unlock controls invisible
                panel1.Visible = false;
                panel1.Hide();
            }
            else
            {
                // message box error
                MaterialMessageBox.Show("Error", "Error", false);
            }

            // enable account button
            materialButton4.Visible = true;
            materialCard11.Visible = true;
            materialCard12.Visible = true;
            materialCard13.Visible = true;
            materialCard14.Visible = true;

            materialCard15.Visible = true;


            Thread dashThread = new Thread(new ThreadStart(UnlockDashThread));
            dashThread.Start();

            DataTable websites = this.keyStoreDataSet.Tables["Websites"];
            QO.queryWebCount(this.keyStoreDataSet, websites);
            DataTable banks = this.keyStoreDataSet.Tables["Banks"];
            QO.queryBankCount(this.keyStoreDataSet, banks);
            DataTable cards = this.keyStoreDataSet.Tables["Cards"];
            QO.queryCardCount(this.keyStoreDataSet, cards);
            DataTable other = this.keyStoreDataSet.Tables["Other"];
            QO.queryOtherCount(this.keyStoreDataSet, other);

            websiteTotal.Text = "Website Records: " + QO.webCount;
            bankTotal.Text = "Bank Records: " + QO.bankCount;
            cardTotal.Text = "Card Records: " + QO.cardCount;
            otherTotal.Text = "Other Records: " + QO.otherCount;
            totalCounts.Text = "Total Records in vault: " + QO.TotalCount();

        }
        private void UnlockDashThread()
        {
            // variable to hold network name
            string nicname = null;
            // get all peformance counter categories
            PerformanceCounterCategory[] cats = PerformanceCounterCategory.GetCategories();
            // for each category
            foreach (PerformanceCounterCategory cat in cats)
            {
                // if category equals networ interface
                if (cat.CategoryName.Equals("Network Interface"))
                {
                    // array string of names, get instance name
                    string[] names = cat.GetInstanceNames();
                    // for each name
                    foreach (string name in names)
                    {
                        // return name to nicname
                        nicname = name;
                    }
                }
            }

            // peformance counters
            PerformanceCounter pcCPU = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
            PerformanceCounter pcRAM = new PerformanceCounter("Memory", "% Committed Bytes In Use");
            PerformanceCounter pcNET = new PerformanceCounter("Network Interface", "Bytes Total/sec", nicname);
            PerformanceCounter pcHDD = new PerformanceCounter("LogicalDisk", "Disk Write Bytes/sec", "_Total");


            // while true (always run)
            while (true)
            {
                // set variables to perfomrnace counters nextvalue
                int cpupercent = (int)pcCPU.NextValue();
                int rampercent = (int)pcRAM.NextValue();
                int netpercent = (int)pcNET.NextValue();
                int hddpercent = (int)pcHDD.NextValue();
                // set the values to the gauages text and progress
                arcScaleComponent1.Value = cpupercent;
                labelComponent1.Text = cpupercent.ToString() + "%";
                arcScaleComponent2.Value = rampercent;
                labelComponent2.Text = rampercent.ToString() + "%";
                arcScaleComponent3.Value = netpercent;
                labelComponent3.Text = SizeSuffix(netpercent);
                arcScaleComponent4.Value = hddpercent;
                labelComponent4.Text = SizeSuffix(hddpercent);
                // wait for 1 second
                thread.Time(1);
            }
        }

        private void VaultCheck_Tick(object sender, EventArgs e)
        {
            // if selected tab matches tabpage 2
            if (materialTabControl1.SelectedTab == tabPage2)
            {
                if (materialTabControl3.Visible == true)
                {
                    // show a button to save vault
                    materialButton8.Visible = true;

                }
            }
            else
            {
                // hid button for saving vault
                materialButton8.Visible = false;

            }
        }

        static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            // if decimals < 0
            if (decimalPlaces < 0)
            {
                // throw exception
                throw new ArgumentOutOfRangeException("decimalPlaces");
            }
            // if value < 0
            if (value < 0)
            {
                // return 
                return "-" + SizeSuffix(-value, decimalPlaces);
            }
            // if value == 0
            if (value == 0)
            {
                // return
                return string.Format("{0:n" + decimalPlaces + "} bytes", 0);
            }

            // size = 0 for bytes, 1 for KB, 2, for MB, etc.
            int size = (int)Math.Log(value, 1024);

            // 1L << (size * 10) == 2 ^ (10 * size) 
            // [i.e. the number of bytes in the unit corresponding to size]
            decimal adjustedSize = (decimal)value / (1L << (size * 10));

            // if value is larger than 1000 then round up
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                size += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[size]);
        }

        private void materialButton9_Click_1(object sender, EventArgs e)
        {
            // create a new query operations class
            QueryOperations qo = new QueryOperations();

            // if a specific tab is selected query that tabs data
            if (materialTabControl3.SelectedTab == tabPage9)
            {
                qo.queryWeb();
            }
            else if (materialTabControl3.SelectedTab == tabPage10)
            {
                qo.queryBank();
            }
            else if (materialTabControl3.SelectedTab == tabPage11)
            {
                qo.queryCard();
            }
            else if (materialTabControl3.SelectedTab == tabPage12)
            {
                qo.queryOther();
            }
            else
            {

            }
        }
    }
}
