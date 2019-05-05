using System;
using System.Collections.Generic;

namespace MarcellToth.WpfFoundation.Services.Abstractions
{
    /// <summary>
    ///     Input parameters for a file picking operation.
    /// </summary>
    /// <seealso cref="IOpenFilePickerService"/>
    /// <seealso cref="ISaveFilePickerService"/>
    public class FilePickerOptions
    {
        /// <summary>
        ///     The list of file types the user is allowed to select.
        /// </summary>
        /// <seealso cref="FilePickerFilter"/>
        public IList<FilePickerFilter> Filters { get; } = new List<FilePickerFilter>();
    }

    /// <summary>
    ///     Defines a type of file that the user is allowed to select.
    /// </summary>
    public class FilePickerFilter
    {
        /// <summary>
        ///     The human readable name of the filter. E.g. "Photoshop Document".
        /// </summary>
        public string DisplayName { get; }

        /// <summary>
        ///     The allowed extension. E.g. "psd".
        /// </summary>
        public string Extension { get; }

        /// <summary>
        ///     Creates an instance of <see cref="FilePickerFilter"/>.
        /// </summary>
        /// <param name="displayName">The <see cref="DisplayName"/> of the filter to be created.</param>
        /// <param name="extension">The <see cref="Extension"/> of the filter to be created.</param>
        public FilePickerFilter(string displayName, string extension)
        {
            DisplayName = displayName ?? throw new ArgumentNullException(nameof(displayName));
            Extension = extension ?? throw new ArgumentNullException(nameof(extension));
        }
    }
}