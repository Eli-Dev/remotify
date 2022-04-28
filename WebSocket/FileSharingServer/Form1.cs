using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace FileSharingServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string rd;
        byte[] content;
        string v;
        int m;

        Int32 port = 5000;
        Int32 port1 = 5001;
        IPAddress localAddr = IPAddress.Parse("172.17.210.16");
        private void Browse_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                content = new byte[m];
                try
                {
                    TcpListener listen = new TcpListener(localAddr, port1);
                    listen.Start();
                    TcpClient client = listen.AcceptTcpClient();
                    NetworkStream writecontent = client.GetStream();
                    FileStream targetfile = null;
                    int bytecnt = 0;
                    try
                    {
                        targetfile = File.OpenWrite(textBox1.Text + "\\" + rd.Substring(0, rd.LastIndexOf('.')));
                        bytecnt = writecontent.Read(content, 0, m);  // this will return byte count from current read
                        while (bytecnt > 0)  // loop until there's nothing more to read from
                        {
                            targetfile.Write(content, 0, bytecnt); // write just the amount you just received
                            bytecnt = writecontent.Read(content, 0, m);
                        }
                        targetfile.Flush();  // before closing filestream, make sure all data has written on disk
                    }
                    finally
                    {
                        if (targetfile != null) targetfile.Close();
                    }
                    listen.Stop();
                    client.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TcpListener list = new TcpListener(localAddr, port1);
            list.Start();
            TcpClient client = list.AcceptTcpClient();
            MessageBox.Show("Client trying to connect");
            StreamReader sr = new StreamReader(client.GetStream());
            rd = sr.ReadLine();
            v = rd.Substring(rd.LastIndexOf('.') + 1);
            m = int.Parse(v);
            list.Stop();
            client.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
