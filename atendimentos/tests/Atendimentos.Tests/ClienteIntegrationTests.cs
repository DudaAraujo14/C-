using Xunit;
using System.Net;
using System.Net.Http.Json;

namespace Atendimentos.Tests
{
    public class ClienteIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ClienteIntegrationTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostCliente_DeveCriarCliente()
        {
            // ========================
            // ARRANGE
            // ========================
            var novoCliente = new
            {
                nome = "Maria",
                telefone = "11999999999"
            };

            // ========================
            // ACT
            // ========================
            var response = await _client.PostAsJsonAsync("/api/clientes", novoCliente);

            // ========================
            // ASSERT
            // ========================
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task GetClientes_DeveRetornarSucesso()
        {
            // ========================
            // ACT
            // ========================
            var response = await _client.GetAsync("/api/clientes");

            // ========================
            // ASSERT
            // ========================
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}