using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ReactNetAPI.Model
{
    /// <summary>
    /// Author Oujun Xu
    /// Model class for each character.
    /// </summary>
    public class CharacterModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Rarity { get; set; }


        public string Birthday { get; set; }

        public string Allegiance { get; set; }

        public string Element { get; set; }


        public string Image { get; set; }

        public string Description { get; set; }

    }
}
