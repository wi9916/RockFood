using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood
{
    public class Shop
    {
        public Storage storage { get; set; }
        
        public void DialogStartWorking()
        {
            while (true)
            {
                Console.Clear();
                Speaker.Output("Press 1 to create new Customer");
                Speaker.Output("Press 2 to choose Customer");
                Speaker.Output("Press 3 to put new Food");

                var key = Console.ReadLine().ToString();
                switch (key)
                {
                    case "1":
                        DialogCreateNewCustomer();
                        break;
                    case "2":
                        DialogChooseCustomer();
                        break;
                    case "3":
                        DialogPutNewFood();
                        break;
                }
            }
        }

        private void DialogPutNewFood()
        {
            var correctInputFlag = true;
            Console.Clear();

            Speaker.Output("Enter Food Name");
            var name = Console.ReadLine().ToString();

            Speaker.Output("Enter Food Price");
            var text = Console.ReadLine();
            decimal price = default;
            var success = Decimal.TryParse(text, out price);
            if (!success)
                correctInputFlag = false;

            Speaker.Output("Enter Food Count");
            text = Console.ReadLine();
            var count = new int();
            success = Int32.TryParse(text, out count);
            if (!success)
                correctInputFlag = false;

            if (correctInputFlag)
                storage.PutNewFood(new Food { Name = name, Price = price, Count = count });
            else
                Speaker.Output("Put food Error", "Error");

        }
        private void DialogCreateNewCustomer()
        {
            Console.Clear();
            Speaker.Output("Enter Customer Name or 9 for exit");

            var text = Console.ReadLine().ToString();
            if (text != "9")
                if (!storage.CreateNewCustomer(text))
                    Speaker.Output("Customer creation Error", "Error");
        }
        private void DialogChooseCustomer()
        {
            Console.Clear();
            Speaker.Output("List of Customer: ");
            foreach (var customer in storage.Customers)
                Speaker.Output("Id - " + customer.Id.ToString() + " Name - " + customer.Name);

            Speaker.Output("Tap Customers id");

            var text = Console.ReadLine();
            var customerId = new int();

            bool success = Int32.TryParse(text, out customerId);
            if (success)
            {
                if (customerId >= 0 && customerId < storage.Customers.Count())
                    DialogChooseProduct(customerId);
            }
            else
                Speaker.Output("Customer Choose Error", "Error");
        }       
        private void DialogChooseProduct(int customerId)
        {
            Console.Clear();
            Speaker.Output("List of Products: ");
            foreach (var food in storage.Foods)
                if (food.Count > 0)
                    Speaker.Output("Id - " + food.Id.ToString() + " " + food.Name + " $ - " + food.Price);

            Speaker.Output("Tap Products id");

            var text = Console.ReadLine();
            var foodId = new int();

            bool success = Int32.TryParse(text, out foodId);
            if (success)
            {
                if (foodId >= 0 && foodId < storage.Customers.Count())
                    DialogBuyProduct(customerId, foodId);
            }
            else
                Speaker.Output("Product Choose Error", "Error");
        }
        private void DialogBuyProduct(int customerId, int foodId)
        {
            var customer = storage.Customers.First(p => p.Id == customerId);
            var food = storage.Foods.First(p => p.Id == foodId);
            Speaker.Output("You bought " + food.Name + " for price $" + food.Price, customer.Name);
            storage.TakeFood(foodId, 1);
        }
    }
}
