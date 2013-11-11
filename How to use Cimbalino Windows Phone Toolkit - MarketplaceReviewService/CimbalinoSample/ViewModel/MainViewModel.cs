namespace CimbalinoSample.ViewModel
{
    using Cimbalino.Phone.Toolkit.Services;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// The marketplace review service.
        /// </summary>
        private readonly IMarketplaceReviewService _marketplaceReviewService;
        
        /// <summary>
        /// The public application url.
        /// </summary>
        private readonly string _appUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="marketplaceReviewService">
        /// The marketplace review service
        /// </param>
        public MainViewModel(IMarketplaceReviewService marketplaceReviewService)
        {
            _marketplaceReviewService = marketplaceReviewService;
            
            RateCommand = new RelayCommand(Rate);
        }

        /// <summary>
        /// Gets the rate command.
        /// </summary>
        public ICommand RateCommand { get; private set; }

        /// <summary>
        /// The rate.
        /// </summary>
        private void Rate()
        {
            _marketplaceReviewService.Show();
        }
    }
}
