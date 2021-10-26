using Basket.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<Cart> GetBasket(string UserName);
        Task<Cart> UpdateBasket(Cart basket);
        Task DeleteBasket(string UserName);
    }
}
