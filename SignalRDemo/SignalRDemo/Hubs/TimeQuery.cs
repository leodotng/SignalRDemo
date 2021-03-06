﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using Microsoft.AspNet.SignalR;
using Timer = System.Timers.Timer;

namespace SignalRDemo.Hubs
{
    public class TimeQuery : Hub
    {
        static string messageToSend = DateTime.Now.ToString();
        Timer t;

        public void StartTimer()
        {
            if (t == null)
            {
                t = new Timer(500);
                t.Elapsed += t_Elapsed;
                t.Start();
            }
        }

        private void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            Clients.All.addMessage("Date time  : " + messageToSend);
            messageToSend = DateTime.Now.ToString();
        }
    }
}