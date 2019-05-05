using System;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MarcellToth.WpfFoundation.Helpers
{
    /// <summary>
    ///     Extension methods for the <see cref="CommonDialog"/> class.
    /// </summary>
    public static class CommonDialogExtensions
    {
        /// <summary>
        ///     Shows a <see cref="CommonDialog"/> asynchronously.
        /// </summary>
        /// <param name="dialog">The dialog to show.</param>
        /// <returns>The result of <code>dialog.ShowDialog()</code>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="dialog"/> is null.</exception>
        /// <remarks>
        ///     Essentially performs a <code>Task.Yield()</code> before a <code>ShowDialog()</code> call to allow other more important tasks to run,
        ///     but the main operation remains synchronous and will block the UI thread.
        ///     No marshalling takes place, this method should be called from the UI thread.
        /// </remarks>
        public static async Task<bool?> ShowDialogAsync(this CommonDialog dialog)
        {
            if (dialog == null) throw new ArgumentNullException(nameof(dialog));

            await Task.Yield();
            return dialog.ShowDialog();
        }
    }
}