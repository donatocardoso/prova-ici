using Newtonsoft.Json;
using ProvaCandidato.Application.ApiProvaCandidato.Cidade.Models;
using ProvaCandidato.Utils.Commons;
using ProvaCandidato.Utils.Environment;
using RestSharp;
using System.Collections.Generic;

namespace ProvaCandidato.Application.ApiProvaCandidato.Cidade
{
    public class CidadeApplication
    {
        private readonly RestClient _restClient;

        public CidadeApplication()
        {
            _restClient = new RestClient(WebEnvironment.ApiProvaCandidato);
        }

        public IReturn<List<CidadeModel>> GetAll()
        {
            var request = new RestRequest("Cidades/GetAll");

            var response = _restClient.GetAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail<List<CidadeModel>>($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<ReturnModel<List<CidadeModel>>>(response.Content);
        }

        public IReturn<CidadeModel> GetByCodigo(int codigo)
        {
            var request = new RestRequest($"Cidades/GetByCodigo/{codigo}");

            var response = _restClient.GetAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail<CidadeModel>($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<ReturnModel<CidadeModel>>(response.Content);
        }

        public IReturn<CidadeModel> GetByNome(string nome)
        {
            var request = new RestRequest($"Cidades/GetByNome/{nome}");

            var response = _restClient.GetAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail<CidadeModel>($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<ReturnModel<CidadeModel>>(response.Content);
        }

        public IReturn Post(CidadeModel cidade)
        {
            var request = new RestRequest("Cidades/Post");

            request.AddJsonBody(cidade);

            var response = _restClient.PostAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<ReturnModel>(response.Content);
        }

        public IReturn Put(CidadeModel cidade)
        {
            var request = new RestRequest($"Cidades/Put/{cidade.Codigo}");

            request.AddJsonBody(cidade);

            var response = _restClient.PutAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<ReturnModel>(response.Content);
        }

        public IReturn Delete(int codigo)
        {
            var request = new RestRequest($"Cidades/Delete/{codigo}");

            var response = _restClient.DeleteAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<ReturnModel>(response.Content);
        }
    }
}
