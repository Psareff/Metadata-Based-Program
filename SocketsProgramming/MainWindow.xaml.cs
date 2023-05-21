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


namespace SocketsProgramming_Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IPHostEntry ipHost;
        IPAddress ipAddr;
        IPEndPoint localEndPoint;
        Socket listener;
        Socket handler;

        public MainWindow()
        {
            InitializeComponent();

            ipHost = Dns.GetHostEntry("localhost");
            ipAddr = ipHost.AddressList[0];
            localEndPoint = new IPEndPoint(ipAddr, 11111);
            listener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(10);
            handler = listener.Accept();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            string data = "";
            byte[] buffer = null;
            
            while (true)
            {
                buffer = new byte[1024];
                int bytes_recieved = handler.Receive(buffer);
                data += Encoding.ASCII.GetString(buffer, 0, bytes_recieved);
                if (String.IsNullOrEmpty(data))
                    break;
            }
            toRecieve.Text = data;
            //Trace.WriteLine("Recieved: " + data);

            //byte[] message = Encoding.ASCII.GetBytes(data);
            //handler.Send(message);

        }

        ~MainWindow()
        {
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
            
        }

        private void toRecieve_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
