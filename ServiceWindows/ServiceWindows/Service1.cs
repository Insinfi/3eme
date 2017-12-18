using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ServiceWindows
{
    public partial class Service1 : ServiceBase
    {
        private Thread MyThread;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            MyThread = new Thread(new ThreadStart(Traitement));
            MyThread.Start();
        }

        private void Traitement()
        {
            try
            {
                while (true)
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnStop()
        {
            MyThread.Abort();
        }
    }
}
