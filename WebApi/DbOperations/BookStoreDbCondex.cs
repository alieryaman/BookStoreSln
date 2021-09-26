using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DbOperations
{
    public class BookStoreDbCondex:DbContext
    {
        public BookStoreDbCondex(DbContextOptions<BookStoreDbCondex> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

    }
}
