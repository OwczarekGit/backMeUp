using System;
using System.Threading;

namespace backMeUp
{
    public abstract class Watched
    {
       public string targetPath { get; private set; } = String.Empty;
        public Thread worker;
        
        public Watched(string path)
        {
            targetPath = path;
        }

        public void start()
        {
            worker = new Thread(watch);
            worker.Start();
        }

        protected abstract void watch();
    }
}