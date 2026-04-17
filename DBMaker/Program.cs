using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_Project;

namespace DBMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MarketData db = new MarketData();

            using (db)
            {
                int id = 0;
                int pid = 0;
                List<Product> products = new List<Product>();
                products.Add(new Product("tesco", "89", "coca-cola", "soda", 1, 2, true, id, pid));
                id++;
                pid++;
                products[0].Hours();
                products.Add(new Product("aldi", "45", "coca-cola", "soda", 1, 2.6, true, id, pid));
                id++;
                pid++;
                products[1].Hours();
                products.Add(new Product("lidl", "67", "coca-cola", "soda", 1, 3, true, id, pid));
                id++;
                pid++;
                products[2].Hours();
                products.Add(new Product("carrefour", "123", "coca-cola", "soda", 1, 2.4, true, id, pid));
                id++;
                pid++;
                products[3].Hours();
                products.Add(new Product("lidl", "67", "cacao", "treat", 0.25, 1.54, false, id, pid));
                id++;
                pid++;
                products[4].Hours();
                products.Add(new Product("tesco", "89", "cacao", "treat", 0.25, 1.56, false, id, pid));
                id++;
                pid++;
                products[5].Hours();
                products.Add(new Product("carrefour", "123", "cacao", "treat", 0.25, 1.2, false, id, pid));
                id++;
                pid++;
                products[6].Hours();
                products.Add(new Product("carrefour", "123", "olive", "fruit", 0.15, 2.36, false, id, pid));
                id++;
                pid++;
                products[7].Hours();
                products.Add(new Product("aldi", "45", "olive", "fruit", 0.15, 2.83, false, id, pid));
                id++;
                pid++;
                products[8].Hours();
                products.Add(new Product("lidl", "67", "olive", "fruit", 0.15, 2.1, false, id, pid));
                id++;
                pid++;
                products[9].Hours();
                products.Add(new Product("tesco", "89", "olive", "fruit", 0.15, 2.76, false, id, pid));
                id++;
                pid++;
                products[10].Hours();
                List<Market> markets = new List<Market>();
                foreach (Market product in products)
                {
                    if (!markets.Contains(product)) { markets.Add(product); }
                }
                foreach (Market market in markets)
                {
                    db.Markets.Add(market);
                }
                foreach(Product product1 in products)
                {
                    db.Products.Add(product1);
                }

            }
        }
    }
}
