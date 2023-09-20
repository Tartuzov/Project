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

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path;
        string path1;
        string linc = "";

        public MainWindow()
        {
            string path = System.IO.Path.GetFullPath(this.ToString());
            InitializeComponent();
            path.Remove(path.Length - 17);
            string path1 = System.IO.Path.GetFileName(path + "\\Рецепт.txt");
            StreamReader f = new StreamReader(path1);
            name.Text=f.ReadLine();
            f.ReadLine();
            linc = "";
            for (int i = 0; ; i++)
            {
                string line = f.ReadLine();
                if (line !="")
                {
                    linc +=line;
                }
                else { break; }
            }
            picture.ImageSource = new BitmapImage(new Uri(linc));
            for (int i = 0;; i++)
            {
                string line = f.ReadLine();
                if (line != "")
                {
                    recipe.Text += line + "\n";
                }
                else { break; }
            }
            for(int i = 0;; i++)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.HasValue)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, $"{name.Text}\n{linc}\n{recipe.Text}\n{desc.Text}");
            MessageBox.Show("Файл сохранен");
        }
    }
}
