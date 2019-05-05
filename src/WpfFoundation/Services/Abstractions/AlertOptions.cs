namespace MarcellToth.WpfFoundation.Services.Abstractions
{
    /// <summary>
    ///     Defines the severity of an alert.
    /// </summary>
    public enum AlertSeverity
    {
        /// <summary>
        ///     Not defined, or verbose / debugging information.
        /// </summary>
        None,
        /// <summary>
        ///     Information.
        /// </summary>
        Info,
        /// <summary>
        ///     Warning.
        /// </summary>
        Warning,
        /// <summary>
        ///     Error.
        /// </summary>
        Error
    }

    /// <summary>
    ///     Defines parameters needed for showing an alert.
    ///     It is up to the <see cref="IAlertService"/> implementor services to interpret this data.
    /// </summary>
    /// <seealso cref="IAlertService"/>
    public class AlertOptions
    {

        /// <summary>
        ///     The severity of the alert.
        /// </summary>
        public AlertSeverity Type { get; }

        /// <summary>
        ///     The short title of the alert.
        /// </summary>
        public string Title { get; }

        /// <summary>
        ///     Longer detail text about the alert.
        /// </summary>
        public string Message { get; }

        private AlertOptions(AlertSeverity type, string title, string message)
        {
            Type = type;
            Title = title;
            Message = message;
        }

        /// <summary>
        ///     Creates an instance of <see cref="AlertOptions"/> with the <see cref="AlertSeverity.None"/> severity.
        /// </summary>
        /// <param name="title">The title of the alert to be created.</param>
        /// <param name="message">The message of the alert to be created.</param>
        public static AlertOptions CreateVerbose(string title, string message) => new AlertOptions(AlertSeverity.None, title, message);

        /// <summary>
        ///     Creates an instance of <see cref="AlertOptions"/> with the <see cref="AlertSeverity.Info"/> severity.
        /// </summary>
        /// <param name="title">The title of the alert to be created.</param>
        /// <param name="message">The message of the alert to be created.</param>
        public static AlertOptions CreateInfo(string title, string message) => new AlertOptions(AlertSeverity.Info, title, message);

        /// <summary>
        ///     Creates an instance of <see cref="AlertOptions"/> with the <see cref="AlertSeverity.Warning"/> severity.
        /// </summary>
        /// <param name="title">The title of the alert to be created.</param>
        /// <param name="message">The message of the alert to be created.</param>
        public static AlertOptions CreateWarning(string title, string message) => new AlertOptions(AlertSeverity.Warning, title, message);

        /// <summary>
        ///     Creates an instance of <see cref="AlertOptions"/> with the <see cref="AlertSeverity.Error"/> severity.
        /// </summary>
        /// <param name="title">The title of the alert to be created.</param>
        /// <param name="message">The message of the alert to be created.</param>
        public static AlertOptions CreateError(string title, string message) => new AlertOptions(AlertSeverity.Error, title, message);
    }
}