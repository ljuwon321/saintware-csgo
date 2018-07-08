using SimpleExternalCheatCSGO.API;
using SimpleExternalCheatCSGO.SDK;
using SimpleExternalCheatCSGO.Structs;
using SimpleExternalCheatCSGO.CodeInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SimpleExternalCSGOCheat;

namespace SimpleExternalCheatCSGO
{
    class Program
    {

        static SettingsForm s = new SettingsForm();

        static void Main()
        {
            Console.Title = RandomString(32);

            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                s.ShowDialog();
            }).Start();

            StartCheat();
        }

        public static void StartCheat()
        {
            Stopwatch netvar_Watch = new Stopwatch();
            Stopwatch cheat_Watch = new Stopwatch();
            Stopwatch signatures_Watch = new Stopwatch();

            cheat_Watch.Start();

            Console.WriteLine("[Version 1.0] - Build Time " + new FileInfo(Application.ExecutablePath).LastWriteTime.ToString("yyyy-MM-dd - HH:mm:ss"));

            Console.WriteLine("Loading CS:GO process...");

            if (!Globals._csgo.LoadCSGO())
            {
                Console.WriteLine("Failed to load CS:GO process!");
                Environment.Exit(0);
            }

            Globals._csgo.DumpInfo();

            Console.WriteLine("Scanning netvars...");
            netvar_Watch.Start();
            Globals._netvar.Init();
            netvar_Watch.Stop();
            Console.WriteLine("NetVar scan completed in " + netvar_Watch.Elapsed.ToString("ss\\.ff") + "s");

            Console.WriteLine("Scanning patterns...");
            signatures_Watch.Start();
            Globals._signatures.Init();
            signatures_Watch.Stop();
            Console.WriteLine("Signatures scan completed in " + signatures_Watch.Elapsed.ToString("ss\\.ff") + "s");

            cheat_Watch.Stop();
            Console.WriteLine("Cheat loaded in   " + cheat_Watch.Elapsed.ToString("ss\\.ff") + "s");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("I AM NOT RESPONSIBLE FOR ANY ACCOUNT BANNED WHILE USING THIS CHEAT,");
            Console.WriteLine("THERMONUCLEAR WAR, YOU GETTING ROASTED/DESTROYED, OR BOTH,");
            Console.WriteLine();
            Console.WriteLine("             USE THIS CHEAT AT YOUR OWN RISK");

            MainThread.Start();
        }


        //direct your eyes in another direction(dont look at this shit)
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefgijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
