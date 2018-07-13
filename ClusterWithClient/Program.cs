using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Cluster.Tools.Client;

namespace ClusterWithClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = @"
akka {
actor {
        provider = ""Akka.Cluster.ClusterActorRefProvider, Akka.Cluster""
    }
remote {
        helios.tcp {
            hostname = ""127.0.0.1"" 
            public-hostname = ""127.0.0.1""
            port = 50000
        }
    }
cluster {
        seed-nodes = [""akka.tcp://ActorSystem@127.0.0.1:50000""]
        roles = [def]
    }
}";

            var actorSystem = ActorSystem.Create("ActorSystem", config);
            ClusterClientReceptionist.Get(actorSystem);

            Console.ReadKey();
        }
    }
}
