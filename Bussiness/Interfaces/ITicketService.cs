using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Interfaces
{
    public interface ITicketService : IGenericService<Ticket>
    {
        int GetCount(int voyageId);
        List<Ticket> GetTicketsByVoyageId(int voyageId);
    }
}
