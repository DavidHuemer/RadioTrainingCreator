using MVVM.Tools;
using System;

namespace RadioTrainingCreator.GUI.ViewModels.Basics
{
    /// <summary>
    /// Base class for all EditorViewModels
    /// </summary>
    public abstract class EditorViewModel<T> : BaseViewModel where T : class
    {
        public bool IsVisible { get; set; } = false;

        public T CurrentObject { get; set; } = null;

        /// <summary>
        /// Should be called when the editor should create a new "item"
        /// </summary>
        public void Add()
        {
            Clear();
            IsVisible = true;
        }

        /// <summary>
        /// Clears the properties
        /// </summary>
        public abstract void Clear();
    }
}
