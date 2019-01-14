using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Demo
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void First()
        {
            using (var context = new Context())
            {
                var list = context.Orders.ToList();
                using (var scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    context.BulkMerge(new List<Product> {new Product {ProductId = 1, Name = "xxx", Size=24}}, options =>
                        {
                            options.AutoMapIdentityExpression = x => x.Name;
                        });

                    throw new Exception();

                    scope.Complete();
                }
            }
        }

        [TestMethod]
        public void Second()
        {
        }
    }
}
