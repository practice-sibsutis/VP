using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using Example1;

namespace ObservableExamples
{
    internal class Examples
    {
        public static async Task Example1()
        {
            IObservable<long> ticks = Observable.Timer(
                dueTime: TimeSpan.Zero,
                period: TimeSpan.FromSeconds(1));

            ticks.Subscribe(t => Console.WriteLine($"Tick {t}"));

            await Task.Delay(4000);

            ticks.Subscribe(t => Console.WriteLine($"Tick2 {t}"));

            Console.ReadLine();
        }

        public static async Task Example2()
        {
            IConnectableObservable<long> ticks = Observable.Timer(
                dueTime: TimeSpan.Zero,
                period: TimeSpan.FromSeconds(1)).Publish();

            ticks.Subscribe(t => Console.WriteLine($"Tick {t}"));

            await Task.Delay(4000);

            ticks.Subscribe(t => Console.WriteLine($"Tick2 {t}"));

            ticks.Connect();

            Console.ReadLine();
        }

        public static void Example3()
        {
            IObservable<long> ticks = Observable.Timer(
                dueTime: TimeSpan.Zero,
                period: TimeSpan.FromSeconds(1));

            IDisposable observer = ticks.Subscribe(new MyConsoleObserver<long>());
            
            Console.ReadLine();
            
            observer.Dispose();

            Console.ReadLine();

        }


        public static void Example4()
        {
            IObservable<long> ticks = (new List<long>(new long[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })).ToObservable();

            ticks.Subscribe(
                value => Console.WriteLine($"Received value {value}"),
                error => Console.WriteLine($"Sequence faulted with {error}"),
                () => Console.WriteLine("Sequence terminated"));

            Console.ReadLine();
        }

        public static void Example5()
        {
            IObservable<FileSystemEventArgs> fs =
                new RxFsEvents(@"d:\docs")
                    .Publish()
                    .RefCount();


            fs.Subscribe(e =>
            {
                switch (e.ChangeType)
                {
                    case WatcherChangeTypes.Created:
                        Console.WriteLine($"{e.FullPath} was created");
                        break;

                    case WatcherChangeTypes.Changed:
                        Console.WriteLine($"{e.FullPath} was changed");
                        break;

                    case WatcherChangeTypes.Deleted:
                        Console.WriteLine($"{e.FullPath} was deleted");
                        break;

                    case WatcherChangeTypes.Renamed:
                        Console.WriteLine($"{e.FullPath} was renamed");
                        break;
                }
            });

            Console.ReadLine();
        }

        public static void Example55(string path)
        {
            RxFsEventsMultiSubscriber fs = new RxFsEventsMultiSubscriber(path);
            fs.Subscribe(e =>
            {
                switch (e.ChangeType)
                {
                    case WatcherChangeTypes.Created:
                        Console.WriteLine($"{e.FullPath} was created");
                        break;

                    case WatcherChangeTypes.Changed:
                        Console.WriteLine($"{e.FullPath} was changed");
                        break;

                    case WatcherChangeTypes.Deleted:
                        Console.WriteLine($"{e.FullPath} was deleted");
                        break;

                    case WatcherChangeTypes.Renamed:
                        Console.WriteLine($"{e.FullPath} was renamed");
                        break;
                }
            });

            fs.Subscribe(e =>
            {
                switch (e.ChangeType)
                {
                    case WatcherChangeTypes.Created:
                        Console.WriteLine($"{e.FullPath} was created");
                        break;

                    case WatcherChangeTypes.Changed:
                        Console.WriteLine($"{e.FullPath} was changed");
                        break;

                    case WatcherChangeTypes.Deleted:
                        Console.WriteLine($"{e.FullPath} was deleted");
                        break;

                    case WatcherChangeTypes.Renamed:
                        Console.WriteLine($"{e.FullPath} was renamed");
                        break;
                }
            });

            Console.ReadLine();
        }

        public static void Example6(string path)
        {
            IObservable<FileSystemEventArgs> fsWatcher = ObserveFileSystem(path);
            fsWatcher.Subscribe(e => 
            {
                switch (e.ChangeType)
                {
                    case WatcherChangeTypes.Created:
                        Console.WriteLine($"{e.FullPath} was created");
                        break;

                    case WatcherChangeTypes.Changed:
                        Console.WriteLine($"{e.FullPath} was changed");
                        break;

                    case WatcherChangeTypes.Deleted:
                        Console.WriteLine($"{e.FullPath} was deleted");
                        break;

                    case WatcherChangeTypes.Renamed:
                        Console.WriteLine($"{e.FullPath} was renamed");
                        break;
                }
            });

            Console.ReadLine();
        }

        //Simple factories
        public static void Example7()
        {
            IObservable<string> singleValue = Observable.Return<string>("Value");
            IObservable<string> empty = Observable.Empty<string>();
            IObservable<string> never = Observable.Never<string>();
            IObservable<string> throws = Observable.Throw<string>(new Exception());
        }

        public static void Example8()
        {
            IObservable<int> numbers = SomeNumbers();
            numbers.Subscribe(e => Console.WriteLine(e.ToString()));
            Console.ReadLine();
        }

