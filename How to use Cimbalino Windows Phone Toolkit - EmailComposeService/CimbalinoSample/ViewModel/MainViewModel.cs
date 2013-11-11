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
        /// The public application url.
        /// </summary>
        private readonly string _appUrl;

        /// <summary>
        /// The email compose service.
        /// </summary>
        private readonly IEmailComposeService _emailComposeService;

        /// <summary>
        /// The message
        /// </summary>
        private string _message;

        /// <summary>
        /// The subject
        /// </summary>
        private string _subject;

        /// <summary>
        /// The to
        /// </summary>
        private string _to;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="emailComposeService">
        /// The email Compose Service.
        /// </param>
        public MainViewModel(IEmailComposeService emailComposeService)
        {
            _emailComposeService = emailComposeService;
            
            SendFeedbackCommand = new RelayCommand(SendFeedback);
            ShareToMailCommand = new RelayCommand(ShareToMail);
            SendCommand =new RelayCommand(Send);
            _appUrl = string.Concat("http://windowsphone.com/s?appid=8df00038-1b7a-406b-b33f-37a78b17348c");
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message
        {
            get { return _message; }
            set { Set("Message", ref _message, value); }
        }

        /// <summary>
        /// Gets the send command.
        /// </summary>
        /// <value>
        /// The send command.
        /// </value>
        public ICommand SendCommand { get; private set; }

        /// <summary>
        /// Gets the send feedback command.
        /// </summary>
        public ICommand SendFeedbackCommand { get; private set; }

        /// <summary>
        /// Gets the share to e-mail command.
        /// </summary>
        public ICommand ShareToMailCommand { get; private set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        public string Subject
        {
            get { return _subject; }
            set { Set("Subject", ref _subject, value); }
        }

        /// <summary>
        /// Gets or sets to.
        /// </summary>
        /// <value>
        /// To.
        /// </value>
        public string To
        {
            get { return _to; }
            set { Set("To", ref _to, value); }
        }

        /// <summary>
        /// Sends mails.
        /// </summary>
        private void Send()
        {
            if (!string.IsNullOrEmpty(To) && !string.IsNullOrEmpty(Subject) && !string.IsNullOrEmpty(Message))
            {
                _emailComposeService.Show(To, Subject, Message);
            }
        }

        /// <summary>
        /// The send feedback.
        /// </summary>
        private void SendFeedback()
        {
            const string to = "saramgsilva@gmail.com";
            const string subject = "My Feedback";
            var body = "This the body";
            _emailComposeService.Show(to, subject, body);
        }
        
        /// <summary>
        /// The share to mail.
        /// </summary>
        private void ShareToMail()
        {
            const string Subject = "Cimbalino Toolkit Sample";
            var body = string.Concat("This application is amazing, you should try it! See in", _appUrl);
            _emailComposeService.Show(Subject, body);
        }
    }
}
