using ArduinoUploader;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO.Ports;

namespace WindowsFormsArduinoUploader
{
    public partial class FmMain : Form
    {
        string SelectedPort = "none";
        string SelectedFile = "none";
        List<string> portNums = new List<string>();
        List<string> portNames = new List<string>();
        BackgroundWorker bw;
        ArduinoUploader.Hardware.ArduinoModel BoardType = 0;


        private class SketchUploaderLogReceiver : IArduinoUploaderLogger
        {
            public void Error(string message, Exception exception)
            {
                Console.WriteLine("e: " + message);
                
            }

            public void Warn(string message)
            {
                Console.WriteLine("w: " + message);
                
            }

            public void Info(string message)
            {
                Console.WriteLine("i: " + message);

            }

            public void Debug(string message)
            {
                Console.WriteLine("d: " + message);

                
            }

            public void Trace(string message)
            {
                Console.WriteLine(message);

            }
        }

        public FmMain()
        {
            InitializeComponent();
            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;

            LoadPorts();
            CmbType.DataSource = Enum.GetValues(typeof(ArduinoUploader.Hardware.ArduinoModel));
            CmbPort.DataSource = portNames;
            EventHook();
        }


        private void LoadPorts()
        {
            ManagementScope connectionScope = new ManagementScope();
            SelectQuery serialQuery = new SelectQuery("SELECT * FROM Win32_SerialPort");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(connectionScope, serialQuery);

            try
            {
                foreach (ManagementObject item in searcher.Get())
                {
                    string desc = item["Description"].ToString();
                    string deviceId = item["DeviceID"].ToString();

                    portNames.Add(desc + " (" + deviceId + ")");
                    portNums.Add(deviceId);
                }
            }
            catch (ManagementException e)
            {
                /* Do Nothing */
            }
            
        }

        private void EventHook()
        {

            bw.RunWorkerCompleted += (sender, e) => BWCompleted(sender, e);
            bw.DoWork += (sender, e) => BWDoWork(sender, e);
            bw.ProgressChanged += (sender, e) => BWReportProgress(sender, e);
        }



        private void BWCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PBMain.Value = 0;
            if (e.Error != null)
            {
                RTBMain.AppendText(e.Error.ToString());
            }
            else
            {
                RTBMain.AppendText("Successful upload to port " + SelectedPort + " with file " + SelectedFile);
            }
        }

        private void BWDoWork(object sender, DoWorkEventArgs e)
        {

            var asuo = new ArduinoSketchUploaderOptions();
            asuo.FileName = SelectedFile;
            asuo.PortName = SelectedPort;
            asuo.ArduinoModel = BoardType;
            var logger = new SketchUploaderLogReceiver();

            var progress = new Progress<double>(
                p => logger.Info($"Programming progress: {p * 100:F1}% ..."));
            progress.ProgressChanged += (isender, ie) => UploadProgressChanged(isender, ie);


            var uploader = new ArduinoSketchUploader(asuo, logger, progress);

            uploader.UploadSketch();
        }

        private void BWReportProgress(object sender, ProgressChangedEventArgs e)
        {
            PBMain.Value = e.ProgressPercentage;
        }


        private void UploadProgressChanged(object sender, double e)
        {
            int prog = Convert.ToInt32(e * 100);
            bw.ReportProgress(prog);
        }


        private void FmMain_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Title = "Open Hex File";
            ofd.Filter = "HEX Files | *.hex";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TBMain.Text = ofd.FileName;
            }
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Enum.TryParse<ArduinoUploader.Hardware.ArduinoModel>(CmbType.SelectedValue.ToString(), out BoardType);
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {


            if (File.Exists(TBMain.Text))
            {
                SelectedFile = TBMain.Text;
                SelectedPort = portNums[CmbPort.SelectedIndex];
                RTBMain.AppendText("Upload Started to port " + SelectedPort + " with file " + SelectedFile);
                bw.RunWorkerAsync();
            }
        }
    }
}
