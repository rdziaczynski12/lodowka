using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kuhlschrank.Models
{
    public class Recipe
    {
        [Key]
        public long id { set; get; }
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string name { set; get; }
        public int difficulty { set; get; }
        public bool vegetarian { set; get; }
        public string type { set; get; }
        public double time { set; get; }
        public string description { set; get; }
        public int portions { set; get; }

        public virtual ICollection<RecipeProduct> products { get; set; }
        public virtual ICollection<HistoryRecipe> recipeHistory { get; set; }

    }
}
