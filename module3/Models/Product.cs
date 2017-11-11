using System.ComponentModel.DataAnnotations;

namespace module3.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Id é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "Id deve ser maior que 0")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(3, ErrorMessage = "Nome deve ter mais que 3 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Preço é Obrigatorio")]
        public decimal Price { get; set; }

    }
}