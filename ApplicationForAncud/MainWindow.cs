using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationForAncud
{

    public partial class MainWindow : Form
    {
        // Поля

        private const int maxCountTask = 3;
        const string pending = "Pending";
        const string computing = "Computing";
        const string help = "Click \"Add\" and select file(s) to add it in table " +
                            "and calculate CRC. \n" +
                            "If You want delete note(s) from table, select note(s) and " +
                            "click \"Delete\". ";

        private struct IDFileToken
        {
            public string fileID;
            public string file;
            public CancellationToken token;
            public CancellationTokenSource tokenSource;
        }

        List<IDFileToken> pendingFileQueue = new List<IDFileToken>();
        List<IDFileToken> currentTaskList = new List<IDFileToken>();
        TaskScheduler contextUI;
        private Mutex mutex = new Mutex();
        private uint fileCounter;

        //Обработчики

        public MainWindow()
        {
            fileCounter = 0;
            InitializeComponent();
        }

        private void AppForAncud_Load(object sender, EventArgs e)
        {
            contextUI = TaskScheduler.FromCurrentSynchronizationContext();

            Task.Run(() => DealerThread());
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog OPF = new OpenFileDialog();

            OPF.Filter = "jpg|*.jpg|txt|*.txt|mkv|*.mkv";
            OPF.Multiselect = true;

            if (OPF.ShowDialog() == DialogResult.OK)
            {
                deleteButton.Enabled = false;
                AddPendingNote(OPF.FileNames);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            mutex.WaitOne();
            foreach (DataGridViewRow row in dgvFileCRC.SelectedRows)
            {
                DeleteNote(row);
            }
            mutex.ReleaseMutex();

            deleteButton.Enabled = false;
            dgvFileCRC.CurrentCell = null;
        }

        private void dgvFileCRC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            deleteButton.Enabled = (dgvFileCRC.SelectedRows != null);
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(help, "Help");
        }

        //Вспомогательные методы

        private void AddPendingNote(object fileNames)
        {
            string[] files = (string[])fileNames;
            //сначала добавляем файлы со статусом "Computing"
            foreach (var file in files)
            {
                int rowIndex = dgvFileCRC.Rows.Add();
                string fileID = (++fileCounter).ToString();

                CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
                CancellationToken token = cancelTokenSource.Token;

                dgvFileCRC.Rows[rowIndex].Cells["columnId"].Value = fileID;
                dgvFileCRC.Rows[rowIndex].Cells["columnFile"].Value = file;
                dgvFileCRC.Rows[rowIndex].Cells["columnCRC32"].Value = pending;
                pendingFileQueue.Add(new IDFileToken
                { fileID = fileID, file = file, token = token,
                    tokenSource = cancelTokenSource});

                dgvFileCRC.CurrentCell = null;
            }
        }

        private void DeleteNote(DataGridViewRow row)
        {
            string fileID = dgvFileCRC.Rows[row.Index].Cells["columnId"].Value.ToString();
            string status = dgvFileCRC.Rows[row.Index].Cells["columnCRC32"].Value.ToString();

            if (status == pending)
            {
                int index = FindFileInList(pendingFileQueue, fileID);
                pendingFileQueue.RemoveAt(index);
            }
            else if (status == computing)
            {
                int index = FindFileInList(currentTaskList, fileID);
                currentTaskList[index].tokenSource.Cancel();
            }
            
            dgvFileCRC.Rows.RemoveAt(row.Index);
        }

        private void DealerThread()
        {
            while (true)
            {
                if (pendingFileQueue.Count != 0 && currentTaskList.Count < maxCountTask)
                {
                    mutex.WaitOne();
                    //Забираем файл из начала очереди
                    IDFileToken currentFile = pendingFileQueue[0];
                    pendingFileQueue.RemoveAt(0);

                    //Помещаем его в список выполняемых задач
                    currentTaskList.Add(currentFile);
                    mutex.ReleaseMutex();

                    //Меняем его статус на Computing
                    Task setComputing = Task.Factory.StartNew(() =>
                        SetComputingStatus(currentFile.fileID),
                        CancellationToken.None, TaskCreationOptions.None, contextUI);

                    //setComputing.Wait();
                    // MessageBox.Show(Thread.CurrentThread.ManagedThreadId.ToString());

                    //считаем CRC

                    var calcCRC = Task.Run(() => CRCTools.CalculateCRC(currentFile.file,
                        currentFile.token));

                    //записываем CRC
                    calcCRC.ContinueWith((t) => SetCRC(currentFile.fileID,
                        calcCRC.Result.ToString()), CancellationToken.None,
                        TaskContinuationOptions.OnlyOnRanToCompletion, contextUI);

                    //удаляем из списка текущих задач
                    calcCRC.ContinueWith((t) =>
                    {
                        mutex.WaitOne();
                        int index = FindFileInList(currentTaskList, currentFile.fileID);
                        currentTaskList.RemoveAt(index);
                        mutex.ReleaseMutex();
                    });
                }
            }
        }

        private int FindRowIndex(string fileID)
        {
            foreach (DataGridViewRow row in dgvFileCRC.Rows)
            {
                if (row.Cells["columnId"].Value.ToString() == fileID)
                {
                    return row.Index;
                }
            }
            return -1;
        }

        private int FindFileInList(List<IDFileToken> list, string id)
        {

            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i].fileID == id)
                {
                    return i;
                }
            }
            return -1;
        }

        private void SetComputingStatus(string fileID)
        {
            int rowIndex = FindRowIndex(fileID);
            dgvFileCRC.Rows[rowIndex].Cells["columnCRC32"].Value = computing;
        }

        private void SetCRC(string fileID, string crc)
        {
            int rowIndex = FindRowIndex(fileID);
            dgvFileCRC.Rows[rowIndex].Cells["columnCRC32"].Value = crc.ToString();
        }
    }
}
