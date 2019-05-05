using System.Threading.Tasks;

namespace MarcellToth.WpfFoundation.Services.Abstractions
{
    /// <summary>
    ///     Service that provides an interface to ask the user to pick a location for saving a file.
    /// </summary>
    /// <remarks>
    ///    The most basic implementation of this service is based on <see cref="Microsoft.Win32.OpenFileDialog"/>
    ///    and is included in this package as <see cref="Win32FileDialogService"/>.
    /// </remarks>
    public interface ISaveFilePickerService
    {
        /// <summary>
        ///     Shows a dialog to the user to select a file for opening.
        ///     Nonexistent files should be allowed.
        ///     If the user selects an already existing file, the implementor should ask for a confirmation before selecting it (and potentially overwriting its contents).
        /// </summary>
        /// <param name="options">Options for showing the dialog.</param>
        /// <returns>The result of the operation. <seealso cref="FilePickerResult.IsSuccess"/></returns>
        Task<FilePickerResult> PickSaveFileAsync(FilePickerOptions options);
    }
}