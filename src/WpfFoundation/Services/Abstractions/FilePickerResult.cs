using System;

namespace MarcellToth.WpfFoundation.Services.Abstractions
{
    /// <summary>
    ///     Represents the result of a file picking request.
    ///     The user either selected a file (success), or canceled the dialog (error).
    /// </summary>
    public class FilePickerResult
    {
        /// <summary>
        ///     The name of the file selected in case of a success.
        ///     Null in case of failure.
        /// </summary>
        public string FileName { get; }

        /// <summary>
        ///     True if a file was picked by the user. False if they cancelled the operation.
        /// </summary>
        public bool IsSuccess => FileName != null;

        private FilePickerResult(string fileName)
        {
            FileName = fileName;
        }

        /// <summary>
        ///     Creates a <see cref="FilePickerResult"/> for a successful operation.
        /// </summary>
        /// <param name="fileName">The name of the file picked. Cannot be null.</param>
        public static FilePickerResult CreateSuccess(string fileName)
        {
            return new FilePickerResult(fileName ?? throw new ArgumentNullException(nameof(fileName)));
        }

        /// <summary>
        ///     Creates a <see cref="FilePickerResult"/> for an unsuccessful operation.
        /// </summary>
        public static FilePickerResult CreateError()
        {
            return new FilePickerResult(null);
        }
    }
}