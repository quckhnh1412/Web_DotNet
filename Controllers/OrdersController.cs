using HouseBuying.Data;
using HouseBuying.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HouseBuying.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        
        AppDBContext _context;
        private readonly ShoppingCart _shoppingCart;

        public OrdersController( ShoppingCart shoppingCart, AppDBContext context)
        {
     
            _shoppingCart = shoppingCart;
            _context = context;
         
        }
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.House).Include(n => n.User).ToListAsync();

            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }


            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _context.Houses.FindAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));

        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _context.Houses.FindAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));

        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    HouseId = item.House.Id,
                    OrderId = order.Id,
                    Price = item.House.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
                item.House.Status = "SOLD";
            }
            await _context.SaveChangesAsync();


            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }

        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllOrders()
        {
 

            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.House).Include(n => n.User).ToListAsync();


            return View(orders);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveOrder(int id)
        {


            var order = await _context.Orders
                .Include(o => o.OrderItems)  // Include OrderItems for eager loading
                .ThenInclude(oi => oi.House)
                 .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }
            // Update House status to "Available" for each associated OrderItem
            foreach (var orderItem in order.OrderItems)
            {
                orderItem.House.Status = "AVAILABLE";
                // If you have a specific status enumeration, replace "Available" with the appropriate value
            }
            // Remove associated OrderItems
            _context.OrderItems.RemoveRange(order.OrderItems);

            // Remove the Order
            _context.Orders.Remove(order);
            
            await _context.SaveChangesAsync();


            return RedirectToAction("GetAllOrders");
        }
    }
}
