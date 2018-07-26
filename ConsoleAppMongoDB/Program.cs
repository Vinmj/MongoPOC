using Business;
using DataAccess;
using System;
using System.Collections.Generic;

namespace ConsoleAppMongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----- Started");

            Utils util = new Utils();
            util.Start();

            Console.WriteLine("----- Finished");
            Console.ReadLine();
        }

       
    }
}
