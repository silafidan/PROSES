using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp13
{
    public partial class Form1 : Form
    {
        private object monitorObject = new object();
        private Mutex mutexObject = new Mutex();
        private Semaphore semaphoreObject = new Semaphore(0, 2);
        private Thread th1;
        private Thread th2;
        private Thread th3;

        long counter = 1;



        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            th1 = new Thread(new ThreadStart(DegerArtir1));
            th2 = new Thread(new ThreadStart(DegerArtir2));
            th3 = new Thread(new ThreadStart(DegerArtir3));

            th1.Start();
            th2.Start();
            th3.Start();

        }

        public void DegerArtir1()
        {
            for (int i = 1; i <= 100; ++i)
            {
                progressBar1.Value += 1;
                listBox1.Items.Add("Thread 1 calisiyor");
                Thread.Sleep(10);
            }
        }


        public void DegerArtir2()
        {
            for (int j = 1; j <= 100; ++j)
            {
                progressBar2.Value += 1;
                listBox1.Items.Add("Thread 2 calisiyor");
                Thread.Sleep(100);

            }
        }
        public void DegerArtir3()
        {
            for (int k = 1; k <= 100; ++k)
            {
                progressBar3.Value += 1;
                listBox1.Items.Add("Thread 3 calisiyor");
                Thread.Sleep(150);

            }
        }
        public void DegerArtirInterlock1()
        {
            try
            {
                while (counter <= 300)
                {
                    Interlocked.Increment(ref counter);
                    progressBar1.Value += 1;
                    listBox1.Items.Add("Thread 1 Calisti");
                    Thread.Sleep(80);
                }
            }
            catch { }
        }
        public void DegerArtirInterlock2()
        {
            try
            {
                while (counter <= 300)
                {
                    Interlocked.Increment(ref counter);
                    progressBar2.Value += 1;
                    listBox1.Items.Add("Thread 2 Calisti");
                    Thread.Sleep(80);
                }
            }
            catch { }
        }
        public void DegerArtirInterlock3()
        {
            try
            {
                while (counter <= 300)
                {
                    Interlocked.Increment(ref counter);
                    progressBar3.Value += 1;
                    listBox1.Items.Add("Thread 3 Calisti");
                    Thread.Sleep(80);
                }
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            th1 = new Thread(new ThreadStart(DegerArtirInterlock1));
            th2 = new Thread(new ThreadStart(DegerArtirInterlock2));
            th3 = new Thread(new ThreadStart(DegerArtirInterlock3));


            th1.Start();
            th2.Start();
            th3.Start();

        }
        //lock.............
        public void DegerArtirLock1()
        {
            for (int i = 1; i <= 100; ++i)
            {
                lock (this)
                {
                    progressBar1.Value += 1;
                    listBox1.Items.Add("Thread 1 Calisti");
                    Thread.Sleep(10);
                }
            }
        }
        public void DegerArtirLock2()
        {
            for (int j = 1; j <= 100; ++j)
            {
                lock (this)
                {
                    progressBar2.Value += 1;
                    listBox1.Items.Add("Thread 2 Calisti");
                    Thread.Sleep(100);
                }
            }
        }
        public void DegerArtirLock3()
        {
            for (int k = 1; k <= 100; ++k)
            {
                lock (this)
                {
                    progressBar3.Value += 1;
                    listBox1.Items.Add("Thread 3 Calisti");
                    Thread.Sleep(150);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            th1 = new Thread(new ThreadStart(DegerArtirInterlock1));
            th2 = new Thread(new ThreadStart(DegerArtirInterlock2));
            th3 = new Thread(new ThreadStart(DegerArtirInterlock3));


            th1.Start();
            th2.Start();
            th3.Start();
        }
        //monitor
        public void DegerArtirMonitor1()
        {
            for (int i = 1; i <= 100; ++i)
            {
                try
                {
                    Monitor.Enter(monitorObject);
                    progressBar1.Value += 1;
                    listBox1.Items.Add("Thread 1 Calisti");
                    Thread.Sleep(10);
                    Monitor.Pulse(monitorObject);
                }
                finally
                {
                    Monitor.Exit(monitorObject);
                }
            } }
        public void DegerArtirMonitor2()
        {
            for (int j = 1; j <= 100; ++j)
            {
                try
                {
                    Monitor.Enter(monitorObject);
                    progressBar2.Value += 1;
                    listBox1.Items.Add("Thread 2 Calisti");
                    Thread.Sleep(100);
                    Monitor.Pulse(monitorObject);
                }
                finally
                {
                    Monitor.Exit(monitorObject);
                }
            } }
        public void DegerArtirMonitor3()
        {
            for (int k = 1; k <= 100; ++k)
            {
                try
                {
                    Monitor.Enter(monitorObject);
                    progressBar3.Value += 1;
                    listBox1.Items.Add("Thread 3 Calisti");
                    Thread.Sleep(150);
                    Monitor.Pulse(monitorObject);
                }
                finally
                {
                    Monitor.Exit(monitorObject);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            th1 = new Thread(new ThreadStart(DegerArtirMonitor1));
            th2 = new Thread(new ThreadStart(DegerArtirMonitor2));
            th3 = new Thread(new ThreadStart(DegerArtirMonitor3));


            th1.Start();
            th2.Start();
            th3.Start();
        }
        public void DegerArtirMutex1()
        {
            for(int i= 1; i<=100; ++i)
            {
                mutexObject.WaitOne();
                progressBar1.Value += 1;
                listBox1.Items.Add("Thread 1 Calisti");
                Thread.Sleep(10);
                mutexObject.ReleaseMutex();
            }
        }
        public void DegerArtirMutex2()
        {
            for (int j = 1; j <= 100; ++j)
            {
                mutexObject.WaitOne();
                progressBar2.Value += 1;
                listBox1.Items.Add("Thread 2 Calisti");
                Thread.Sleep(100);
                mutexObject.ReleaseMutex();
            }
        }
        public void DegerArtirMutex3()
        {
            for (int k= 1; k <= 100; ++k)
            {
                mutexObject.WaitOne();
                progressBar3.Value += 1;
                listBox1.Items.Add("Thread 3 Calisti");
                Thread.Sleep(150);
                mutexObject.ReleaseMutex();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            th1 = new Thread(new ThreadStart(DegerArtirMutex1));
            th2 = new Thread(new ThreadStart(DegerArtirMutex2));
            th3 = new Thread(new ThreadStart(DegerArtirMutex3));


            th1.Start();
            th2.Start();
            th3.Start();
        }
        //semaphore
        public void DegerArtirSemaphore1()
        {
            for(int i=1; i<=100; ++i)
            {
                semaphoreObject.WaitOne();
                progressBar1.Value += 1;
                listBox1.Items.Add("Thread 1 Calisti");
                Thread.Sleep(10);
                semaphoreObject.Release();
            }
        }
        public void DegerArtirSemaphore2()
        {
            for (int j = 1; j <= 100; ++j)
            {
                semaphoreObject.WaitOne();
                progressBar2.Value += 1;
                listBox1.Items.Add("Thread 2 Calisti");
                Thread.Sleep(100);
                semaphoreObject.Release();
            }
        }
        public void DegerArtirSemaphore3()
        {
            for (int k = 1; k<= 100; ++k)
            {
                semaphoreObject.WaitOne();
                progressBar3.Value += 1;
                listBox1.Items.Add("Thread 3 Calisti");
                Thread.Sleep(150);
                semaphoreObject.Release();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            th1 = new Thread(new ThreadStart(DegerArtirSemaphore1));
            th2 = new Thread(new ThreadStart(DegerArtirSemaphore2));
            th3 = new Thread(new ThreadStart(DegerArtirSemaphore3));


            th1.Start();
            th2.Start();
            th3.Start();

            semaphoreObject.Release();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            th1.Interrupt();
            th2.Interrupt();
            th2.Interrupt();

            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;

            progressBar1.Refresh();
            progressBar2.Refresh();
            progressBar3.Refresh();

            listBox1.Items.Clear();

            counter = 1;



        }
    }
}