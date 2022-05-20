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
using WebApplication;
using System.Threading;
using Logic;

namespace FileSharingServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void Browse_Click(object sender, EventArgs e)
        {

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                Logic.JSONPath jsonFile = Logic.JSONPath.GetInstance;
                jsonFile.Path = folderBrowserDialog1.SelectedPath;
                Utility.JsonPath = jsonFile.Path;
                var pathToSave = Path.Combine(WebApplication.Utility.JsonPath);
                label1.Text = pathToSave;
                label2.Visible = false;


                

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            Thread t = new Thread(Websocket.Start);
            t.IsBackground = false;
            t.Start();
            new Controller();
            Logic.JSONPath jsonFile = Logic.JSONPath.GetInstance;
            Utility.JsonPath = jsonFile.Path;
            label1.Text = label1.Text + $"http://{Utility.GetLocalIPAddress()}:5001";
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
