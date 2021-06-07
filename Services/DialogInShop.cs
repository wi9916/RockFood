using RockFood.Interfaces;
using RockFood.Models;
using RockFood.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockFood.Services
{
    public class DialogInShop: IDialogable
    {
        private readonly IStoredOperationable _sameStorage;
        private readonly IResidentOperationable _sameCustomers;      
        public DialogInShop(IStoredOperationable sameStorage, IResidentOperationable sameCustomers)
        {
            _sameStorage = sameStorage;
            _sameCustomers = sameCustomers;          
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
 
            if (!Decimal.TryParse(text, out var price))
                correctInputFlag = false;

            Speaker.Output("Enter Food Count");
            text = Console.ReadLine();                    
            if (!int.TryParse(text, out var count))
                correctInputFlag = false;

            if (correctInputFlag)
                _sameStorage.AddFood(new Food { Name = name, Price = price, Count = count });
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
                if (!_sameCustomers.AddCustomer(person))
                    Speaker.Output("Customer creation Error", "Error");
        }
        public void DialogChooseCustomer()
        {
            Console.Clear();
            Speaker.Output("List of Customer: ");           
            if(!_sameCustomers.GetCustomerInfo())
                    Speaker.Output("Output Error", "Error");

            Speaker.Output("Tap Customers id");

            var text = Console.ReadLine();           
            if (int.TryParse(text, out var customerId))
            {
                if (_sameCustomers.GetCustomerInfoById(customerId))           
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
            if (!_sameStorage.GetFoodInfo())
                Speaker.Output("Output Error", "Error");

            Speaker.Output("Tap Products id");

            var text = Console.ReadLine();            
            if (int.TryParse(text, out var foodId))
            {             
                if(!DialogBuyProduct(customerId, foodId))               
                    Speaker.Output("Product Choose Error", "Error");
            }
            else
                Speaker.Output("Product Choose Error", "Error");
        }
        public bool DialogBuyProduct(int customerId, int foodId)
        {
            if (_sameCustomers.GetCustomerInfoById(customerId))
                if (_sameStorage.GetFoodInfoById(foodId))
                    if (!_sameStorage.GetFood(foodId, 1))
                    {
                        Speaker.Output("Product bought Error", "Error");
                        return false;
                    }
            return true;                     
        }
        public void ValidatorDialog()
        {          
            while(true)
            {
                Speaker.Output("Tap you phone number: ");
                var phone = Console.ReadLine();
                if (ContactInfoValidator.CheckPhone(phone))
                {
                    Speaker.Output("Phone number is correct");
                    break;
                }
                else
                    Speaker.Output("Phone number is not correct");
            }

            while (true)
            {
                Speaker.Output("Tap you address: ");
                var address = Console.ReadLine();
                if (ContactInfoValidator.CheckAddress(address))
                {
                    Speaker.Output("Address is correct");
                    break;
                }
                else
                    Speaker.Output("Address is not correct");
            }
        }
    }
}
