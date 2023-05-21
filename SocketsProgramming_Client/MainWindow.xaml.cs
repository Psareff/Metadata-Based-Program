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

using System.Diagnostics;

using System.Net;
using System.Net.Sockets;

namespace SocketsProgramming_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IPHostEntry ipHost;
        IPAddress ipAddr;
        IPEndPoint remoteEndPoint;
        Socket sndr;

        public MainWindow()
        {
            InitializeComponent();

           ipHost = Dns.GetHostEntry("localhost");
           ipAddr = ipHost.AddressList[0];
           remoteEndPoint = new IPEndPoint(ipAddr, 11111);
           sndr = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
           sndr.Connect(remoteEndPoint);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {



            //sndr.Receive(bytes);
            //Encoding.ASCII.GetString(bytes, 0, bytes.Length);
            byte[] message = Encoding.ASCII.GetBytes(toSend.Text);
            sndr.Send(message);


        }
        ~MainWindow()
        {
            sndr.Shutdown(SocketShutdown.Both);
            sndr.Close();

        }

        private void toSend_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
