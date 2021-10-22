using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PaymentAPI.Models;


namespace PaymentAPI.Data
{
    //dengan mewarisi dari IdentityDbContext pada DbContext, EntityFramework akan tahu bahwa kita menggunakan otentikasi dan itu akan menggunakan tabel default identity
    public class ApiDbContext : IdentityDbContext
    {
        public virtual DbSet<PaymentDetailData> PaymentDetailItems { get; set;}
        public virtual DbSet<RefreshToken> RefreshTokens { get; set;}

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base (options)
        {
            
        } 
    }
}