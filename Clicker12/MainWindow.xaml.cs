using System.IO;
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
        public MainWindow()
        {
            InitializeComponent();

            IconList = new List<IconItem>();
            LoadImages("C:\\Users\\bob2a\\Source\\Repos\\Clicker12\\Clicker12\\Monsters");
            IconListBox.ItemsSource = IconList;
            
            
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
    }
}