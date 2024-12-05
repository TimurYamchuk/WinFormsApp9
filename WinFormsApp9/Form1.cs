using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AuthorsAndBooks
{
    public partial class Form1 : Form
    {
        private Dictionary<string, List<string>> catalog = new Dictionary<string, List<string>>();

        public Form1()
        {
            InitializeComponent();
            BindEvents();
            LoadKnownAuthorsAndBooks(); // Загрузка известных авторов и книг при старте приложения
        }

        private void BindEvents()
        {
            loadDataMenuItem.Click += (s, e) => LoadData();
            saveDataMenuItem.Click += (s, e) => SaveData();
            exitMenuItem.Click += (s, e) => Close();

            addAuthorMenuItem.Click += (s, e) => AddAuthor();
            editAuthorMenuItem.Click += (s, e) => EditAuthor();
            deleteAuthorMenuItem.Click += (s, e) => DeleteAuthor();

            addBookMenuItem.Click += (s, e) => AddBook();
            editBookMenuItem.Click += (s, e) => EditBook();
            deleteBookMenuItem.Click += (s, e) => DeleteBook();

            viewAllBooksMenuItem.Click += (s, e) => ViewAllBooks();
            viewBooksByAuthorMenuItem.Click += (s, e) => ViewBooksByAuthor();
            filterBooksByAuthorMenuItem.Click += (s, e) => FilterBooksByAuthor();
        }

        private void LoadKnownAuthorsAndBooks()
        {
            // Пример известных авторов и их книг
            catalog["Лев Толстой"] = new List<string> { "Война и мир", "Анна Каренина", "Воскресение" };
            catalog["Федор Достоевский"] = new List<string> { "Преступление и наказание", "Идиот", "Братья Карамазовы" };
            catalog["Александр Пушкин"] = new List<string> { "Евгений Онегин", "Капитанская дочка", "Руслан и Людмила" };
            catalog["Антон Чехов"] = new List<string> { "Вишневый сад", "Три сестры", "Дядя Ваня" };

            MessageBox.Show("Известные авторы и книги загружены!", "Успех");
        }

        private void LoadData()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Text Files (*.txt)|*.txt", Title = "Загрузить данные" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        catalog = File.ReadAllLines(openFileDialog.FileName)
                            .Select(line => line.Split('|'))
                            .Where(parts => parts.Length == 2)
                            .ToDictionary(parts => parts[0], parts => parts[1].Split(',').ToList());
                        MessageBox.Show("Данные успешно загружены!", "Успех");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка");
                    }
                }
            }
        }

        private void SaveData()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Text Files (*.txt)|*.txt", Title = "Сохранить данные" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllLines(saveFileDialog.FileName, catalog.Select(entry => $"{entry.Key}|{string.Join(",", entry.Value)}"));
                        MessageBox.Show("Данные успешно сохранены!", "Успех");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка");
                    }
                }
            }
        }

        private void AddAuthor()
        {
            string author = PromptInput("Введите имя автора:");
            if (!string.IsNullOrWhiteSpace(author))
            {
                if (!catalog.ContainsKey(author))
                {
                    catalog[author] = new List<string>();
                    MessageBox.Show("Автор добавлен!", "Успех");
                }
                else
                {
                    ShowError("Автор уже существует!");
                }
            }
        }

        private void EditAuthor()
        {
            string oldAuthor = PromptInput("Введите имя автора для редактирования:");
            if (catalog.ContainsKey(oldAuthor))
            {
                string newAuthor = PromptInput("Введите новое имя автора:");
                if (!string.IsNullOrWhiteSpace(newAuthor) && !catalog.ContainsKey(newAuthor))
                {
                    catalog[newAuthor] = catalog[oldAuthor];
                    catalog.Remove(oldAuthor);
                    MessageBox.Show("Автор изменён!", "Успех");
                }
                else
                {
                    ShowError("Автор с таким именем уже существует или введено пустое имя!");
                }
            }
            else
            {
                ShowError("Автор не найден!");
            }
        }

        private void DeleteAuthor()
        {
            string author = PromptInput("Введите имя автора для удаления:");
            if (catalog.Remove(author))
            {
                MessageBox.Show("Автор удалён!", "Успех");
            }
            else
            {
                ShowError("Автор не найден!");
            }
        }

        private void AddBook()
        {
            string author = PromptInput("Введите имя автора:");
            if (catalog.ContainsKey(author))
            {
                string book = PromptInput("Введите название книги:");
                if (!string.IsNullOrWhiteSpace(book))
                {
                    catalog[author].Add(book);
                    MessageBox.Show("Книга добавлена!", "Успех");
                }
            }
            else
            {
                ShowError("Автор не найден!");
            }
        }

        private void EditBook()
        {
            string author = PromptInput("Введите имя автора:");
            if (catalog.ContainsKey(author))
            {
                string oldBook = PromptInput("Введите название книги для редактирования:");
                if (catalog[author].Contains(oldBook))
                {
                    string newBook = PromptInput("Введите новое название книги:");
                    int index = catalog[author].IndexOf(oldBook);
                    catalog[author][index] = newBook;
                    MessageBox.Show("Книга изменена!", "Успех");
                }
                else
                {
                    ShowError("Книга не найдена!");
                }
            }
            else
            {
                ShowError("Автор не найден!");
            }
        }

        private void DeleteBook()
        {
            string author = PromptInput("Введите имя автора:");
            if (catalog.ContainsKey(author))
            {
                string book = PromptInput("Введите название книги для удаления:");
                if (catalog[author].Remove(book))
                {
                    MessageBox.Show("Книга удалена!", "Успех");
                }
                else
                {
                    ShowError("Книга не найдена!");
                }
            }
            else
            {
                ShowError("Автор не найден!");
            }
        }

        private void ViewAllBooks()
        {
            mainTextBox.Clear();
            foreach (var entry in catalog)
            {
                mainTextBox.AppendText($"Автор: {entry.Key}\r\n");
                foreach (var book in entry.Value)
                {
                    mainTextBox.AppendText($"    - {book}\r\n");
                }
            }
        }

        private void ViewBooksByAuthor()
        {
            string author = PromptInput("Введите имя автора:");
            if (catalog.ContainsKey(author))
            {
                mainTextBox.Clear();
                mainTextBox.AppendText($"Автор: {author}\r\n");
                foreach (var book in catalog[author])
                {
                    mainTextBox.AppendText($"    - {book}\r\n");
                }
            }
            else
            {
                ShowError("Автор не найден!");
            }
        }

        private void FilterBooksByAuthor()
        {
            string author = PromptInput("Введите имя автора для фильтрации:");
            if (catalog.ContainsKey(author))
            {
                mainTextBox.Clear();
                mainTextBox.AppendText($"Фильтр по автору: {author}\r\n");
                foreach (var book in catalog[author])
                {
                    mainTextBox.AppendText($"    - {book}\r\n");
                }
            }
            else
            {
                ShowError("Автор не найден!");
            }
        }

        private string PromptInput(string prompt)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(prompt, "Ввод данных", "");
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка");
        }
    }
}
