using Resturant_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant_Api.Repository
{
    public interface IMenusRep
    {
        public List<Menu> GetDetails();
        public Menu GetDetail(int id);
        public int AddDetail(Menu menu);
       
        public int Delete(int id);
    }
}
