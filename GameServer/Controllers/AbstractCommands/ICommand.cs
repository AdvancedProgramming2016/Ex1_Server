﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Controllers.AbstractCommands
{
    /// <summary>
    /// The basic command interface.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// The method which will execute the command.
        /// </summary>
        /// <param name="args">command arguments</param>
        /// <param name="client">the received client</param>
        /// <returns>command result string</returns>
        string Execute(string[] args, TcpClient client = null);
    }
}