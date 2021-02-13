using Bussiness.Interfaces;
using Data.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Concrete
{
    public class TicketManager : GenericManager<Ticket>, ITicketService
    {
        private readonly IGenericDal<Ticket> _dal;
        public TicketManager(IGenericDal<Ticket> dal):base(dal)
        {
            _dal = dal;
        }

        public int GetCount(int voyageId)
        {
            return _dal.GetAll(a => a.VoyageId == voyageId)==null?0:_dal.GetAll(a=>a.VoyageId==voyageId).Count;
        }

        public List<Ticket> GetTicketsByVoyageId(int voyageId)
        {
            return _dal.GetAll(a => a.VoyageId == voyageId);
        }
    }
}
