using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SkillBridge.Message;
using ProtoBuf;
using System.IO;
using Common;
using System.Threading;
using log4net.Repository;
using log4net;

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo fi = new System.IO.FileInfo("log4net.xml");
            ILoggerRepository repository = LogManager.CreateRepository("default");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(repository, fi);
            Log.Init("GameServer");
            Log.Info("Game Server Init");

            GameServer server = new GameServer();
            server.Init();
            server.Start();
            Console.WriteLine("Game Server Running......");
            CommandHelper.Run();
            Log.Info("Game Server Exiting...");
            server.Stop();
            Log.Info("Game Server Exited");
        }
    }
}
