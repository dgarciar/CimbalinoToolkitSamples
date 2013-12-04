using GalaSoft.MvvmLight;

namespace CimbalinoSample.ViewModel
{
    using Cimbalino.Phone.Toolkit.Services;

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
        /// The user extended properties service
        /// </summary>
        private readonly IUserExtendedPropertiesService _userExtendedPropertiesService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IUserExtendedPropertiesService userExtendedPropertiesService)
        {
            _userExtendedPropertiesService = userExtendedPropertiesService;
        }

        /// <summary>
        /// Gets the anonymous user identifier.
        /// </summary>
        /// <value>
        /// The anonymous user identifier.
        /// </value>
        public string AnonymousUserID
        {
            get
            {
                return _userExtendedPropertiesService.AnonymousUserID;
            }
        }
    }
}