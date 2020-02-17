using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace gija1
{
    public partial class Form1 : Form
    {
        ManualResetEvent resetEvent = new ManualResetEvent(true);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(CountDown);
            th.IsBackground = true;
            th.Start();
           
        }

        private void CountDownMethod()
        {
            for (int i = 20; i >= 0; i--)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    label1.Text = i.ToString();
                });

                Thread.Sleep(1000);
            }
        }

        private void CountDown()
        {
            int i = 0;
            while (i >= 0)
            {
                this.BeginInvoke((MethodInvoker)delegate
                {
                    label1.Text = i.ToString();
                    i++;
                });

                Thread.Sleep(1000);

                resetEvent.WaitOne();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetEvent.Reset(); // signalas sustoti
        }

        private void button3_Click(object sender, EventArgs e)
        {
            resetEvent.Set(); // signalas tęsti
        }


    }
}
