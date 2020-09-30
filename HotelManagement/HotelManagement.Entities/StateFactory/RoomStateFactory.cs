using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HotelManagement.Entities.Bills.States;
using HotelManagement.Entities.Reciepts.States;
using HotelManagement.Entities.Rooms.States;

namespace HotelManagement.Entities.StateFactory
{
    public static class RoomStateFactory
    {
        public static RoomState GetRoomState(string stateTypeName)
        {
            var list = FindAllDerivedStates(typeof(RoomState));
            dynamic returnedValue = new AvailableState();
            foreach (var state in list)
                if (state.Name == stateTypeName) returnedValue = (RoomState) Activator.CreateInstance(state);
            return returnedValue;
        }

        public static BillState GetBillState(string stateTypeName)
        {
            var list = FindAllDerivedStates(typeof(BillState));
            dynamic returnedValue = new UnsettledBill();
            foreach (var state in list)
                if (state.Name == stateTypeName) returnedValue = (BillState) Activator.CreateInstance(state);
            return returnedValue;
        }

        public static RecieptState GetRecieptState(string stateTypeName)
        {
            var list = FindAllDerivedStates(typeof(RecieptState));
            dynamic returnedValue = new UnsettledReciept();
            foreach (var state in list)
                if (state.Name == stateTypeName) returnedValue = (RecieptState) Activator.CreateInstance(state);
            return returnedValue;
        }

        private static IEnumerable<Type> FindAllDerivedStates(Type derivedType)
        {
            var assembly = Assembly.GetAssembly(derivedType);
            return assembly.GetTypes().Where(t => t != derivedType && derivedType.IsAssignableFrom(t)).ToList();
        }
    }
}