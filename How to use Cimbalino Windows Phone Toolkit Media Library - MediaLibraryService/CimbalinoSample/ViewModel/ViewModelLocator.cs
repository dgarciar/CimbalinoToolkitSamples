/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:CimbalinoSample"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

namespace CimbalinoSample.ViewModel
{
    using Cimbalino.Phone.Toolkit.Services;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Ioc;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (!SimpleIoc.Default.IsRegistered<INavigationService>())
            {
                SimpleIoc.Default.Register<INavigationService, NavigationService>();
            }

            if (!SimpleIoc.Default.IsRegistered<IMediaLibraryService>())
            {
                SimpleIoc.Default.Register<IMediaLibraryService, MediaLibraryService>();
            }
            if (!SimpleIoc.Default.IsRegistered<ICameraCaptureService>())
            {
                SimpleIoc.Default.Register<ICameraCaptureService, CameraCaptureService>();
            }
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AlbunsViewModel>();
            SimpleIoc.Default.Register<PicturesViewModel>();
        }

        /// <summary>
        /// Gets the main view model.
        /// </summary>
        /// <value>
        /// The main view model.
        /// </value>
        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        /// <summary>
        /// Gets the albuns view model.
        /// </summary>
        /// <value>
        /// The albuns view model.
        /// </value>
        public AlbunsViewModel AlbunsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AlbunsViewModel>();
            }
        }

        /// <summary>
        /// Gets the pictures view model.
        /// </summary>
        /// <value>
        /// The pictures view model.
        /// </value>
        public PicturesViewModel PicturesViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PicturesViewModel>();
            }
        }

        /// <summary>
        /// Cleanups.
        /// </summary>
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
            var viewModelLocator = (ViewModelLocator)App.Current.Resources["Locator"];
            viewModelLocator.MainViewModel.Cleanup();
        }
    }
}