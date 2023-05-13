using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using MenuElement;


namespace MetadataDLL
{
    /// <summary>
    /// Interaction logic for Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        List<MenuElement.User> users = new List<User>();
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

            InitializeComponent();
            DataContext = this;

            Language.Text = "Current language: " + InputLanguage.CurrentInputLanguage.LayoutName;
            Caps.Text = "Caps Lock is " + (System.Windows.Forms.Control.IsKeyLocked(Keys.CapsLock) ? "On" : "Off");
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        { 

            foreach (var i in users)
            {
                if (i.username == Name_Field.Text &&
                    i.password == Password_Field.Password)
                {
                    MainWindow mainWindow = new MainWindow(i.filename);
                    this.Close();
                    mainWindow.Show();
                    return;
                }
            }
            System.Windows.MessageBox.Show("Invalid login or password");
        }

    }
}
