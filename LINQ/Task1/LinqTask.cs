using System;
using System.Collections.Generic;
using System.Linq;
using Task1.DoNotChange;

namespace Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            return customers.Where(c => c.Orders.Sum(o => o.Total) > limit);
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            return customers.Select(cust => (cust, suppliers.Where(s => s.Country == cust.Country && s.City == cust.City)));
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            return customers
                .GroupJoin(
                    suppliers,
                    cust => new { cust.Country, cust.City },
                    supp => new { supp.Country, supp.City },
                    (cust, supplierGroup) => (cust, supplierGroup)
                );
        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            var filteredCustomers = customers
        .Where(c => c.Orders.Sum(o => o.Total) > limit)
        .ToList();

            return filteredCustomers;
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers
        )
        {
            var result = customers
        .Where(c => c.Orders.Any())
        .Select(c => (customer: c, dateOfEntry: c.Orders.Min(o => o.OrderDate)))
        .Where(entry => entry.customer.Orders.Any()) // Exclude customers without orders
        .ToList();

            return result;
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers
        )
        {
            return customers
                .Where(c => c.Orders.Any())
                .Select(c => (c, c.Orders.Min(o => o.OrderDate)))
                .OrderBy(t => t.Item2);
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            var filteredCustomers = customers
                .Where(c => !IsNumericPostalCode(c.PostalCode) || string.IsNullOrEmpty(c.Region) || !HasOperatorCode(c.Phone))
                .ToList();

            return filteredCustomers;
        }

        private static bool IsNumericPostalCode(string postalCode)
        {
            return !string.IsNullOrEmpty(postalCode) && postalCode.All(char.IsDigit);
        }

        private static bool HasOperatorCode(string phoneNumber)
        {
            return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.Contains("(") && phoneNumber.Contains(")");
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            return products
                .GroupBy(p => p.Category)
                .Select(group => new Linq7CategoryGroup
                {
                    Category = group.Key,
                    UnitsInStockGroup = group
                        .GroupBy(p => p.UnitsInStock)
                        .Select(unitGroup => new Linq7UnitsInStockGroup
                        {
                            UnitsInStock = unitGroup.Key,
                            Prices = unitGroup.Select(p => p.UnitPrice)
                        })
                });
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            var cheapProducts = products.Where(p => p.UnitPrice <= cheap).ToList();
            var middleProducts = products.Where(p => p.UnitPrice > cheap && p.UnitPrice <= middle).ToList();
            var expensiveProducts = products.Where(p => p.UnitPrice > middle && p.UnitPrice <= expensive).ToList();

            var result = new List<(decimal category, IEnumerable<Product> products)>
                {
                    (cheap, cheapProducts),
                    (middle, middleProducts),
                    (expensive, expensiveProducts)
                };

            return result;
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers)
        {
            var result = customers
                .GroupBy(c => c.City)
                .Select(group => new
                {
                    City = group.Key,
                    TotalIncome = group.Sum(c => c.Orders.Sum(o => o.Total)),
                    TotalIntensity = group.Sum(c => c.Orders.Length),
                    CustomerCount = group.Count()
                })
                .Select(info => (
                    city: info.City,
                    averageIncome: info.CustomerCount > 0 ? (int)Math.Round(info.TotalIncome / info.CustomerCount) : 0,
                    averageIntensity: info.CustomerCount > 0 ? info.TotalIntensity / info.CustomerCount : 0
                ))
                .ToList();

            return result;
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            return string.Join("", suppliers
                .Select(s => s.Country)
                .Distinct()
                .OrderBy(c => c.Length)
                .ThenBy(c => c)
            );
        }
    }
}