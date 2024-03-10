using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    public class RxFsEvents : IObservable<FileSystemEventArgs>
    {
        public RxFsEvents(string folder)
        {
            _folder = folder;
        }
        public IDisposable Subscribe(IObserver<FileSystemEventArgs> observer)
        {
            FileSystemWatcher watcher = new(_folder);
            object sync = new();

            bool onErrorAlreadyCalled = false;

            void SendToObserver(object _, FileSystemEventArgs e)
            {
                lock (sync)
                {
                    if (onErrorAlreadyCalled == false)
                    {
                        observer.OnNext(e);
                    }
                }
            }

            watcher.Created += SendToObserver;
            watcher.Changed += SendToObserver;
            watcher.Renamed += SendToObserver;
            watcher.Deleted += SendToObserver;


            watcher.Error += (_, e) =>
            {
                lock (sync)
                {
                    if (!onErrorAlreadyCalled)
                    {
                        observer.OnError(e.GetException());
                        onErrorAlreadyCalled = true;
                        watcher.Dispose();
                    }
                }
            };

            watcher.EnableRaisingEvents = true;

            return watcher;
        }

        private readonly string _folder;
    }
}
