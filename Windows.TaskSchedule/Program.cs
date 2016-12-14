﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.TaskSchedule.Core.Utility;
using Topshelf;

namespace Windows.TaskSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<ScheduleFactory>(sc =>
                {
                    sc.ConstructUsing(() => new ScheduleFactory());
                    sc.WhenStarted(s => s.Start());
                    sc.WhenStopped(s => s.Stop());
                });
                x.SetServiceName(ScheduleFactory.ServerName);
                x.SetDisplayName(ScheduleFactory.DisplayName);
                x.SetDescription(ScheduleFactory.Description);
                x.RunAsLocalSystem();
                x.StartAutomatically();
            });
        }
    }
}
