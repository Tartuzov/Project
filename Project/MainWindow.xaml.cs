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
    /// List<Recipe> recipes = new List<Recipe>();
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
            path = path.Remove(path.Length - 19);
            video1.Source = new Uri(path+"\\video.mp4");
            path1 = System.IO.Path.GetFullPath(path + "\\Перша страва\\Украинская кухня\\Рецепт.txt");
            List<string> direct = Directory.GetDirectories(path).ToList();
            for (int i = 0; i < direct.Count; i++)
            {
                List<string> kyx = Directory.GetDirectories(direct[i]).ToList();
                for (int j = 0; j < kyx.Count; j++)
                {
                    string a = kyx[j].Trim(direct[i].ToCharArray());
                    string name = "";
                    for(int k = 0; k < a.Length; k++)
                    {
                        if (a[k] == ' ')
                            name += a[k];
                        else
                            break;
                    }
                    menu1.Items.Add(new MenuItem { Name=name, Header=a});          
                    List<string> rec = Directory.GetFiles(kyx[j]).ToList();
                    for (int k = 0; k < rec.Count; k++)
                    {
                        Recipe recipe = new Recipe();
                        StreamReader f = new StreamReader(rec[k]);
                        recipe.FoodName = f.ReadLine();
                        f.ReadLine();
                        string linc = "";
                        recipe.TypeFood = f.ReadLine();
                        f.ReadLine();
                        recipe.KitchenName = f.ReadLine();
                        f.ReadLine();
                        for (int g = 0; ; g++)
                        {
                            string line = f.ReadLine();
                            if (line != "")
                            {
                                linc += line;
                            }
                            else { break; }
                        }
                        recipe.PhotoLink = linc;
                        for (int g = 0; ; g++)
                        {
                            string line = f.ReadLine();
                            if (line != "")
                            {
                                recipe.Ingredients += line + "\n";
                            }
                            else { break; }
                        }
                        for (int g = 0; ; g++)
                        {
                            string line = f.ReadLine();
                            if (line != "")
                            {
                                recipe.Guide += line + "\n";
                            }
                            else { break; }
                        }
                        f.Close(); recipes.Add(recipe);
                    }
                }
            }
        }
        public class Recipe
        {
            public string TypeFood = "";
            public string KitchenName = "";
            public string FoodName = "";
            public string PhotoLink = "";
            public string Ingredients = "";
            public string Guide = "";
        }
    }
}
