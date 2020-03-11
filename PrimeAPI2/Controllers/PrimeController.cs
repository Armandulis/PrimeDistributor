﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrimeAPI2.Repository;

namespace PrimeAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimeController : ControllerBase
    {
        private PrimesRepo _pr;
        public PrimeController()
        {
            _pr = new PrimesRepo();

        }

        // GET api/values/12
        [HttpGet("{id}")]
        public ActionResult<bool> Get(int id)
        {
            return _pr.IsPrime(id);
        }

    }
}