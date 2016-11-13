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
        /// <returns></returns>
        public virtual MemoryStream ExtractStream(string pathToFile)
		{
			var image = ExtractImage(pathToFile);
			var stream = new MemoryStream();
			image.Save(stream, image.RawFormat);
			stream.Position = 0;
			return stream;
		}


        /// <summary>
        /// Extracts thumbnail to an image file.
        /// </summary>
        /// <param name="srcFile">The source file.</param>
        /// <param name="outFile">The output file.</param>
        /// <returns></returns>
        public virtual bool ExtractFile(string srcFile, string outFile)
		{
			var image = ExtractImage(srcFile);
			image.Save(outFile);
			return File.Exists(outFile);
		}

        /// <summary>
        /// Extracts thumbnail to an image object.
        /// </summary>
        /// <param name="pathToFile">The path to file.</param>
        /// <returns></returns>
        public abstract Image ExtractImage(string pathToFile);
	}
}
