using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Clicker12.Classes;
using Microsoft.Win32;

namespace Clicker12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class IconItem
        {
            public string IconPath { get; set; }
            public string IconName { get; set; }
            public IconItem(string iconPath)
            {
                IconPath = iconPath;
                string[] m = iconPath.Split(new char[] { '\\' });
                IconName = m.Last();
            }
        }
        public List<IconItem> IconList { get; set; }
        public CEnemyTemplateList EnemyList { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            IconList = new List<IconItem>();
            EnemyList = new CEnemyTemplateList();

            LoadImages("C:\\Users\\tummy\\source\\repos\\Clicker12\\Clicker12\\Monsters");
            IconListBox.ItemsSource = IconList;
            
            EnemyList.AddEnemy(new CEnemyTemplate());
            DataContext = EnemyList;
            
        }
        private void EnemyListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EnemyListBox.SelectedItem != null)
            {
            }
        }
        public void LoadImages(string path)
        {
            string filter = "*.png";
            string[] files = Directory.GetFiles(path, filter);
            foreach (string file in files)
            {
                IconList.Add(new IconItem(file));
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            EnemyList.AddEnemy(new CEnemyTemplate());
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (EnemyListBox.SelectedItem != null) EnemyList.DelByName((string) EnemyListBox.SelectedItem);
        }

        private void IconListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EnemyListBox.SelectedItem != null & IconListBox.SelectedItem != null)
                (EnemyListBox.SelectedItem as CEnemyTemplate).IconName = (IconListBox.SelectedItem as IconItem).IconName;
        }
    }
}