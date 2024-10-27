using System.ComponentModel.DataAnnotations;

namespace Crud_IBGE.Models
{
    public class Processo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do processo é obrigatório")]
        [StringLength(255, ErrorMessage = "O nome do processo deve ter no máximo 255 caracteres")]
        public string NomeProcesso { get; set; }

        [Required(ErrorMessage = "O NPU é obrigatório")]
        [RegularExpression(@"^\d{7}-\d{2}\.\d{4}\.\d\.\d{2}\.\d{4}$", ErrorMessage = "O NPU deve estar no formato 1111111-11.1111.1.11.1111")]
        public string NPU { get; set; }

        [Display(Name = "Data de Cadastro")]
        [Required(ErrorMessage = "A data de cadastro é obrigatória")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "Data de Visualização")]
        public DateTime? DataVisualizacao { get; set; }

        [Required(ErrorMessage = "A UF é obrigatória")]
        [StringLength(2, ErrorMessage = "A UF deve ter exatamente 2 caracteres")]
        public string UF { get; set; }

        [Required(ErrorMessage = "O nome do município é obrigatório")]
        public string MunicipioNome { get; set; }

        [Required(ErrorMessage = "O código do município é obrigatório")]
        public int MunicipioCodigo { get; set; }
    }
}
