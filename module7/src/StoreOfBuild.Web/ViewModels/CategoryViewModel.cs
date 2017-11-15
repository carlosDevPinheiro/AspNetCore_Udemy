using System.ComponentModel.DataAnnotations;

namespace StoreOfBuild.Web.ViewModels 
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}