using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplicationEFAjax.Models
{
    public class MyItemsDbcontext : DbContext
    {
        public MyItemsDbcontext() :base ("MyItemsDb")
        {

        }


        public DbSet<Person> People { get; set; }
        public DbSet<Belonging> Belongings { get; set; }

    }
}