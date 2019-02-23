using System;
using System.Windows.Forms;
using System.Threading;

namespace ApplicationForAncud
{
    public partial class MainWindow : Form
    {
        const string computing = "Computing...";
        const string help = "Click \"Add\" and select file(s) to add it in table " +
                            "and calculate CRC. \n" +
                            "If You want delete note(s) from table, select note(s) and " +
                            "click \"Delete\". ";

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
            //сначала добавляем файлы со статусом "Computing"
            foreach (var file in files)
            {
                int rowIndex = dgvFileCRC.Rows.Add();

                dgvFileCRC.Rows[rowIndex].Cells[0].Value = file;
                dgvFileCRC.Rows[rowIndex].Cells[1].Value = computing;
                dgvFileCRC.CurrentCell = null;
                deleteButton.Enabled = false;
            }
            //обновляем статус
            foreach (var file in files)
            {
                int rowIndex = FindRowIndex(file);
                if (rowIndex == -1)
                {
                    continue;
                }

                uint resultCRC = CRCTools.CalculateCRC(file);

                rowIndex = FindRowIndex(file);
                if (rowIndex == -1)
                {
                    continue;
                }

                if (resultCRC == 0xFFFFFFFF)
                {
                    MessageBox.Show("Failed to read file: " + file, "Error");
                    dgvFileCRC.Rows.RemoveAt(rowIndex);
                    continue;
                }
                else
                {
                    dgvFileCRC.Rows[rowIndex].Cells[1].Value = resultCRC;
                }
            }
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

        private int FindRowIndex(string file)
        {
            foreach (DataGridViewRow row in dgvFileCRC.Rows)
            {
                if(row.Cells[0].Value.ToString() == file &&
                    row.Cells[1].Value.ToString() == computing)
                {
                    return row.Index;
                }
            }
            return -1;
        }

        private void AppForAncud_Load(object sender, EventArgs e)
        {
            deleteButton.Enabled = false;
        }


        private void dgvFileCRC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            deleteButton.Enabled = (dgvFileCRC.SelectedRows != null);
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(help, "Help");
        }
    }
}
