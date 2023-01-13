using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restApi2.model;

namespace restApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ItemDbContext _context;
        public OrderController(ItemDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("GetAllOrder")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrder()
        {
            if (_context.items == null)
            {
                return NotFound();
            }
            //var item = _restDbContext.Item.ToListAsync();

            return await _context.order.ToListAsync();
        }

        [HttpPost]
        [Route("AddOrder")]
        public async Task<ActionResult<Order>> AddOrder(Order order)
        {


            _context.order.Add(order);

            // _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT MyDB.Users ON;");
            await _context.SaveChangesAsync();

            return Ok(order);
        }

        [HttpGet]
        [Route("{OrderID:int}")]
        public async Task<IActionResult> GetOrder([FromRoute] int OrderID)
        {
            var order = await _context.order.FirstOrDefaultAsync(x => x.OrderID == OrderID);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPut]
        [Route("{OrderID:int}")]
        public async Task<IActionResult> UpdateItem([FromRoute] int OrderID, Order updateOrderRequest)
        {
            var order = await _context.order.FindAsync(OrderID);
            if (order == null)
            {
                return NotFound();
            }
            order.CustomerID = updateOrderRequest.CustomerID;
            order.OrderNo = updateOrderRequest.OrderNo;
            order.GTotal = updateOrderRequest.GTotal;
           // order.CustomerID = updateOrderRequest.CustomerID;

            await _context.SaveChangesAsync();

            return Ok(order);
        }

        [HttpDelete]
        [Route("{OrderID:int}")]
        public async Task<IActionResult> DeleteItem([FromBody] int OrderID)
        {
            var orders = await _context.order.FindAsync(OrderID);

            if (orders == null)
            {
                return NotFound();
            }
            _context.order.Remove(orders);
            await _context.SaveChangesAsync();

            return Ok(orders);

        }
    }
}
