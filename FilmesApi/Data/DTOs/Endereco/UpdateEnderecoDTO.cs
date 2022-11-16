using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Data.DTOs.Endereco
{
    public class UpdateEnderecoDTO
    {
        //[Required(ErrorMessage = "Título é um campo obrigatório")]
        public string Logradouro { get; set; }

        public string Bairro { get; set; }

        public int Numero { get; set; }
    }
}
