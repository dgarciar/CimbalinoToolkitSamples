namespace CimbalinoSample.ViewModel
{
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;

    using Cimbalino.Phone.Toolkit.Services;

    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight;
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The phone call service
        /// </summary>
        private readonly IPhoneCallService _phoneCallService;

        /// <summary>
        /// The number
        /// </summary>
        private string _number;

        /// <summary>
        /// The name
        /// </summary>
        private string _name;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IPhoneCallService phoneCallService)
        {
            _phoneCallService = phoneCallService;
            CallCommand =new RelayCommand(CallTo);
        }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        public string Number
        {
            get
            {
                return _number;
            }
            set
            {
                Set("Number", ref _number, value);
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                Set("Name", ref _name, value);
            }
        }

        /// <summary>
        /// Gets the call command.
        /// </summary>
        /// <value>
        /// The call command.
        /// </value>
        public ICommand CallCommand { get; private set; }

        /// <summary>
        /// Calls to.
        /// </summary>
        private void CallTo()
        {
            _phoneCallService.Show(Number, Name);
        }
    }
}