using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

/*Создайте редактор на базе RichTextBox и добавьте в него возмож-
ность выбора из каталога и просмотра содержимого файла перета-
скиванием файла на поле редактора.  */

namespace Task_3
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFile = null;
        public Form1()
        {
            InitializeComponent();
            richTextBox.AllowDrop = true;
            DirectoryTreeNode();
            treeView.BeforeExpand += TreeView_BeforeSelect;

            treeView.ItemDrag += TreeView_ItemDrag;

            richTextBox.DragEnter += RichTextBox_DragEnter;
            richTextBox.DragDrop += RichTextBox_DragDrop;
            richTextBox.TextChanged += RichTextBox_TextChanged;
            richTextBox.SelectionChanged += RichTextBox_SelectionChanged;

            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            saveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;

            cutToolStripItem.Click += CutToolStripItem_Click;
            cutToolStripMenuItem.Click += CutToolStripItem_Click;

            undoToolStripItem.Click += UndoToolStripItem_Click;
            undoToolStripMenuItem.Click += UndoToolStripItem_Click;

            redoToolStripItem.Click += RedoToolStripItem_Click;
            redoToolStripMenuItem.Click += RedoToolStripItem_Click;

            pastToolStripItem.Click += PastToolStripItem_Click;
            pastToolStripMenuItem.Click += PastToolStripItem_Click;

            copyToolStripItem.Click += CopyToolStripItem_Click;
            copyToolStripMenuItem.Click += CopyToolStripItem_Click;

            deliteToolStripItem.Click += DeliteToolStripItem_Click;
            deliteToolStripMenuItem.Click += DeliteToolStripItem_Click;

            selectAllToolStripItem.Click += SelectAllToolStripItem_Click;

            fontToolStripMenuItem.Click += FontToolStripMenuItem_Click;
            colorToolStripMenuItem.Click += ColorToolStripMenuItem_Click;
            backColorToolStripMenuItem.Click += BackColorToolStripMenuItem_Click;

            centerToolStripMenuItem.Click += CenterToolStripMenuItem_Click;
            rightToolStripMenuItem.Click += RightToolStripMenuItem_Click;
            leftToolStripMenuItem.Click += LeftToolStripMenuItem_Click;
            tabToolStripMenuItem.Click += TabToolStripMenuItem_Click;

            сlearToolStripMenuItem.Click += СlearToolStripMenuItem_Click;
        }


        private void СlearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void TabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectionIndent = 20;
        }

        private void LeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void RightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void CenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void BackColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = richTextBox.SelectionBackColor;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionBackColor = dialog.Color;
            }
        }

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = richTextBox.SelectionColor;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionColor = dialog.Color;
            }
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.Font = richTextBox.SelectionFont;
            dialog.Color = richTextBox.SelectionColor;
            dialog.ShowColor = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox.SelectionFont = dialog.Font;
                richTextBox.SelectionColor = dialog.Color;
            }
        }
        private void SelectAllToolStripItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectAll();
        }
        private void DeliteToolStripItem_Click(object sender, EventArgs e)
        {
            richTextBox.SelectedText = "";
        }

        private void CopyToolStripItem_Click(object sender, EventArgs e)
        {
            richTextBox.Copy();
        }

        private void PastToolStripItem_Click(object sender, EventArgs e)
        {
            richTextBox.Paste();
        }
        private void RedoToolStripItem_Click(object sender, EventArgs e)
        {
            richTextBox.Redo();
        }
        private void UndoToolStripItem_Click(object sender, EventArgs e)
        {
            richTextBox.Undo();
        }

        private void CutToolStripItem_Click(object sender, EventArgs e)
        {
            richTextBox.Cut();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "All file(*.*)|*.*|TXT file (*.txt)|*.txt|RTF file(*.rtf)|*.rtf";
            saveFile.FilterIndex = 2;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (saveFile.FileName.EndsWith("rtf"))
                    {
                        richTextBox.SaveFile(saveFile.FileName, RichTextBoxStreamType.RichText);
                    }
                    else
                    {
                        richTextBox.SaveFile(saveFile.FileName, RichTextBoxStreamType.PlainText);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFile.FileName != "")
            {
                if (openFile.FileName.EndsWith("rtf"))
                {
                    richTextBox.SaveFile(openFile.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    richTextBox.SaveFile(openFile.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox.Text == "" || openFile.FileName != null)
            {
                labelText.Visible = false;
                richTextBox.BackColor = Color.White;
                pathToolStripLabel.Visible = true;
                pathToolStripLabel.Text = openFile.FileName;
                menuStrip.Enabled = true;
                richTextBox.ContextMenuStrip = contextMenuStrip;
                contextMenuStrip.Enabled = true;
                lineLabel.Visible = true;
            }
            else
            {
                Refresh();
            }
            lineLabel.Text = $"Cтрок:{richTextBox.Lines.Length} | Символов:{richTextBox.Text.Length}";

            undoToolStripItem.Enabled = richTextBox.CanUndo;
            undoToolStripMenuItem.Enabled = richTextBox.CanUndo;

            redoToolStripItem.Enabled = richTextBox.CanRedo;
            redoToolStripMenuItem.Enabled = richTextBox.CanRedo;

        }
        private void RichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            if (richTextBox.SelectedText == "")
            {
                cutToolStripItem.Enabled = false;
                copyToolStripItem.Enabled = false;
                deliteToolStripItem.Enabled = false;

                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                deliteToolStripMenuItem.Enabled = false;
            }
            else
            {
                cutToolStripItem.Enabled = true;
                copyToolStripItem.Enabled = true;
                deliteToolStripItem.Enabled = true;

                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                deliteToolStripMenuItem.Enabled = true;
            }
        }

        private void RichTextBox_DragDrop(object sender, DragEventArgs e)
        {
            openFile = new OpenFileDialog();
            string name = e.Data.GetData(DataFormats.Text).ToString();
            richTextBox.Clear();
            try
            {
                openFile = new OpenFileDialog();
                openFile.FileName = name;

            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Refresh();
            }
        }

        private void RichTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void TreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            richTextBox.ReadOnly = false;
            TreeNode s = (TreeNode)e.Item;
            openFile = new OpenFileDialog();
            DoDragDrop(s.FullPath, DragDropEffects.Copy | DragDropEffects.Move);
            try
            {
                if (openFile.FileName.EndsWith("rtf"))
                {
                    richTextBox.LoadFile(openFile.FileName, RichTextBoxStreamType.RichText);
                }
                else
                {
                    using (StreamReader reader = new StreamReader(openFile.FileName, Encoding.Default))
                    {
                        richTextBox.Text = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Refresh();
            }
        }

        private void TreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();
            try
            {
                if (Directory.Exists(e.Node.FullPath))
                {
                    string[] dir = Directory.GetDirectories(e.Node.FullPath);
                    for (int i = 0; i < dir.Length; i++)
                    {
                        TreeNode dirNode = new TreeNode(new DirectoryInfo(dir[i]).Name);
                        FillTreeNode(dirNode, dir[i]);
                        e.Node.Nodes.Add(dirNode);
                    }
                    string[] file = Directory.GetFiles(e.Node.FullPath);
                    for (int i = 0; i < file.Length; i++)
                    {
                        TreeNode fileNode = new TreeNode(new DirectoryInfo(file[i]).Name);
                        e.Node.Nodes.Add(fileNode);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Refresh();
            }
        }
        private void DirectoryTreeNode()
        {
            try
            {
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    TreeNode treeNode = new TreeNode(drive.Name);
                    FillTreeNode(treeNode, drive.Name);
                    treeView.Nodes.Add(treeNode);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Refresh();
            }
        }
        private void FillTreeNode(TreeNode driveNode, string path)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(path);//добавляем + если есть папки
                foreach (string dir in dirs)
                {
                    TreeNode dirNode = new TreeNode(dir.Remove(0, dir.LastIndexOf("\\") + 1));
                    driveNode.Nodes.Add(dirNode);
                }
                string[] files = Directory.GetFiles(path);//добавляем + когда нет папок, а есть только файлы
                foreach (string file in files)
                {
                    TreeNode fileNode = new TreeNode(new DirectoryInfo(file).Name);
                    driveNode.Nodes.Add(fileNode);
                }
            }
            catch (Exception)
            {

            }
        }
        public override void Refresh()
        {
            labelText.Visible = true;
            richTextBox.Text = "";
            richTextBox.ReadOnly = true;
            richTextBox.BackColor = Color.LightGray;
            labelText.Visible = true;
            pathToolStripLabel.Visible = false;
            pathToolStripLabel.Text = openFile.FileName;
            menuStrip.Enabled = false;
            contextMenuStrip.Enabled = false;
            lineLabel.Visible = false;
            lineLabel.Text = "";
        }
    }
}
