﻿
using HowLeaky.DataModels;
using System;
using System.Collections.Generic;

namespace HowLeaky
{
    class Program
    {
        static void Main(string[] args)
        {
            //Project p = new Project(@"C:\projects\HLTest\Banana_reeftool.hlk");

            //Project p = new Project(@"C:\projects\HLTest\Compare\Model test.hlk");
            //p.RunSimulations()

            List<string> argsList = new List<string>(args);

            if(argsList.Contains("-h"))
            {
                PrintHelp();
                return;
            }

            Project p = null;
            int numberOfCores = 4;
            if (args.Length > 0)
            {
                p = new Project(args[0].ToString());
            }

            if (argsList.IndexOf("-O") > 0)
            {
                p.OutputPath = args[argsList.IndexOf("-O") + 1].ToString();
            }

            if (argsList.IndexOf("-P") > 0)
            {
                numberOfCores = int.Parse(args[argsList.IndexOf("-P") + 1].ToString());
            }

            if (argsList.Contains("-SQL"))
            {
                p.OutputType = OutputType.SQLiteOutput;
            }

            if (argsList.Contains("-CSV"))
            {
                p.OutputType = OutputType.CSVOutput;
            }

            p.RunSimulations(numberOfCores);

            Console.WriteLine("Press any key to exit when sims completed...\n");
            Console.ReadKey();
        }

        public static void PrintHelp()
        {
            Console.WriteLine("How Leaky Command Line Argumnets:");
            Console.WriteLine("   howleaky.exe <hlkfile.hlk:required>");
            Console.WriteLine("Optional Parameters:");
            Console.WriteLine("    -O <outputpath>        | The default path will be the same as the hlk file unlsess this is set");
            Console.WriteLine("    -P <No. of Processors> | The default is -1, which means HL will leave 1 processor spare. If you want to use specify the number of processors set this");
            Console.WriteLine("    -CSV                   | Output to CSV files. Default if not set");
            Console.WriteLine("    -SQL                   | Output to SQL file");
            Console.WriteLine("");
        }
    }
}
