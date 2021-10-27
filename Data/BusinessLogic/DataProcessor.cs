using ReactNetAPI.Model;
using System.Data.SqlClient;
using System.Collections.Generic;
using ReactNetAPI.Data.DataAccess;
using System.Data;

namespace ReactNetAPI.Data.BusinessLogic
{
    public class DataProcessor
    {
        public static int CreateCharacter(string name, string rarity, string birthday,
           string allegiance, string element, string image, string description, string connectionString)
        {
            CharacterModel data = new CharacterModel()
            {
                Name = name,
                Rarity = rarity,
                Birthday = birthday,
                Allegiance = allegiance,
                Element = element,
                Image = image,
                Description = description
            };

            string sql = @"insert into dbo.CharacterTable (Name, Rarity, Birthday, Allegiance, Element, Image, Description)
                           values (@Name, @Rarity, @Birthday, @Allegiance, @Element, @Image, @Description);";

            return SQLDataAccess.SaveData(sql, data, connectionString);

        }

        public static List<T> GetAllCharacter<T>(string connectionString)
        {
            string sql = @"select * from dbo.CharacterTable;";

            return SQLDataAccess.LoadData<T>(sql, connectionString);
        }

        public static List<T> GetLatestCharacter<T>(string connectionString)
        {
            string sql = "Select * " +
                            "from dbo.NewlyReleasedCharacter " +
                            "Where Name in ('Raiden Shogun', 'Yoimiya')";

            return SQLDataAccess.LoadData<T>(sql, connectionString);
        }

        public static List<T> DeleteCharacter<T>(int id, string connectionString)
        {
            string sql = "Delete from dbo.CharacterTable " + "Where Id =" + id;

            return SQLDataAccess.LoadData<T>(sql, connectionString);
        }

        public static List<CharacterModel> UpdateCharacter(int id, string name, string rarity, string birthday,
           string allegiance, string element, string image, string description, string connectionString)
        {
            CharacterModel data = new CharacterModel()
            {
                Id = id,
                Name = name,
                Rarity = rarity,
                Birthday = birthday,
                Allegiance = allegiance,
                Element = element,
                Image = image,
                Description = description
            };
            //Name, Rarity, Birthday, Allegiance, Element, Image, Description
            string sql = $"Update dbo.CharacterTable " +
                $"Set Name = @Name, Rarity = @Rarity, Birthday = @Birthday, Allegiance = @Allegiance, Element = @Element, Image = @Image, Description = @Description " +
                $"Where Id = @Id;";
                

            return SQLDataAccess.UpdateData<CharacterModel>(sql, data, connectionString);
        }
    }
}

