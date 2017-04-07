using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:8080/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("Server running...\nPress any key to exit.");
                
                Console.ReadKey();
            }
        }
    }
}
