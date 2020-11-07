using System;
using System.IO;
using System.Collections.Generic;
//using System.Collections.IEnumerable;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using cw2_Asynchroniczny_Serwer_TCP_biblioteka;

namespace cw2_Asynchroniczny_Serwer_TCP
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 a = new Class1(IPAddress.Parse("127.0.0.1"), 2048);
            a.Start();
        }
    }
}