namespace AuthorsAndBooks
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.loadDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDataMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.authorsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addAuthorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editAuthorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAuthorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.booksMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addBookMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editBookMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteBookMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllBooksMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewBooksByAuthorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterBooksByAuthorMenuItem = new System.Windows.Forms.ToolStripMenuItem(); // Новый элемент

            this.mainTextBox = new System.Windows.Forms.TextBox();

            this.menuStrip.SuspendLayout();
            this.SuspendLayout();

            // MenuStrip
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.fileMenu,
                this.authorsMenu,
                this.booksMenu,
                this.viewMenu
            });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";

            // File Menu
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.loadDataMenuItem,
                this.saveDataMenuItem,
                this.exitMenuItem
            });
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(48, 20);
            this.fileMenu.Text = "Файл";

            this.loadDataMenuItem.Name = "loadDataMenuItem";
            this.loadDataMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadDataMenuItem.Text = "Загрузить данные";

            this.saveDataMenuItem.Name = "saveDataMenuItem";
            this.saveDataMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveDataMenuItem.Text = "Сохранить данные";

            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitMenuItem.Text = "Выход";

            // Authors Menu
            this.authorsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.addAuthorMenuItem,
                this.editAuthorMenuItem,
                this.deleteAuthorMenuItem
            });
            this.authorsMenu.Name = "authorsMenu";
            this.authorsMenu.Size = new System.Drawing.Size(61, 20);
            this.authorsMenu.Text = "Авторы";

            this.addAuthorMenuItem.Name = "addAuthorMenuItem";
            this.addAuthorMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addAuthorMenuItem.Text = "Добавить автора";

            this.editAuthorMenuItem.Name = "editAuthorMenuItem";
            this.editAuthorMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editAuthorMenuItem.Text = "Редактировать автора";

            this.deleteAuthorMenuItem.Name = "deleteAuthorMenuItem";
            this.deleteAuthorMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteAuthorMenuItem.Text = "Удалить автора";

            // Books Menu
            this.booksMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.addBookMenuItem,
                this.editBookMenuItem,
                this.deleteBookMenuItem
            });
            this.booksMenu.Name = "booksMenu";
            this.booksMenu.Size = new System.Drawing.Size(49, 20);
            this.booksMenu.Text = "Книги";

            this.addBookMenuItem.Name = "addBookMenuItem";
            this.addBookMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addBookMenuItem.Text = "Добавить книгу";

            this.editBookMenuItem.Name = "editBookMenuItem";
            this.editBookMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editBookMenuItem.Text = "Редактировать книгу";

            this.deleteBookMenuItem.Name = "deleteBookMenuItem";
            this.deleteBookMenuItem.Size = new System.Drawing.Size(180, 22);
            this.deleteBookMenuItem.Text = "Удалить книгу";

            // View Menu
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.viewAllBooksMenuItem,
                this.viewBooksByAuthorMenuItem,
                this.filterBooksByAuthorMenuItem // Новый элемент
            });
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(81, 20);
            this.viewMenu.Text = "Просмотр";

            this.viewAllBooksMenuItem.Name = "viewAllBooksMenuItem";
            this.viewAllBooksMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewAllBooksMenuItem.Text = "Все книги";

            this.viewBooksByAuthorMenuItem.Name = "viewBooksByAuthorMenuItem";
            this.viewBooksByAuthorMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewBooksByAuthorMenuItem.Text = "Книги по автору";

            // Настройка свойства для нового пункта меню
            this.filterBooksByAuthorMenuItem.Name = "filterBooksByAuthorMenuItem";
            this.filterBooksByAuthorMenuItem.Size = new System.Drawing.Size(180, 22);
            this.filterBooksByAuthorMenuItem.Text = "Фильтровать по автору";
            this.filterBooksByAuthorMenuItem.Click += new System.EventHandler(this.FilterBooksByAuthorMenuItem_Click); // Добавление обработчика

            // Main TextBox
            this.mainTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTextBox.Location = new System.Drawing.Point(0, 24);
            this.mainTextBox.Multiline = true;
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.ReadOnly = true;
            this.mainTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.mainTextBox.Size = new System.Drawing.Size(800, 426);
            this.mainTextBox.TabIndex = 1;

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainTextBox);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Авторы и книги";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem loadDataMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDataMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem authorsMenu;
        private System.Windows.Forms.ToolStripMenuItem addAuthorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editAuthorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAuthorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem booksMenu;
        private System.Windows.Forms.ToolStripMenuItem addBookMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editBookMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteBookMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem viewAllBooksMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewBooksByAuthorMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterBooksByAuthorMenuItem; // Новый элемент
        private System.Windows.Forms.TextBox mainTextBox;

        // Обработчик для фильтрации книг по автору
        private void FilterBooksByAuthorMenuItem_Click(object sender, EventArgs e)
        {
            // Логика фильтрации книг по автору (пример)
            mainTextBox.Text = "Фильтрация книг по автору еще не реализована.";
        }
    }
}
