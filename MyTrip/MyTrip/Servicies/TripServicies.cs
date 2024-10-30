﻿using Microsoft.AspNetCore.Mvc;
using MyTrip.Entities;

namespace MyTrip.Servicies
{
    public class TripServicies
    {
        static List<Trip> dataTrips = new List<Trip>();

        public List<Trip> Get()
        {
            return dataTrips;
        }
        public Trip GetById(int id)
        {
            return dataTrips.FirstOrDefault(x => x.Id == id);
        }

        public ActionResult<bool> Add(Trip trip)
        {
            dataTrips.Add(trip);
            return true;
        }
        public ActionResult<bool> Update(Trip trip)
        {
            for (int i = 0; i < dataTrips.Count; i++)
            {
                if (dataTrips[i].Id == trip.Id)
                {
                    dataTrips[i] = new Trip(trip);
                    return true;
                }
            }
            return false;
        }
        public ActionResult<bool> Delete(int id)
        {
            return dataTrips.Remove(dataTrips.FirstOrDefault(x => x.Id == id));
        }
    }
}
