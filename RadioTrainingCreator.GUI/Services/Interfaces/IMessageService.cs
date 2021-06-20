namespace RadioTrainingCreator.GUI.Services.Interfaces
{
    public interface IMessageService
    {
        void Show(string text);

        void ShowWarning(string title, string warning);

        void ShowError(string title, string error);
    }
}
