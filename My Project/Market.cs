using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace My_Project
{
    public abstract class Market
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Location { get; set; }
        public int[] OpenSchedule { get; set; }
        public int[] CloseSchedule { get; set; }

        public Market(string brandname, string location, int id) 
        { 
            Id=id;
            BrandName = brandname;
            Location = location;
            OpenSchedule = new int[7];
            CloseSchedule = new int[7];
        }
        public void Hours()
        {
            for (int i = 0; i < OpenSchedule.Length - 1; i++)
            {
                OpenSchedule[i] = i;
                CloseSchedule[i] = 12 + i;
            }
        }
    }
    public class Product : Market 
    { 
        public int PId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public bool Liquid { get; set; }
        public double KgorLPrice { get; set; }

        public Product(string brandname, string location, string name, string type, double quantity, double price, bool liquid,int id, int pid) : base(brandname, location,id)
        {
            PId = pid;
            Name = name;
            Type = type;
            Quantity = quantity;
            Price = price;
            Liquid = liquid;
            KgorLPrice = Price/Quantity;
        }
        public override string ToString()
        {
            return Name;
        }
    }
    public class MarketData : DbContext 
    {
        public MarketData() : base("MyDataBase") {}
        public DbSet<Market> Markets { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
