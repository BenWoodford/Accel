using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AccelServer
{
    class TCPServer
    {
        Socket server;
        List<Device> deviceList;
        const int BUFFER_SIZE = 255;

        public TCPServer()
        {
            deviceList = new List<Device>();
            try
            {
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(new IPEndPoint(IPAddress.Any, 3333));
                server.Listen(100);
                server.BeginAccept(new AsyncCallback(onConnectionAccept), null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ah damn, the server won't start.");
                Console.WriteLine(ex.Message);
            }
        }

        private void onConnectionAccept(IAsyncResult ar)
        {
            try
            {
                Device dev = new Device();
                dev.clientSocket = server.EndAccept(ar);
                Console.WriteLine("Client Connected on " + dev.clientSocket.LocalEndPoint.ToString());
                dev.buffer = new byte[BUFFER_SIZE];
                dev.clientSocket.BeginReceive(dev.buffer, 0, dev.buffer.Length, SocketFlags.None, new AsyncCallback(onReceiveData), dev.clientSocket);
                server.BeginAccept(new AsyncCallback(onConnectionAccept), null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void onReceiveData(IAsyncResult ar)
        {
            try
            {
                int received = 0;
                Socket current = (Socket)ar.AsyncState;

                Device dev = null;
                foreach (Device d in deviceList)
                {
                    if (d.clientSocket == current)
                        dev = d;
                }

                if (dev == null)
                {
                    Console.WriteLine("Unknown device...?");
                    return;
                }

                received = current.EndReceive(ar);
                byte[] data = new byte[received];

                if (received == 0) return;

                Array.Copy(dev.buffer, data, received);
                dev.buffer = null;
                Array.Resize(ref dev.buffer, current.ReceiveBufferSize);

                current.BeginReceive(dev.buffer, 0, dev.buffer.Length, SocketFlags.None, new AsyncCallback(onReceiveData), current);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
