using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data;
using domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace weppi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var samurai = new Samurai { Name = "jacke" };
            var battle = new Battle { Name = "b1",
                EndDate = new DateTime(2000, 02, 02),
                StartDate = new DateTime(2000, 04, 02),
            };

            using (var db = new SamuraiContext())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    //db.AddRange(samurai, battle);
                    try
                    {



                        ////var xx = db.Add(samurai);

                        //db.SaveChanges();
                        //throw new Exception();


                        //var kk = new Samurai { Name = xx.Entity.Id.ToString() + "test" };
                        //db.Add(kk);
                        //db.SaveChanges();
                        var samurai2 = new Samurai { Name = "jacke", Quotes = new List<Quote> { new Quote { Text = "vvv" } } };
                        var ss = new Samurai { Name = "aaaaa", SecretIdentity = new SecretIdentity { RealName = "clanes", } };
                        db.Add(samurai2);
                        db.Add(ss);
                        db.SaveChanges();

                        dbContextTransaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        Console.WriteLine("Error occurred.");
                    }
                              //  transaction.Commit();

                  }
            }

                return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
