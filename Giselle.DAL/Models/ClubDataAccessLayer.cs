using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Giselle.DAL.Models
{
    public class ClubDataAccessLayer
    {
        GiselleContext db = new GiselleContext();

        public IEnumerable<Club> GetAllClubs()
        {
            try
            {
                return db.Club.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new club record     
        public int AddClub(Club club)
        {
            try
            {
                db.Club.Add(club);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar club    
        public int UpdateClub(Club club)
        {
            try
            {
                db.Entry(club).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }


        //Get the details of a particular club    
        public Club GetClubData(int id)
        {
            try
            {
                Club club = db.Club.Find(id);
                return club;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular employee    
        public int DeleteClub(int id)
        {
            try
            {
                Club club = db.Club.Find(id);
                db.Club .Remove(club);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        ////To Get the list of Countries    
        //public List<Countries> GetCities()
        //{
        //    List<TblCities> lstCity = new List<TblCities>();
        //    lstCity = (from CityList in db.TblCities select CityList).ToList();
        //    return lstCity;
        //}
    }
}
