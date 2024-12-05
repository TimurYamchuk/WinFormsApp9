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
            LoadKnownAuthorsAndBooks(); // �������� ��������� ������� � ���� ��� ������ ����������
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
            // ������ ��������� ������� � �� ����
            catalog["��� �������"] = new List<string> { "����� � ���", "���� ��������", "�����������" };
            catalog["����� �����������"] = new List<string> { "������������ � ���������", "�����", "������ ����������" };
            catalog["��������� ������"] = new List<string> { "������� ������", "����������� �����", "������ � �������" };
            catalog["����� �����"] = new List<string> { "�������� ���", "��� ������", "���� ����" };

            MessageBox.Show("��������� ������ � ����� ���������!", "�����");
        }

        private void LoadData()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Text Files (*.txt)|*.txt", Title = "��������� ������" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        catalog = File.ReadAllLines(openFileDialog.FileName)
                            .Select(line => line.Split('|'))
                            .Where(parts => parts.Length == 2)
                            .ToDictionary(parts => parts[0], parts => parts[1].Split(',').ToList());
                        MessageBox.Show("������ ������� ���������!", "�����");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"������ ��� �������� ������: {ex.Message}", "������");
                    }
                }
            }
        }

        private void SaveData()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Text Files (*.txt)|*.txt", Title = "��������� ������" })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllLines(saveFileDialog.FileName, catalog.Select(entry => $"{entry.Key}|{string.Join(",", entry.Value)}"));
                        MessageBox.Show("������ ������� ���������!", "�����");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"������ ��� ���������� ������: {ex.Message}", "������");
                    }
                }
            }
        }

        private void AddAuthor()
        {
            string author = PromptInput("������� ��� ������:");
            if (!string.IsNullOrWhiteSpace(author))
            {
                if (!catalog.ContainsKey(author))
                {
                    catalog[author] = new List<string>();
                    MessageBox.Show("����� ��������!", "�����");
                }
                else
                {
                    ShowError("����� ��� ����������!");
                }
            }
        }

        private void EditAuthor()
        {
            string oldAuthor = PromptInput("������� ��� ������ ��� ��������������:");
            if (catalog.ContainsKey(oldAuthor))
            {
                string newAuthor = PromptInput("������� ����� ��� ������:");
                if (!string.IsNullOrWhiteSpace(newAuthor) && !catalog.ContainsKey(newAuthor))
                {
                    catalog[newAuthor] = catalog[oldAuthor];
                    catalog.Remove(oldAuthor);
                    MessageBox.Show("����� ������!", "�����");
                }
                else
                {
                    ShowError("����� � ����� ������ ��� ���������� ��� ������� ������ ���!");
                }
            }
            else
            {
                ShowError("����� �� ������!");
            }
        }

        private void DeleteAuthor()
        {
            string author = PromptInput("������� ��� ������ ��� ��������:");
            if (catalog.Remove(author))
            {
                MessageBox.Show("����� �����!", "�����");
            }
            else
            {
                ShowError("����� �� ������!");
            }
        }

        private void AddBook()
        {
            string author = PromptInput("������� ��� ������:");
            if (catalog.ContainsKey(author))
            {
                string book = PromptInput("������� �������� �����:");
                if (!string.IsNullOrWhiteSpace(book))
                {
                    catalog[author].Add(book);
                    MessageBox.Show("����� ���������!", "�����");
                }
            }
            else
            {
                ShowError("����� �� ������!");
            }
        }

        private void EditBook()
        {
            string author = PromptInput("������� ��� ������:");
            if (catalog.ContainsKey(author))
            {
                string oldBook = PromptInput("������� �������� ����� ��� ��������������:");
                if (catalog[author].Contains(oldBook))
                {
                    string newBook = PromptInput("������� ����� �������� �����:");
                    int index = catalog[author].IndexOf(oldBook);
                    catalog[author][index] = newBook;
                    MessageBox.Show("����� ��������!", "�����");
                }
                else
                {
                    ShowError("����� �� �������!");
                }
            }
            else
            {
                ShowError("����� �� ������!");
            }
        }

        private void DeleteBook()
        {
            string author = PromptInput("������� ��� ������:");
            if (catalog.ContainsKey(author))
            {
                string book = PromptInput("������� �������� ����� ��� ��������:");
                if (catalog[author].Remove(book))
                {
                    MessageBox.Show("����� �������!", "�����");
                }
                else
                {
                    ShowError("����� �� �������!");
                }
            }
            else
            {
                ShowError("����� �� ������!");
            }
        }

        private void ViewAllBooks()
        {
            mainTextBox.Clear();
            foreach (var entry in catalog)
            {
                mainTextBox.AppendText($"�����: {entry.Key}\r\n");
                foreach (var book in entry.Value)
                {
                    mainTextBox.AppendText($"    - {book}\r\n");
                }
            }
        }

        private void ViewBooksByAuthor()
        {
            string author = PromptInput("������� ��� ������:");
            if (catalog.ContainsKey(author))
            {
                mainTextBox.Clear();
                mainTextBox.AppendText($"�����: {author}\r\n");
                foreach (var book in catalog[author])
                {
                    mainTextBox.AppendText($"    - {book}\r\n");
                }
            }
            else
            {
                ShowError("����� �� ������!");
            }
        }

        private void FilterBooksByAuthor()
        {
            string author = PromptInput("������� ��� ������ ��� ����������:");
            if (catalog.ContainsKey(author))
            {
                mainTextBox.Clear();
                mainTextBox.AppendText($"������ �� ������: {author}\r\n");
                foreach (var book in catalog[author])
                {
                    mainTextBox.AppendText($"    - {book}\r\n");
                }
            }
            else
            {
                ShowError("����� �� ������!");
            }
        }

        private string PromptInput(string prompt)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(prompt, "���� ������", "");
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "������");
        }
    }
}
