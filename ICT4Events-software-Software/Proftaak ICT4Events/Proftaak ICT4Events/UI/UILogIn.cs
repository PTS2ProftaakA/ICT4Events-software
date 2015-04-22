using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Phidgets;
using Phidgets.Events;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proftaak_ICT4Events.UI
{
    public partial class UILogIn : Form
    {
        private RFID userRFID;
        private Database database;
        
        public UILogIn()
        {
            InitializeComponent();


            userRFID = new RFID();
            database = new Database();

            //Makes sure the computer knows when the scanner is attached or not
            userRFID.Attach += new AttachEventHandler(userRFID_Attach);
            userRFID.Detach += new DetachEventHandler(userRFID_Detach);

            userRFID.Tag += new TagEventHandler(userRFID_Tag);

            openCmdLine(userRFID);

            //Makes this form undeniable for the user
            //He has to log in to navigate the application
            ShowDialog();
        }

        void userRFID_Attach(object sender, AttachEventArgs e)
        {
            //userRFID.Attached is boolean to see if the Phidgets is connected
            RFID userRFID = (RFID)sender;
            lblExplain.Text = "Of log in door je RFID te scannen!";
        }

        void userRFID_Detach(object sender, DetachEventArgs e)
        {
            //userRFID.Attached is boolean to see if the Phidgets is connected
            RFID userRFID = (RFID)sender;
            lblExplain.Text = "Verbind de RFID-scanner!";         
        }

        public void userRFID_Tag(object sender, TagEventArgs e)
        {
            //e.Tag is the actual RFID that belongs to the chip
            //e.protocol is the protocol that belongs to that chip
            //The user is retrieved from the database using a function from the User class
            CurrentUser.currentUser = User.StaticGetByRFID(e.Tag, database);
            if (CurrentUser.currentUser != null)
            {
                this.Close();
            }
        }

        //Source of the piece of example code at http://www.phidgets.com/docs/Language_-_C_Sharp#Quick_Downloads
        #region Command line open functions
        private void openCmdLine(Phidget p)
        {
            openCmdLine(p, null);
        }
        private void openCmdLine(Phidget p, String pass)
        {
            int serial = -1;
            String logFile = null;
            int port = 5001;
            String host = null;
            bool remote = false, remoteIP = false;
            string[] args = Environment.GetCommandLineArgs();
            String appName = args[0];

            try
            { //Parse the flags
                for (int i = 1; i < args.Length; i++)
                {
                    if (args[i].StartsWith("-"))
                        switch (args[i].Remove(0, 1).ToLower())
                        {
                            case "l":
                                logFile = (args[++i]);
                                break;
                            case "n":
                                serial = int.Parse(args[++i]);
                                break;
                            case "r":
                                remote = true;
                                break;
                            case "s":
                                remote = true;
                                host = args[++i];
                                break;
                            case "p":
                                pass = args[++i];
                                break;
                            case "i":
                                remoteIP = true;
                                host = args[++i];
                                if (host.Contains(":"))
                                {
                                    port = int.Parse(host.Split(':')[1]);
                                    host = host.Split(':')[0];
                                }
                                break;
                            default:
                                goto usage;
                        }
                    else
                        goto usage;
                }
                if (logFile != null)
                    Phidget.enableLogging(Phidget.LogLevel.PHIDGET_LOG_INFO, logFile);
                if (remoteIP)
                    p.open(serial, host, port, pass);
                else if (remote)
                    p.open(serial, host, pass);
                else
                    p.open(serial);
                return; //success
            }
            catch { }
        usage:
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Invalid Command line arguments." + Environment.NewLine);
            sb.AppendLine("Usage: " + appName + " [Flags...]");
            sb.AppendLine("Flags:\t-n   serialNumber\tSerial Number, omit for any serial");
            sb.AppendLine("\t-l   logFile\tEnable phidget21 logging to logFile.");
            sb.AppendLine("\t-r\t\tOpen remotely");
            sb.AppendLine("\t-s   serverID\tServer ID, omit for any server");
            sb.AppendLine("\t-i   ipAddress:port\tIp Address and Port. Port is optional, defaults to 5001");
            sb.AppendLine("\t-p   password\tPassword, omit for no password" + Environment.NewLine);
            sb.AppendLine("Examples: ");
            sb.AppendLine(appName + " -n 50098");
            sb.AppendLine(appName + " -r");
            sb.AppendLine(appName + " -s myphidgetserver");
            sb.AppendLine(appName + " -n 45670 -i 127.0.0.1:5001 -p paswrd");
            MessageBox.Show(sb.ToString(), "Argument Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Application.Exit();
        }
        #endregion

        //Checks if the combination of username and password is correct
        //If this is not the case an appropriate error will be shown
        //If this is the case the user will be logged in and saved
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (tbInlogName.Text != "" && tbPassword.Text != "")
            {
                string userName = tbInlogName.Text;
                string password = tbPassword.Text;
                CurrentUser.currentUser = User.StaticGet(userName, password, database);
                if (CurrentUser.currentUser != null)
                {

                    this.Close();
                }
                else
                    MessageBox.Show("Inlognaam of wachtwoord onjuist.");
            }
            else
            {
                if (tbInlogName.Text == "" && tbPassword.Text == "")
                    MessageBox.Show("Voor uw inlognaam en wacthwoord in.");
                else if (tbInlogName.Text == "")
                    MessageBox.Show("Vul uw inlognaam in.");
                else if (tbPassword.Text == "")
                    MessageBox.Show("Vul uw wachtwoord in.");
            }
        }

        private void UILogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
