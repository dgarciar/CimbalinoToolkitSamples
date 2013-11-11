namespace CimbalinoSample.ViewModel
{
    using Cimbalino.Phone.Toolkit.Services;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Windows.Input;

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The share link service.
        /// </summary>
        private readonly IShareLinkService _shareLinkService;

        /// <summary>
        /// The public application url.
        /// </summary>
        private readonly string _appUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="shareLinkService">
        /// The share Link Service.
        /// </param>
        public MainViewModel(IShareLinkService shareLinkService)
        {
            _shareLinkService = shareLinkService;

            ShareSocialNetworkCommand = new RelayCommand(ShareSocialNetwork);
            _appUrl = string.Concat("http://windowsphone.com/s?appid=8df00038-1b7a-406b-b33f-37a78b17348c");
        }
        
        /// <summary>
        /// Gets the share social network command.
        /// </summary>
        public ICommand ShareSocialNetworkCommand { get; private set; }
    
        /// <summary>
        /// The share social network.
        /// </summary>
        private void ShareSocialNetwork()
        {
            const string Message = "This application is amazing, should try it! See in";
            _shareLinkService.Show("Cimbalino Toolkit Sample", Message, new Uri(_appUrl, UriKind.Absolute));
        }
    }
}
