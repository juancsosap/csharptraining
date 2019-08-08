using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace fileDownloading
{
    class Program
    {
        static void Main(string[] args)
        {
            String pathUrl = @"https://www.ietf.org/rfc/";
        
            for(int i=0; i<100; i++) //8294
            {
                String fileName = "rfc" + (i+1) + ".txt";
                new FileDownloader(pathUrl + fileName);
            }
            
            Console.ReadLine();
        }
    }
}
