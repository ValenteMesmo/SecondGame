using NetworkStuff;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ClientExemple
{
    class Program
    {
        static void Main(string[] args)
        {
            var listen = 20012;
            var write = 20013;
            while (true)
            {
                try
                {
                    TryOnThesePorts(listen++, write++);
                }
                catch (Exception)
                {
                }
            }
        }

        private static void TryOnThesePorts(int listen, int write)
        {
            var client = Factory.CreateClient(listen, write);
            client.InformYourListeningPortToHost("192.168.0.7", 8001, messageReceived);

            while (true)
            {
                client.SendMessage(Console.ReadLine());
            }
        }

        private static void messageReceived(string arg1, Address arg2)
        {
            Console.WriteLine(
                string.Format("{0}:{1} => {2}", arg2.Ip, arg2.Port, arg1)
                );
        }
    }
}

class Exemple : IExemple { }
interface IExemple { }

class Container
{
    private readonly Dictionary<Type, Func<object>> dictionary =
        new Dictionary<Type, Func<object>>();

    public void Register<T>(Func<T> getInstance) where T : class
    {
        var type = typeof(T);
        if (dictionary.ContainsKey(type))
            throw new Exception("!");

        dictionary.Add(type, getInstance);
    }

    public T Resolve<T>()
    {
        var type = typeof(T);
        if (dictionary.ContainsKey(type))
            return (T)dictionary[type]();

        throw new Exception("!");
    }
}