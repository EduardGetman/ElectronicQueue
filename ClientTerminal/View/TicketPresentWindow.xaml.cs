using ElectronicQueue.Core.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClientTerminal.View
{
    /// <summary>
    /// Логика взаимодействия для TicketPresentWindow.xaml
    /// </summary>
    public partial class TicketPresentWindow : Window
    {
        const string CreateTimeFormat = "dd.MM.yyyy HH:mm";
        public string TicketNameText
        {
            get => TicketName.Text; 
            set => TicketName.Text = value; 
        }
        public string ServiceNameText
        {
            get => ServiceName.Text;
            set => ServiceName.Text = value;
        }
        public string CreateTimeText
        { 
            get => CreateTime.Text; 
            set => CreateTime.Text = value;
        }

        public TicketDto Ticket { get; set; }
        public TicketPresentWindow(TicketDto ticket)
        {
            InitializeComponent();
            Ticket = ticket;
            ServiceNameText = Ticket.Service.Name;
            CreateTimeText = Ticket.CreateTime.ToString(CreateTimeFormat);
            TicketNameText = Ticket.Name;
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
