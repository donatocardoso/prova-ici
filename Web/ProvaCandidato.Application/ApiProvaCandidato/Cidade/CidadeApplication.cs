using Newtonsoft.Json;
using ProvaCandidato.Utils.Commons;
using ProvaCandidato.Utils.Environment;
using RestSharp;
using System.Collections.Generic;

namespace ProvaCandidato.Application.ApiProvaCandidato
{
    public class CidadeApplication
    {
        private readonly RestClient _restClient;

        public CidadeApplication()
        {
            _restClient = new RestClient(WebEnvironment.ApiProvaCandidato);
        }

        public IReturn<IEnumerable<CidadeModel>> GetAll()
        {
            var request = new RestRequest("Cidades/GetAll");

            var response = _restClient.GetAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail<IEnumerable<CidadeModel>>($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<IReturn<IEnumerable<CidadeModel>>>(response.Content);
        }

        public IReturn<CidadeModel> GetByCodigo(int codigo)
        {
            var request = new RestRequest($"Cidades/GetByCodigo/{codigo}");

            var response = _restClient.GetAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail<CidadeModel>($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<IReturn<CidadeModel>>(response.Content);
        }

        public IReturn<CidadeModel> GetByNome(string nome)
        {
            var request = new RestRequest($"Cidades/GetByNome/{nome}");

            var response = _restClient.GetAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail<CidadeModel>($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<IReturn<CidadeModel>>(response.Content);
        }

        public IReturn Post(CidadeModel cidade)
        {
            var request = new RestRequest("Cidades/Post");

            request.AddJsonBody(cidade);

            var response = _restClient.GetAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<IReturn>(response.Content);
        }

        public IReturn Put(int codigo, CidadeModel cidade)
        {
            var request = new RestRequest($"Cidades/Put/{codigo}");

            request.AddJsonBody(cidade);

            var response = _restClient.GetAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<IReturn>(response.Content);
        }

        public IReturn Delete(int codigo)
        {
            var request = new RestRequest($"Cidades/Delete/{codigo}");

            var response = _restClient.GetAsync(request).Result;

            if (!response.IsSuccessful)
            {
                return Return.Fail($"Falha ao conectar a api, detalhes: {response.ErrorMessage}");
            }

            return JsonConvert.DeserializeObject<IReturn>(response.Content);
        }
    }
}
