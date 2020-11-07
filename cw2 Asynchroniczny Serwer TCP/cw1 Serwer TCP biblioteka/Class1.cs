using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace cw2_Asynchroniczny_Serwer_TCP_biblioteka
{
    public class Class1 : Serwer_Abstrakcyjny
    {
        public Class1(IPAddress IP, int Port) : base(IP, Port) { }

        public delegate void TransmissionDataDelegate(NetworkStream Stream, int buffer_size);

        private String[] users_table = new String[] { "user1", "user2", "user3", "user4", "user5" };

        private void TransmissionCallback(IAsyncResult ar)
        {
            Console.WriteLine("END");
        }

        public override void AcceptClient()
        {
            while (true)
            {
                TcpClient client = TCPlisener.AcceptTcpClient();

                Streamer = client.GetStream();

                int buffer_size = client.ReceiveBufferSize;
                TransmissionDataDelegate transmissionDelegate = new TransmissionDataDelegate(BeginDataTransmission);
                transmissionDelegate.BeginInvoke(Streamer, buffer_size, TransmissionCallback, client);
            }
        }

        public void ReadMessage(byte[] buffer, NetworkStream Stream)
        {
            String letter = Encoding.ASCII.GetString(buffer);
            byte[] reply = new byte[1024];
            String reply_letter;
            bool login = false;

            for (int i = 0; i < users_table.Length; i++)
            {
                if (letter.Contains(users_table[i]))
                {
                    login = true;
                }
            }

            if (login == true)
            {
                reply_letter = "pomyslnie zalogowano!";
            }
            else
            {
                reply_letter = "logowanie sie nie powiodlo.";
            }

            reply = Encoding.ASCII.GetBytes(reply_letter);
            Stream.Write(reply, 0, 1024);

        }

        protected override void BeginDataTransmission(NetworkStream Stream, int buffer_size)
        {
            byte[] buffer = new byte[buffer_size];

            while (true)
            {
                try
                {
                    Stream.Read(buffer, 0, buffer_size);
                    ReadMessage(buffer, buffer_size);
                }
                catch (IOException e)
                {
                    break;
                }
            }
        }


        public override void Start()
        {
            StartListening();
            AcceptClient();
        }

    }
}