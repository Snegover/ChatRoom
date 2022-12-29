using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace ChatLogin
{
    /// <summary>
    /// Логика взаимодействия для ChatSelection.xaml
    /// </summary>
    public partial class ChatSelection : Window
    {
        public List<ChatRoom> chatRooms = new List<ChatRoom>();
        public List<ChatRoomEmloyee> chatRoomEmployee = new List<ChatRoomEmloyee>();
        public static ChatRoom chatRoom;
        public ChatSelection()
        {
            InitializeComponent();
            HelloGrid.DataContext = MainWindow.employee;
            GetRooms();
        }
        public async void GetRooms()
        {
            HttpResponseMessage httpResponseMessage = await MainWindow.httpClient.GetAsync("http://localhost:50203/api/chatRooms");
            var header = await httpResponseMessage.Content.ReadAsStringAsync();
            HttpResponseMessage httpResponseEmp = await MainWindow.httpClient.GetAsync("http://localhost:50203/api/ChatroomEmploees");
            var emp = await httpResponseEmp.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ChatRoomEmloyee>>(emp).Where(i => i.idEmployee == MainWindow.employee.id).ToList();
            if (result == null)
            {
            
            }
            else
            {
                var temp = JsonConvert.DeserializeObject<List<ChatRoom>>(header).ToList();
                ChatRoomList.ItemsSource = from t in temp
                                           join r in result on t.id equals r.IdChatRoom
                                           select t;
            }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            chatRoom = ChatRoomList.SelectedItem as ChatRoom;
            ChatWindow  c = new ChatWindow();
            c.Show();
            Close();
        }
    }
}
