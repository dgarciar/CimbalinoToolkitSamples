namespace CimbalinoSample.ViewModel
{
    using Cimbalino.Phone.Toolkit.Services;

    using Microsoft.Xna.Framework.Media;

    public class AlbunsViewModel
    {
         /// <summary>
        /// The media library service
        /// </summary>
        private readonly IMediaLibraryService _mediaLibraryService;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="PicturesViewModel" /> class.
        /// </summary>
        /// <param name="mediaLibraryService">The media library service.</param>
        public AlbunsViewModel(IMediaLibraryService mediaLibraryService)
        {
            _mediaLibraryService = mediaLibraryService;
        }

        /// <summary>
        /// Gets a lbuns.
        /// </summary>
        /// <value>
        /// Albuns.
        /// </value>
        public AlbumCollection Albuns 
        { 
            get
            {
                return _mediaLibraryService.Albums;
            } 
        }
    }
}
