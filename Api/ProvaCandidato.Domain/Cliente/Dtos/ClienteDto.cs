using ProvaCandidato.Domain.Cidade.Dtos;
using System;

namespace ProvaCandidato.Domain.Cliente.Dtos
{
    public class ClienteDto
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public DateTime? DataNascimento { get; set; }

        public int CidadeId { get; set; }

        public CidadeDto Cidade { get; set; }

        public bool Ativo { get; set; }
    }
}
