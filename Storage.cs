using RockFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood
{
    public class Storage
    {       
        public List<Customer> Customers { get; set; }
        public List<Seller> Sellers { get; set; }
        public List<Food> Foods { get; set; }

        public Storage()
        {
            Customers = new List<Customer>();
            Foods = new List<Food>();

            CreateNewBaseStorage();
        }

        public void CreateNewBaseStorage()
        {          
            Customers.Add(new Customer {Id = 0, Name = "Jon" });
            Customers.Add(new Customer { Id = 1, Name = "Petro" });           

            Foods.Add(new Food { Id = 0, Name = "The Best Cakes", Price = 20, Count = 100 });
            Foods.Add(new Food { Id = 1, Name = "The Cakes", Price = 30, Count = 100 });
        }

        public void StartWorking()
        {          
            while (true)
            {
                Console.Clear();
                Output("Press 1 to create new Customer");
                Output("Press 2 to choose Customer");
                Output("Press 3 to put new Food");             

                var kay = Console.ReadLine().ToString();
                switch(kay)
                {
                    case "1":
                        DialogCreateNewCustomer();
                        break;
                    case "2":
                        DialogChooseCustomer();
                        break;
                    case "3":
                        break;                  
                }
            }
        }
        private void DialogPutNewFood()
        {
            var correctInputFlag = true;
            Console.Clear();

            Output("Enter Food Name");
            var name = Console.ReadLine().ToString();

            Output("Enter Food Price");
            var text = Console.ReadLine();
            var price = new decimal();
            bool success = Decimal.TryParse(text, out price);
            if (!success)
                correctInputFlag = false;


            Output("Enter Food Count");
            text = Console.ReadLine();            
            var count = new int();
            success = Int32.TryParse(text, out count);
            if (!success)
                correctInputFlag = false;

            if (correctInputFlag)
                PutNewFood(new Food {Name = name, Price = price, Count = count });
            else
                Output("Put food Error", "Error");

        }
        private bool PutNewFood(Food food)
        {
            if (Foods is not null)
            {
                food.Id = Foods.Count();
                Foods.Add(food);
                Output("new food: " + food.Name,"Put");
                return true;
            }
            return false;
        }
        private void DialogCreateNewCustomer()
        {
            Console.Clear();
            Output("Enter Customer Name or 9 for exit");

            var text = Console.ReadLine().ToString();
            if (text != "9")
                if(!CreateNewCustomer(text))
                    Output("Customer creation Error", "Error");

        }
        private bool CreateNewCustomer(string name)
        {          
            if (Customers is not null)
            {
                var id = Customers.Count();
                Customers.Add(new Customer { Id = id, Name = name });
                Output("new Customer => " + name, "Create");
                return true;
            }
            return false;
        }
        private void DialogChooseCustomer()
        {
            Console.Clear();
            Output("List of Customer: ");
            foreach(var customer in Customers)
                Output("Id - " + customer.Id.ToString() + " Name - " + customer.Name);

            Output("Tap Customers id");

            var text = Console.ReadLine();
            var customerId = new int();

            bool success = Int32.TryParse(text, out customerId);
            if (success)
            {
                if (customerId >= 0 && customerId < Customers.Count())
                    DialogChooseProduct(customerId);
            }               
            else
                Output("Customer Choose Error", "Error");
        }
        private void DialogChooseProduct(int customerId)
        {
            Console.Clear();
            Output("List of Products: ");
            foreach (var food in Foods)
                if(food.Count> 0)
                    Output("Id - " + food.Id.ToString() + " " + food.Name + " $ - " + food.Price);

            Output("Tap Products id");

            var text = Console.ReadLine();
            var foodId = new int();

            bool success = Int32.TryParse(text, out foodId);
            if (success)
            {
                if (foodId >= 0 && foodId < Customers.Count())
                    DialogBuyProduct(customerId, foodId);
            }
            else
                Output("Product Choose Error", "Error");

        }
        private void DialogBuyProduct(int customerId,int foodId)
        {
            var customer = Customers.First(p => p.Id == customerId);
            var food = Foods.First(p => p.Id == foodId);
            Output("You bought " + food.Name + " for price $" + food.Price, customer.Name);
            TakeFood(foodId, 1);
        }      
        public void TakeFood(int foodId, int number)
        {
            var index = Foods.FindIndex(f => f.Id == foodId);
            if(index >= 0)
                Foods[index].Count -= number;
        }
        private void Output(string message, string messageAuthor = "System")
        {
            Console.WriteLine("{0}: {1}",messageAuthor, message);
            if (messageAuthor != "System")
                Console.ReadKey();
        }
    }
}
