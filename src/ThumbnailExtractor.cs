using System;
using System.Drawing;
using System.IO;

namespace CodeCave.CAD.Toolkit
{
    /// <summary>
    /// Thumbnail extractor
    /// </summary>
    /// <seealso cref="IThumbnailExtractor" />
    public abstract class ThumbnailExtractor : IThumbnailExtractor
	{

        /// <summary>
        /// Extracts thumbnail to a stream.
        /// </summary>
        /// <param name="pathToFile">The path to file.</param>
        /// <returns>
        /// Memory stream containing thumbnail data
        /// </returns>
        /// <exception cref="InvalidDataException"></exception>
        public virtual MemoryStream ExtractStream(string pathToFile)
		{
			var image = ExtractImage(pathToFile);

		    try
		    {
		        var stream = new MemoryStream();
		        image.Save(stream, image.RawFormat);
		        stream.Position = 0;
		        return stream;
		    }
		    catch (Exception ex)
		    {
                throw new InvalidDataException($"", ex);
		    }
		}


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
			var image = ExtractImage(srcFile);

            try
            {
                image.Save(outFile);
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
        /// <returns>
        /// Image object
        /// </returns>
        public abstract Image ExtractImage(string pathToFile);
	}
}
