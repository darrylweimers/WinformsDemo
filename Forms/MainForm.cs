using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Template.Forms; 

namespace Template
{
    public partial class MainForm : Form
    {

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        // MARK: Form Properties 
        #region Form Properties
        private TableForm tableForm;
        private LogForm logForm;
        private CreateTemplateForm createTemplateForm;
        #endregion

        // MARK: Init 
        #region Init
        public MainForm()
        {
            InitializeComponent();
            Setup();
        }
        private void Setup()
        {
            SelfInit();
            LogFormInit();
            TableFormInit();
            CreateTemplateFormInit(); 
            StyleInit();
            LayoutInit();
            
        }

        private void StyleInit()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.BackColor = Color.White;
                childForm.ForeColor = Color.Black;
                childForm.Font = new Font("Arial Rounded MT Bold", 12, FontStyle.Regular); 
            }
        }

        private void SelfInit()
        {
            this.IsMdiContainer = true;
        }

        private void LayoutInit()
        {
            LayoutCheckUpdate(LayoutType.Cascade);
        }

        private void TableFormInit()
        {
            tableForm = new TableForm();
            tableForm.MdiParent = this;
            tableForm.Show(); 
        }

        private void LogFormInit()
        {
            logForm = new LogForm();
            logForm.completeDidClick += NewLogAvailable; 
            logForm.MdiParent = this;
            logForm.Show();
        }

        private void CreateTemplateFormInit()
        {
            createTemplateForm = new CreateTemplateForm();
            createTemplateForm.MdiParent = this;
            createTemplateForm.Show();
        }
        #endregion

        // MARK: Event Handler
        #region Event Handler
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
            this.Dispose();
            this.Close();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Hide();
            }
        }

       
        private void NewLogAvailable(object sender, EventArgs e)
        {
            tableForm.AddRow(logForm.task.name, logForm.task.duration); 
        }
        #endregion


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        // MARK: Layout 
        #region Form Layout
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
            LayoutCheckUpdate(LayoutType.Cascade); 
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
            LayoutCheckUpdate(LayoutType.Horizontal); 
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
            LayoutCheckUpdate(LayoutType.Vertical); 
        }

       
        enum LayoutType 
        {
            Cascade, Horizontal, Vertical

        }

        private void LayoutCheckUpdate(LayoutType layoutType)
        {
            switch(layoutType) 
            {
                case LayoutType.Cascade:
                    tileVerticalToolStripMenuItem.Checked = false; 
                    tileHorizontalToolStripMenuItem.Checked = false;
                    cascadeToolStripMenuItem.Checked = true; 
                    break;

                case LayoutType.Horizontal:
                    tileVerticalToolStripMenuItem.Checked = false; 
                    tileHorizontalToolStripMenuItem.Checked = true;
                    cascadeToolStripMenuItem.Checked = false; 
                    break;

                case LayoutType.Vertical:
                    tileVerticalToolStripMenuItem.Checked = true; 
                    tileHorizontalToolStripMenuItem.Checked = false;
                    cascadeToolStripMenuItem.Checked = false; 
                    break; 
            }

        }
        #endregion

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {

           
        }

        private void logTimeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logForm.Show(); 
        }

        private void tasksViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableForm.Show(); 
        }
    }
}
