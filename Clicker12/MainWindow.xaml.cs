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
        //public string GetPathByName(string name, ObservableCollection<IconItem> ilist) 
        //{
        //    foreach (IconItem x in ilist)
        //        if (x.IconName == name) return x.IconPath;
        //    return null;
        //}
        public IconItem SelectedI { get; set; }
        public ObservableCollection<IconItem> IconList { get; set; }
        public CEnemyTemplateList EnemyList { get; set; }
        public CEnemyTemplate SelectedE { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            IconList = new ObservableCollection<IconItem>();
            EnemyList = new CEnemyTemplateList();

            LoadImages("C:\\Users\\SAPR\\Source\\Repos\\Clicker12\\Clicker12\\Monsters");
            IconListBox.ItemsSource = IconList;
            IconComboBox.ItemsSource = IconList;
            //EnemyIcon.DataContext = IconList;

            SelectedE = new CEnemyTemplate();
            EnemyList.AddEnemy(SelectedE);
            DataContext = EnemyList;
            
        }
        private void EnemyListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EnemyListBox.SelectedItem != null)
            {
            }
        }
        private void IconListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EnemyListBox.SelectedItem != null & IconListBox.SelectedItem != null)
                (EnemyListBox.SelectedItem as CEnemyTemplate).IconName = (IconListBox.SelectedItem as IconItem).IconPath;
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
            if (EnemyListBox.SelectedItem != null) EnemyList.DelByName((EnemyListBox.SelectedItem as CEnemyTemplate).Name);
        }


        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            EnemyList.SaveJson();

        }

        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            EnemyList.Clear();
            EnemyList.LoadJson();
 
        }
    }
}