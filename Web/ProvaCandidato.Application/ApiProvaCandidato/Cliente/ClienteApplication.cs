using Newtonsoft.Json;
using ProvaCandidato.Application.ApiProvaCandidato.Cliente.Models;
using ProvaCandidato.Utils.Commons;
using ProvaCandidato.Utils.Environment;
using RestSharp;
using System.Collections.Generic;

namespace ProvaCandidato.Application.ApiProvaCandidato.Cliente
{
    public class ClienteApplication
    {
        private readonly RestClient _restClient;

        public ClienteApplication()
        {
            _restClient = new RestClient(WebEnvironment.ApiProvaCandidato);
        }

        public IReturn<List<ClienteModel>> GetAll()
        {
            var request = new RestRequest("Clientes/GetAll");

            var response = _restClient.GetAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail<List<ClienteModel>>($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<ReturnModel<List<ClienteModel>>>(response.Content);
        }

        public IReturn<ClienteModel> GetByCodigo(int codigo)
        {
            var request = new RestRequest($"Clientes/GetByCodigo/{codigo}");

            var response = _restClient.GetAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail<ClienteModel>($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<ReturnModel<ClienteModel>>(response.Content);
        }

        public IReturn<ClienteModel> GetByNome(string nome)
        {
            var request = new RestRequest($"Clientes/GetByNome/{nome}");

            var response = _restClient.GetAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail<ClienteModel>($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<ReturnModel<ClienteModel>>(response.Content);
        }

        public IReturn Post(ClienteModel cliente)
        {
            var request = new RestRequest("Clientes/Post");

            request.AddJsonBody(cliente);

            var response = _restClient.PostAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<ReturnModel>(response.Content);
        }

        public IReturn Put(ClienteModel cliente)
        {
            var request = new RestRequest($"Clientes/Put/{cliente.Codigo}");

            request.AddJsonBody(cliente);

            var response = _restClient.PutAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<ReturnModel>(response.Content);
        }

        public IReturn Delete(int codigo)
        {
            var request = new RestRequest($"Clientes/Delete/{codigo}");

            var response = _restClient.DeleteAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<ReturnModel>(response.Content);
        }
    }
}
