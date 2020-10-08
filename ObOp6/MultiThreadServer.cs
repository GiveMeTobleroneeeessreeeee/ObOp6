using FOPLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ObOp6
{
    class MultiThreadServer
    {

        private static void ProcessClientRequests(object argument)
        {
            TcpClient client = (TcpClient)argument;
            try
            {
                StreamReader reader = new StreamReader(client.GetStream());
                StreamWriter writer = new StreamWriter(client.GetStream());

                string s = string.Empty;
                while (!(s = reader.ReadLine()).Equals("Exit") || (s == null))
                {
                    Console.WriteLine("From client ->" + s);
                    string output;

                    switch (s.ToLower())
                    {
                        case "hentalle":
                            output = JsonConvert.SerializeObject(HentAlle());
                            writer.Write(output);
                            break;

                        case "hent":
                            string message = reader.ReadLine();
                            int id = Convert.ToInt32(message);
                            output = JsonConvert.SerializeObject(HentId(id));
                            writer.Write(output);
                            break;

                        case "gem":
                            string input = reader.ReadLine();
                            FanOutPut fop = JsonConvert.DeserializeObject<FanOutPut>(input);
                            Gem(fop);
                            break;
                    }     
                         
                         
                       
                        

                    writer.WriteLine("From server ->" + s);
                    writer.Flush();
                }
                reader.Close();
                writer.Close();
                client.Close();
                Console.WriteLine("Closing client connection");
            }
            catch (IOException)
            {
                Console.WriteLine("Problem with client communication. Exiting thread.");
            }
            finally
            {
                if (client != null)
                {
                    client.Close();
                }
            }
        }


        static void Main()
        {
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Loopback, 4646);
                listener.Start();

                Console.WriteLine("MultiThreadedServer started...");
                while (true)
                {
                    Console.WriteLine("Waiting for incoming client connections...");
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Accepted new client connection...");
                    Thread t = new Thread(ProcessClientRequests);
                    t.Start(client);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                if (listener != null)
                {
                    listener.Stop();
                }
            }
            //Console.WriteLine("Hello World!");
        }

        private static readonly List<FanOutPut> fanOutPuts = new List<FanOutPut>()
        {
            new FanOutPut(1, 55.32, 23.2, "Omklædningsrum"),
            new FanOutPut(2, 45, 21, "Indgang"),
            new FanOutPut(3, 42, 16, "Kontor"),
            new FanOutPut(4, 43.23, 15.3, "Gymnastiksal"),
            new FanOutPut(5, 45.24, 16.53, "Klasseværelse 001"),
            new FanOutPut(6, 76.34, 24.3, "Klasseværelse 002"),
            new FanOutPut(7, 76.99, 19.2, "Klasseværelse 003")
        };

        public void DoClient(TcpClient connectionSocket)
        {
            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;
        }

        public static List<FanOutPut> HentAlle()
        {
            return fanOutPuts;

        }

        public static FanOutPut HentId(int id)
        {
 
            return HentAlle().Find(i =>i.Id==id);
        }

        public static void Gem(FanOutPut fop)
        {
            fanOutPuts.Add(fop);

        }
    }
}
