using Newtonsoft.Json;
using ProvaCandidato.Application.ApiProvaCandidato.Cliente.Models;
using ProvaCandidato.Utils.Commons;
using ProvaCandidato.Utils.Environment;
using RestSharp;
using System.Collections.Generic;

namespace ProvaCandidato.Application.ApiProvaCandidato.Cliente
{
    public class ClienteApplication : IClienteApplication
    {
        private readonly RestClient _restClient;

        public ClienteApplication()
        {
            _restClient = new RestClient(WebEnvironment.ApiProvaCandidato);
        }

        public IReturn<IEnumerable<ClienteModel>> GetAll()
        {
            var request = new RestRequest("Clientes/GetAll");

            var response = _restClient.GetAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail<IEnumerable<ClienteModel>>($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<IReturn<IEnumerable<ClienteModel>>>(response.Content);
        }

        public IReturn<ClienteModel> GetByCodigo(int codigo)
        {
            var request = new RestRequest($"Clientes/GetByCodigo/{codigo}");

            var response = _restClient.GetAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail<ClienteModel>($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<IReturn<ClienteModel>>(response.Content);
        }

        public IReturn<ClienteModel> GetByNome(string nome)
        {
            var request = new RestRequest($"Clientes/GetByNome/{nome}");

            var response = _restClient.GetAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail<ClienteModel>($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<IReturn<ClienteModel>>(response.Content);
        }

        public IReturn Post(ClienteModel cliente)
        {
            var request = new RestRequest("Clientes/Post");

            request.AddJsonBody(cliente);

            var response = _restClient.GetAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<IReturn>(response.Content);
        }

        public IReturn Put(int codigo, ClienteModel cliente)
        {
            var request = new RestRequest($"Clientes/Put/{codigo}");

            request.AddJsonBody(cliente);

            var response = _restClient.GetAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<IReturn>(response.Content);
        }

        public IReturn Delete(int codigo)
        {
            var request = new RestRequest($"Clientes/Delete/{codigo}");

            var response = _restClient.GetAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<IReturn>(response.Content);
        }
    }
}
