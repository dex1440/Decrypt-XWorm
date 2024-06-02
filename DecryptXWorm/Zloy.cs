using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Security.Cryptography;

namespace Stub
{
    public class Zloy
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter the Hosts: ");
            Settings.Hosts = Console.ReadLine();

            Console.Write("Please enter the Port: ");
            Settings.Port = Console.ReadLine();

            Console.Write("Please enter the KEY: ");
            Settings.KEY = Console.ReadLine();

            Console.Write("Please enter the SPL: ");
            Settings.SPL = Console.ReadLine();

            Console.Write("Please enter the Group: ");
            Settings.Groub = Console.ReadLine();

            Console.Write("Please enter the USBNM: ");
            Settings.USBNM = Console.ReadLine();

            Console.Write("Please enter the Mutex: ");
            Settings.Mutex = Console.ReadLine();

            DAPS();
        }

        public static void DAPS()
        {
            Settings.Hosts = Conversions.ToString(AlgorithmAES.Decrypt(Settings.Hosts));
            Settings.Port = Conversions.ToString(AlgorithmAES.Decrypt(Settings.Port));
            Settings.KEY = Conversions.ToString(AlgorithmAES.Decrypt(Settings.KEY));
            Settings.SPL = Conversions.ToString(AlgorithmAES.Decrypt(Settings.SPL));
            Settings.Groub = Conversions.ToString(AlgorithmAES.Decrypt(Settings.Groub));
            Settings.USBNM = Conversions.ToString(AlgorithmAES.Decrypt(Settings.USBNM));

            Console.WriteLine("Decrypted Settings:");
            Console.WriteLine("Hosts: " + Settings.Hosts);
            Console.WriteLine("Port: " + Settings.Port);
            Console.WriteLine("KEY: " + Settings.KEY);
            Console.WriteLine("SPL: " + Settings.SPL);
            Console.WriteLine("Groub: " + Settings.Groub);
            Console.WriteLine("USBNM: " + Settings.USBNM);

            // Pause the program
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }

    public class Settings
    {
        public static string Hosts;
        public static string Port;
        public static string KEY;
        public static string SPL;
        public static int Sleep = 3;
        public static string Groub;
        public static string USBNM;
        public static string Mutex;
    }

    public class AlgorithmAES
    {
        public static object Decrypt(string input)
        {
            RijndaelManaged rM = new RijndaelManaged();
            MD5CryptoServiceProvider cP = new MD5CryptoServiceProvider();
            byte[] dA = new byte[32];
            byte[] h = cP.ComputeHash(Helper.S(Settings.Mutex));
            Array.Copy(h, 0, dA, 0, 16);
            Array.Copy(h, 0, dA, 15, 16);
            rM.Key = dA;
            rM.Mode = CipherMode.ECB;
            ICryptoTransform dcr = rM.CreateDecryptor();
            byte[] iB = Convert.FromBase64String(input);
            return Helper.B(dcr.TransformFinalBlock(iB, 0, iB.Length));
        }
    }

    public class Helper
    {
        public static byte[] S(string i)
        {
            return System.Text.Encoding.UTF8.GetBytes(i);
        }

        public static string B(byte[] i)
        {
            return System.Text.Encoding.UTF8.GetString(i);
        }
    }
}
