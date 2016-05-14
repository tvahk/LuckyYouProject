using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Interfaces
{
    public interface IWinningRepository : IEFRepository<Winning>
    {
        List<Winning> GetUserWinnings(string userid);
        int CountUserWinnings(string userid);
        List<Winning> GetAllWinningsWithUserAndDraws();
    }
}