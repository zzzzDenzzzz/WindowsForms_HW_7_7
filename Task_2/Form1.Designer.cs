namespace Task_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_tile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_list = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_table = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_icons = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_content = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView.ContextMenuStrip = this.contextMenuStrip1;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(12, 12);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(776, 426);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Tile;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_tile,
            this.toolStripMenuItem_list,
            this.toolStripMenuItem_table,
            this.toolStripMenuItem_icons,
            this.toolStripMenuItem_content});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 114);
            this.contextMenuStrip1.Text = "Вид";
            // 
            // toolStripMenuItem_tile
            // 
            this.toolStripMenuItem_tile.Name = "toolStripMenuItem_tile";
            this.toolStripMenuItem_tile.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem_tile.Text = "Плитка";
            this.toolStripMenuItem_tile.Click += new System.EventHandler(this.toolStripMenuItem_tile_Click);
            // 
            // toolStripMenuItem_list
            // 
            this.toolStripMenuItem_list.Name = "toolStripMenuItem_list";
            this.toolStripMenuItem_list.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem_list.Text = "Список";
            this.toolStripMenuItem_list.Click += new System.EventHandler(this.toolStripMenuItem_list_Click);
            // 
            // toolStripMenuItem_table
            // 
            this.toolStripMenuItem_table.Name = "toolStripMenuItem_table";
            this.toolStripMenuItem_table.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem_table.Text = "Таблица";
            this.toolStripMenuItem_table.Click += new System.EventHandler(this.toolStripMenuItem_table_Click);
            // 
            // toolStripMenuItem_icons
            // 
            this.toolStripMenuItem_icons.Name = "toolStripMenuItem_icons";
            this.toolStripMenuItem_icons.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem_icons.Text = "Иконки";
            this.toolStripMenuItem_icons.Click += new System.EventHandler(this.toolStripMenuItem_icons_Click);
            // 
            // toolStripMenuItem_content
            // 
            this.toolStripMenuItem_content.Name = "toolStripMenuItem_content";
            this.toolStripMenuItem_content.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem_content.Text = "Содержимое";
            this.toolStripMenuItem_content.Click += new System.EventHandler(this.toolStripMenuItem_content_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Computer-Hardware-Notebook-icon.png");
            this.imageList.Images.SetKeyName(1, "FauxS-XP (Cobalt) V1.5 Icon 04.ico");
            this.imageList.Images.SetKeyName(2, "FauxS-XP (Cobalt) V1.5 Icon 25.ico");
            this.imageList.Images.SetKeyName(3, "FauxS-XP (Cobalt) V1.5 Icon 28.ico");
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 200;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_tile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_list;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_table;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_icons;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_content;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}

