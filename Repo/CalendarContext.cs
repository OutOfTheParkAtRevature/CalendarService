using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CalendarContext : DbContext
    {
        public CalendarContext() { }

        public CalendarContext(DbContextOptions<CalendarContext> options) : base(options) { }
    }
}
