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
using System.Windows.Shapes;
using System.Globalization;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.IO;
using System.Windows.Automation;
using System.Diagnostics;


namespace Metadata
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        List<User> users = new List<User>();
        public Authorization()
        {
            StreamReader streamReader = new StreamReader("../../../Logins.txt");
            string row;

            while ((row = streamReader.ReadLine()) != null)
            {
                string[] buff = row.Split(' ');
                foreach (var i in buff)
                    Trace.WriteLine(i + " ");
                users.Add(new User()
                {
                    username = buff[0],
                    password = buff[1],
                    filename = buff[2]
                });
            }


            CultureInfo ci = CultureInfo.InstalledUICulture;
            InitializeComponent();
            
            Language.Text = "Current language: " + CultureInfo.CurrentUICulture.Name;
            Caps.Text = "Caps Lock is " + (System.Windows.Forms.Control.IsKeyLocked(Keys.CapsLock) ? "On" : "Off");
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {

            foreach(var i in users)
            {
                if (i.username == Name_Field.Text && 
                    i.password == Password_Field.Text)
                {
                    MainWindow mainWindow = new MainWindow(i.filename);
                    this.Close();
                    mainWindow.Show();
                }
            }
        }
    }
}
