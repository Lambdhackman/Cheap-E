using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace My_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Product> products {  get; set; }
        public List<Market> markets { get; set; }
        List<Product> filtered_products;
        private bool _isloaded;
        public List<Product> UserList { get; set; }
        public bool already {  get; set; }

        public MainWindow()
        {
            int id =0;
            int pid = 0;
            _isloaded = false;
            products = new List<Product>();
            products.Add(new Product("tesco", "89", "coca-cola", "soda", 1, 2, true,id,pid));
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
            products.Add(new Product("carrefour", "123", "coca-cola", "soda", 1, 2.4, true, id,pid));
            id++;
            pid++;
            products[3].Hours();
            products.Add(new Product("lidl", "67", "cacao", "treat", 0.25, 1.54, false,id,pid));
            id++;
            pid++;
            products[4].Hours();
            products.Add(new Product("tesco", "89", "cacao", "treat", 0.25, 1.56, false,id,pid));
            id++;
            pid++;
            products[5].Hours();
            products.Add(new Product("carrefour", "123", "cacao", "treat", 0.25, 1.2, false,id,pid));
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
            markets = new List<Market>();
            foreach (Market product in products)
            {
                if (!markets.Contains(product)) {  markets.Add(product); }
            }
            filtered_products = new List<Product>();
            UserList=new List<Product>();
            InitializeComponent();
            MarketLabel.Visibility = Visibility.Hidden;
            MarketInformation.Visibility = Visibility.Hidden;
            ProductInfo.Visibility = Visibility.Hidden;
            BestProduct.Visibility = Visibility.Collapsed;
            BestList.Visibility = Visibility.Collapsed;
            DeleteButton.Visibility = Visibility.Hidden;
            _isloaded = true;
            already = true;
            SearchBar.Text = "";
        }
        
        
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!_isloaded)
            {
                return;
            }
            foreach (Product item in products)
            {
                if (item.Name.Contains(SearchBar.Text))
                {
                    foreach (Product var in filtered_products)
                    {
                        if (item.Name == var.Name)
                        {
                            already = true;
                        }
                    }
                    if (!already|| filtered_products==new List<Product>())
                        filtered_products.Add(item);
                    already = false;
                }
            }
            SearchCompletion.ItemsSource = filtered_products;
            filtered_products = new List<Product>();
        }


        private void SearchCompletion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SearchCompletion.SelectedItem==null)
                { return; }
            Product selected = SearchCompletion.SelectedItem as Product;
            try
            {
                SearchBar.Text = selected.Name;
                SearchCompletion.SelectedItem = null;
            }
            catch (Exception ex) { return; }
            
        }

        private void SearchCompletion_Loaded(object sender, RoutedEventArgs e)
        {
            SearchCompletion.ItemsSource = filtered_products;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            List<Product> finded_products=new List<Product>();
            foreach (Product item in products)
            {
                if (item.Name==SearchBar.Text)
                {
                    finded_products.Add(item);
                }
            }
            if (finded_products.Count == 0)
                return;
            Product best_product = finded_products[0];
            foreach (Product item in finded_products)
            {
                if (best_product.KgorLPrice > item.KgorLPrice)
                    best_product = item;
            }
            string l = "Kg";
            if (best_product.Liquid)
            {
                l = "L";
            }
            ProductInfo.Visibility = Visibility.Visible;
            BestList.Visibility = Visibility.Collapsed;
            BestProduct.Visibility = Visibility.Visible;
            ProductInfo.Text = $"{best_product.Name} {best_product.Quantity}{l}\nbest price : {best_product.Price}€\n{best_product.KgorLPrice}€/{l}";


            MarketLabel.Visibility = Visibility.Visible;
            MarketInformation.Visibility = Visibility.Visible;
            MarketInformation.Text = $"{best_product.BrandName}      {best_product.Location}\n{best_product.OpenSchedule[0]}H - {best_product.CloseSchedule[0]}H\n{best_product.OpenSchedule[1]}H - {best_product.CloseSchedule[1]}H\n{best_product.OpenSchedule[2]}H - {best_product.CloseSchedule[2]}H\n{best_product.OpenSchedule[3]}H - {best_product.CloseSchedule[3]}H\n{best_product.OpenSchedule[4]}H - {best_product.CloseSchedule[4]}H\n{best_product.OpenSchedule[5]}H - {best_product.CloseSchedule[5]}H\n{best_product.OpenSchedule[6]}H - {best_product.CloseSchedule[6]}H";
        }

        private void AddList_Click(object sender, RoutedEventArgs e)
        {
            bool added = true;
            List<Product> temp=new List<Product>();

            foreach (Product item in products)
            {
                if (item.Name == SearchBar.Text&&added)
                {
                    UserList.Add(item);
                    added=false;
                }
            }
            foreach (Product item in UserList)
            {
                temp.Add(item);
            }
            ShoppingList.ItemsSource = temp;
        }

        private void ShoppingList_Loaded(object sender, RoutedEventArgs e)
        {
            ShoppingList.ItemsSource= UserList;
        }

        private void ShoppingList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DeleteButton.Visibility=Visibility.Visible;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            List<Product> temp=new List<Product>();
            Product selected = ShoppingList.SelectedItem as Product;
            UserList.Remove(selected);
            foreach (Product item in UserList)
            {
                temp.Add(item);
            }
            ShoppingList.ItemsSource = temp;
            ShoppingList.SelectedItem = null;
            DeleteButton.Visibility=Visibility.Hidden;
        }

        private void SearchList_Click(object sender, RoutedEventArgs e)
        {
            if (UserList.Count == 0)
                return;
            var grouped = products
            .Where(p => UserList.Any(u => u.Name == p.Name))
            .GroupBy(p => p.BrandName)
            .ToList();

            List<Product>[] ListByMarket = grouped
                .Select(g => g.ToList())
                .ToArray();

            int marketplace = 0;
            double[] cost=new double[ListByMarket.Length];
            for (int i = 0;i < ListByMarket.Length;i++)
                cost[i]=TotalPrice(ListByMarket[i], UserList);
            for (int i = 0; i < cost.Length; i++)
            {
                if (cost[i] < cost[marketplace])
                    marketplace = i;
            }
            ProductInfo.Visibility = Visibility.Visible;
            BestProduct.Visibility = Visibility.Collapsed;
            BestList.Visibility = Visibility.Visible;
            ProductInfo.Text = $"best price : {cost[marketplace]}€\n";
            Product best_product = ListByMarket[marketplace][0];

            MarketLabel.Visibility = Visibility.Visible;
            MarketInformation.Visibility = Visibility.Visible;
            MarketInformation.Text = $"{best_product.BrandName}      {best_product.Location}\n{best_product.OpenSchedule[0]}H - {best_product.CloseSchedule[0]}H\n{best_product.OpenSchedule[1]}H - {best_product.CloseSchedule[1]}H\n{best_product.OpenSchedule[2]}H - {best_product.CloseSchedule[2]}H\n{best_product.OpenSchedule[3]}H - {best_product.CloseSchedule[3]}H\n{best_product.OpenSchedule[4]}H - {best_product.CloseSchedule[4]}H\n{best_product.OpenSchedule[5]}H - {best_product.CloseSchedule[5]}H\n{best_product.OpenSchedule[6]}H - {best_product.CloseSchedule[6]}H";
        }
        public double TotalPrice(List<Product> products, List<Product> UserList)
        {
            double total = 0;
            int ok = 0;
            int i = 0;
            foreach (Product product in UserList)
            {
                while (products.Count > i)
                {
                    if (product.Name == products[i].Name)
                    {
                        total += products[i].Price;
                        ok++;
                    }
                    i++;
                }
                i = 0;
            }
            if (UserList.Count!=ok)
                return 100000;
            return total;
        }
    }
}
