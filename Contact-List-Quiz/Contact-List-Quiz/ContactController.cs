using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_List_Quiz
{
    [Route("api/contacts")]
    public class ContactController : Controller
    {
        public ContactController() { }

        private static List<Person> persons = new List<Person>
        {
            new Person(1,"Mario","Ebner","if130009@htblaperg.onmicrosoft.com"),
            new Person(2,"David","Buchinger","if130007@htblaperg.onmicrosoft.com"),
            new Person(3,"Philipp","Gusenleitner","if1300012@htblaperg.onmicrosoft.com"),
            new Person(4,"Lukas","Juster","if130013@htblaperg.onmicrosoft.com")
        };

        // GET api/contacts
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(persons);
        }

        // GET api/contacts/findByName
        [HttpGet("findByName")]
        public IActionResult GetByName(string name) 
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Invalid or missing name!");
            } else
            {
                var result = persons.Where(p => p.firstName.ToUpper().Contains(name.ToUpper()) ||
                                                p.lastName.ToUpper().Contains(name.ToUpper()))
                                                .ToList();

                if (result == null || result.Count == 0)
                {
                    return BadRequest("Invalid or missing name!");
                } else
                {
                    return Ok(result);
                }
            }

        }

        // POST api/contacts
        [HttpPost]
        public IActionResult Add([FromBody]Person person)
        {
            if (person == null)
            {
                persons.Add(person);
                return Created("api/contacts", "Person successfully created!");
            } else
            {
                return BadRequest("Invalid input!");
            }
        }    

        // DELETE api/contacts/{personId}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id.Equals(0) || id == null)
            {
                return BadRequest("Invalid ID supplied");
            } else
            {
                var result = persons.Where(p => p.id == id);
                if (result.Count() == 0)
                {
                    return BadRequest("Person not found");
                } else
                {
                    persons.Remove(result.ElementAt(0));
                    return StatusCode(204, "Successful Operation");
                }
            }
        } 
    }
}
