using CakeShop.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace CakeShop.Persistence
{
    public static class DbInitializer
    {
        public static void SeedDatabase(
            CakeShopDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            System.Console.WriteLine("Seeding... - Start");

            var categories = new List<Category>
            {
                new Category { Name = "Baju"},
                new Category { Name = "Celana" },
                new Category { Name = "Pakaian Dalam"}
            };

            var cakes = new List<Cake>
{
    new Cake
    {
        Id = 7,
        CategoryId = 1,
        ImageUrl = "https://babyhoki.store/cdn/shop/files/O1CN01geNADW1CfVaSHjlWg__2425500108-0-cib.jpg?v=1707530079&width=1500",
        IsCakeOfTheWeek = true,
        Name = "Baju Setelan Kemeja Kotak Kotak Celana Jeans Anak Cowok - Motif Gradation Box",
        Price = 150000.00M,
        ShortDescription = "Motif : Gradation Box",
        LongDescription = "Motif : Gradation Box    Detail size :    1 Tahun : LB 34 cm, PB 33 cm, PC 46 cm  2 Tahun : LB 35 cm, PB 35 cm, PC 49 cm  3 Tahun : LB 36 cm, PB 37 cm, PC 52 cm  4 Tahun : LB 37 cm, PB 39 cm, PC 56 cm  5 Tahun : LB 38 cm, PB 41 cm, PC 60 cm    LB = Lebar baju  PB = Panjang baju  PC = Panjang celana    *Toleransi Ukuran 1 - 2 cm"
    },
    new Cake
    {
        Id = 8,
        CategoryId = 1,
        ImageUrl = "https://images.tokopedia.net/img/cache/700/VqbcmM/2021/4/16/254c6fd3-1f8a-404d-a009-044f9fd07d41.jpg",
        IsCakeOfTheWeek = false,
        Name = "KAOS BAJU OYA KOHKOH HIGH AND LOW - Hitam, M",
        Price = 100000.00M,
        ShortDescription = "BAHAN 100% COTTON COMBED REACTIF",
        LongDescription = "> Ketebalan bahan 24s & 30s  > Serat benang lebih halus, hasil rajutan dan permukaan kaos lebih merata.  > Daya tahan menyerap keringat sangat baik.    Available Warna & Size  Putih, Hitam, Navy, Abu Misty, Merah.    Size Chart :    S : Lebar 45cm - Panjang 66cm    M : Lebar 48cm - Panjang 69cm    L : Lebar 51cm - Panjang 72cm    XL : Lebar 54cm - Panjang 75cm    XXL : Lebar 57cm - Panjang 78cm (+ 10.000)    Untuk tambahan harga XXL, silahkan tambahkan produk 'TAMBAHAN HARGA' yang sudah di sediakan di kategori produk atau chet penjual terlebih dahulu.    Toleransi ukuran 1-2 cm"
    },
    new Cake
    {
        Id = 9,
        CategoryId = 1,
        ImageUrl = "https://media.karousell.com/media/photos/products/2021/1/26/kaos_bape_a_bathing_ape_1st_ca_1611622269_ee4e6e69",
        IsCakeOfTheWeek = false,
        Name = "Terjual Kaos BAPE A Bathing Ape 1st Camo Shark Tee L",
        Price = 800000.00M,
        ShortDescription = "100% Original with plastic bag",
        LongDescription = "Kaos BAPE A Bathing Ape 1st Camo Shark Tee Black/Green L  Ukuran L"
    },
    new Cake
    {
        Id = 10,
        CategoryId = 2,
        ImageUrl = "https://images.tokopedia.net/img/cache/700/attachment/2019/8/6/15651016573108/15651016573108_7489a3fa-671b-4e55-9ef9-a7b16b04b72d.png",
        IsCakeOfTheWeek = false,
        Name = "BAPE x Adidas SB Tight Green",
        Price = 1500000.00M,
        ShortDescription = "BAPE x Adidas SB Tight Green",
        LongDescription = "Hanya tersedia 1 ukuran    Up to weist ukuran 32"
    },
    new Cake
    {
        Id = 11,
        CategoryId = 2,
        ImageUrl = "https://images.tokopedia.net/img/cache/900/product-1/2019/9/8/75657564/75657564_f38ca656-d0c1-4f0a-a937-2297cbd9b3a0_700_700",
        IsCakeOfTheWeek = false,
        Name = "CELANA PENDEK PRIA BAPE CITY CAMO SHARK SHORTS",
        Price = 1000000.00M,
        ShortDescription = "CELANA PENDEK PRIA  BAPE CITY CAMO SHARK SHORTS",
        LongDescription = "CELANA PENDEK PRIA  BAPE CITY CAMO SHARK SHORTS"
    },
    new Cake
    {
        Id = 12,
        CategoryId = 2,
        ImageUrl = "https://images.tokopedia.net/img/cache/700/VqbcmM/2021/12/20/0da58ea5-0ff7-4b37-8f6c-a4b7a1873df7.jpg",
        IsCakeOfTheWeek = false,
        Name = "CELANA PANJANG CHINO POLOS CASUAL PRIA",
        Price = 200000.00M,
        ShortDescription = "READY STOCK! .. CELANA PANJANG PRIA CHINO",
        LongDescription = "Bahan : Cotton  Bahan Adem, nyaman dipakai berlama-lama, cocok untuk semua kalangan dan dipakai sehari - hari.    Size: 27-38  Variasi Warna : Hitam,abu-abu,mocca,cream    JAM PENGIRIMAN :  SENIN - JUM'AT JAM 07:00 - 09:00 MALAM  SABTU-MINGGU JAM 06:00 - 08:00 MALAM    .  .  .KELEBIHAN Belanja di LAPAK KAMI:    - Kesesuaian warna 90%  - Jahitan Kuat Dan Rapi  - Bahan Berkualitas  - Barang selalu Up to Date dan Stylish  25 - 26 = ( 70 - 72 )cm  27 - 28 = ( 74 - 76 )cm  29 - 30 = ( 78 - 80 )cm  31 - 32 = ( 82 - 84 )cm  33 - 34 = ( 86 - 88 )cm  35 - 36 = ( 89 - 90 )cm  37 - 38 = ( 92 - 94 )cm"
    },
    new Cake
    {
        Id = 13,
        CategoryId = 3,
        ImageUrl = "https://img2.pngdownload.id/20180403/dvq/avhrb0md9.webp",
        IsCakeOfTheWeek = false,
        Name = "PAKAIAN DALAM 1",
        Price = 50000.00M,
        ShortDescription = "PAKAIAN DALAM",
        LongDescription = "PAKAIAN DALAM 111"
    },
    new Cake
    {
        Id = 14,
        CategoryId = 3,
        ImageUrl = "https://img2.pngdownload.id/20180403/dvq/avhrb0md9.webp",
        IsCakeOfTheWeek = false,
        Name = "PAKAIAN DALAM 2",
        Price = 50000.00M,
        ShortDescription = "PAKAIAN DALAM 2",
        LongDescription = "PAKAIAN DALAM"
    },
    new Cake
    {
        Id = 15,
        CategoryId = 3,
        ImageUrl = "https://img2.pngdownload.id/20180403/dvq/avhrb0md9.webp",
        IsCakeOfTheWeek = false,
        Name = "PAKAIAN DALAM 3",
        Price = 50000.00M,
        ShortDescription = "PAKAIAN DALAM 3",
        LongDescription = "PAKAIAN DALAM"
    }
};

            if (!context.Categories.Any() && !context.Cakes.Any())
            {
                context.Categories.AddRange(categories);
                context.Cakes.AddRange(cakes);
                context.SaveChanges();
            }


            IdentityUser usr = null;
            string userEmail = configuration["Admin:Email"] ?? "admin@admin.com";
            string userName = configuration["Admin:Username"] ?? "admin";
            string password = configuration["Admin:Password"] ?? "Passw@rd!123";

            if (!context.Users.Any())
            {
                usr = new IdentityUser
                {
                    Email = userEmail,
                    UserName = userName
                };
                userManager.CreateAsync(usr, password);
            }

            if (!context.UserRoles.Any())
            {
                roleManager.CreateAsync(new IdentityRole("Admin"));

            }
            if (usr == null)
            {
                usr = userManager.FindByEmailAsync(userEmail).Result;
            }
            if (!userManager.IsInRoleAsync(usr, "Admin").Result)
            {
                userManager.AddToRoleAsync(usr, "Admin");
            }

            context.SaveChanges();

            System.Console.WriteLine("Seeding... - End");
        }

    }
}