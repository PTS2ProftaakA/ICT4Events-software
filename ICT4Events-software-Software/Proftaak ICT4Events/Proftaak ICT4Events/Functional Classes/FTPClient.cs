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
        private Database mDatabase;
        //credentials to connect to the server
        private const string mHost = "ftp://192.168.0.4:21",
                             mUser = "SME",
                             mPass = "";

        public FTPClient(Database database)
        {
            mDatabase = database;
        }

        //Changes the way the path is interpreted
        private string CleanPathFromNode(TreeNode node)
        {
            if (node == null) return "/";
            //FILTER ROOT NODE NAME AND REPLACE \ (Windows) with / (Unix/web)
            return node.FullPath.Substring(3).Replace('\\', '/');
        }

        public TreeNode GetTreeNode()
        {
            return GetTreeNode("/", "SME");
        }

        //Tree view data is compiled here from the directory
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

        //Creates a list of folders and files.
        private List<string> GetDirectoryListing(string path)
        {
            //This doesn't work outside the client server structure on the INFRA-lab
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

        //Downloads the selected file to the selected folder
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

        //Uploads the a file to the selected node
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
                    if (GetDirectoryListing(path).Where(s => s == Path.GetFileName(ofd.FileName)).Count() != 0)
                    {
                        MessageBox.Show("Bestand bestaat al");
                        return;
                    }

                    List<string> forbiddenWords = ForbiddenWord.GetAllStrings(mDatabase);
                    foreach (string s in forbiddenWords)
                    {
                        if (Path.GetFileNameWithoutExtension(ofd.FileName).Contains(s))
                        {
                            MessageBox.Show("Bestandsnaam bevat een verboden woord");
                            return;
                        }
                    }

                    byte[] contents;
                    string ext = Path.GetExtension(ofd.FileName);

                    if (ext == ".txt")
                    {
                        foreach (string l in File.ReadAllLines(ofd.FileName))
                        {
                            foreach (string s in forbiddenWords)
                            {
                                if (l.Contains(s))
                                {
                                    MessageBox.Show("Tekstbestand bevat een verboden woord");
                                    return;
                                }
                            }
                        }
                        contents = Encoding.UTF8.GetBytes(reader.ReadToEnd());
                    }
                    else if (ext == ".jpg" || ext == ".png" || ext == ".gif" || ext == ".mp4" || ext == ".avi" || ext == ".mp3")
                    {
                        contents = File.ReadAllBytes(ofd.FileName);
                    }
                    else
                    {
                        MessageBox.Show("Bestandstype niet toegestaan.");
                        return;
                    }

                    if ((request.ContentLength = contents.Length) == 0)
                    {
                        MessageBox.Show("Bestand heeft geen inhoud");
                        return;
                    }

                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(contents, 0, contents.Length);
                        MessageBox.Show("Bestand is geupload");
                    }
                }
            }
        }

        //Add a directory with a custom name
        public void CreateDirectory(TreeNode targetNode, string name)
        {
            string path = CleanPathFromNode(targetNode);

            if (name == String.Empty)
            {
                MessageBox.Show("Map moet een naam hebben");
                return;
            }

            if (GetDirectoryListing(path).Where(d => d == name).Count() > 0)
            {
                MessageBox.Show("Map bestaat al");
                return;
            }

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
