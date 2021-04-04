using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento
{
    class ListaFuncionarios
    {
        private static List<Funcionario> lista = new List<Funcionario>();

        public static void AddFuncionario(Funcionario f)
        {
            lista.Add(f);
        }

        public static List<Funcionario> GetFuncionario()
        {
            return lista;
        }

        public static Funcionario SearchFuncionario(string cpf)
        {
            foreach (Funcionario f in lista)
            {
                if (f.CPF.Equals(cpf))
                {
                    return f;
                }
            }
            return null;
        }

    }
}
