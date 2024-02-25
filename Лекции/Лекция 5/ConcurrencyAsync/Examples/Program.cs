// See https://aka.ms/new-console-template for more information

//Example 1
using System.Diagnostics;

{
    Thread t = new Thread(WriteY);
    t.Start();


    for (int i = 0; i < 1000; i++) Console.Write("x");

    void WriteY()
    {
        for (int i = 0; i < 1000; i++) Console.Write("y");
    }
}

//Example 2
{
    Thread t = new Thread(Go);
    t.Start();
    t.Join();
    Console.WriteLine("Thread t has ended!");

    /*
     * Thread.Sleep (TimeSpan.FromHours (1));  // Sleep for 1 hour
     * Thread.Sleep (500);                     // Sleep for 500 milliseconds
     * Thread.Sleep(0)                         // Yield
     */

    void Go() { for (int i = 0; i < 1000; i++) Console.Write("y"); }
}

//Example 3
{
    while (DateTime.Now < nextStartTime)
        Thread.Sleep(100);
}


// Example 4
{
    while (DateTime.Now < nextStartTime);
}

//Example 5
{
    new Thread(Go).Start();
    Go();

    void Go()
    {
        for (int cycles = 0; cycles < 5; cycles++) Console.Write('?');
    }
}

//Example 6
{
    bool _done = false;

    new Thread(Go).Start();
    Go();

    void Go()
    {
        if (!_done) { _done = true; Console.WriteLine("Done"); }
    }
}

//Example 7
{
    bool done = false;
    ThreadStart action = () =>
    {
        if (!done) { done = true; Console.WriteLine("Done"); }
    };
    new Thread(action).Start();
    action();
}

//Example 8
{
    var tt = new ThreadTest();
    new Thread(tt.Go).Start();
    tt.Go();

    class ThreadTest
    {
        bool _done;

        public void Go()
        {
            if (!_done) { _done = true; Console.WriteLine("Done"); }
        }
    }
}

//Example 9
{
    class ThreadTest
    {
        static bool _done;    // Static fields are shared between all threads
        // in the same process.
        static void Main()
        {
            new Thread(Go).Start();
            Go();
        }

        static void Go()
        {
            if (!_done) { _done = true; Console.WriteLine("Done"); }
        }
    }
}


//Example 10
{
    static void Go()
    {
        if (!_done) { Console.WriteLine("Done"); _done = true; }
    }
}

//Example 11
{
    class ThreadSafe
    {
        static bool _done;
        static readonly object _locker = new object();

        static void Main()
        {
            new Thread(Go).Start();
            Go();
        }

        static void Go()
        {
            lock (_locker)
            {
                if (!_done) { Console.WriteLine("Done"); _done = true; }
            }
        }
    }
}


//Example 12
{
    Thread t = new Thread(() => Print("Hello from t!"));
    t.Start();

    void Print(string message) => Console.WriteLine(message);
}

//Example 13
{
    new Thread(() =>
    {
        Console.WriteLine("I'm running on another thread!");
        Console.WriteLine("This is so easy!");
    }).Start();
}

//Example 14
{
    Thread t = new Thread(Print);
    t.Start("Hello from t!");

    void Print(object messageObj)
    {
        string message = (string)messageObj;   // We need to cast here
        Console.WriteLine(message);
    }
}

//Example 15
{
    for (int i = 0; i < 10; i++)
        new Thread(() => Console.Write(i)).Start();
}

//Example 16
{
    for (int i = 0; i < 10; i++)
    {
        int temp = i;
        new Thread(() => Console.Write(temp)).Start();
    }
}

//Example 17
{
    string text = "t1";
    Thread t1 = new Thread(() => Console.WriteLine(text));

    text = "t2";
    Thread t2 = new Thread(() => Console.WriteLine(text));

    t1.Start(); t2.Start();
}

//Example 18
{
    try
    {
        new Thread(Go).Start();
    }
    catch (Exception ex)
    {
        // We'll never get here!
        Console.WriteLine("Exception!");
    }

    void Go() { throw null; }   // Throws a NullReferenceException
}

