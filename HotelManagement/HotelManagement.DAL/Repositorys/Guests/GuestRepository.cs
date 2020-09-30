using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.DAL.Repositorys.Shared;
using HotelManagement.Entities.Persons.Guests;

namespace HotelManagement.DAL.Repositorys.Guests
{
    public class GuestRepository : EFRepository<HotelManagementContext,Guest>, IGuestRepository
    {
        
    }
}



//public async Task<Guest> Get(int id)
//{
//Guest guest = null;

//    using (var context = new HotelManagementContext())
//{
//    guest = await context.Guests.FindAsync(id);
//}
//return guest;
//}

//public async Task<IEnumerable<Guest>> Get()
//{
//IEnumerable<Guest> guests = null;

//using (var context = new HotelManagementContext())
//{
//guests = await context.Guests.ToListAsync();
//}
//return guests;
//}

//public async Task Add(Guest entity)
//{
//if (entity == null) return;

//using (var context = new HotelManagementContext())
//{
//context.Guests.Add(entity);
//await context.SaveChangesAsync();
//}
//}


//public async Task Add(IEnumerable<Guest> entity)
//{
//if (entity == null) return;
//using (var context = new HotelManagementContext())
//{
//context.Guests.AddRange(entity);
//await context.SaveChangesAsync();
//}
//}

//public async Task Delete(Guest entity)
//{
//if (entity == null) return;
//using (var context = new HotelManagementContext())
//{
//context.Guests.Remove(entity);
//await context.SaveChangesAsync();
//}
//}

//public async Task Delete(IEnumerable<Guest> entity)
//{
//if (entity == null) return;
//using (var context = new HotelManagementContext())
//{
//context.Guests.RemoveRange(entity);
//await context.SaveChangesAsync();
//}
//}


//public async Task Update(Guest entity)
//{
//if (entity == null) return;

//using (var context = new HotelManagementContext())
//{
//context.Entry(entity).State = EntityState.Modified;
//await context.SaveChangesAsync();
//}
//}

//public async Task<IEnumerable<Guest>> Find(Func<Guest, bool> predicate)
//{
//IEnumerable<Guest> guests = null;
//using (var context = new HotelManagementContext())
//{
//guests = await Task.Run(() => context.Guests.Where(predicate));

//}
//return guests;
//}

//public Task<IEnumerable<Guest>> GetGuestsWithRoom()
//{
//throw new NotImplementedException();
//}

//public Task<IEnumerable<Guest>> GetGuestsWithoutRoom()
//{
//throw new NotImplementedException();
//}

//public Task<IEnumerable<Guest>> GetGuestsWithReciepts()
//{
//throw new NotImplementedException();
//}

//public Task<IEnumerable<Guest>> GetGuestsWithoutRecipts()
//{
//throw new NotImplementedException();
//}