using CakeShop.Core.Dto;
using CakeShop.Core.Models;
using CakeShop.Core.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShop.Persistence
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CakeShopDbContext _context;
        private readonly IShoppingCartService _shoppingCartService;

        public OrderRepository(
            CakeShopDbContext context,
            IShoppingCartService shoppingCartService)
        {
            _context = context;
            _shoppingCartService = shoppingCartService;
        }

        public async Task CreateOrderAsync(Order order)
        {
            order.OrderPlacedTime = DateTime.Now;
            order.Status = 0;
            await _context.Orders.AddAsync(order);

            var shoppingCartItems = await _shoppingCartService.GetShoppingCartItemsAsync();
            order.OrderTotal = (await _shoppingCartService.GetCartCountAndTotalAmmountAsync()).TotalAmmount;
            await _context.OrderDetails.AddRangeAsync(shoppingCartItems.Select(e => new OrderDetail
            {
                Qty = e.Qty,
                CakeName = e.Cake.Name,
                OrderId = order.Id,
                Price = e.Cake.Price
            }));

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MyOrderViewModel>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .Include(e => e.OrderDetails)
                .Select(e => new MyOrderViewModel
                {
                    OrderPlacedTime = e.OrderPlacedTime,
                    OrderTotal = e.OrderTotal,
                    OrderPlaceDetails = new OrderDto
                    {
                        AddressLine1 = e.AddressLine1,
                        AddressLine2 = e.AddressLine2,
                        City = e.City,
                        Country = e.Country,
                        Email = e.Email,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        PhoneNumber = e.PhoneNumber,
                        State = e.State,
                        ZipCode = e.ZipCode,
                        Id = e.Id,
                        Status = e.Status
                    },
                    CakeOrderInfos = e.OrderDetails.Select(o => new MyCakeOrderInfo
                    {
                        Name = o.CakeName,
                        Price = o.Price,
                        Qty = o.Qty
                    })
                })
                .ToListAsync();

        }
        public async Task<bool> UpdateStatusTransactionAsync(int id, int status)
        {
            var item = await _context.Orders.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            item.Status = status;

            // Ensure the entity is tracked
            _context.Entry(item).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<MyOrderViewModel>> GetAllOrdersAsync(string userId)
        {
            return await _context.Orders
                .Where(e => e.UserId == userId)
                .Include(e => e.OrderDetails)
                .Select(e => new MyOrderViewModel
                {
                    OrderPlacedTime = e.OrderPlacedTime,
                    OrderTotal = e.OrderTotal,
                    OrderPlaceDetails = new OrderDto
                    {
                        AddressLine1 = e.AddressLine1,
                        AddressLine2 = e.AddressLine2,
                        City = e.City,
                        Country = e.Country,
                        Email = e.Email,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        PhoneNumber = e.PhoneNumber,
                        State = e.State,
                        ZipCode = e.ZipCode,
                        Id = e.Id,
                        Status = e.Status
                    },
                    CakeOrderInfos = e.OrderDetails.Select(o => new MyCakeOrderInfo
                    {
                        Name = o.CakeName,
                        Price = o.Price,
                        Qty = o.Qty
                    })
                })
                .ToListAsync();
        }
    }
}
