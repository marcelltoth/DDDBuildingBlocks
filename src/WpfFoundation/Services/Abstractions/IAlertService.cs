using System.Threading.Tasks;

namespace MarcellToth.WpfFoundation.Services.Abstractions
{
    /// <summary>
    ///     Interface for a service that shows GUI alerts to the user.
    /// </summary>
    /// <remarks>
    ///    The most basic implementation of this service is based on <see cref="System.Windows.MessageBox"/>
    ///    and is included in this package as <see cref="MessageBoxAlertService"/>.
    /// </remarks>
    public interface IAlertService
    {
        /// <summary>
        ///     Shows a simple alert to the user that does not require an answer.
        /// </summary>
        /// <param name="options">The configuration of the alert.</param>
        Task ShowSimpleAlertAsync(AlertOptions options);
        /// <summary>
        ///     Shows a question to the user that requires a Ok/Cancel answer.
        /// </summary>
        /// <param name="options">The configuration of the alert.</param>
        /// <returns>
        ///     True on confirmation, false on active rejection, null on a cancel (e.g. clicking the X on a MessageBox)
        /// </returns>
        Task<bool?> ShowConfirmationAsync(AlertOptions options);
    }
}