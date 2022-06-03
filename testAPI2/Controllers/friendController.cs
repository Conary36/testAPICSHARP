using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace testAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class friendController : ControllerBase



    {

        List<Friend> friends = new List<Friend>{
            new Friend(1, "Conary", "Dean", "Boston", DateTime.Today),
            new Friend(2, "Dillon", "Rich", "Montana", DateTime.Today),
            new Friend(3, "Taylor", "Rook", "Michigan", DateTime.Today),
            new Friend(4, "Shelly", "Lakloo", "New York", DateTime.Today)


        };

        // GET: api/friend
        [HttpGet]
        public List<Friend> Get()    //IEnumerable<string>***replaced with List<Friend>
        {
            //return new string[] { "value1", "value2" };
            return friends;
        }

        // GET: api/friend/5
        [HttpGet("{id}", Name = "Get")]
        public Friend Get(int id)
        {
            Friend friend = friends.Find(f => f.id == id);
            return friend;
        }

        // POST: api/friend
        [HttpPost]
        public List<Friend> Post([FromBody] Friend friend)
        {
            friends.Add(friend);
            return friends;
        }

        // PUT: api/friend/5
        [HttpPut("{id}")]
        public List<Friend> Put(int id, [FromBody] Friend friend)
        {
            Friend friendToUpdate = friends.Find(f => f.id == id);
            int index = friends.IndexOf(friendToUpdate);

            friends[index].firstname = friend.firstname;
            friends[index].lastname = friend.lastname;
            friends[index].location = friend.location;
            friends[index].dateOfHire = friend.dateOfHire;

            return friends;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<Friend> Delete(int id)
        {
            Friend friend = friends.Find(f => f.id == id);
            friends.Remove(friend);
            return friends;
        }
    }
}
