using RadioTrainingCreator.GUI.Services.Interfaces;
using RadioTrainingCreator.GUI.Services.Services.MessageServices;
using RadioTrainingCreator.Handler.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RadioTrainingCreator.GUI.ViewModels.Basics
{
    /// <summary>
    /// Basic class for all ViewModels
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Is called when a property has changed
        /// </summary>
        /// <param name="name">The name of the changed property</param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected IMessageService MessageService;

        public BaseViewModel()
        {
            MessageService = MessageServiceHandler.GetCorrectMessageService(); 
        }
    }
}
