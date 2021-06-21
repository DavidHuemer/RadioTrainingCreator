using RadioTrainingCreator.GUI.Services.Interfaces;
using RadioTrainingCreator.GUI.ViewModels.Basics;
using System;

namespace RadioTrainingCreator.GUI.Services.Services.WindowServices
{
    public class TestingWindowService : IWindowService
    {
        public void Open(BaseViewModel viewModel)
        {
            Console.WriteLine("Should open window");
        }
    }
}
