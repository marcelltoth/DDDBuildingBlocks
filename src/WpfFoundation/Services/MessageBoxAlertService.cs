using System;
using System.Threading.Tasks;
using System.Windows;
using MarcellToth.WpfFoundation.Services.Abstractions;

namespace MarcellToth.WpfFoundation.Services
{
    /// <summary>
    ///     Implements <see cref="IAlertService"/> based on a <see cref="System.Windows.MessageBox"/>.
    /// </summary>
    public class MessageBoxAlertService : IAlertService
    {
        private static MessageBoxImage SelectImage(AlertSeverity severity)
        {
            switch (severity)
            {
                case AlertSeverity.None:
                    return MessageBoxImage.None;
                case AlertSeverity.Info:
                    return MessageBoxImage.Information;
                case AlertSeverity.Warning:
                    return MessageBoxImage.Warning;
                case AlertSeverity.Error:
                    return MessageBoxImage.Error;
                default:
                    throw new ArgumentOutOfRangeException(nameof(severity), severity, null);
            }
        }

        /// <inheritdoc />
        public async Task ShowSimpleAlertAsync(AlertOptions options)
        {
            await Task.Yield();
            MessageBox.Show(options.Message, options.Title, MessageBoxButton.OK, SelectImage(options.Type));
        }

        /// <inheritdoc />
        public async Task<bool?> ShowConfirmationAsync(AlertOptions options)
        {
            await Task.Yield();
            var result = MessageBox.Show(options.Message, options.Title, MessageBoxButton.OKCancel, SelectImage(options.Type), MessageBoxResult.None);
            switch (result)
            {
                case MessageBoxResult.None:
                    return null;
                case MessageBoxResult.OK:
                case MessageBoxResult.Yes:
                    return true;
                case MessageBoxResult.No:
                case MessageBoxResult.Cancel:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}