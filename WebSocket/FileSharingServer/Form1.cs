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
        byte[] b1;
        string v;
        int m;

        Int32 port = 5000;
        Int32 port1 = 5055;
        IPAddress localAddr = IPAddress.Parse("192.168.188.46");
        private void Browse_Click(object sender, EventArgs e)
        {
             
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                TcpListener list = new TcpListener(localAddr,port);
                list.Start();
                TcpClient client = list.AcceptTcpClient();
                Stream s = client.GetStream();
                b1 = new byte[m];
                s.Read(b1, 0, b1.Length);
                File.WriteAllBytes(textBox1.Text + "\\" + rd.Substring(0, rd.LastIndexOf('.')), b1);
                list.Stop();
                client.Close();
                label1.Text = "File Received......";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TcpListener list = new TcpListener(localAddr, port);
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
