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

namespace ElectronicQueue.AdminClient.View.DialogWindow
{
    /// <summary>
    /// Логика взаимодействия для AccountEditDialogWindow.xaml
    /// </summary>
    public partial class AccountEditDialogWindow : Window
    {
        Action<string, string> _saveData;
        public string WindowName { get => WindowNameBlock.Text; set => WindowNameBlock.Text = value; }
        public string UserName { get => UserNameBox.Text; set => UserNameBox.Text = value; }
        public string Password { get => PasswordBox.Password; set => PasswordBox.Password = value; }
        public AccountEditDialogWindow(Action<string, string> saveData, string windowName, string userName = "")
        {
            InitializeComponent();
            _saveData = saveData;
            WindowName = windowName;
            UserName = userName;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (Validate(UserName) && Validate(Password))
            {
                MessageBox.Show("Заполните все поля", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            _saveData(UserName, Password);
            Close();
        }
        private bool Validate(string value) => string.IsNullOrWhiteSpace(value) || value.Contains(' ');
    }
}