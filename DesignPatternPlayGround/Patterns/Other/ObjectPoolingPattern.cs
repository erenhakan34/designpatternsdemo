using System;
using System.Collections.Concurrent;

namespace DesignPatternPlayGround.Patterns
{
    public static class ObjectPoolingPattern
    {
        public static void Run()
        {
            Console.WriteLine("Object Pooling Pattern\n-------------------------\n");

            ObjectPool<DbContext> dbContextPool = new ObjectPool<DbContext>(() => new DbContext() { ConnectionId = 10 });
            DbContext dbContext = dbContextPool.Acquire();
            Console.WriteLine(dbContext);
            dbContextPool.Release(dbContext);

            DbContext dbContext2 = dbContextPool.Acquire();
            Console.WriteLine(dbContext2);
            dbContextPool.Release(dbContext2);

            Console.WriteLine($"Reference Equals > {ReferenceEquals(dbContext, dbContext2)}");
        }
    }

    public class DbContext
    {
        public int ConnectionId { get; set; }

        public override string ToString()
        {
            return $"Connection Id = { ConnectionId}";
        }
    }

    public class ObjectPool<T> where T : class
    {
        private readonly ConcurrentBag<T> _objects;
        private readonly Func<T> _objectGenerator;

        public ObjectPool(Func<T> objectGenerator)
        {
            _objectGenerator = objectGenerator ?? throw new ArgumentNullException(nameof(objectGenerator));
            _objects = new ConcurrentBag<T>();
        }

        public T Acquire()
        {
            return _objects.TryTake(out T item) ? item : _objectGenerator();
        }

        public void Release(T item)
        {
            _objects.Add(item);
        }
    }
}
