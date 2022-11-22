using System;
using System.IO;
using System.Windows.Forms;

/*Создайте  приложение  на  базе  ListView  для  просмотра  каталога 
файлов в 5-ти вариантах, для вариантов иконки-плитка-список изо-
бражений отображать содержимое графических файлов. */

namespace Task_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView.SmallImageList = imageList;
            P();
        }

        private void toolStripMenuItem_tile_Click(object sender, EventArgs e)
        {
            listView.View = View.Tile;
        }

        private void toolStripMenuItem_list_Click(object sender, EventArgs e)
        {
            listView.View = View.List;
        }

        private void toolStripMenuItem_table_Click(object sender, EventArgs e)
        {
            listView.View = View.Details;
        }

        private void toolStripMenuItem_icons_Click(object sender, EventArgs e)
        {
            listView.View = View.LargeIcon;
        }

        void P()
        {
            string path = "Files";
            // получаем все файлы
            string[] files = Directory.GetFiles(path);
            // перебор полученных файлов
            foreach (string file in files)
            {
                ListViewItem lvi = new ListViewItem();
                // установка названия файла
                lvi.Text = file.Remove(0, file.LastIndexOf('\\') + 1);
                lvi.ImageIndex = 0; // установка картинки для файла
                // добавляем элемент в ListView
                listView.Items.Add(lvi);
                listView.View = View.Details;
            }
        }

        private void toolStripMenuItem_content_Click(object sender, EventArgs e)
        {
            listView.View = View.SmallIcon;
        }
    }
}
