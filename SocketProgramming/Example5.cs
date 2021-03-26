using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace SocketProgramming
{
    public class Example5
    {
        IPAddress servAddr;
        int servPort = 0;
        TcpListener servTCP;

        public bool keepRunning { get; set; }

        public async void StartServer(string _servAddr = null, int _servPort = 0)
        {

            if(_servAddr == null || _servPort <=0)
                Console.WriteLine("Invalid Address to connect");

            bool success = IPAddress.TryParse(_servAddr, out servAddr);
            servPort = _servPort;

            servTCP = new TcpListener(servAddr, servPort);
            servTCP.Start();

            keepRunning = true;
            while (keepRunning)
            {
                var result = await servTCP.AcceptTcpClientAsync();

                Console.WriteLine("Client Connected Successfully..." + result);

                TakeCareofTCPClient(result);
            }
        }


        private async void TakeCareofTCPClient(TcpClient tcpClient)
        {
            NetworkStream ns = null;
            StreamReader sr = null;

            try
            {
                ns = tcpClient.GetStream();
                sr = new StreamReader(ns);

                char[] buff = new char[64];

                while (keepRunning)
                {
                    int retValue = await sr.ReadAsync(buff, 0, buff.Length);
                    Console.WriteLine("Returned Data : " + retValue);

                    if (retValue == 0) break;

                    string receivedText = new string(buff);

                    Array.Clear(buff, 0, buff.Length);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
