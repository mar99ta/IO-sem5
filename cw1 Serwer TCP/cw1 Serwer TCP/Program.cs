using System;
using System.IO;
using System.Collections.Generic;
//using System.Collections.IEnumerable;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using cw1_Serwer_TCP_biblioteka;

namespace cw1_Serwer_TCP
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 a = new Class1();
            a.connection();
        }
    }
}