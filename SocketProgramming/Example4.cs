using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketProgramming
{
    public class Example4
    {
        public static void ServerStart()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipaddress = IPAddress.Any;

            IPEndPoint iPEndPoint = new IPEndPoint(ipaddress, 23000);

            try
            {

                socket.Bind(iPEndPoint);

                socket.Listen(5);


                Console.WriteLine("Server is about to listen connection...");

                Socket socketClient = socket.Accept(); //its a blocking operation, synchronous operation



                Console.WriteLine("Client Connected : " + socketClient);
                Console.WriteLine("IP Endpoint : " + socketClient.RemoteEndPoint);


                byte[] buff = new byte[128];

                while (true)
                {
                    int numberOfReceivedBytes = 0;

                    numberOfReceivedBytes = socketClient.Receive(buff);
                    string receivedInfo = Encoding.ASCII.GetString(buff, 0, numberOfReceivedBytes);

                    Console.WriteLine("Number Of Received Bytes : " + numberOfReceivedBytes);
                    Console.WriteLine("Info Received : " + receivedInfo);

                    socketClient.Send(buff);

                    if (receivedInfo == "x")
                        break;

                    Array.Clear(buff, 0, buff.Length);
                    numberOfReceivedBytes = 0;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            Console.ReadKey();
        }
    }
}
