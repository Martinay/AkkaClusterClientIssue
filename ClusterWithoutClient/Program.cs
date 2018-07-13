using System;
using Akka.Actor;
using Akka.Cluster.Tools.Client;

namespace ClusterWithoutClient
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
            port = 60000
        }
    }
cluster {
        seed-nodes = [""akka.tcp://ActorSystem@127.0.0.1:50000""]
        roles = [abc]
    }
}";

            var actorSystem = ActorSystem.Create("ActorSystem", config);
            
            //ClusterClientReceptionist.Get(actorSystem);
            
            Console.ReadKey();
        }
    }
}
