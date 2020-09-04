using System;
using System.Collections.Generic;
using System.Linq;
using API.Models;

namespace API.Data
{
    public class SqlDealerRepo : IDealerRepo
    {
        private readonly DealerDataContext _context;
        public SqlDealerRepo(DealerDataContext context)
        {
            _context = context;

        }
        
        public IEnumerable<DealerInfo> GetAllDealers()
        {
            return _context.DealerInfos.ToList();
        }
        
        public DealerInfo GetDealerInfoById(int id)
        {
            return _context.DealerInfos.FirstOrDefault(p => p.Id == id);
        }

        public void CreateDealerInfo(DealerInfo dealerInfo)
        {
            if(dealerInfo == null)
            {
                throw new ArgumentNullException(nameof(dealerInfo));
            }

            _context.DealerInfos.Add(dealerInfo);
        }

        public void DeleteDealerInfo(DealerInfo dealerInfo)
        {
            if(dealerInfo == null)
            {
                throw new ArgumentNullException(nameof(dealerInfo));
            }

            _context.DealerInfos.Remove(dealerInfo);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateDealerInfo(DealerInfo dealerInfo)
        {
            //Nothing
        }
    }
}