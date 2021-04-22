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
            food.Id = Foods.Count();
            Foods.Add(food);
            Speaker.Output("new food: " + food.Name, "Put");
            return true;
        }
        public bool CreateNewCustomer(string name)
        {          
            if (Customers is not null)
            {
                var id = Customers.Count();
                Customers.Add(new Customer { Id = id, Name = name });
                Speaker.Output("new Customer => " + name, "Create");
                return true;
            }
            return false;
        }              
        public bool TakeFood(int foodId, int number)
        {
            var index = Foods.FindIndex(f => f.Id == foodId);
            if (index >= 0)
            {
                Foods[index].Count -= number;
                Speaker.Output("You bought " + Foods[index].Name + " for price $" + Foods[index].Price, "Buy");
                return true;
            }
            return false;
        }   
        public bool InfoAboutFoodOutput(int foodId)
        {
            var index = Foods.FindIndex(f => f.Id == foodId);
            if (index >= 0)
            {
                Speaker.Output("Id - " + Foods[index].Id.ToString() + " " + Foods[index].Name + "Count - " 
                    + Foods[index].Count.ToString() + " $ - " + Foods[index].Price);
                return true;
            }
            return false;           
        }
        public bool InfoAboutCustomerOutput(int customerId)
        {
            var index = Customers.FindIndex(f => f.Id == customerId);
            if (index >= 0)
            {
                Speaker.Output("Id - " + Customers[index].Id.ToString() + " Name - " + Customers[index].Name);
                return true;
            }
            return false;
        }
    }
}
