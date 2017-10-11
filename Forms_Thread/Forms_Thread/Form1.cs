using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Forms_Thread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Thread Traitement = new Thread(new ThreadStart(WriteTB));
            //Traitement.Start();
            var MyTask = Task<string>.Run(async()=> {
                //System.Threading.Thread.Sleep(1000);
                await Task.Delay(1000);
                this.WriteTB("Yop");
                System.Threading.Thread.Sleep(1000);
                return "TOTO";
            }).ContinueWith((test)=> { MessageBox.Show(test.Result); });
            WriteTB("Wop");
        }

        private void WriteTB(string data)
        {
            this.textBox1.Invoke((MethodInvoker)delegate { this.textBox1.Text = data; });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread.Sleep(100000);
        }
    }
}
