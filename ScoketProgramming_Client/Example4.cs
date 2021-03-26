using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketProgramming_Client
{
    public class Example4
    {
        public static void ClientStart()
        {
            Socket socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipaddress = null;
            int Port = 0;

            try
            {
                Console.WriteLine("Starting Server...");
                Console.WriteLine("Enter IP address of Server");

                string ipAddr = Console.ReadLine();

                Console.WriteLine("Enter IP address of Server");

                string port = Console.ReadLine();

                if (!IPAddress.TryParse(ipAddr, out ipaddress))
                    Console.WriteLine("Invalid IP Address");

                if (!int.TryParse(port, out Port))
                    Console.WriteLine("Invalid port");

                if (Port <= 0 || Port > 65535)
                    Console.WriteLine("Invalid port");

                socketClient.Connect(ipaddress, Port);

                Console.WriteLine("Connected to the Server...");

                string inputCmd = "";

                while (true)
                {
                    inputCmd = Console.ReadLine();

                    if (inputCmd == "<EXIT>")
                        break;

                    byte[] buffSend = Encoding.ASCII.GetBytes(inputCmd);
                    socketClient.Send(buffSend);

                    byte[] buffReceive = new byte[128];
                    int nRecv = socketClient.Receive(buffReceive);

                    string recvData = Encoding.ASCII.GetString(buffReceive, 0, nRecv);

                    Console.WriteLine("Data from Server : " + recvData);
                }

                Console.ReadKey();

            }
            catch (Exception ex)
            {
                String error = ex.Message;
            }
            finally
            {
                if(socketClient != null)
                    if(socketClient.Connected)
                        socketClient.Shutdown(SocketShutdown.Both);
              
                socketClient.Close();
                socketClient.Dispose();

                Console.WriteLine("Press a key to exit.");
                Console.ReadKey();
            }

        }
    }
}
