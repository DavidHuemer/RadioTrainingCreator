using RadioTrainingCreator.GUI.Views.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RadioTrainingCreator
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private void RadioTraining_Startup(object sender, StartupEventArgs e)
        {
            new WelcomeWindow().Show();
        }
    }
}
