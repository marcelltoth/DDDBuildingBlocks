using System.Linq;
using System.Threading.Tasks;
using MarcellToth.WpfFoundation.Helpers;
using MarcellToth.WpfFoundation.Services.Abstractions;
using Microsoft.Win32;

namespace MarcellToth.WpfFoundation.Services
{
    /// <summary>
    ///     Implements <see cref="IOpenFilePickerService"/> based on <see cref="OpenFileDialog"/> and <see cref="ISaveFilePickerService"/> based on <see cref="SaveFileDialog"/>.
    /// </summary>
    public class Win32FileDialogService : IOpenFilePickerService, ISaveFilePickerService
    {
        /// <inheritdoc />
        public Task<FilePickerResult> PickOpenFileAsync(FilePickerOptions options)
        {
            return PickFileAsync(options, new OpenFileDialog());
        }

        /// <inheritdoc />
        public Task<FilePickerResult> PickSaveFileAsync(FilePickerOptions options)
        {
            return PickFileAsync(options, new SaveFileDialog());
        }

        private async Task<FilePickerResult> PickFileAsync(FilePickerOptions options, FileDialog dialog)
        {
            dialog.Filter = string.Join("|", options.Filters.Select(f => $"{f.DisplayName}|*.{f.Extension}"));
            dialog.DefaultExt = $".{options.Filters.FirstOrDefault()?.Extension ?? "*"}";

            bool? result = await dialog.ShowDialogAsync();
            if (result == true)
            {
                return FilePickerResult.CreateSuccess(dialog.FileName);
            }

            return FilePickerResult.CreateError();
        }
    }
}