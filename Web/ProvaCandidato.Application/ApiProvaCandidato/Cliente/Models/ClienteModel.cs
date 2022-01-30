using System;

namespace ProvaCandidato.Application.ApiProvaCandidato.Cliente.Models
{
    public class ClienteModel
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public DateTime? DataNascimento { get; set; }

        public int CidadeId { get; set; }

        public bool Ativo { get; set; }
    }
}
