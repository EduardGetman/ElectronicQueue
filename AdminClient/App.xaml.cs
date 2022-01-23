﻿using ElectronicQueue.Data.Dto.Maps;
using System.Windows;

namespace ElectronicQueue.AdminClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Configuration.Configure();
        }
    }
}
