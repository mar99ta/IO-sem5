using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace cw2_Asynchroniczny_Serwer_TCP_biblioteka
{
    public abstract class Serwer_Abstrakcyjny
    {
        #region Pola
        IPAddress IP;
        int Port;
        TcpListener TCPlistener;
        TcpClient TCPclient;
        NetworkStream Stream;
        #endregion

        #region Funkcje
        public Serwer_Abstrakcyjny(IPAddress IP, int Port)
        {
            this.IP = IP;
            this.Port = Port;
        }

        protected void StartListening()
        {
            this.TCPlistener = new TcpListener(IP, Port);
            this.TCPlistener.Start();
        }

        protected TcpListener TCPlisener { get => TCPlistener; set => TCPlistener = value; }
        protected TcpClient TCPclienter { get => TCPclient; set => TCPclient = value; }
        protected NetworkStream Streamer { get => Stream; set => Stream = value; }

        public abstract void Start();
        public abstract void AcceptClient();
        protected abstract void BeginDataTransmission(NetworkStream nwStream, int client_buf_size);
        #endregion
    }
}
