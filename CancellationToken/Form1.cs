
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Xml;

namespace CancellationToken
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Open = new OpenFileDialog();
        }

        void btnBrowse_Click(object sender, EventArgs e)
        {
            if(Open.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("File Opened!");
            }
        }

        private void ThreadFoo()
        {
            lbxDisplay.Items.Add(JsonConvert.DeserializeObject<Car[]>(File.ReadAllText(Open?.FileName)).FirstOrDefault());
        }

        private void ThreadPoolFoo()
        {
            foreach (var car in JsonConvert.DeserializeObject<Car[]>(File.ReadAllText(Open.FileName)))
            {
                lbxDisplay.Items.Add(car);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var watch = new Stopwatch();
            watch.Start();

            if (rbtnSingle.Checked)
            {
                Thread = new Thread(ThreadFoo);
                Thread.Start();
                lblTimer.Text = watch.ElapsedMilliseconds.ToString();
            }
            else if (rbtnMulti.Checked)
            {
                ThreadPool.QueueUserWorkItem((o) => { ThreadPoolFoo(); });
            }
            watch.Stop();
            lblTimer.Text = watch.ElapsedMilliseconds.ToString();
        }
        OpenFileDialog Open { get; set; }
        Thread Thread { get; set; }
    }
}