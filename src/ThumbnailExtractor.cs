using System;
using System.Drawing;
using System.IO;

namespace CodeCave.CAD.Toolkit
{
    /// <summary>
    /// Extracts thumbnails from 3D models without relying on proprietary APIs
    /// </summary>
    /// <seealso cref="IThumbnailExtractor" />
    public abstract class ThumbnailExtractor : IThumbnailExtractor
    {
        /// <summary>
        /// Extracts thumbnail to an image file.
        /// </summary>
        /// <param name="srcFile">The source file.</param>
        /// <param name="outFile">The output image file.</param>
        /// <returns>
        /// true if thumbnail has been extracted successfully
        /// </returns>
        /// <exception cref="InvalidDataException">Failed to extract to extract thumbnail from \"{srcFile}\" to \"{outFile}\</exception>
        public virtual bool TryExtractFile(string srcFile, string outFile)
        {
            var imageBytes = ExtractImageBytes(srcFile);

            try
            {
                using (var ms = new MemoryStream(imageBytes))
                {
                    using (var imageTmp = Image.FromStream(ms))
                    {
                        imageTmp.Save(outFile);
                    }
                }

                return File.Exists(outFile);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException($"Failed to extract to extract thumbnail from \"{srcFile}\" to \"{outFile}\"", ex);
            }
		}

        /// <summary>
        /// Extracts thumbnail to an image object.
        /// </summary>
        /// <param name="pathToFile">The path to file.</param>
        /// <returns></returns>
        public virtual byte[] ExtractImageBytes(string pathToFile)
        {
            using (var imageStream = ExtractStream(pathToFile))
            {
                return imageStream.ToArray();
            }
        }

        /// <summary>
        /// Extracts thumbnail to a stream.
        /// </summary>
        /// <param name="pathToFile">The path to file.</param>
        /// <returns>
        /// Memory stream containing thumbnail data
        /// </returns>
        public abstract MemoryStream ExtractStream(string pathToFile);
    }
}
