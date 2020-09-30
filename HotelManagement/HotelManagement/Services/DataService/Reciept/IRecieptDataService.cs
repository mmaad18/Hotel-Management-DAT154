using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Reception.Services.DataService.Reciept
{
    using Entities.Reciepts;
    public interface IRecieptDataService
    {
        void GetReciepts(Action<List<Reciept>, Exception> callback);
    }
}
