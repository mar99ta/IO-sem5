using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace cw1_Serwer_TCP_biblioteka
{
    public class Class1
    {
        public void connection()
        {
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 2048);
            server.Start();

            TcpClient client = server.AcceptTcpClient();
            NetworkStream stream = client.GetStream();

            while (true)
            {
                stream = client.GetStream();
                byte[] buffer = new byte[client.ReceiveBufferSize];
                stream.Read(buffer, 0, client.ReceiveBufferSize);

                // x - liczba zadana przez użytkownika
                int x = answer(buffer);

                if (x > 0)
                {
                    Array.Clear(buffer, 0, buffer.Length);
                    buffer = Encoding.UTF8.GetBytes(x.ToString());
                    stream.Write(buffer, 0, buffer.Length);
                }
                
                Array.Clear(buffer, 0, buffer.Length);
            }
        }

        public int answer(byte[] buffer)
        {
            string a = ASCIIEncoding.ASCII.GetString(buffer, 0, buffer.Length);

            // w - wynik potęgowania 3-stopnia
            int w = 0;

            if (Int32.TryParse(a, out w))
            {
                w = Convert.ToInt32(Math.Pow(Convert.ToDouble(w), 3.0));
            }

            Console.Write(w);

            return w;
        }
    }
}