using System;
using System.ComponentModel;
using System.IO;
using System.Net;

namespace fileDownloading
{
    class FileDownloader
    {
        private WebClient wc = new WebClient();
        private String path;
        private static int success = 0, failed = 0;
        
        private static ActionTimeMeter timeMeter = new ActionTimeMeter();

        public FileDownloader(String path, Boolean progress)
        {
            this.path = path;
            timeMeter.Begin();
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(FileDownloadComplete);
            if(progress) wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(FileDownloadProgress);
            Uri fileUrl = new Uri(this.path);
            Console.WriteLine("Downloading " + this.path);
            wc.DownloadFileAsync(fileUrl, @"RFCs/" + Path.GetFileName(path));
        }
        public FileDownloader(String path) : this(path, false) { }

        private void FileDownloadComplete(Object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Console.WriteLine("Download Completed : " + this.path);
                FileDownloader.success++;
            }
            else
            {
                Console.WriteLine("Download Failed : " + this.path);
                Console.WriteLine(e.Error.Message);
                FileDownloader.failed++;
            }
            ((WebClient)sender).Dispose();

            String elapsedTime = timeMeter.End();
            if (elapsedTime != null)
            {
                Console.WriteLine("RunTime " + elapsedTime);
                Console.WriteLine(FileDownloader.success + " Success Downloads");
                Console.WriteLine(FileDownloader.failed + " Failed Downloads");
            }
        }

        private void FileDownloadProgress(Object sender, DownloadProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage % 5 == 0) { Console.Write("#"); }
        }
    }
}
