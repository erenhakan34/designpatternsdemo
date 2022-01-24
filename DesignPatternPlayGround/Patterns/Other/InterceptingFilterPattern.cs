using System;
using System.Collections.Generic;

namespace DesignPatternPlayGround.Patterns.Other
{
    public static class InterceptingFilterPattern
    {
        public static void Run()
        {
            Console.WriteLine("Intercepting Filter Pattern\n---------------------------");
            FilterManager filterManager = new FilterManager(new CustomerCreationService());
            filterManager.AddFilter(new CustomerValidationFilter());
            filterManager.ExecuteFilters();
        }
    }

    public interface IService
    {
        void Execute();
    }

    public class CustomerCreationService : IService
    {
        public void Execute()
        {
            Console.WriteLine("Customer is created");
        }
    }

    public interface IFilter
    {
        void Execute();
    }

    public class CustomerValidationFilter : IFilter
    {
        public void Execute()
        {
            Console.WriteLine("Customer is validated");
        }
    }

    public class FilterChain
    {
        private readonly List<IFilter> _filters;
        private readonly IService _service;

        public FilterChain(IService service)
        {
            _filters = new();
            _service = service;
        }

        public void AddFilter(IFilter filter)
        {
            _filters.Add(filter);
        }

        public void ExecuteFilters()
        {
            _filters.ForEach(filter => filter.Execute());
            _service.Execute();
        }
    }

    public class FilterManager 
    {
        private FilterChain _filterChain;

        public FilterManager(IService service)
        {
            _filterChain = new(service);
        }

        public void AddFilter(IFilter filter)
            => _filterChain.AddFilter(filter);

        public void ExecuteFilters()
            => _filterChain.ExecuteFilters();
    }

}
