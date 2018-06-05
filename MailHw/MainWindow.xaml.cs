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
using Limilabs.Mail;
using Limilabs.Client.POP3;
using System.IO;
using Newtonsoft.Json;

namespace MailHw
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<MailDisplay> Mails { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Mails = new List<MailDisplay>();
            string path = "localMails";

            if (File.Exists(path))
            {
                Mails.AddRange(JsonConvert.DeserializeObject<List<MailDisplay>>(File.ReadAllText(path)));
            }


            using (Pop3 pop3 = new Pop3())
            {
                pop3.ConnectSSL("pop.mail.ru", 995);  // or ConnectSSL for SSL 
                pop3.UseBestLogin("testpop3stepit@mail.ru", "123456Aa");
                foreach (string uid in pop3.GetAll())
                {
                    if(Mails.Any(m => m.Id == uid)){
                        continue;
                    }
                    byte[] eml = pop3.GetMessageByUID(uid);

                    IMail mail = new MailBuilder().CreateFromEml(eml);

                    MailDisplay mailDisplay = new MailDisplay
                    {
                        Id = uid,
                        Sender = mail.Sender.Name,
                        Subject = mail.Subject,
                        Text = mail.Text,
                        TimeSent = mail.Date
                    };

                    Mails.Add(mailDisplay);
                }
            }

            File.WriteAllText(path, JsonConvert.SerializeObject(Mails));
            mailList.ItemsSource = Mails;
        }

        private void MailSelected(object sender, MouseButtonEventArgs e)
        {
            string text = (mailList.SelectedItem as MailDisplay).Text;
            MailContent page = new MailContent(text);
            page.Show();

        }
    }
}