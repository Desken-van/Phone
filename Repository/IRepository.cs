using Phone.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phone.Repository
{
    public interface IRepository
    {
        IEnumerable<PhoneNumber> GetAll();
        PhoneNumber Get(int id);
    }
}
