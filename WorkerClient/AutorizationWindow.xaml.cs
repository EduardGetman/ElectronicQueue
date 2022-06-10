using AutoMapper;
using ElectronicQueue.Core.Application.Dto;
using ElectronicQueue.RestEndpoint;
using System;
using System.Windows;

namespace WorkerClient
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        public string Login { get => UserName.Text; set => UserName.Text = value; }
        public string Password { get => PasswordBox.Password; set => PasswordBox.Password = value; }
        public Action<WorkerDto> Save { get; set; }
        public AutorizationWindow(Action<WorkerDto> save)
        {
            InitializeComponent();
            Save = save;
        }

        private void Autorizate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password))
                {
                    throw new Exception("Ведите логин и пароль!");
                }
                var resounse = EndpoinCollection.Worker.Autorize(new AccountDto() { Login = Login, PasswordHash = Password });
                if (resounse.IsSuccessfull)
                {
                    Save(resounse.Worker);
                    Close();
                }
                else
                {
                    throw new Exception("Вы ввели неверный логин или пароль!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
