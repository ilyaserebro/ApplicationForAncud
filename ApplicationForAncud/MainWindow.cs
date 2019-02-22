using System;
using System.Windows.Forms;
using System.Threading;


namespace ApplicationForAncud
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();

            OPF.Filter = "jpg|*.jpg|txt|*.txt|mkv|*.mkv";
            OPF.Multiselect = true;

            if (OPF.ShowDialog() == DialogResult.OK)
            {
                Thread add = new Thread(AddNote);
                add.Start(OPF.FileNames);
            }
        }

        private void AddNote(object fileNames)
        {
            string[] files = (string[])fileNames;
            foreach (var file in files)
            {
                uint resultCRC = CRCTools.CalculateCRC(file);

                if (resultCRC == 0xFFFFFFFF)
                {
                    MessageBox.Show("Failed to read file: " + file, "Error");
                    continue;
                }

                int rowNumber = dgvFileCRC.Rows.Add();

                dgvFileCRC.Rows[rowNumber].Cells[0].Value = file;
                dgvFileCRC.Rows[rowNumber].Cells[1].Value = resultCRC;
            }
            dgvFileCRC.CurrentCell = null;
            deleteButton.Enabled = false;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvFileCRC.SelectedRows)
            {
                dgvFileCRC.Rows.RemoveAt(row.Index);
            }

            deleteButton.Enabled = false;
            dgvFileCRC.CurrentCell = null;
        }

        private void AppForAncud_Load(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
        }


        private void dgvFileCRC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            deleteButton.Enabled = (dgvFileCRC.SelectedRows != null);
        }

    }
}
