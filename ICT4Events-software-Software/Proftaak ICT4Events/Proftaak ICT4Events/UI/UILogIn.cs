﻿using System;
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

            this.ControlBox = false;

            userRFID = new RFID();
            database = new Database();

            userRFID.Attach += new AttachEventHandler(userRFID_Attach);
            userRFID.Detach += new DetachEventHandler(userRFID_Detach);

            userRFID.Tag += new TagEventHandler(userRFID_Tag);

            openCmdLine(userRFID);
        }

        void userRFID_Attach(object sender, AttachEventArgs e)
        {
            RFID userRFID = (RFID)sender;
            lblExplain.Text = "Of log in door je RFID te scannen!";
            //userRFID.Attached is boolean to see if the Phidgets is connected;
        }

        void userRFID_Detach(object sender, DetachEventArgs e)
        {
            RFID userRFID = (RFID)sender;
            lblExplain.Text = "Verbind de RFID-scanner!";
            //userRFID.Attached is boolean to see if the Phidgets is connected;
        }

        public void userRFID_Tag(object sender, TagEventArgs e)
        {
            CurrentUser.currentUser = User.StaticGet(e.Tag, database);
            this.Close();

            //e.Tag is the actual RFID that belongs to the chip
            //e.protocol is the protocol that belongs to that chip
        }

        //Source a piece of example code at http://www.phidgets.com/docs/Language_-_C_Sharp#Quick_Downloads
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

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            CurrentUser.currentUser = User.StaticGet(tbInlogName.Text, tbPassword.Text, database);
            this.Close();
        }
    }
}
