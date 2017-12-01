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
    public partial class TableForm : Form
    {
        public TableForm()
        {
            InitializeComponent();
            Setup(); 
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            
            /*
            System.Drawing.Size s = new Size((this.Size.Width / 2) - 18, (this.Size.Height - 81));
            listViewTransmit.Size = s;
            listViewTransmit.Size = s;
            listViewTransmit.Location = new Point(listViewTransmit.Width + 10, 36); 
             */
        }

        // MARK: Delegate 

        //Delegate signature 
        /*
        public delegate void AddData(String TaskName, String Duration);

        public AddData OnAddData;
 
        private void AddDataToTable()
        {
            if (OnAddData != null)
            {
                OnAddData(this, EventArgs.Empty); 
            }
        }

        */

        // MARK: Setup
        private void Setup()
        {
            SelfInit(); 
            TableInit(); 
        }


        private void SelfInit()
        {
            this.Text = "Hour Logs";
        }

        private void TableHeaderInit()
        {
            const int width = 200;
            listViewTransmit.View = View.Details;
            listViewTransmit.Columns.Add("Task", width, HorizontalAlignment.Center);
            listViewTransmit.Columns.Add("Date", width, HorizontalAlignment.Center);
            listViewTransmit.Columns.Add("Duration", width, HorizontalAlignment.Center);
        }

        private void TableInit() 
        {
            System.Drawing.Size s = new Size(this.Width, this.Height);
            listViewTransmit.Size = s;
            listViewTransmit.GridLines = true;

            TableHeaderInit();
        }


        public void AddRow(String TaskName, String Duration)
        {
            DateTime today = DateTime.Now; 
            listViewTransmit.Items.Add(new ListViewItem(new String[] { TaskName, today.ToString() , Duration})); 
        }

        private void TableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hide form instead of closing it
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }



    }
}
