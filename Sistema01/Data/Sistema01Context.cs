using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sistema01.Models;

namespace Sistema01.Data
{
    public class Sistema01Context : DbContext
    {
        public Sistema01Context(DbContextOptions<Sistema01Context> options)
        : base(options)
        {}
        
        
    }
}