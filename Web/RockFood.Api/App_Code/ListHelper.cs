using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using RockFood.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RockFood.Api.App_Code
{
    public static class ListHelper
    {
        public static HtmlString CreateList(this IHtmlHelper html, IEnumerable<IFoodable> foods, string nameController = null)
        {
            var result = "<tbody>";
            foreach (var food in foods)
            {
                result = $"<tr>{result}<td>{food.Name}</td>";
                result = $"{result}<td>{food.About}</td>";
                result = $"{result}<td>{food.Price}</td>";
                result = $"{result}<td>{food.Count}</td>";
                if (nameController is not null)
                {
                    result = $"{result}<td><a href=\"/{nameController}/Edit/{food.Id}\"> Edit </a> | ";
                    result = $"{result}<a href=\"/{nameController}/Details/{food.Id}\"> Details </a> | ";
                    result = $"{result}<a href=\"/{nameController}/Delete/{food.Id}\"> Delete </a></td></tr>";
                }
            }
            result = $"{result}</tbody>";
            return new HtmlString(result);
        }
    }
}

