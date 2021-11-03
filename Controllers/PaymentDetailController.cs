using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models.DTOs.Responses;
using PaymentAPI.Data;
using PaymentAPI.Models;

namespace PaymentAPI_SqLite.Controllers
{
    [Route("api/[controller]")] // Define routing
    [ApiController] // We need to specify type controller
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]// Login user only aka JWT Auth
    public class PaymentDetail : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PaymentDetail(ApiDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _context.PaymentDetailItems.ToListAsync();
            return Ok(new GlobalResponse()
            {
                Message = new List<string>() {
                        "ResultMessage: " + "Berikut data dari tabel",
                },
                result = items,
                Success = true
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(PaymentDetailData data)
        {
            if (ModelState.IsValid)
            {
                await _context.PaymentDetailItems.AddAsync(data);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetItems), new { data.paymentDetailId }, data);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item = await _context.PaymentDetailItems.FirstOrDefaultAsync(x => x.paymentDetailId == id);

            if (item == null)
                return NotFound();

            return Ok(new GlobalResponse()
            {
                Message = new List<string>() {
                        "ResultMessage: " + "Berikut data dari id yang anda pilih",
                },
                result = item,
                Success = true
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, PaymentDetailData item)
        {
            //if (id != item.paymentDetailId)
                //return BadRequest();

            var existItem = await _context.PaymentDetailItems.FirstOrDefaultAsync(x => x.paymentDetailId == id);

            if (existItem == null)
                return NotFound();

            existItem.cardOwnerName = item.cardOwnerName;
            existItem.cardNumber = item.cardNumber;
            existItem.expirationDate = item.expirationDate;
            existItem.securityCode = item.securityCode;

            await _context.SaveChangesAsync();

            return Ok(new GlobalResponse()
            {
                Message = new List<string>() {
                        "ResultMessage: " + "Berhasil update item",
                },
                Success = true
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var existItem = await _context.PaymentDetailItems.FirstOrDefaultAsync(x => x.paymentDetailId == id);

            if (existItem == null)
                return NotFound();

            _context.PaymentDetailItems.Remove(existItem);
            await _context.SaveChangesAsync();

            return Ok(new GlobalResponse()
            {
                Message = new List<string>() {
                        "ResultMessage: " + "Berikut data id yang dihapus",
                },
                result = existItem,
                Success = true
            });
        }

    }
}