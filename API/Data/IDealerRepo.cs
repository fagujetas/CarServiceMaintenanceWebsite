using System.Collections.Generic;
using API.Models;

namespace API.Data
{
    public interface IDealerRepo
    {
        bool SaveChanges();
        IEnumerable <DealerInfo> GetAllDealers();
        DealerInfo GetDealerInfoById(int id);
         
        void CreateDealerInfo(DealerInfo dealerInfo);
        void UpdateDealerInfo(DealerInfo dealerInfo);
        void DeleteDealerInfo(DealerInfo dealerInfo);
    }
}