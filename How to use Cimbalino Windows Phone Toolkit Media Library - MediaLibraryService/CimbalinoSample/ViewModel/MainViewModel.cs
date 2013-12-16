namespace CimbalinoSample.ViewModel
{
    using System;
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
        /// The navigation service
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// The media library service
        /// </summary>
        private readonly IMediaLibraryService _mediaLibraryService;

        /// <summary>
        /// The camera capture service
        /// </summary>
        private readonly ICameraCaptureService _cameraCaptureService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        /// <param name="mediaLibraryService">The media library service.</param>
        /// <param name="cameraCaptureService">The camera capture service.</param>
        public MainViewModel(INavigationService navigationService, IMediaLibraryService mediaLibraryService, ICameraCaptureService cameraCaptureService)
        {
            _navigationService = navigationService;
            _mediaLibraryService = mediaLibraryService;
            _cameraCaptureService = cameraCaptureService;
            ShowAlbunsCommand =new RelayCommand(ShowAlbuns);
            ShowPicturesCommand = new RelayCommand(ShowPictures);
            SavePictureCommand = new RelayCommand(SavePicture);
        }

        /// <summary>
        /// Saves the picture.
        /// </summary>
        private void SavePicture()
        {
            _cameraCaptureService.Show(CameraCapetureResult);
        }

        /// <summary>
        /// Shows the pictures.
        /// </summary>
        private void ShowPictures()
        {
            _navigationService.NavigateTo(new Uri("/PicturesPage.xaml", UriKind.Relative));
        }

        /// <summary>
        /// Shows the albuns.
        /// </summary>
        private void ShowAlbuns()
        {
            _navigationService.NavigateTo(new Uri("/AlbunsPage.xaml", UriKind.Relative));
        }

        /// <summary>
        /// Gets the show albuns command.
        /// </summary>
        /// <value>
        /// The show albuns.
        /// </value>
        public ICommand ShowAlbunsCommand { get; private set; }
        /// <summary>
        /// Gets the show pictures command.
        /// </summary>
        /// <value>
        /// The show pictures command.
        /// </value>
        public ICommand ShowPicturesCommand { get; private set; }

        /// <summary>
        /// Gets the sava picture command.
        /// </summary>
        /// <value>
        /// The sava picture command.
        /// </value>
        public ICommand SavePictureCommand { get; private set; }

        /// <summary>
        /// Cameras the capeture result.
        /// </summary>
        /// <param name="photoResult">The photo result.</param>
        private async void CameraCapetureResult(Microsoft.Phone.Tasks.PhotoResult photoResult)
        {
            if (photoResult.ChosenPhoto != null)
            {
                _mediaLibraryService.SavePicture("CimbalinoPicture",photoResult.ChosenPhoto);
            }
        }
    }
}