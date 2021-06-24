using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APICalculoIMC.Models;
using Calculos.Common;

namespace APICalculoIMC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculoIMCController : ControllerBase
    {
        private readonly ILogger<CalculoIMCController> _logger;

        public CalculoIMCController(ILogger<CalculoIMCController> logger)
        {
            _logger = logger;
        }

        [HttpGet("imc")]
        [ProducesResponseType(typeof(ClassificacaoPessoa), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(FalhaCalculo), (int)HttpStatusCode.BadRequest)]
        public ActionResult<ClassificacaoPessoa> Get(double peso, double altura)
        {
            _logger.LogInformation(
                "Recebida nova requisição|" +
               $"Peso em Kg: {peso}|" +
               $"Altura em Metros: {altura}");
            
            // Simulação de falha - Validações comentadas a fim de forçar um erro
            // de código 500 pela API
            /*if (peso <= 0)
                return GerarResultParamInvalido("O Peso em Kg");

            if (altura <= 0)
                return GerarResultParamInvalido("A Altura em Metros");*/

            var imc = IndiceMassaCorporea.Calcular(peso, altura).Value;
            var resultado = new ClassificacaoPessoa()
            {
                Peso = peso,
                Altura = altura,
                IMC = imc,
                Situacao = IndiceMassaCorporea.ObterClassificacao(imc)
            };
            _logger.LogInformation("Resultado -> " +
                $"IMC: {resultado.IMC}|" +
                $"Situação: {resultado.Situacao}");            
            
            return resultado;
        }

        private BadRequestObjectResult GerarResultParamInvalido(
            string descCampo)
        {
            var erro = $"{descCampo} deve ser maior do que zero!";
            _logger.LogError(erro);
            return new BadRequestObjectResult(
                new FalhaCalculo() { Mensagem = erro });
        }
    }
}