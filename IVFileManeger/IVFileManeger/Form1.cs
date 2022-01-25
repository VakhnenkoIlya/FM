using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace IVFileManeger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
            disksButton = new List<Button>();
            ShowDisk(GetAllDisk());
            FileTree(GetAllDisk()[0]);
            textBox = new Form2();
            changeName = textBox.changeName;
        }

        List<Button> disksButton;
        string pathOpen;
        string changeName;
        Form2 textBox;
        Filemanager fm = new();
       
        
    
        public List<string> GetAllDisk()
        {
            
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            List<string> disk = new List<string>();
            foreach (DriveInfo d in allDrives)
            {
                disk.Add(d.Name);
            }
            return disk;
            
        }

        public void CreateButton(int number, string name)
        {
            Button button = new Button();
            button.Text = name;
            button.Size = new Size(75, 23);
            button.Click += ButtonTree;
            if (number == 0)
            {
                button.Location = new Point(12, 90);
            }
            if (number > 0)
            {
                button.Location = new Point(97 * number, 90);
            }
            Controls.Add(button);
            disksButton.Add(button);
        }

        private void ButtonTree(object sender, EventArgs e)
        {
            FileTree(((Button)sender).Text);
        }

        private void DeleteDiskButton(Button diskBtn)
        {
            if (Controls.Contains(diskBtn))
            {
                Controls.Remove(diskBtn);
            }
        }
        private void ShowDisk(List<string> disk)
        {
            if (disksButton.Count > 0)
            {
                for (int i = 0; i < disksButton.Count; i++)
                {
                    DeleteDiskButton(disksButton[i]);
                }
                disksButton.Clear();
            }
            for (int i = 0; i < disk.Count - 1; i++)
            {
                CreateButton(i, disk[i]);
            }
        }

        public void FileTree(string path)
        {
            string[] diskTree = Directory.GetFileSystemEntries(path);
            var directory = new DirectoryInfo(path);
            if (path == directory.Root.FullName)
            {
                FMtree.Nodes.Clear();
                FMtree.Nodes.Add(path);
            }
            else
            {
                FMtree.Nodes.Clear();
                FMtree.Nodes.Add(path);
                FMtree.Nodes.Add(directory.Parent.FullName);
            }
            for (int i = 0; i < diskTree.Length; i++)
            {
                FMtree.Nodes[0].Nodes.Add(diskTree[i]);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowDisk(GetAllDisk());
            FileTree(pathOpen);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            pathOpen = e.Node.Text;
            InitializeMyControl();
            FileInfo allFails = new FileInfo(pathOpen);
            if (allFails.Exists)
            {
                MessageBox.Show("Это файл");
            }
            else FileTree(e.Node.Text);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var directory = new DirectoryInfo(pathOpen);
            IFMEntity entity;
            string message;
            if (File.Exists(pathOpen))
            {
                entity = new FMFile(pathOpen);
                message = "файл удален";
            }
            else
            {
                entity = new FMDirectory(pathOpen);
                message = "папка удалена";
            }
            fm.Execute(new DeleteCommand(pathOpen, entity));
            MessageBox.Show($"{message}");
            pathOpen = directory.Parent.FullName; 
            InitializeMyControl();
            FileTree(pathOpen);
        }
     
        private void DialogCreateDirectory()
        {
            
            DialogResult result = MessageBox.Show("Вы хотите создать папку?",
                "Сообщение",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                IFMEntity entity = new FMDirectory(pathOpen);
                textBox.ShowDialog();
                string name = textBox.changeName;
                string nameNewFile = (pathOpen + "\\" + name);
                fm.Execute(new CreateCommand(nameNewFile, entity));
                MessageBox.Show($"Папка {name} создана");
            }
            if (result == DialogResult.No)
            {
                DialogFileCreate();
            }
        }
        private void DialogFileCreate()
        {
            IFMEntity entity = new FMFile(pathOpen);
            DialogResult result = MessageBox.Show("Вы хотите создать файл?",
             "Сообщение",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Information,
              MessageBoxDefaultButton.Button1,
              MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                textBox.ShowDialog();
                string name = textBox.changeName;
                string nameNewFile = (pathOpen + "\\" + name + ".txt");
                fm.Execute(new CreateCommand(nameNewFile, entity));
                MessageBox.Show($"Файл {name} создан");
            }  
        }
        private void Create_Click(object sender, EventArgs e)
        {
            DialogCreateDirectory();
            InitializeMyControl();
            FileTree(pathOpen);
        }
        private void InitializeMyControl()
        { 
            textBox1.Text = pathOpen;
        }
        private void ReName_Click(object sender, EventArgs e)
        {
            IFMEntity entity = new FMDirectory(pathOpen);
            textBox.ShowDialog();
            string newname = textBox.changeName;
            string newPath = pathOpen.Remove(pathOpen.LastIndexOf('\\')) + "\\" + newname;
            fm.Execute(new ReNameCommand(pathOpen, newPath, entity));
        }
    } 
}
