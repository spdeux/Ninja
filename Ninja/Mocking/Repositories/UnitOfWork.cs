using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ninja.Mocking.Repositories
{
    public class UnitOfWork
    {
        public IQueryable<Booking> Query<T>()
        {
            return new List<Booking>().AsQueryable();
        }
    }
}
