using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using Tic.Nova.Dados.Entidade;

namespace Tic.Nova.Dados.Repositorio
{
    public class ClienteRepositorio
    {
        private readonly CloudStorageAccount _storageAccount;
        private readonly CloudTable _table;

        public ClienteRepositorio()
        {
            _storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=ticnova;AccountKey=xyPoXKVmHHATAM2Q0GXhR9n97S6j3g5lU4vMJSRmZrJ9LUlPO0eqLcxZpa4+l+atNDaiDn1qwvNKsG98e15iXQ==");
            var tableClient = _storageAccount.CreateCloudTableClient();
            _table = tableClient.GetTableReference(Cliente.NomeTabela);
        }

        public Cliente InserirCliente(Cliente cliente)
        {
            cliente.PartitionKey = cliente.Email.Substring(0, 2).ToUpper();
            cliente.RowKey = cliente.Email;
            cliente.Aprovado = false;

            TableOperation insertOperation = TableOperation.Insert(cliente);
            var resposta = _table.Execute(insertOperation);
            var retorno = (Cliente)resposta.Result;

            GerarMensagem(retorno.Email);

            return retorno;
        }

        public Cliente ObterClientePorEmail(string email)
        {
            var particao = email.Substring(0, 2).ToUpper();

            var retrieveOperation = TableOperation.Retrieve<Cliente>(particao, email);

            var retrievedResult = _table.Execute(retrieveOperation);

            var produto = (Cliente)retrievedResult.Result;

            return produto;
        }

        public Cliente AprovarCliente(string email)
        {
            return new Cliente();
        }

        public void GerarMensagem(string mensagem)
        {
            CloudQueueClient queueClient = _storageAccount.CreateCloudQueueClient();
            var repositorio = queueClient.GetQueueReference("processamento0");
            repositorio.AddMessage(new CloudQueueMessage(mensagem));
        }
    }
}
