using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag14.EntityFramework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var context = new NorthwindContext()) {
                var highProductPricesQuery = from product in context.Products
                                             where product.UnitPrice > 100M
                                             select product;
                foreach (var product in highProductPricesQuery)
                {
                    Console.WriteLine(string.Format("Name: {0}\tPrice: {1}", product.ProductName, Math.Round(product.UnitPrice ?? 0, 2)));
                }
                Console.ReadKey();
            }
        }
    }
}
