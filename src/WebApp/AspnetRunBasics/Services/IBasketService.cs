﻿using AspnetRunBasics.Models;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public interface IBasketService
    {
        Task<BasketModel> GetBasket(string userName);
        Task<BasketModel> UpdateBasket(BasketModel model);
        Task DeleteBasket(string userName);
        Task CheckoutBasket(BasketModel model);
    }
}
