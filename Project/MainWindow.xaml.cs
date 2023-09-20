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
            for (int i = 0; i < recipes.Count; i++)
            {

            }
            Bl.Items.Add("Перша страва");
            Bl.Items.Add("Друга страва");
            Bl.Items.Add("Салат");
            Bl.Items.Add("Соус");
            Bl.Items.Add("Десерт");
            Bl.Items.Add("Выпечка");
            Bl.Items.Add("Закуски");
            Bl.Items.Add("Напиток");
            path = System.IO.Path.GetFullPath(this.ToString());
            path= path.Remove(path.Length - 19);
            path1 = System.IO.Path.GetFullPath(path + "\\Перша страва\\Украинская кухня\\Рецепт.txt");
            Open();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveAt();
        }
        public class Recipe
        {
            public string TypeFood { get; set; }
            public string KitchenName { get; set; }
            public string FoodName { get; set; }
            public string PhotoLink { get; set; }
            public string Ingredients { get; set; }
            public string Guide { get; set; }
        }
        private void SaveAt()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.HasValue)
                return;
            string filename = saveFileDialog.FileName;
            System.IO.File.WriteAllText(filename, $"{name.Text}\n\n{Bl.SelectedValue}\n\n{kyxna.Text}\n\n{linc}\n\n{recipe.Text}\n{desc.Text}");
            MessageBox.Show("Файл сохранен");
        }
        private void Open()
        {
            StreamReader f = new StreamReader(path1);
            name.Text = f.ReadLine();
            f.ReadLine();
            linc = "";
            string ab = f.ReadLine();
            for (int i = 0; i < Bl.Items.Count; i++)
            {
                if (Bl.Items[i].ToString() == ab)
                    Bl.SelectedValue = Bl.Items[i];
            }
            f.ReadLine();
            kyxna.Text = f.ReadLine();
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
