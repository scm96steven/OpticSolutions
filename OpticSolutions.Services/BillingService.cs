using OpticSolutions.Repositories;
using OpticSolutions.Repositories.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticSolutions.Services
{
    class BillingService
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


    }
}
