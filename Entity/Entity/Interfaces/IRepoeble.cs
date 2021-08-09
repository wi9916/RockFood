using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Interfaces
{
    public interface IRepoeble
    {       
        ICompanable GetById(int Id);
        List<Company> GetAll();
        void Add(ICompanable obj);
        void Update(ICompanable obj);
        void Delate(int Id);
    }
}
