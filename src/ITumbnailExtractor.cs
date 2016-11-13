using System.Drawing;
using System.IO;

namespace CodeCave.CAD.Toolkit
{
    public interface IThumbnailExtractor
    {
        /// <summary>
        /// Extracts thumbnail to an image object.
        /// </summary>
        /// <param name="pathToFile">The path to file.</param>
        /// <returns>Image object</returns>
        Image ExtractImage(string pathToFile);

        /// <summary>
        /// Extracts thumbnail to a stream.
        /// </summary>
        /// <param name="pathToFile">The path to file.</param>
        /// <returns>Memory stream containing thumbnail data</returns>
        MemoryStream ExtractStream(string pathToFile);

        /// <summary>
        /// Tries to extract thumbnail to an image file.
        /// </summary>
        /// <param name="srcFile">The source file.</param>
        /// <param name="outFile">The output image file.</param>
        /// <returns>true if thumbnail has been extracted successfully</returns>
        bool TryExtractFile(string srcFile, string outFile);
    }
}
