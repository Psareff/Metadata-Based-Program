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
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Runtime;



namespace MetadataDLLimplicit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
      
            Assembly a = Assembly.LoadFrom("C:\\Users\\ilyap\\source\\repos\\Psareff\\Metadata-Based-Program\\MenuElement\\bin\\Debug\\net6.0-windows\\MenuElement.dll");

            Type delegates_t = a.GetType("Metadata.Delegates");
            Type menuBarParser_t = a.GetType("Metadata.menuBarParser");
            Type menuBarProcessor_t = a.GetType("Metadata.menuBarProcessor");
            Type user_t = a.GetType("Metadata.User");

            object ctor_params = "../../../" + "ToParse1.txt";

            var menuBarParser = Activator.CreateInstance(menuBarParser_t, ctor_params);

            ctor_params = menuBarParser;
            var menuBarProcessor = Activator.CreateInstance(menuBarProcessor_t);
            var user = Activator.CreateInstance(user_t);

            var process_items = menuBarProcessor_t.GetMethod("Process", null);

            Menu m = new Menu();
            m.ItemsSource = (System.Collections.IEnumerable)process_items.Invoke(menuBarProcessor, null);
            InitializeComponent();
            MainGrid.Children.Add(m);
        }
    }
}
