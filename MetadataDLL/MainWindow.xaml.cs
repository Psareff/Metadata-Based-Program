using System;
using System.Collections.Generic;
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
using MenuElement;

namespace MetadataDLL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string filename)
        {
            MenuBarParser menu_bar_parser = new MenuBarParser("../../../" + filename);
            MenuBarProcessor menu_bar_processor = new MenuBarProcessor(menu_bar_parser);
            Delegates delegates = new Delegates();
            Menu m = new Menu();
            m.ItemsSource = menu_bar_processor.Process();
            InitializeComponent();
            MainGrid.Children.Add(m);
        }
    }
}
