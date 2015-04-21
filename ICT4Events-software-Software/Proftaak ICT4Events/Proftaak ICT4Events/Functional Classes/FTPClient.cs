using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Proftaak_ICT4Events
{
    class FTPClient
    {
        private const string mHost = "ftp://192.168.0.4:21",
                             mUser = "SME",
                             mPass = "";

        private string CleanPathFromNode(TreeNode node)
        {
            //FILTER ROOT NODE NAME AND REPLACE \ (Windows) with / (Unix/web)
            return node.FullPath.Substring(3).Replace('\\', '/');
        }

        public TreeNode GetTreeNode()
        {
            return GetTreeNode("/", "SME");
        }

        private TreeNode GetTreeNode(string path, string name)
        {
            TreeNode node = new TreeNode(name);
            List<string> listing = GetDirectoryListing(path);

            foreach (string s in listing.Where(l => !l.Contains(".")))
            {
                node.Nodes.Add(GetTreeNode(path + s + "/", s));
            }
            foreach (string s in listing.Where(l => l.Contains(".")))
            {
                node.Nodes.Add(new TreeNode(s));
            }

            return node;
        }

        private List<string> GetDirectoryListing(string path)
        {
            //QUICKFIX
            return new List<string>();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(mHost + path);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(mUser, mPass);
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            List<string> result = new List<string>();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    while (!reader.EndOfStream)
                    {
                        result.Add(reader.ReadLine());
                    }
                }
            }
            return result;
        }

        public void DownloadFile(TreeNode targetNode)
        {
            string file = CleanPathFromNode(targetNode);

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(mHost + file);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(mUser, mPass);
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                using (StreamReader reader = new StreamReader(stream))
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.FileName = Path.GetFileName(file);
                    sfd.Filter = "Alle bestanden (*.*)|*.*";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter writer = new StreamWriter(sfd.FileName))
                        {
                            writer.Write(reader.ReadToEnd());
                        }
                    }
                }
            }
        }

        public void UploadFile(TreeNode targetNode)
        {
            string path = CleanPathFromNode(targetNode);

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Alle bestanden (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string destination = mHost + path + "/" + Path.GetFileName(ofd.FileName);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(destination);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(mUser, mPass);
                using (StreamReader reader = new StreamReader(ofd.FileName))
                {
                    byte[] contents = Encoding.UTF8.GetBytes(reader.ReadToEnd());

                    request.ContentLength = contents.Length;

                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(contents, 0, contents.Length);
                    }
                }
            }
        }

        public void CreateDirectory(TreeNode targetNode, string name)
        {
            string path = CleanPathFromNode(targetNode);

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(mHost + path + "/" + name);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.Credentials = new NetworkCredential(mUser, mPass);
            try {
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse()) { }
            }
            catch (Exception)
            {
                MessageBox.Show("Map kon niet toegevoegd worden :(");
            }
        }
    }
}
