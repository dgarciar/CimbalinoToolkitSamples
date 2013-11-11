using GalaSoft.MvvmLight;

namespace CimbalinoSample.ViewModel
{
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Input;

    using Cimbalino.Phone.Toolkit.Services;

    using GalaSoft.MvvmLight.Command;

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The message box service.
        /// </summary>
        private readonly IMessageBoxService _messageBoxService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IMessageBoxService messageBoxService)
        {
            _messageBoxService = messageBoxService;
            ShowMessageBoxCommand = new RelayCommand(ShowMessageBox);
        }

        /// <summary>
        /// Shows the message box.
        /// </summary>
        private void ShowMessageBox()
        {
            _messageBoxService.Show("I am a message box", "Cimbalino sample", MessageBoxButton.OK);
        }

        /// <summary>
        /// Gets the show message box command.
        /// </summary>
        /// <value>
        /// The show message box command.
        /// </value>
        public ICommand ShowMessageBoxCommand { get; private set; }
    }
}