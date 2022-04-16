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
        
        [EnableCors("newpolicy")]
        [HttpGet]
        public List<Song> Get()
        {
            IReadSongs read = new ReadFromDB();
            return read.ReadSongs();
        }

        
        [EnableCors("newpolicy")]
        [HttpGet("{id}", Name = "Get")]
        public Song Get(int temp)
        {
            IReadSongs read = new ReadFromDB();
            return read.ReadOne(temp);
        }

        
        [HttpPost]
        public void Post([FromBody] Song newSong)
        {
            ICreateSongs create = new WriteToDB();
            create.Create(newSong);
        }

        
        [HttpPut]
        public void Put([FromBody] Song updatedSong)
        {
            IUpdateSongs update = new UpdateDB();
            update.Update(updatedSong);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteSongs delete = new DeleteSongFromDB();
            delete.Delete(id);
        }
    }
}