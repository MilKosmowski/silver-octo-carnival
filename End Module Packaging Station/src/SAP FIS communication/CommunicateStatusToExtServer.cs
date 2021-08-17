using System;
using System.Net.Sockets;

namespace Central_pack
{
    public abstract class CommunicateStatusToServer
    {
        public CommunicateStatusToServer(String server, String message, int portNumber)
        {
            this.Server = server;
            this.Message = message;
            this.PortNumber = portNumber;

            client = new TcpClient(server, portNumber);
            stream = client.GetStream();
            stream.ReadTimeout = 10000;
            stream.WriteTimeout = 10000;
        }

        public abstract string GetData();

        protected string Server;
        protected string Message;
        protected int PortNumber;
        protected TcpClient client;
        protected NetworkStream stream;
    }

    public class CommunicateStatusToExtServer: CommunicateStatusToServer
    {
        public CommunicateStatusToExtServer (String server, String message, int portNumber):base(server,message,portNumber)
        {}

        public override string GetData()
        {
            throw new NotImplementedException();
        }

        string SendToSAP(String server, String message, int portNumber)
        {
            string error;
            try
            {
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                TcpClient client = new TcpClient(server, portNumber);
                NetworkStream streamSAP = client.GetStream();
                streamSAP.ReadTimeout = 10000;
                streamSAP.WriteTimeout = 10000;
                streamSAP.Write(data, 0, data.Length);
                String responseData = String.Empty;
                data = new byte[256];
                int bytes = streamSAP.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                streamSAP.Close();
                client.Close();
                bytes = 0;
                return responseData;
            }
            catch (Exception e)
            {
                error = "Problem z wysyłką , " + e.ToString();
                return error;
            }
        }
    }
}
