using MFS.Domain.MerchantAggregate;
using MFS.Domain.TransactionAggregate;
using MFS.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MFS.xUnitTest.Initialize
{
    public class DatabaseInitializer
    {
        public static void Initialize(MFSContext context)
        {
            if (!context.Merchants.Any())
                SeedData(context);
        }

        private static void SeedData(MFSContext context)
        {
            var MerchantA = Merchant.Create(new MerchantCreateDto
            {
                FirstName = "Erfan",
                LastName = "Kazemi",
                Email = "erfan@yahoo.com",
                NationalCode = "1111111111",
                PhoneNo = "111",
                MerchantDiscount = 20
            });

            MerchantA.Transactions = new List<Transaction>();

            MerchantA.Transactions.Add(Transaction.Create(new TransactionCreateDto
            {
                DayOfWeek = DayOfWeek.Wednesday,
                Price = 3000
            }));

            MerchantA.Transactions.Add(Transaction.Create(new TransactionCreateDto
            {
                DayOfWeek = DayOfWeek.Saturday,
                Price = 1500
            }));

            var MerchantB = Merchant.Create(new MerchantCreateDto
            {
                FirstName = "Parsa",
                LastName = "Ghaemi",
                Email = "parsa@yahoo.com",
                NationalCode = "2222222222",
                PhoneNo = "222",
                MerchantDiscount = 10
            });

            MerchantB.Transactions = new List<Transaction>();

            MerchantB.Transactions.Add(Transaction.Create(new TransactionCreateDto
            {
                DayOfWeek = DayOfWeek.Monday,
                Price = 500
            }));

            MerchantB.Transactions.Add(Transaction.Create(new TransactionCreateDto
            {
                DayOfWeek = DateTime.Now.DayOfWeek,
                Price = 700
            }));

            var MerchantC = Merchant.Create(new MerchantCreateDto
            {
                FirstName = "Amir",
                LastName = "Bakhtiary",
                Email = "amir@yahoo.com",
                NationalCode = "3333333333",
                PhoneNo = "333",
                MerchantDiscount = 15
            });

            MerchantC.Transactions = new List<Transaction>();

            MerchantC.Transactions.Add(Transaction.Create(new TransactionCreateDto
            {
                DayOfWeek = DayOfWeek.Sunday,
                Price = 1000
            }));

            MerchantC.Transactions.Add(Transaction.Create(new TransactionCreateDto
            {
                DayOfWeek = DayOfWeek.Thursday,
                Price = 700
            }));

            context.Merchants.Add(MerchantA);
            context.Merchants.Add(MerchantB);
            context.Merchants.Add(MerchantC);

            context.SaveChanges();
        }
    }
}
