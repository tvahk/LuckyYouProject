using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Factories
{
    public class BillFactory
    {
    public DTO.BillDTO createBasicDTO(Domain.Bill bill)
    {
        return new DTO.BillDTO
        {
            BillId = bill.BillId,
            BillDeadline = bill.BillDeadline,
            DrawId = bill.Draw.DrawId
        };
    }
}
}