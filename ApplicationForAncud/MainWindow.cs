using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    class CRCTools
    {
        static uint[] tableCRC32;

        static CRCTools()
        {
            InitTableCRC32();
        }

        static void InitTableCRC32()
        {
            tableCRC32 = new uint[256];
            const uint POLYNOMIAL = 0xEDB88320;
            uint crc32;

            for (int i = 0; i < 256; i++)
            {
                crc32 = (uint)i;

                for (int j = 8; j > 0; j--)
                {
                    if ((crc32 & 1) == 1)
                        crc32 = (crc32 >> 1) ^ POLYNOMIAL;
                    else
                        crc32 >>= 1;
                }
        
                tableCRC32[i] = crc32;
            }
        }

        public static uint CalculateCRC(string fileName)
        {
            const int bufferSize = 1024;
            byte[] buffer = new byte[bufferSize];
            uint result = 0xFFFFFFFF;
            System.IO.FileStream stream = System.IO.File.OpenRead(fileName);
            int count = stream.Read(buffer, 0, bufferSize);

            while (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    result = ((result) >> 8)
                        ^ tableCRC32[(buffer[i])
                        ^ ((result) & 0x000000FF)];
                }

                count = stream.Read(buffer, 0, bufferSize);
            }

            return ~result;
        }
    }
}
