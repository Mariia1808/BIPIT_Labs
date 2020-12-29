using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
using ChatClient.ServiceChat;

namespace ChatClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IServiceChatCallback
    {
        private int id;
        private bool con = false;
        private ServiceChatClient client;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConnectUser()
        {
            client = new ServiceChatClient(new InstanceContext(this));
            id = client.Connect(nameUser.Text);
            var messageHistory= client.GetMessageHistory();
            lbChat.Items.Clear();
            foreach (var item in messageHistory)
                lbChat.Items.Add(item);
            nameUser.IsEnabled = false;
            connect.Content="Disconnect";
            con = true;
        }

        private void DisconnectUser()
        {
            if (!con) return;
            client.Disconnect(id);
            client = null;
            nameUser.IsEnabled = true;
            connect.Content = "Connect";
            con = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (con)
                DisconnectUser();
            else
                ConnectUser();
        }

        public void MessageCallBack(string message)
        {
            lbChat.Items.Add(message);
            lbChat.ScrollIntoView(lbChat.Items[lbChat.Items.Count-1]);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectUser();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter) return;
            client?.SendMessage(message.Text, id);
            message.Text = "";
        }
    }
}
