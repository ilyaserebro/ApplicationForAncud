using System;
using System.Windows.Forms;

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

            OPF.Filter = "jpg|*.jpg|txt|*.txt";
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                int rowNumber = dgvFileCRC.Rows.Add();

                dgvFileCRC.Rows[rowNumber].Cells[0].Value = OPF.FileName;
                dgvFileCRC.Rows[rowNumber].Cells[1].Value = CRCTools.CalculateCRC(OPF.FileName);
                dgvFileCRC.CurrentCell = null;
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int deleteNumber = dgvFileCRC.SelectedCells[0].RowIndex;
            string fileName = dgvFileCRC.SelectedCells[0].Value.ToString();

            dgvFileCRC.Rows.RemoveAt(deleteNumber);
            deleteButton.Enabled = false;
            dgvFileCRC.CurrentCell = null;
        }

        private void AppForAncud_Load(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
        }


        private void dgvFileCRC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            deleteButton.Enabled = (dgvFileCRC.CurrentRow != null);
        }

    }
}
