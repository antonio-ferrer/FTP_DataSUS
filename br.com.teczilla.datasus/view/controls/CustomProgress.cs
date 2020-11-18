using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace br.com.teczilla.datasus.view.controls
{
    public partial class CustomProgress : UserControl
    {
        public CustomProgress()
        {
            InitializeComponent();
            this.Load += CustomProgress_Load;
        }

        private void CustomProgress_Load(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            _work = null;
            _finish = null;
            backgroundWorker1.DoWork += (s, evt) =>
            {
                if (_work == null)
                    throw new NullReferenceException();
                currentStep = 0;
                finished = false;
                Exception error = null;
                ThreadSafeExec(()=> Cursor = Cursors.WaitCursor);
                try
                {
                    AnimeBar();
                    _currentTask = new Thread(new ThreadStart(_work));
                    _currentTask.Start();
                    while (_currentTask.IsAlive)
                    {
                        Thread.Sleep(100);
                        if (backgroundWorker1.CancellationPending)
                        {
                            _currentTask.Abort();
                            throw new OperationCanceledException("operação cancelada pelo usuário");
                        }
                    }
                }
                catch (Exception ex)
                {
                    error = ex;
                }
                finally
                {
                    finished = true;
                    _finish?.Invoke(error);
                    _currentTask = null;
                    ThreadSafeExec(() => progressBar.Value = 100);
                    ThreadSafeExec(()=> Cursor = Cursors.Default);
                }
            };

        }

        private int currentStep;
        private bool finished;

        private Action _work;
        private Action<Exception> _finish;
        private Thread _currentTask;

        public CustomProgress Config(Action run, Action<Exception> onfinish = null)
        {
            _work = run;
            _finish = onfinish;
            return this;
        }

        public void ThreadSafeExec(Action fx)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(fx));
                }
                else
                    fx();
            }
            catch { return; }
        }

        public bool Start()
        {
            if (backgroundWorker1.IsBusy)
            {
                return false;
            }
            if (!backgroundWorker1.IsBusy)
            {
                finished = false;
                currentStep = 0;
                backgroundWorker1.RunWorkerAsync();
            }
            else
                throw new Exception("Fail on start a new work");
            return true;
        }


        private void DoProgress()
        {
            if (currentStep >= 100)
                currentStep = new Random().Next(45, 85);
            progressBar.Value = ++currentStep;
        }

        private void RunProgress()
        {
            while (!finished)
            {
                Thread.Sleep(200);
                ThreadSafeExec(DoProgress);
            }
        }

        private void AnimeBar()
        {
            Task.Run(() =>
            {
                currentStep = 0;
                RunProgress();
            });
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }
    }
}
