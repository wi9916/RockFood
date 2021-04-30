using RockFood.Interfaces;
using RockFood.Models;
using RockFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood
{
    public class DialogInShop: IDialogable
    {
        private readonly IStoredOperationable sameStorage;
        private readonly IResidentOperationable sameCustomers;
        public DialogInShop()
        {         
            sameStorage = new StorageOperation();
            sameCustomers = new ResidentsOperation();           
        }
        public DialogInShop(IStoredOperationable sameStorage, IResidentOperationable sameCustomers)
        {
            this.sameStorage = sameStorage;
            this.sameCustomers = sameCustomers;
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

        public void DialogPutNewFood()
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
            int count = default;
            success = Int32.TryParse(text, out count);           
            if (!success)
                correctInputFlag = false;

            if (correctInputFlag)
                sameStorage.PutNewFood(new Food { Name = name, Price = price, Count = count });
            else
                Speaker.Output("Put food Error", "Error");
        }
        public void DialogCreateNewCustomer()
        {
            Console.Clear();
            Speaker.Output("Enter Customer Name or 9 for exit");

            var text = Console.ReadLine().ToString();
            var person = new Customer {Name = text };
            if (text != "9")
                if (!sameCustomers.CreateNewCustomer(person))
                    Speaker.Output("Customer creation Error", "Error");
        }
        public void DialogChooseCustomer()
        {
            Console.Clear();
            Speaker.Output("List of Customer: ");           
            if(!sameCustomers.OutputInfoAboutCustomer())
                    Speaker.Output("Output Error", "Error");

            Speaker.Output("Tap Customers id");

            var text = Console.ReadLine();
            var customerId = new int();

            var success = Int32.TryParse(text, out customerId);
            if (success)
            {
                if (sameCustomers.OutputInfoAboutCustomer(customerId))           
                    DialogChooseProduct(customerId);
                else
                    Speaker.Output("Customer Choose Error", "Error");
            }
            else
                Speaker.Output("Customer Choose Error", "Error");
        }
        public void DialogChooseProduct(int customerId)
        {
            Console.Clear();
            Speaker.Output("List of Products: ");
            if (!sameStorage.OutputInfoAboutFood())
                Speaker.Output("Output Error", "Error");

            Speaker.Output("Tap Products id");

            var text = Console.ReadLine();
            int foodId = default;
            var success = Int32.TryParse(text, out foodId);
            if (success)
            {             
                if(!DialogBuyProduct(customerId, foodId))               
                    Speaker.Output("Product Choose Error", "Error");
            }
            else
                Speaker.Output("Product Choose Error", "Error");
        }
        public bool DialogBuyProduct(int customerId, int foodId)
        {
            if (sameCustomers.OutputInfoAboutCustomer(customerId))
                if (sameStorage.OutputInfoAboutFood(foodId))
                    if (!sameStorage.TakeFood(foodId, 1))
                    {
                        Speaker.Output("Product bought Error", "Error");
                        return false;
                    }
            return true;                     
        }
    }
}
