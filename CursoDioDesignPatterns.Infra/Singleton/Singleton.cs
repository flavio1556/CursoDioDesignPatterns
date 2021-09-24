using System;
using System.Collections.Generic;
using System.Text;

namespace CursoDioDesignPatterns.Infra.Singleton
{
  public sealed class Singleton
    {
        public Guid Id { get; } =  Guid.NewGuid();
        private static Singleton _instance = null;
        private Singleton()
        {
        }
        public  static Singleton Instance 
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return Instance;
            }
        }
    }
}
