using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace Tic.Nova.Dados.Entidade
{
    public class Cliente : TableEntity
    {
        public static string NomeTabela = "Cliente5";

        public Cliente() { }

        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Aprovado { get; set; }
    }
}
