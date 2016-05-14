using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class BillService
    {
        private DAL.Interfaces.IBillRepository _repo;
        private Factories.BillFactory _factory;

        public BillService()
        {
            this._repo = new DAL.Repositories.BillRepository(new DAL.LuckyYouDbContext());
            this._factory = new Factories.BillFactory();
        }

        public List<DTO.BillDTO> getAllBills()
        {
             return
               this._repo.getAllBills().Select(
                   x => _factory.createBasicDTO(x)).ToList();
        }

        public DTO.BillDTO getBillById(int id)
        {
            var query = _repo.getAllBills().Where(x => _factory.createBasicDTO(x).BillId == id).FirstOrDefault();
            return new DTO.BillDTO()
            {
                BillId = query.BillId,
                BillDeadline = query.BillDeadline,
                DrawId = query.Draw.DrawId
            };
        }
    }
}
