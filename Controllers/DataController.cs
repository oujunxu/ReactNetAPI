using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ReactNetAPI.Data.BusinessLogic;
using System.Data.SqlClient;
using ReactNetAPI.Model;
using ReactNetAPI.Data.Model;
using ReactNetAPI.Data.DataAccess;

namespace ReactNetAPI.Controllers
{
    /// <summary>
    /// Author Oujun
    /// Class used as a flow controller of data.
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DataController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            string sqlDataSource = _configuration.GetConnectionString("GenshinDB");
            return sqlDataSource;
        }


        [HttpGet]
        public JsonResult Get() {
            return new JsonResult(DataProcessor.GetAllCharacter<CharacterModel>(GetConnectionString()));
        }

        [Route("GetNew")]
        public JsonResult GetNew()
        {
            return new JsonResult(DataProcessor.GetLatestCharacter<CharacterModel>(GetConnectionString()));
        }

        [HttpPost]
        public JsonResult Post(CharacterModel cm)
        {
            DataProcessor.CreateCharacter(
                cm.Name,
                cm.Rarity,
                cm.Birthday,
                cm.Allegiance,
                cm.Element,
                cm.Image,
                cm.Description,
                GetConnectionString()
                
            );
            return new JsonResult("Added Successfully");
        }

        [HttpDelete]
        public JsonResult Delete(DeleteModel cm)
        {
            DataProcessor.DeleteCharacter<CharacterModel>(cm.Id, GetConnectionString());
            return new JsonResult("Successfully Deleted!");
        }

        [HttpPut]
        public JsonResult Put(CharacterModel cm)
        {
            DataProcessor.UpdateCharacter(
                cm.Id,
                cm.Name,
                cm.Rarity,
                cm.Birthday,
                cm.Allegiance,
                cm.Element,
                cm.Image,
                cm.Description,
                GetConnectionString()
            );
            return new JsonResult("Update Successfully");
        }


    }
}
