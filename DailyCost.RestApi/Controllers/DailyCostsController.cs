using DailyCost.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DailyCost.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyCostsController : ControllerBase
    {
        private readonly AppDbContext _db=new AppDbContext();
        [HttpGet]
        public IActionResult Get()
        {
            var list = _db.TblDailyCosts.ToList();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item=_db.TblDailyCosts.FirstOrDefault(x=>x.CostId==id);
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post(TblDailyCost cost)
        {
            cost.TotalPrice = cost.Price * cost.Qty;
            _db.TblDailyCosts.Add(cost);
            _db.SaveChanges();
            return Ok(cost);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,TblDailyCost cost)
        {
            var item = _db.TblDailyCosts.FirstOrDefault(x => x.CostId == id);
           if(item is null)
            {
                return NotFound();  
            }
           item.Date = DateTime.Now;
            item.Thing=cost.Thing;
            item.Qty=cost.Qty;
            item.Price=cost.Price;
            item.TotalPrice=cost.Price*cost.Qty;
            _db.SaveChanges();
            return Ok(item);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id,TblDailyCost cost)
        {
            var item=_db.TblDailyCosts.AsNoTracking().FirstOrDefault( x => x.CostId==id);
            if(item is null)
            {
                return NotFound();
            }
            item.Date = DateTime.Now;
            if (!string.IsNullOrEmpty(cost.Thing))
            {
                item.Thing = cost.Thing;
            }
            if (cost.Qty >0)
            {
                item.Qty = cost.Qty;
            }
            if(cost.Price >0)
            {
                item.Price = cost.Price;
            }
            item.TotalPrice = item.Price*item.Qty;
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return Ok(item);
        }

    }
}
