namespace CimbalinoSample.ViewModel
{
    using System.Windows.Input;

    using Cimbalino.Phone.Toolkit.Services;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    public class Page2ViewModel : ViewModelBase
    {
        /// <summary>
        /// The navigation service
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="Page2ViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        public Page2ViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GoBackCommand = new RelayCommand(GoBack);
        }

        /// <summary>
        /// Gets the parameter.
        /// </summary>
        /// <value>
        /// The parameter.
        /// </value>
        public string Parameter
        {
            get
            {
                return _navigationService.QueryString["parameter"].ToString();
            }
        }

        /// <summary>
        /// Gets a value indicating whether [can go back].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [can go back]; otherwise, <c>false</c>.
        /// </value>
        public bool CanGoBack 
        {
            get
            {
              return  _navigationService.CanGoBack;
            }
        }

        /// <summary>
        /// Gets the go back command.
        /// </summary>
        /// <value>
        /// The go back command.
        /// </value>
        public ICommand GoBackCommand { get; private set; }

        /// <summary>
        /// Goes the back.
        /// </summary>
        private void GoBack()
        {
            _navigationService.GoBack();
        }
    }
}
