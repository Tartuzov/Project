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

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Recipe> recipes = new List<Recipe>();
        string path;
        string path1;
        string linc = "";
        public MainWindow()
        {
            InitializeComponent();
            path = System.IO.Path.GetFullPath(this.ToString());
            path= path.Remove(path.Length - 19);
            List<string> direct = Directory.GetDirectories(path).ToList();
            for(int i = 0; i < direct.Count; i++)
            {
                List<string> kyx = Directory.GetDirectories(direct[i]).ToList();
                for (int j = 0; j < kyx.Count; j++)
                {
                    List<string> rec = Directory.GetFiles(kyx[j]).ToList();
                    for(int k=0; k<rec.Count; k++)
                    {
                        Recipe recipe = new Recipe();
                        recipe.Open1(rec[k]);
                        recipes.Add(recipe);
                    }
                }
            }
            path1 = System.IO.Path.GetFullPath(path + "\\Перша страва\\Украинская кухня\\Рецепт.txt");
            Open(path1);
        }
        public class Recipe
        {
            public string TypeFood = "";
            public string KitchenName = "";
            public string FoodName = "";
            public string PhotoLink = "";
            public string Ingredients = "";
            public string Guide = "";
            public void Open1(string path)
            {
                StreamReader f = new StreamReader(path);
                FoodName = f.ReadLine();
                f.ReadLine();
                string linc = "";
                TypeFood = f.ReadLine();
                f.ReadLine();
                KitchenName = f.ReadLine();
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
                PhotoLink = linc;
                for (int i = 0; ; i++)
                {
                    string line = f.ReadLine();
                    if (line != "")
                    {
                        Ingredients += line + "\n";
                    }
                    else { break; }
                }
                for (int i = 0; ; i++)
                {
                    string line = f.ReadLine();
                    if (line != "")
                    {
                        Guide += line + "\n";
                    }
                    else { break; }
                }
                f.Close();
            }
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
            kyxna.Content = f.ReadLine();
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
