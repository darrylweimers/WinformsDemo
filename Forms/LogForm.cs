using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace Template.Forms
{

  

    public partial class LogForm : Form
    {
      
        // MARK: Properties 
        public Template.Class.Task task; 
        private Timer timer;
        private const int millisecondInterval = 1000;
        private Time time; 

        public LogForm()
        {
            InitializeComponent();
            Setup(); 
        }

      
        // MARK: Setup 
        private void Setup()
        {
            SelfInit();
            TimerInit();
            task = new Template.Class.Task();    
        }

        private void SelfInit()
        {
            this.Text = "Log Your Hours"; 
        }

        private void TimerInit()
        {
            TimeInit();

            // Timer 
            timer = new System.Windows.Forms.Timer();
            timer.Interval = millisecondInterval;
            timer.Enabled = true;
            timer.Tick += new EventHandler(TimerUpdate);
            timer.Stop();
        }

        private void TimeInit()
        {
            time = new Time(millisecondInterval / 1000);
        }


        // MARK: Time Manangement 

        public class Time
        {
            private int seconds;
            private int interval;

            // MARK: interval in seconds 
            public Time(int interval)
            {
                this.interval = interval;
                seconds = 0;
            }

            public void Update()
            {
                seconds += interval;
            }

            public int GetSeconds()
            {
                return seconds;
            }

            public String GetTime()
            {
                return String.Format("{0:00}:{1:00}:{2:00}", GetSeconds() / 60 / 60, GetSeconds() / 60 % 60, GetSeconds() % 60); 

            }

            public void Reset()
            {
                seconds = 0; 
            }
        }

        // MARK: Event complete 
        public delegate void CompleteDidClick(object sender, EventArgs e);
        public event CompleteDidClick completeDidClick;

        // MARK: Event Handlers 
        #region Event Handler

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hide form instead of closing it
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }
        #region Timer event handlers
        private void TimerUpdate(Object myObject, EventArgs myEventArgs)
        {
            time.Update();
            labelTime.Text = time.GetTime();
        }

        private void toolStripButtonPlay_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void toolStripButtonComplete_Click(object sender, EventArgs e)
        {
            timer.Stop();
            time.Reset();
            // Update Task
            task.name = textBoxName.Text;
            task.duration = labelTime.Text;
            // Trigger event complete did click 
            completeDidClick(sender, e);
            // Clear data 
            textBoxName.Text = "";
            labelTime.Text = "00:00:00";

        }
        #endregion

        private void LogForm_Load(object sender, EventArgs e)
        {

        }
        #endregion




    }
}
