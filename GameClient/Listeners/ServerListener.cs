﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using GameClient.Listeners;

namespace GameClient
{
    public class ServerListener : IListener

    {
        private TcpClient client;
        private StreamReader reader;
        private Task readTask;

        private bool Continue { get; set; }
        private bool IsMultiplayer { get; set; }
        private bool IsRead { get; set; }
        public string Command { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="reader"></param>
        public ServerListener(TcpClient client, StreamReader reader)
        {
            this.client = client;
            this.reader = reader;
            this.Continue = true;
            this.IsRead = false;
        }

        /// <summary>
        /// Listens for server input.
        /// </summary>
        public void StartListening()
        {
            this.readTask = new Task(() =>
            {
                while (Continue)
                {
                    this.Continue = true;
                    this.IsRead = false;
                    this.IsMultiplayer = false;

                    try
                    {
                        // Get result from server

//                        Command = Regex.Replace(reader.ReadLine(),
//                            @"(\r\n|\n)", "%");

                        string rawCommand = reader.ReadLine();

                        Command = rawCommand.Replace('@', '\n');
                        

                        Console.WriteLine("Result:\n {0}", Command);
                        Command = string.Empty;
                        //Thread.Sleep(1000);
                    }

                    catch (Exception e)
                    {
                        return;
                    }
                }
            });

            this.readTask.Start();
        }

        public void WaitForTask()
        {
            this.readTask.Wait();
        }

        public void Stop()
        {
            Continue = false;
            //readTask.Dispose();
        }
    }
}