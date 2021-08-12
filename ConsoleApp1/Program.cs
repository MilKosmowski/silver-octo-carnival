using System;
using System.Net.Sockets;

namespace ConsoleApp1
{
    class Program
    {
        public static TcpClient client;
        public static NetworkStream stream;
        static void Main(string[] args)
        {
        client = new TcpClient("10.235.241.235", Int32.Parse("24210"));
        stream = client.GetStream();

         Byte[] data = System.Text.Encoding.ASCII.GetBytes("BCRTCN|lot=123123121|process=PACK|station=CENTRAL_PACK_6|qty=6|delphipartnumber=11112222|status=PASS\n");
        stream.Write(data, 0, data.Length);
                data = new Byte[4056];
                stream.ReadTimeout = 5000;
                stream.WriteTimeout = 5000;
            Console.WriteLine(System.Text.Encoding.ASCII.GetString(data, 0, stream.Read(data, 0, data.Length)));
            Console.ReadLine();
        }
    }
}
