using CQRSDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqSpecs;

namespace CQRSDemo.Repository.Extensions
{
    public static class Specification
    {
        public static AdHocSpecification<User> HasId(long id) => new(e => e.UserId == id);

        public static AdHocSpecification<User> IsActive()
        {
            return new AdHocSpecification<User>(e => (bool)e.Status);
        }


    }

}