//Example 19
{
    new Thread(Go).Start();

    void Go()
    {
        try
        {
            ...
            throw null;    // The NullReferenceException will get caught below
            ...
        }
        catch (Exception ex)
        {
            // Typically log the exception and/or signal another thread
            // that we've come unstuck
            ...
        }
    }
}

//Example 20
{
    static void Main(string[] args)
    {
        Thread worker = new Thread(() => Console.ReadLine());
        if (args.Length > 0) worker.IsBackground = true;
        worker.Start();
    }
}

//Example21
{
    enum ThreadPriority { Lowest, BelowNormal, Normal, AboveNormal, Highest }
}

//Example 22
{
    using Process p = Process.GetCurrentProcess();
    p.PriorityClass = ProcessPriorityClass.High;

}

//Example 23

{
    var signal = new ManualResetEvent(false);

    new Thread(() =>
    {
        Console.WriteLine("Ожидание сигнала...");
        signal.WaitOne();
        signal.Dispose();
        Console.WriteLine("Есть сигнал!");
    }).Start();

    Thread.Sleep(2000);
    signal.Set();
}

//Example 24
{
    // Task находится в System.Threading.Tasks
    Task.Run(() => Console.WriteLine("Привет из пула потоков"));
}

//Example 25
{
    ThreadPool.QueueUserWorkItem(notUsed => Console.WriteLine("Hello"));
}

//Example 26
{
    Task.Run(() => Console.WriteLine("Foo"));
}

//Example 27
{
    new Thread(() => Console.WriteLine("Foo")).Start();
}

//Example 28
{
    Task task = Task.Run(() =>
    {
        Thread.Sleep(2000);
        Console.WriteLine("Foo");
    });
    Console.WriteLine(task.IsCompleted);  // False
    task.Wait();  // Blocks until task is complete
}

//Example 29
{
    Task task = Task.Factory.StartNew(() => ...,
        TaskCreationOptions.LongRunning);
}

//Example 30
{
    Task<int> task = Task.Run(() =>
    {
        Console.WriteLine("Foo");
        return 3;
    });

    int result = task.Result; // Блокировка, если задача еще не завершена
    Console.WriteLine(result); // 3
}

//Example 31
{
    Task<int> primeNumberTask = Task.Run(() =>
        Enumerable.Range(2, 3000000).Count(n =>
            Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));

    Console.WriteLine("Задача выполняется...");
    Console.WriteLine("Ответ - " + primeNumberTask.Result);
}

//Example 32
{
    // Запускаем задачу, которая выбрасывает NullReferenceException:
    Task task = Task.Run(() => { throw null; });
    try
    {
        task.Wait();
    }
    catch (AggregateException aex)
    {
        if (aex.InnerException is NullReferenceException)
            Console.WriteLine("Null!");
        else
            throw;
    }
}

//Example 33
{
    Task<int> primeNumberTask = Task.Run(() =>
        Enumerable.Range(2, 3000000).Count(n =>
            Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));

    var awaiter = primeNumberTask.GetAwaiter();
    awaiter.OnCompleted(() =>
    {
        int result = awaiter.GetResult();
        Console.WriteLine(result);       // Writes result
    });
}

//Exemple 34
{
    primeNumberTask.ContinueWith(antecedent =>
    {
        int result = antecedent.Result;
        Console.WriteLine(result); // Пишет 123
    });
}

//Example 35
{
    public class TaskCompletionSource<TResult>
    {
        public void SetResult(TResult result);
        public void SetException(Exception exception);
        public void SetCanceled();

        public bool TrySetResult(TResult result);
        public bool TrySetException(Exception exception);
        public bool TrySetCanceled();
        public bool TrySetCanceled(CancellationToken cancellationToken);
            ...
    }
}

//Example 36
{
    var tcs = new TaskCompletionSource<int>();

    new Thread(() => { Thread.Sleep(5000); tcs.SetResult(42); })
            { IsBackground = true }
        .Start();

    Task<int> task = tcs.Task;         // Our "slave" task.
    Console.WriteLine(task.Result);   // 42
}

