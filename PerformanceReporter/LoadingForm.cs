using System.ComponentModel;
using System.Windows.Forms;

namespace PerformanceReporter
{
    public partial class LoadingForm : Form
    {
        internal BackgroundWorker Worker;

        public LoadingForm(BackgroundWorker worker)
        {
            Worker = worker;
            InitializeComponent();
            CenterToParent();
        }

        private void LoadingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Worker.IsBusy)
            {
                Worker.CancelAsync();
            }
        }
    }
}
