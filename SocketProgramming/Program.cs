using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketProgramming
{
    /*
        IPv4  is group of 4 bit number, so total length is 32 bits
        IPv6  is 128 bits address
        
        IP address + Port = Endpoint

        there are 65536 port on a computer
        0 - 1023 Well-know ports or systems ports

        two seperate thread from same process can also connect to each other using sockets
        TCP/IP is stream data for transportaion

        ** Turn ON telnet service from Control Panel >> Program & Features >> Turn On/Off Windows Feature. 
         
    */



    class Program
    {
        static void Main(string[] args)
        {
            //Example1.ServerStart();
            //Example2.ServerStart();
            //Example3.ServerStart();
            //Example4.ServerStart();
            Example5 ex5 = new Example5();
            ex5.StartServer("127.0.0.1", 23000);

            Console.ReadKey();
        }
    }
}