//Example 37
{
    Task<int> GetAnswerToLife()
    {
        var tcs = new TaskCompletionSource<int>();
        // Create a timer that fires once in 5000 ms:
        var timer = new System.Timers.Timer(5000) { AutoReset = false };
        timer.Elapsed += delegate { timer.Dispose(); tcs.SetResult(42); };
        timer.Start();
        return tcs.Task;
    }
}

//Example 38
{
    var awaiter = GetAnswerToLife().GetAwaiter();
    awaiter.OnCompleted(() => Console.WriteLine(awaiter.GetResult()));
}

//Example 39
{
    Task Delay(int milliseconds)
    {
        var tcs = new TaskCompletionSource<object>();
        var timer = new System.Timers.Timer(milliseconds) { AutoReset = false };
        timer.Elapsed += delegate { timer.Dispose(); tcs.SetResult(null); };
        timer.Start();
        return tcs.Task;
    }
}

//Example 40
{
    Task.Delay(5000).GetAwaiter().OnCompleted(() => Console.WriteLine(42));

    Task.Delay(5000).ContinueWith(ant => Console.WriteLine(42));
}

//Example 41
{
    int GetPrimesCount(int start, int count)
    {
        return
            ParallelEnumerable.Range(start, count).Count(n =>
                Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0));
    }
}

//Example 42
{
    void DisplayPrimeCounts()
    {
        for (int i = 0; i < 10; i++)
            Console.WriteLine(GetPrimesCount(i * 1000000 + 2, 1000000) +
                              " primes between " + (i * 1000000) + " and " + ((i + 1) * 1000000 - 1));
        Console.WriteLine("Done!");
    }

    Task.Run(() => DisplayPrimeCounts());
}

//Example 43
{
    Task<int> GetPrimesCountAsync(int start, int count)
    {
        return Task.Run(() =>
            ParallelEnumerable.Range(start, count).Count(n =>
                Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)));
    }
}

//Example 44
{
    for (int i = 0; i < 10; i++)
    {
        var awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000).GetAwaiter();
        awaiter.OnCompleted(() =>
            Console.WriteLine(awaiter.GetResult() + " primes between... "));
    }
    Console.WriteLine("Done");
}

//Example 45
{
    void DisplayPrimeCounts()
    {
        DisplayPrimeCountsFrom(0);
    }

    void DisplayPrimeCountsFrom(int i)
    {
        var awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000).GetAwaiter();
        awaiter.OnCompleted(() =>
        {
            Console.WriteLine(awaiter.GetResult() + " primes between...");
            if (++i < 10) DisplayPrimeCountsFrom(i);
            else Console.WriteLine("Done");
        });
    }
}

//Example 46
{
Task DisplayPrimeCountsAsync()
{
    var machine = new PrimesStateMachine();
    machine.DisplayPrimeCountsFrom(0);
    return machine.Task;
}

    class PrimesStateMachine
    {
        TaskCompletionSource<object> _tcs = new TaskCompletionSource<object>();
    public Task Task { get { return _tcs.Task; } }

        public void DisplayPrimeCountsFrom(int i)
        {
            var awaiter = GetPrimesCountAsync(i * 1000000 + 2, 1000000).GetAwaiter();
            awaiter.OnCompleted(() =>
            {
                Console.WriteLine(awaiter.GetResult());
                if (++i < 10) DisplayPrimeCountsFrom(i);
                else { Console.WriteLine("Done"); _tcs.SetResult(null); }
            });
        }
    }
}


//Example 47
{
    async Task DisplayPrimeCountsAsync()
    {
        for (int i = 0; i < 10; i++)
            Console.WriteLine(await GetPrimesCountAsync(i * 1000000 + 2, 1000000) +
                              " primes between " + (i * 1000000) + " and " + ((i + 1) * 1000000 - 1));
        Console.WriteLine("Done!");
    }
}

