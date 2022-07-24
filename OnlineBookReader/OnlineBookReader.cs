namespace OnlineBookReader;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OnlineBookReaderContext : DbContext
{
    public DbSet<Books> Books { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<BookPages> BookPages { get; set; }
    public DbSet<UserBooks> UserBooks { get; set; }
    public DbSet<LoginInfo> LoginInfo { get; set; }


    public OnlineBookReaderContext()
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:muratturkoglu.database.windows.net,1433;Initial Catalog=OnlineBookReader;Persist Security Info=False;User ID=CloudSA9f14cfae;Password=Ramazan1953;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }

}

public class BookPages
{
    public int BookID { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BookPageID { get; set; }

    public int PageNumber { get; set; }

    public string? Content { get; set; }

}

public class Books
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BookID { get; set; }

    public string? Name { get; set; }

    public string? Author { get; set; }

    public string? Publisher { get; set; }

    public decimal Price { get; set; }

    [ForeignKey("BookID")]
    public ICollection<BookPages> BookPages { get; set; }
}

public class UserBooks
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserBookID { get; set; }

    public int BookID { get; set; }
    [ForeignKey("BookID")]
    public Books Book { get; set; }
    public int UserID { get; set; }

}

public class Users
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserID { get; set; }

    public string? Username { get; set; }

    [ForeignKey("UserID")]
    public ICollection<UserBooks> UserBooks { get; set; }
}

public class LoginInfo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LoginInfoID { get; set; }

    public int UserID { get; set; }
    [ForeignKey("UserID")]
    public Users User { get; set; }
}