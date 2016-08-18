using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tic.Nova.Dados.Entidade;
using Tic.Nova.Dados.Repositorio;
using Xunit;

namespace Tic.Nova.Teste
{
    public class Class1
    {
        [Fact]
        public void InserirCliente_Sucesso()
        {
            ClienteRepositorio repositorio = new ClienteRepositorio();

            var requisicao = new Cliente()
            {
                Nome = "Usuario Teste",
                Email = $"{Guid.NewGuid().ToString("N")}@ticnova.com.br"
            };

            var cliente = repositorio.InserirCliente(requisicao);

            Assert.Equal(requisicao.Nome, cliente.Nome);
            Assert.Equal(requisicao.Email, cliente.Email);
        }
    }
}
