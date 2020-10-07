using FOPLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ObOp6
{
    //port skal være 4646

    //Skal håndterer flere clienter

    //skalhåndterer målinger af typen FanOutPut som jeg lavede i opg 1

    //skal kunne forstå følgende "requests (protokol"

    //Linje1: Hent alle
    //Linje2:  (tom)

    //Linje1: Hent
    //Linje2: Id

    //Linje1: Gem
    //Linje2: en måling med jason f.eks {"ID":123,"Navn":"D12","Temp":30,"Fugt":70}

    //Serveren har en statisk liste med målingerne

    //Til sidst test løsningen med SocketTest programmet.


    public class Server
    {
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
        public static void Start()
        {
            TcpListener serverSocket = new TcpListener(IPAddress.Loopback, 4646);

            serverSocket.Start();

            

            while(true)
            {
                Console.Write("Waiting for a connection...");
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("Connected!");


                Stream ns = connectionSocket.GetStream();




            }

            
            

        }

        public void DoClient(TcpClient Socket)
        {
            
            //TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            //Console.WriteLine("server activated");
            //Stream ns = connectionSocket.GetStream();
            //StreamReader sr = new StreamReader(ns);
            //string message = sr.ReadLine();
            
            //Console.WriteLine("recieved message" + message);
            //StreamWriter sw = new StreamWriter(ns);
            //sw.WriteLine(message.ToUpper());
            

        }


        public void HentAlle()
        {


        }

        public void HentId()
        {


        }

        public void Gem()
        {

        }


    }
}
