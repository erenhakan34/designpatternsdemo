using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternPlayGround.Patterns
{
    public static class ObserverPattern
    {
        public static void Run()
        {
            Console.WriteLine("Observer Pattern\n-----------------");

            Console.WriteLine("Product 1\n");

            Product product = ProductDataSource.Instance.FirstOrDefault();
            product.AddObserver(new StockObserver());
            product.AddObserver(new PaymentObserver());
            product.Buy(2);

            Console.WriteLine("\nProduct 2\n");

            Product product2 = ProductDataSource.Instance.LastOrDefault();
            product2.AddObserver(new StockObserver());
            product2.AddObserver(new PaymentObserver());
            product2.Buy(5);
        }
    }

    public interface IProductObserver
    {
        void Update(int productId, int amount);
    }

    public class StockObserver : IProductObserver
    {
        public void Update(int productId, int amount)
        {
            Product product = ProductDataSource.Instance.FirstOrDefault(p => p.Id == productId);
            product.Amount = product.Amount - amount;

            Console.WriteLine($"Stock güncellendi. Ürün = { product.Name } için stokta kalan miktar = {  product.Amount }");
        }
    }

    public class PaymentObserver : IProductObserver
    {
        public void Update(int productId, int amount)
        {
            Product product = ProductDataSource.Instance.Where(p => p.Id == productId).FirstOrDefault();

            Console.WriteLine($"Stock güncellendi. Ürün = { product.Name } için {product.Price} TL ödeme alındı");
        }
    }


    public class Product
    {
        private List<IProductObserver> ProductObservers;

        public Product()
        {
            ProductObservers = new List<IProductObserver>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public void Buy(int buyAmount) 
        {
            ProductObservers.ForEach(p => p.Update(Id, buyAmount));
        }

        public void AddObserver(IProductObserver productObserver)
        {
            ProductObservers.Add(productObserver);
        }
    }


    public class ProductDataSource : List<Product>
    {
        private static ProductDataSource instance;

        public static ProductDataSource Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductDataSource();
                }

                return instance;
            }
        }


        private ProductDataSource()
        {
            Add(new Product() { Id = 1, Name = "Pen", Amount = 5, Price = 10 });
            Add(new Product() { Id = 2, Name = "Book", Amount = 7, Price = 20 });
            Add(new Product() { Id = 3, Name = "Eraser", Amount = 2, Price = 30 });
            Add(new Product() { Id = 4, Name = "Paper", Amount = 9, Price = 40 });
        }
    }

}
