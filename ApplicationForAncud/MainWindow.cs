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
                MessageBox.Show("File " + OPF.FileName + " added.", "Add", MessageBoxButtons.OK);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dgvFileCRC.CurrentRow == null)
            {
                MessageBox.Show("Choose row!");
                return;
            }

            int deleteNumber = dgvFileCRC.SelectedCells[0].RowIndex;
            string fileName = dgvFileCRC.SelectedCells[0].Value.ToString();

            dgvFileCRC.Rows.RemoveAt(deleteNumber);
            MessageBox.Show("File " + fileName + " deleted.", "Delete", MessageBoxButtons.OK);
        }

        private void AppForAncud_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
