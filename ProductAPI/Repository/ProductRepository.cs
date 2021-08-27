using Microsoft.EntityFrameworkCore;
using ProductAPI.Context;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            this._context = context;
        }

        public List<ZeroRemaingDaysProduct> DayIncrementer()
        {
            var output = new List<ZeroRemaingDaysProduct>();
            var temp = new ZeroRemaingDaysProduct();
            var products = new List<Product>();

            try 
            {
                var productEntity =  _context.Products.ToList();
                foreach (var product in productEntity)
                {
                    product.TodaysDate = product.TodaysDate.AddDays(1);

                    if (product.RemainingDays == 0 || product.RemainingDays<0)
                    {
                        product.RemainingDays = 0;
                       
                    }

                    if (product.RemainingDays != 0)
                    {
                        product.RemainingDays = product.RemainingDays - 1;
                        products.Add(product);
                        _context.Entry(product).State = EntityState.Modified;
                        _context.SaveChanges();
                    }
                    //_context.Products.Add(product);
                    //_context.SaveChanges();
                }

                //_context.Products.AddRange(products);
                // _context.SaveChanges();

                productEntity =  _context.Products.ToList();


                foreach (var product in productEntity)
                {
                    //var remainingDays = product.TodaysDate.Subtract(product.CreatedDate);

                    //product.RemainingDays = remainingDays.Days;

                    if (product.RemainingDays == 0 && !product.IsSold)
                    {
                        temp.ProdId = product.Id;
                        temp.ProductName = product.ProductName;
                        output.Add(temp);

                        //var query = _context.Products.Where(x => x.Id == product.Id).FirstOrDefault();
                        //query.IsSold = true;
                        product.IsSold = true;

                        _context.Entry(product).State = EntityState.Modified;
                         _context.SaveChanges();
                    }
                }

            }
            catch (Exception e)
            {
               var x= e.Message;
                return null;
            }
           


            return output;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        //public async Task<List<Product>> ResettingDayCounter()
        //{
        //    //reset todaysdate fielt to datetime.now
        //    throw new NotImplementedException();
        //}
    }
}
