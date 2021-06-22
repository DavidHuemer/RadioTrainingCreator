using RadioTrainingCreator.GUI.Views.Controls.Default;
using System.Windows;

namespace RadioTrainingCreator.GUI.Views.Controls.Custom.Buttons
{
    public class NavigationButton : ExButton
    {
        #region Is Selected

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register(
          nameof(IsSelected), typeof(bool), typeof(NavigationButton), new PropertyMetadata(false));

        #endregion
    }
}
