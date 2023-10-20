using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Razor.Language;

namespace Projeto.Models
{
    public class Categoria
    {
        public int CategoriaId{get;set;}
        [Display(Name = "Nome da categoria")]
        [Required (ErrorMessage = "Informe o nome da categoria: ")]
        public string Nome{get;set;}
        public List <Item>Itens{get;set;}
    }
}