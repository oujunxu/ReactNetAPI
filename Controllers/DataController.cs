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

namespace ReactNetAPI.Controllers
{
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
            return new JsonResult(DataProcessor.GetAllCharacter());
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
                cm.Description
            );
            return new JsonResult("Added Successfully");
        }

        [HttpDelete]
        public JsonResult Delete(DeleteModel cm)
        {
            DataProcessor.DeleteCharacter(cm.Id);
            return new JsonResult("Successfully Deleted!");
        }


    }
}
