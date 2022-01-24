using System;
using System.Collections.Generic;

namespace DesignPatternPlayGround.Patterns
{
    public static class DecoratorPattern
    {
        public static void Run()
        {
            Console.WriteLine("Decorator Pattern\n-----------------");
            Repository repository = new Repository();
            CachebleRepository cachebleRepository = new CachebleRepository(repository);
            LoggingRepository loggingRepository = new LoggingRepository(cachebleRepository);
            loggingRepository.Get();
        }
    }

    public interface IRepository 
    {
        List<string> Get();
    }

    public class Repository : IRepository
    {
        private readonly List<string> _dataList;

        public Repository()
        {
            _dataList = new List<string>();
            _dataList.Add("Value1");
            _dataList.Add("Value2");
        }

        public List<string> Get()
        {
            Console.WriteLine("Data fetched");
            return _dataList;
        }
    }

    public class CachebleRepository : IRepository 
    {
        private readonly IRepository _repository;
        private readonly List<string> _cachedData;
        public CachebleRepository(IRepository repository)
        {
            _repository = repository;
            _cachedData = _repository.Get();
        }

        public List<string> Get()
        {
            Console.WriteLine("Data fetched from cache");
            return _cachedData;
        }
    }

    public class LoggingRepository : IRepository 
    {
        private readonly IRepository _repository;

        public LoggingRepository(IRepository repository)
        {
            _repository = repository;
        }

        public List<string> Get()
        {
            Console.WriteLine("Logging done before fetch data");
            return _repository.Get();
        }
    }
}
