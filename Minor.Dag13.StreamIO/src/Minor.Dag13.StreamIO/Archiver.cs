using System;
using System.IO;
using System.IO.Compression;

namespace Minor.Dag13.StreamIO
{
    public class Archiver
    {
        
        public Archiver()
        {

        }

        public void ZipFile(string location)
        {
            var fileInfo = new FileInfo(location);

            using (FileStream originalFileStream = fileInfo.OpenRead())
            {
                if ((File.GetAttributes(fileInfo.FullName) &
                    FileAttributes.Hidden) != FileAttributes.Hidden & fileInfo.Extension != ".archive")
                {
                    using (FileStream compressedFileStream = File.Create(fileInfo.FullName + DateTime.Now.ToString("yyyyMMdd") + ".archive"))
                    {
                        using (StreamWriter sw = new StreamWriter(compressedFileStream))
                        {
                            sw.Write("Filename:" + fileInfo.FullName);
                            sw.Write("Date" + DateTime.Now.ToString("yyyyMMdd"));
                        }
                        using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                            CompressionMode.Compress))
                        {
                            originalFileStream.CopyTo(compressionStream);
                        }
                    }
                    FileInfo info = new FileInfo(fileInfo + "\\" + fileInfo.Name + ".archive");
                }
            }
        }        
    }
}