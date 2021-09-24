using CursoDioDesignPatterns.Domain.Veiculo;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CursoDioDesignPatterns.Infra.Facade
{
    public class VeiculoDetranFacade : IVeiculoDetran
    {
        private readonly DetranOptions _detranOptions;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoDetranFacade(IOptionsMonitor<DetranOptions> optionsMonitor,
            IHttpClientFactory httpClientFactory,
            IVeiculoRepository veiculoRepository)
        {
            this._detranOptions = optionsMonitor.CurrentValue;
            this._httpClientFactory = httpClientFactory;
            this._veiculoRepository = veiculoRepository;
        }
        public async Task AgendarVistoriaDetran(Guid veicuiloId)
        {
            var veiculo = _veiculoRepository.GetById(veicuiloId);

            var requestModel = new AgendamentoVistoriaModel()
            {
                Placa = veiculo.Placa,
                AgendadoPara = DateTime.Now.AddDays(_detranOptions.QuantidadeDiasParaAgendamento)
            };
            var cliente = _httpClientFactory.CreateClient();
            cliente.BaseAddress = new Uri(_detranOptions.BaseUrl);
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var jsonContext = JsonSerializer.Serialize(requestModel);
            var contentString = new StringContent(jsonContext, Encoding.UTF8, "application/json");

            await cliente.PostAsync(_detranOptions.VistoriaUrl, contentString);
        }
    }
}
