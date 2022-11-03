using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ItemTest
{
    class Program
    {
        List<Item> lstItem = new List<Item>
            {
                new Item {Id =1, Name = "M&M", Price = 2.00M },

                new Item {Id =2, Name = "Pepsi",  Price = 3.00M },

                new Item {Id =3, Name = "Water",  Price = 1.50M },

                new Item {Id =4, Name = "Lays",  Price = 2.00M },

                new Item {Id =5, Name = "Juice",  Price = 2.50M }
            };

        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Input Item Id Between 1 to 5");
            string Id = Console.ReadLine();
            var a = p.getPriceForItem(Convert.ToInt32(Id));
            Console.WriteLine("Item Price" + " = " + a.ToString("C", CultureInfo.CurrentCulture));

            Console.WriteLine("Input Your Price");
            string price = Console.ReadLine();
            price = price.Replace('$', ' ');
            if (p.isValidInput(price))
            {
                var c = p.getItemIds();
                var b = p.validatePurchage(Convert.ToInt32(Id), Convert.ToDecimal(price));
                Console.WriteLine("Item Ids = {0} , {1} , {2} , {3} , {4} ", c[0], c[1], c[2], c[3], c[4]);
                Console.ReadKey();
            }
            else
            {
                Console.ReadKey();
            }
        }

        private bool isValidInput(string price)
        {
            bool result = true;
            try
            {
                Convert.ToDecimal(price);
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine("Exception" + " = " + ex.Message.ToString());
            }

            return result;
        }

        //Validate Price
        private bool validatePurchage(int itemId, decimal Money)
        {
            bool IsValid = false;
            try
            {
                decimal price = getPriceForItem(itemId);
                if (price > Money)
                {
                    IsValid = false;
                }
                else
                {
                    IsValid = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception" + " = " + ex.Message.ToString());
            }
            return IsValid;
        }
        //Get item id for all Item
        private List<int> getItemIds()
        {
            return lstItem.Select(c => c.Id).ToList();
            // return lstItem.ToList();
        }

        //Get item price filter by Item id
        private decimal getPriceForItem(int itemId)
        {
            try
            {
                Item item = lstItem.Where(i => i.Id == itemId).FirstOrDefault();
                return item.Price;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception" + " = " + "Index outof bound. " + ex.Message.ToString());
                return 0;
            }
        }

        //Item Class
        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
    }
}
