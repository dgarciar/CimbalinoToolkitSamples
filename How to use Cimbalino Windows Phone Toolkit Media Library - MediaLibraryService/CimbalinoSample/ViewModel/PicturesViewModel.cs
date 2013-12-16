namespace CimbalinoSample.ViewModel
{
    using Cimbalino.Phone.Toolkit.Services;

    using GalaSoft.MvvmLight;

    using Microsoft.Xna.Framework.Media;

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    public class PicturesViewModel:ViewModelBase
    {
        /// <summary>
        /// The media library service
        /// </summary>
        private readonly IMediaLibraryService _mediaLibraryService;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="PicturesViewModel" /> class.
        /// </summary>
        /// <param name="mediaLibraryService">The media library service.</param>
        public PicturesViewModel(IMediaLibraryService mediaLibraryService)
        {
            _mediaLibraryService = mediaLibraryService;
        }
        
        /// <summary>
        /// Gets the pictures.
        /// </summary>
        /// <value>
        /// The pictures.
        /// </value>
        public PictureCollection Pictures
        { 
            get
            {
                return _mediaLibraryService.Pictures;
            } 
        }
    }
}
