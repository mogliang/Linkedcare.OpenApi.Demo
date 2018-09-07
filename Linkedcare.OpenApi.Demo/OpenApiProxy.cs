using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linkedcare.OpenApi.Demo
{
    public class OpenApiProxy : IOpenApiProxy
    {
        OpenApiConfig _config;
        public OpenApiProxy(OpenApiConfig config)
        {
            _config = config;
        }

        public PageDto<OfficeDto> GetOffices(QueryInputBase input)
        {
            var restClient = new RestClient(_config.ApiAddress);
            var token = GetSaasToken();
            restClient.Authenticator = new JwtAuthenticator(token.Token.Split()[1]);
            var request = new RestRequest("/office", Method.GET)
                .AddQueryParameter(nameof(input.FromTime),input.FromTime.ToString())
                .AddQueryParameter(nameof(input.PageIndex),input.PageIndex.ToString());

            return ResolveResponse(restClient.Execute<PageDto<OfficeDto>>(request));
        }


        OpenApiToken _cachedToken;
        public OpenApiToken GetSaasToken()
        {
            if(_cachedToken==null || _cachedToken.ExpiredTime< DateTime.Now.AddMinutes(10))
            {
                _cachedToken =  GetSaasTokenImpl();
            }
            return _cachedToken;
        }

        protected OpenApiToken GetSaasTokenImpl()
        {
            var restClient = new RestClient(_config.ApiAddress);
            var request = new RestRequest("/auth/token", Method.POST)
                .AddJsonBody(new
                {
                    ticket = _config.Secret
                });

            return ResolveResponse(restClient.Execute<OpenApiToken>(request));
        }

        T ResolveResponse<T>(IRestResponse<T> response)
        {
            if (!response.IsSuccessful)
            {
                throw new Exception($"访问e看牙OpenApi失败, error: {response.ErrorMessage}");
            }
            else
            {
                return response.Data;
            }
        }

        public PageDto<PatientDto> GetPatients(OfficeQueryInput input)
        {
            var restClient = new RestClient(_config.ApiAddress);
            var token = GetSaasToken();
            restClient.Authenticator = new JwtAuthenticator(token.Token.Split()[1]);
            var request = new RestRequest("/patient", Method.GET)
                .AddQueryParameter(nameof(input.FromTime), input.FromTime.ToString())
                .AddQueryParameter(nameof(input.OfficeId), input.OfficeId)
                .AddQueryParameter(nameof(input.PageIndex), input.PageIndex.ToString());

            return ResolveResponse(restClient.Execute<PageDto<PatientDto>>(request));
        }
    }
}
