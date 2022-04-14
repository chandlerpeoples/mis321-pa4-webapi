using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using api.Models;
using api.DatabaseUtil;
using api.Interfaces;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        // GET: api/Song
        [EnableCors("newpolicy")]
        [HttpGet]
        public List<Song> Get()
        {
            IReadSongs song = new ReadFromDB();
            return song.ReadSongs();
        }

        // GET: api/Song/5
        [EnableCors("newpolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Song Get(int temp)
        {
            IReadSongs readObj = new ReadFromDB();
            return readObj.ReadOne(temp);
        }

        // POST: api/Song
        [HttpPost]
        public void Post([FromBody] Song newSong)
        {
            ICreateSongs createObj = new WriteToDB();
            createObj.Create(newSong);
        }

        // PUT: api/Song/5
        [HttpPut]
        public void Put([FromBody] Song updatedSong)
        {
            IUpdateSongs updateObj = new UpdateDatabase();
            Console.WriteLine(updatedSong);
            updateObj.Update(updatedSong);
        }

        // DELETE: api/Song/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteSongs deleteObj = new DeleteFromDatabase();
            deleteObj.Delete(id);
        }
    }
}