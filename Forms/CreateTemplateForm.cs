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
    public partial class CreateTemplateForm : Form
    {


        // MARK: File Management 
        #region FileManagement

        // TODO: Add error handler 
        private String OpenFile()
        {
            String fileName = ""; 
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
            }

            return fileName; 
        }

        private void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }
        #endregion

        // MARK: Setup
        #region Init
        public CreateTemplateForm()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            SelfInit();
        }

        private void SelfInit()
        {
            String[] templateTypes = new String[] { "C programming" }; 
            String[] fileTypes = new String[] { "Regular file", "Test file" }; 
            this.Text = "Create Templates";

            foreach (String fileType in fileTypes)
            {
                comboBoxFileType.Items.Add(fileType); 
            }

            foreach (String templateType in templateTypes)
            {
                comboBoxTemplateType.Items.Add(templateType);
            }
        }
        #endregion

        private void CreateTemplateForm_Load(object sender, EventArgs e)
        {

        }

        #region Event Handler
        private void buttonCreate_Click(object sender, EventArgs e)
        {

        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            String saveFilePath = OpenFile();
            if (!comboBoxSaveDirectory.Items.Contains(saveFilePath))
            {
                comboBoxSaveDirectory.Items.Add(saveFilePath); 
            }
            comboBoxSaveDirectory.Text = saveFilePath;
        }
        #endregion

       
    }
}