//Example 48
{
    var result = await expression; //This

    //That
    var awaiter = expression.GetAwaiter();
    awaiter.OnCompleted(() =>
    {
        var result = awaiter.GetResult();
        statement(s);
    });
}

//Example 48
{
    async void DisplayPrimesCount()
    {
        int result = await GetPrimesCountAsync(2, 1000000);
        Console.WriteLine(result);
    }

    Task<int> GetPrimesCountAsync(int start, int count)
    {
        return Task.Run(() =>
            ParallelEnumerable.Range(start, count).Count(n =>
                Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i > 0)))
    }

    int result = await GetPrimesCountAsync(2, 1000000);
    Console.WriteLine(result);
}

//Example 49
{
    async void DisplayPrimeCounts()
    {
        for (int i = 0; i < 10; i++)
            Console.WriteLine(await GetPrimesCountAsync(i * 1000000 + 2, 1000000));
    }
}

//Example 50
{
    async Task PrintAnswerToLife() // Мы можем вернуть Task вместо void
    {
        await Task.Delay(5000);
        int answer = 21 * 2;
        Console.WriteLine(answer);
    }
}

//Example 51
{
    async Task Go()
    {
        await PrintAnswerToLife();
        Console.WriteLine("Готово");
    }
}

//Example 52
{
    Task PrintAnswerToLife()
    {
        var tcs = new TaskCompletionSource<object>();
        var awaiter = Task.Delay(5000).GetAwaiter();
        awaiter.OnCompleted(() =>
        {
            try
            {
                awaiter.GetResult(); // Повторно отбрасываем исключения
                int answer = 21 * 2;
                Console.WriteLine(ответ);
                tcs.SetResult(null);
            }
            catch (Exception ex) { tcs.SetException(ex); }
        });
        return tcs.Task;
    }
}

//Example 53
{
    async Task<int> GetAnswerToLife()
    {
        await Task.Delay(5000);
        int answer = 21 * 2;
        return answer;    // Method has return type Task<int> we return int
    }
}

//Example 54
{
    async Task Go()
    {
        await PrintAnswerToLife();
        Console.WriteLine("Готово");
    }

    async Task PrintAnswerToLife()
    {
        int answer = await GetAnswerToLife();
        Console.WriteLine(ответ);
    }

    async Task<int> GetAnswerToLife()
    {
        await Task.Delay(5000);
        int answer = 21 * 2;
        return answer;
    }
}

//Example 55
{
    void Go()
    {
        PrintAnswerToLife();
        Console.WriteLine("Готово");
    }

    void PrintAnswerToLife()
    {
        int answer = GetAnswerToLife();
        Console.WriteLine(ответ);
    }

    int GetAnswerToLife()
    {
        Thread.Sleep(5000);
        int answer = 21 * 2;
        return answer;
    }
}

//Example 56
{
    Func<Task> unnamed = async () =>
    {
        await Task.Delay(1000);
        Console.WriteLine("Foo");
    };

    async IAsyncEnumerable<int> RangeAsync(
        int start, int count, int delay)
    {
        for (int i = start; i < start + count; i++)
        {
            await Task.Delay(delay);
            yield return i;
        }
    }

    await foreach (var number in RangeAsync(0, 10, 500))
        Console.WriteLine(number);
}

//Example 57
{
    static async Task<IEnumerable<int>> RangeTaskAsync(int start, int count,
        int delay)
    {
        List<int> data = new List<int>();
        for (int i = start; i < start + count; i++)
        {
            await Task.Delay(delay);
            data.Add(i);
        }

        return data;
    }

    foreach (var data in await RangeTaskAsync(0, 10, 500))
        Console.WriteLine(data);
}

//Example 58
{
    class CancellationToken
    {
        public bool IsCancellationRequested { get; private set; }
        public void Cancel() { IsCancellationRequested = true; }
        public void ThrowIfCancellationRequested()
        {
            if (IsCancellationRequested)
                throw new OperationCanceledException();
        }
    }
}

//Example 59
{
    async Task Foo(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
            await Task.Delay(1000);
            cancellationToken.ThrowIfCancellationRequested();
        }
    }
}

