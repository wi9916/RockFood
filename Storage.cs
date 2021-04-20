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
        public bool PutNewFood(Food food)
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
        public bool CreateNewCustomer(string name)
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
        public void TakeFood(int foodId, int number)
        {
            var index = Foods.FindIndex(f => f.Id == foodId);
            if(index >= 0)
                Foods[index].Count -= number;
        }
        public void Output(string message, string messageAuthor = "System")
        {
            Console.WriteLine("{0}: {1}",messageAuthor, message);
            if (messageAuthor != "System")
                Console.ReadKey();
        }
    }
}
