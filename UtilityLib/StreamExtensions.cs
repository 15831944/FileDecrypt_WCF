using System;
using System.Configuration;
using System.IO;

public static class StreamExtensions
    {
        /// <summary>
        /// Copies data from one stream to another.
        /// </summary>
        /// <param name="input">The input stream</param>
        /// <param name="output">The output stream</param>
        public static void CopyTo(this Stream input, Stream output)
        {
            int bufferSize;
            try
            {
                bufferSize = int.Parse(ConfigurationManager.AppSettings["BufferSize"]);
            }
            catch (Exception)
            {

                bufferSize = 1024*1024*4;//4MB
            }
            
            byte[] buffer = new byte[bufferSize];
            int bytes;

            while ((bytes = input.Read(buffer, 0, bufferSize)) > 0)
            {
                output.Write(buffer, 0, bytes);
            }
        }
    }