using GalaSoft.MvvmLight;

namespace CimbalinoSample.ViewModel
{
    using System;
    using System.Windows.Input;

    using Cimbalino.Phone.Toolkit.Services;

    using GalaSoft.MvvmLight.Command;

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The navigation service.
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateWithoutParameterCommand = new RelayCommand(NavigateWithoutParameter);
            NavigateWithParameterCommand = new RelayCommand(NavigateWithParameter);
        }

        /// <summary>
        /// Gets the navigate without parameter command.
        /// </summary>
        /// <value>
        /// The navigate without parameter command.
        /// </value>
        public ICommand NavigateWithoutParameterCommand { get; private set; }

        /// <summary>
        /// Gets the navigate with parameter command.
        /// </summary>
        /// <value>
        /// The navigate with parameter command.
        /// </value>
        public ICommand NavigateWithParameterCommand { get; private set; }
        
        /// <summary>
        /// Navigates the without parameter.
        /// </summary>
        private void NavigateWithoutParameter()
        {
            _navigationService.NavigateTo(new Uri("/Page1.xaml", UriKind.Relative));
        }

        /// <summary>
        /// Navigates the with parameter command.
        /// </summary>
        private void NavigateWithParameter()
        {
            _navigationService.NavigateTo(new Uri("/Page2.xaml?parameter=1", UriKind.Relative));
        }
    }
}