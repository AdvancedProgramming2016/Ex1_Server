﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Models.Players
{
    /// <summary>
    /// Contains two players that play togather.
    /// </summary>
    public class GameRoom
    {
       /// <summary>
       /// Constructor.
       /// </summary>
       /// <param name="name">Game name</param>
        public GameRoom(string name)
        {
            this.Name = name;
            this.IsGameClosed = false;
            this.IsGameReady = false;
            this.IsGameAvailable = true;
        }

        public string Name { get; private set; }

        public bool IsGameClosed { get; set; }

        public bool IsGameReady { get; set; }

        public bool IsGameAvailable { get; set; }

        public Player PlayerOne { get; set; }

        public Player PlayerTwo { get; set; }
    }
}