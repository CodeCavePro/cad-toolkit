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
        /// <returns></returns>
        Image ExtractImage(string pathToFile);

        /// <summary>
        /// Extracts thumbnail to a stream.
        /// </summary>
        /// <param name="pathToFile">The path to file.</param>
        /// <returns></returns>
        MemoryStream ExtractStream(string pathToFile);

        /// <summary>
        /// Extracts thumbnail to an image file.
        /// </summary>
        /// <param name="srcFile">The source file.</param>
        /// <param name="outFile">The output file.</param>
        /// <returns></returns>
        bool ExtractFile(string srcFile, string outFile);
    }
}
