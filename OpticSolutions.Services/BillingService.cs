using OpticSolutions.Repositories;
using OpticSolutions.Repositories.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticSolutions.Services
{
    public class BillingService
    {
        public BillingRepository repo = new BillingRepository();

        public List<Orders> GetList(Orders Ord)
        {
            var data = GetList(Ord);
            return data;
        }

        public void BillList(Orders Ord)
        {
            //repo.BillList(Ord);
        }


        public void CreateOrder(Orders Ord)
        {

            repo.CreateOrder(Ord);

        }

        public Orders GetOrderById(Orders ord)
        {
            ord = repo.GetOrderById(ord);

            return ord;
        }

        public int GetOrderId(Orders Ord)
        {

            var x = repo.GetOrderId(Ord);

            return x;
        }

    }
}
