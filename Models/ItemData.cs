using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PaymentAPI.Models
{
    public class PaymentDetailData
    {
        [Key]
        public int paymentDetailId { get; set; }
        public string cardOwnerName { get; set; }
        public string cardNumber { get; set; }
        public string expirationDate { get; set; }
        public string securityCode { get; set; }
    }
}