using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Giselle.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Giselle.Controllers
{
    public class ClubController : Controller
    {
        ClubDataAccessLayer objclub = new ClubDataAccessLayer();

        [HttpGet]
        [Route("api/Club/Index")]
        public IEnumerable<Club> Index()
        {
            return objclub.GetAllClubs();
        }

        [HttpPost]
        [Route("api/Club/Create")]
        public int Create(Club club)
        {
            return objclub.AddClub(club);
        }

        [HttpGet]
        [Route("api/Club/Details/{id}")]
        public Club Details(int id)
        {
            return objclub.GetClubData(id);
        }

        [HttpPut]
        [Route("api/Club/Edit")]
        public int Edit(Club club)
        {
            return objclub.UpdateClub(club);
        }

        [HttpDelete]
        [Route("api/Club/Delete/{id}")]
        public int Delete(int id)
        {
            return objclub.DeleteClub(id);
        }

        //[HttpDelete]
        //[Route("api/Club/Delete/{id}")]
        //public int Delete(int id)
        //{
        //    return objclub.DeleteClub(id);
        //}

        [HttpGet]
        [Route("api/Club/GetClubList")]
        public IEnumerable<Club> Details()
        {
            return objclub.GetAllClubs();
        }

    }
}
