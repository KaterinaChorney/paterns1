using System;

namespace paterns1.creational
{
    internal sealed class BakeryManager
    {
        private static BakeryManager _instance;
        private BakeryManager() { }
        public static BakeryManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BakeryManager();
            }
            return _instance;
        }
        public void ManageBakery()
        {
            Console.WriteLine("The pastry shop works!");
        }
    }
}