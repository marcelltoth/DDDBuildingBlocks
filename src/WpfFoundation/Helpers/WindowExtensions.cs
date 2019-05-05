using System;
using System.Threading.Tasks;
using System.Windows;

namespace MarcellToth.WpfFoundation.Helpers
{
    /// <summary>
    ///     Extension methods for the <see cref="Window"/> class.
    /// </summary>
    public static class WindowExtensions
    {
        /// <summary>
        ///     Shows a <see cref="Window"/> asynchronously.
        /// </summary>
        /// <remarks>
        ///    Essentially places the <code>window.ShowDialog()</code> call onto the dispatcher queue, then returns a Task that awaits its execution.
        /// </remarks>
        /// <param name="self">The window to show.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="self"/> is null.</exception>
        public static Task<bool?> ShowDialogAsync(this Window self)
        {
            if (self == null) throw new ArgumentNullException(nameof(self));

            var completion = new TaskCompletionSource<bool?>();
            self.Dispatcher.BeginInvoke(new Action(() => completion.SetResult(self.ShowDialog())));
            return completion.Task;
        }
    }
}