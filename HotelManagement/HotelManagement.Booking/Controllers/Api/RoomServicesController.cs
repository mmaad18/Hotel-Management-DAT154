using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HotelManagement.DAL;
using HotelManagement.Entities.RoomServices;
using HotelManagement.Entities.RoomServices.Food;
using HotelManagement.Entities.RoomServices.Housekeeping;
using HotelManagement.Entities.RoomServices.Janitor;

namespace HotelManagement.Booking.Controllers.Api
{
    public class RoomServicesController : ApiController
    {
        private HotelManagementContext db = new HotelManagementContext();

        // GET: api/RoomServices
        public IQueryable<RoomService> GetRoomServices()
        {
            return db.RoomServices;
        }

        // GET: api/Employees/username={text}&password={text}
        [Route("api/RoomServices/FoodServices")]
        [ResponseType(typeof(RoomService))]
        public List<RoomService> GetFoodServices()
        {
            return db.RoomServices.ToList().Where(x=> x.GetType() == typeof(FoodService) && x.EmployeeId == null).ToList();
        }

        // GET: api/Employees/username={text}&password={text}
        [Route("api/RoomServices/HousekeepingServices")]
        [ResponseType(typeof(RoomService))]
        public List<RoomService> GetHousekeepingServices()
        {
            var roomservices= db.RoomServices.ToList().Where(x => x.GetType() == typeof(HousekeepingService) && x.EmployeeId == null).ToList(); ;

            return roomservices; ;
        }

        // GET: api/Employees/username={text}&password={text}
        [Route("api/RoomServices/JanitorServices")]
        [ResponseType(typeof(RoomService))]
        public List<RoomService> GetJanitorServices()
        {
            return db.RoomServices.ToList().Where(x => x.GetType() == typeof(JanitorService) && x.EmployeeId == null).ToList(); ;
        }

        // GET: api/RoomServices/5
        [ResponseType(typeof(RoomService))]
        public IHttpActionResult GetRoomService(int id)
        {
            RoomService roomService = db.RoomServices.Find(id);
            if (roomService == null)
            {
                return NotFound();
            }

            return Ok(roomService);
        }

        // PUT: api/RoomServices/5
        [Route("api/RoomServices/JanitorServices/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJanitorService(int id, JanitorService roomService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roomService.Id)
            {
                return BadRequest();
            }

            db.Entry(roomService).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomServiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        // PUT: api/RoomServices/5
        [Route("api/RoomServices/HousekeepingServices/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHousekeepingService(int id, HousekeepingService roomService)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roomService.Id)
            {
                return BadRequest();
            }

            db.Entry(roomService).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomServiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        // PUT: api/RoomServices/5
        [Route("api/RoomServices/FoodServices/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFoodService(int id, FoodService roomService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roomService.Id)
            {
                return BadRequest();
            }

            db.Entry(roomService).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomServiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RoomServices
        [ResponseType(typeof(RoomService))]
        public IHttpActionResult PostRoomService(RoomService roomService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RoomServices.Add(roomService);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = roomService.Id }, roomService);
        }

        // DELETE: api/RoomServices/5
        [ResponseType(typeof(RoomService))]
        public IHttpActionResult DeleteRoomService(int id)
        {
            RoomService roomService = db.RoomServices.Find(id);
            if (roomService == null)
            {
                return NotFound();
            }

            db.RoomServices.Remove(roomService);
            db.SaveChanges();

            return Ok(roomService);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoomServiceExists(int id)
        {
            return db.RoomServices.Count(e => e.Id == id) > 0;
        }
    }
}