using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Cryptography;
using static Project.Window1;

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        string path;
        string path1;
        string linc = "";
        public Window1()
        {
            InitializeComponent();          
            path1 = System.IO.Path.GetFullPath(path + "\\Перша страва\\Украинская кухня\\Рецепт.txt");
            Open(path1);
        }
        private void SaveAt()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.HasValue)
                return;
            string filename = saveFileDialog.FileName;
            System.IO.File.WriteAllText(filename, $"{name.Content}\n\n{Bl.Content}\n\n{kyxna.Content}\n\n{linc}\n\n{recipe.Text}\n{desc.Text}");
            MessageBox.Show("Файл сохранен");
        }
        private void Open(string path)
        {
            StreamReader f = new StreamReader(path1);
            name.Content = f.ReadLine();
            f.ReadLine();
            linc = "";
            Bl.Content = f.ReadLine();
            f.ReadLine();
            kyxna.Content += f.ReadLine();
            f.ReadLine();
            for (int i = 0; ; i++)
            {
                string line = f.ReadLine();
                if (line != "")
                {
                    linc += line;
                }
                else { break; }
            }
            picture.ImageSource = new BitmapImage(new Uri(linc));
            for (int i = 0; ; i++)
            {
                string line = f.ReadLine();
                if (line != "")
                {
                    recipe.Text += line + "\n";
                }
                else { break; }
            }
            for (int i = 0; ; i++)
            {
                string line = f.ReadLine();
                if (line != "")
                {
                    desc.Text += line + "\n";
                }
                else { break; }
            }
            f.Close();
        }
    }
}