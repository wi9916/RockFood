using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood
{
    public class DialogInShop
    {
        public Storage SameStorage { get; set; }
        public DialogInShop()
        {
            SameStorage = new Storage();
        }
        
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
                SameStorage.PutNewFood(new Food { Name = name, Price = price, Count = count });
            else
                Speaker.Output("Put food Error", "Error");

        }
        private void DialogCreateNewCustomer()
        {
            Console.Clear();
            Speaker.Output("Enter Customer Name or 9 for exit");

            var text = Console.ReadLine().ToString();
            if (text != "9")
                if (!SameStorage.CreateNewCustomer(text))
                    Speaker.Output("Customer creation Error", "Error");
        }
        private void DialogChooseCustomer()
        {
            Console.Clear();
            Speaker.Output("List of Customer: ");
            foreach (var customer in SameStorage.Customers)
                SameStorage.InfoAboutCustomerOutput(customer.Id);

            Speaker.Output("Tap Customers id");

            var text = Console.ReadLine();
            var customerId = new int();

            bool success = Int32.TryParse(text, out customerId);
            if (success)
            {
                if (SameStorage.Customers.Exists(x => x.Id == customerId))           
                    DialogChooseProduct(customerId);
                else
                    Speaker.Output("Customer Choose Error", "Error");
            }
            else
                Speaker.Output("Customer Choose Error", "Error");
        }       
        private void DialogChooseProduct(int customerId)
        {
            Console.Clear();
            Speaker.Output("List of Products: ");
            foreach (var food in SameStorage.Foods)
                if (food.Count > 0)
                    SameStorage.InfoAboutFoodOutput(food.Id);                 

            Speaker.Output("Tap Products id");

            var text = Console.ReadLine();
            var foodId = new int();

            bool success = Int32.TryParse(text, out foodId);
            if (success)
            {
                
                if(SameStorage.Foods.Exists(x => x.Id == foodId)) 
                    DialogBuyProduct(customerId, foodId);
                else
                    Speaker.Output("Product Choose Error", "Error");
            }
            else
                Speaker.Output("Product Choose Error", "Error");
        }
        private void DialogBuyProduct(int customerId, int foodId)
        {
            var customer = SameStorage.Customers.First(p => p.Id == customerId);
            var food = SameStorage.Foods.First(p => p.Id == foodId);
            
            if(!SameStorage.TakeFood(foodId, 1))
                Speaker.Output("Product bought Error", "Error");
        }
    }
}
