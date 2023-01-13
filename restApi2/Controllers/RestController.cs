using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restApi2.model;

namespace restApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestController : ControllerBase
    {

        private readonly ItemDbContext _context;


        public RestController(ItemDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("GetItem")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItem()
        {
            if (_context.items == null)
            {
                return NotFound();
            }
            //var item = _restDbContext.Item.ToListAsync();

            return await _context.items.ToListAsync();
        }


        [HttpPost]
        [Route("AddItem")]
        public async Task<ActionResult<Item>> AddItem( Item item)
        {

            
            _context.items.Add(item);

           // _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT MyDB.Users ON;");
            await _context.SaveChangesAsync();

            return Ok(item);
        }

       [HttpGet]
        [Route("{ItemID:int}")]
        public async Task<IActionResult> GetItems([FromRoute] int ItemID)
        {
            var item= await _context.items.FirstOrDefaultAsync(x => x.ItemID == ItemID);
            if(item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPut]
        [Route("{ItemID:int}")]
        public async Task<IActionResult> UpdateItem ([FromRoute] int ItemID ,Item updateItemRequest)
        {
           var item=await _context.items.FindAsync(ItemID);
            if (item == null)
            {
                return NotFound();
            }
            item.Name = updateItemRequest.Name;
            item.Price = updateItemRequest.Price;

          await  _context.SaveChangesAsync();

            return Ok(item);
        }
        [HttpDelete]
        [Route("{ItemID:int}")]
        public async Task<IActionResult> DeleteItem([FromBody] int ItemId)
        {
            var item =await _context.items.FindAsync(ItemId);

            if(item == null)
            {
                return NotFound();
            }
            _context.items.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(item);

        }

    }
}
/*      [HttpGet]
       public async Task<ActionResult<IEnumerable<Item>>> GetAllItem(Guid ItemID, ActionResult<IEnumerable<Item>> item)
       {
           if (_context.items == null)
           {
               return NotFound();
           }
           var items = await _context.items.FindAsync(ItemID);
                   if(items == null)
                   {
                return NotFound();
                   }
                   return items;
       }*/