        public static void Example9()
        {
            IObservable<int> ints = TaskIntRange();
            IDisposable token = ints.Subscribe(e => Console.WriteLine(e.ToString()));
            Console.ReadLine();
            token.Dispose();
            Console.ReadLine();
        }

        public static void Example10(string path)
        {
            IObservable<string> strings = ReadFileLines(path);
            CancellationTokenSource token = new CancellationTokenSource();

            strings.Subscribe(Console.WriteLine, 
                () => Console.WriteLine("Complete"), token.Token);

            Console.ReadLine();
        }

        public static void Example11()
        {
            IObservable<int> ints = Observable.Defer(() =>
            {
                Console.WriteLine("Doing some startup work...");
                return Observable.Range(1, 5);
            });

            ints.Subscribe(Console.WriteLine);
            Console.ReadLine();
            ints.Subscribe(Console.WriteLine);
            Console.ReadLine();
        }

        public static void Example12()
        {
            IObservable<Unit> start = Observable.Start(() =>
            {
                Console.WriteLine("Working away");
                for (int i = 0; i < 10; ++i)
                {
                    Thread.Sleep(100);
                    Console.Write(".");
                }
            });

            start.Subscribe(
                _ => Console.WriteLine("Unit published"),
                () => Console.WriteLine("Action complited"));

            Console.ReadLine();
        }

        public static void Example13()
        {
            IObservable<string> start = Observable.Start(() =>
            {
                Console.WriteLine("Working away");
                for (int i = 0; i < 10; ++i)
                {
                    Thread.Sleep(100);
                    Console.Write(".");
                }

                return "Published value";
            });

            start.Subscribe(
                e => Console.WriteLine($"{e}"),
                () => Console.WriteLine("Action complited"));

            Console.ReadLine();
        }

        //From events go to ObserveFileSystem method

        public static void Example14()
        {
            Task<string> t = Task.Run(() =>
            {
                Console.WriteLine("Task running...");
                return "Test";
            });
            IObservable<string> source = t.ToObservable();
            source.Subscribe(
                Console.WriteLine,
                () => Console.WriteLine("completed"));
            source.Subscribe(
                Console.WriteLine,
                () => Console.WriteLine("completed"));

            Console.ReadLine();
        }

        public static void Example15()
        {
            IObservable<string> source = Observable.FromAsync(() => Task.Run(() =>
            {
                Console.WriteLine("Task running...");
                return "Test";
            }));

            source.Subscribe(
                Console.WriteLine,
                () => Console.WriteLine("completed"));
            source.Subscribe(
                Console.WriteLine,
                () => Console.WriteLine("completed"));

            Console.ReadLine();
        }

        private static IObservable<FileSystemEventArgs> ObserveFileSystem(string folder)
        {
            return
                Observable.Defer(() =>
                    {
                        FileSystemWatcher fsw = new(folder);
                        fsw.EnableRaisingEvents = true;

                        return Observable.Return(fsw);
                    })
                    .SelectMany(fsw =>
                        Observable.Merge(new[]
                            {
                                Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
                                    h => fsw.Created += h, h => fsw.Created -= h),
                                Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
                                    h => fsw.Changed += h, h => fsw.Changed -= h),
                                Observable.FromEventPattern<RenamedEventHandler, FileSystemEventArgs>(
                                    h => fsw.Renamed += h, h => fsw.Renamed -= h),
                                Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
                                    h => fsw.Deleted += h, h => fsw.Deleted -= h)
                            })
                            .Select(ep => ep.EventArgs)
                            .Finally(() => fsw.Dispose()))
                    .Publish()
                    .RefCount();
        }

        private static IObservable<int> SomeNumbers()
        {
            return Observable.Create(
                (IObserver<int> observer) =>
                {
                    observer.OnNext(1);
                    observer.OnNext(2);
                    observer.OnNext(3);
                    observer.OnCompleted();

                    return Disposable.Empty;

                });
        }

        private static IObservable<int> TaskIntRange()
        {
            return Observable.Create<int>(observer =>
            {
                CancellationTokenSource cts = new();
                Task.Run(async () =>
                {
                    int i = 0;
                    while (!cts.IsCancellationRequested)
                    {
                        observer.OnNext(i);
                        ++i;
                        await Task.Delay(1000);
                    }
                });

                return () =>
                {
                    Console.WriteLine("Cancel!");
                    cts.Cancel();
                };
            });
        }

        private static IObservable<string> ReadFileLines(string path) =>
            Observable.Create<string>(async (observer, cancellationToken) =>
            {
                using (StreamReader reader = File.OpenText(path))
                {
                    Console.WriteLine($"Start read file...{cancellationToken.IsCancellationRequested}\n");
                    while (cancellationToken.IsCancellationRequested == false)
                    {
                        Console.WriteLine("Read line");
                        string? line = await reader.ReadLineAsync(cancellationToken).ConfigureAwait(false);
                        if (line is null)
                        {
                            break;
                        }

                        observer.OnNext(line);
                    }

                    observer.OnCompleted();

                    Console.WriteLine("End read file...");
                }
            });


    }
}
