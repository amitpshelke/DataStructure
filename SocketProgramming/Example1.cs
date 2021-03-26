using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketProgramming
{
    public class Example1
    {
        public static void ServerStart()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress ipaddress = IPAddress.Any;

            IPEndPoint iPEndPoint = new IPEndPoint(ipaddress, 23000);

            socket.Bind(iPEndPoint);

            socket.Listen(5);

            socket.Accept(); //its a blocking operation, synchronous operation


            //TO run this is working
            //after hitting f5, run CMD and execute command "telnet 127.0.0.1 23000"

        }
    }
}