//Example 60
{
    var cancelSource = new CancellationTokenSource();

    var cancelSource = new CancellationTokenSource();
    Task foo = Foo(cancelSource.Token);
    ...
    ... (некоторое время спустя)
    cancelSource.Cancel();
}

//Example 61
{
    async Task Foo(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
            await Task.Delay(1000, cancellationToken);
        }
    }
}

//Example 62
{
    async Task<int> Delay1() { await Task.Delay(1000); return 1; }
    async Task<int> Delay2() { await Task.Delay(2000); return 2; }
    async Task<int> Delay3() { await Task.Delay(3000); return 3; }
}

//Example 63
{
    Task<int> winningTask = await Task.WhenAny(Delay1(), Delay2(), Delay3());
    Console.WriteLine("Done");
    Console.WriteLine(winningTask.Result);   // 1
}

//Example 64
{
    Task<string> task = SomeAsyncFunc();
    Task winner = await (Task.WhenAny(task, Task.Delay(5000)));
    if (winner != task) throw new TimeoutException();
    string result = await task;   // Unwrap result/re-throw
}

//Example 65
{
    await Task.WhenAll(Delay1(), Delay2(), Delay3());

    //Also
    Task task1 = Delay1(), task2 = Delay2(), task3 = Delay3();
    await task1; await task2; await task3;
}

//Example 66
{
    Task task1 = Task.Run(() => { throw null; });
    Task task2 = Task.Run(() => { throw null; });

    Task all = Task.WhenAll(task1, task2);
    try { await all; }
    catch
    {
        Console.WriteLine(all.Exception.InnerExceptions.Count);   // 2 
    }
}

//Example 67
{
    Task<int> task1 = Task.Run(() => 1);
    Task<int> task2 = Task.Run(() => 2);
    int[] results = await Task.WhenAll(task1, task2);   // { 1, 2 }
}

//Example 68
{
    async static Task<TResult> WithTimeout<TResult>(this Task<TResult> task,
        TimeSpan timeout)
    {
        Task winner = await Task.WhenAny(task, Task.Delay(timeout))
            .ConfigureAwait(false);
        if (winner != task) throw new TimeoutException();
        return await task.ConfigureAwait(false);   // Unwrap result/re-throw
    }
}

//Example 69
{
    async static Task<TResult> WithTimeout<TResult>(this Task<TResult> task,
        TimeSpan timeout)
    {
        var cancelSource = new CancellationTokenSource();
        var delay = Task.Delay(timeout, cancelSource.Token);
        Task winner = await Task.WhenAny(task, delay).ConfigureAwait(false);
        if (winner == task)
            cancelSource.Cancel();
        else
            throw new TimeoutException();
        return await task.ConfigureAwait(false);   // Unwrap result/re-throw
    }
}

//Example 70
{
    static Task<TResult> WithCancellation<TResult>(this Task<TResult> task,
        CancellationToken cancelToken)
    {
        var tcs = new TaskCompletionSource<TResult>();
        var reg = cancelToken.Register(() => tcs.TrySetCanceled());
        task.ContinueWith(ant =>
        {
            reg.Dispose();
            if (ant.IsCanceled)
                tcs.TrySetCanceled();
            else if (ant.IsFaulted)
                tcs.TrySetException(ant.Exception.InnerExceptions);
            else
                tcs.TrySetResult(ant.Result);
        });
        return tcs.Task;
    }
}

//Example 71
{
    async Task<TResult[]> WhenAllOrError<TResult>
        (params Task<TResult>[] tasks)
    {
        var killJoy = new TaskCompletionSource<TResult[]>();
        foreach (var task in tasks)
            task.ContinueWith(ant =>
            {
                if (ant.IsCanceled)
                    killJoy.TrySetCanceled();
                else if (ant.IsFaulted)
                    killJoy.TrySetException(ant.Exception.InnerExceptions);
            });
        return await await Task.WhenAny(killJoy.Task, Task.WhenAll(tasks))
            .ConfigureAwait(false);
    }
}