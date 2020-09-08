using Resturant_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant_Api.Repository
{
    public class MenuRep : IMenusRep
    {
        private readonly ResturantContext db;
        public MenuRep(ResturantContext _db)
        {
            db = _db;
        }
        public int AddDetail(Menu menu)
        {
            db.Menu.Add(menu);
            db.SaveChanges();

            return menu.Id;
        }

        public int Delete(int id)
        {
            int result = 0;

            if (db != null)
            {
                var deletePost = db.Menu.FirstOrDefault(p => p.Id == id);

                if (deletePost != null)
                {
                    db.Menu.Remove(deletePost);
                    result = db.SaveChanges();
                    return 1;
                }
                return result;
            }
            return result;
        }

    

    public Menu GetDetail(int id)
        {
        if (db != null)
        {
            return (db.Menu.Where(p => p.Id == id)).FirstOrDefault();
        }
        return null;
    }

        public List<Menu> GetDetails()
        {
            return db.Menu.ToList();
        }
    }
}
