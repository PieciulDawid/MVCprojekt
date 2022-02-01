using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCprojekt.Models
{
    public class HomeIndexViewModel
    {
        private ApplicationDbContext DbContext = new ApplicationDbContext();
        public ICollection<ProductModel> ListOfProducts { get; set; }
        public int Counter { get; set; }

        public HomeIndexViewModel CreateModel()
        {

            var counter = DbContext.CounterModels.AsQueryable().First();

            if (counter == null)
            {
                counter = DbContext.CounterModels.Create();
                counter.Counter++;
                DbContext.CounterModels.Add(counter);
            }
            else
            {
                counter.Counter++;
            }
            
            DbContext.SaveChanges();



            return new HomeIndexViewModel
            {
                Counter = counter.Counter,
                ListOfProducts = DbContext.ProductModels.ToList()
        };
        }

    }
}