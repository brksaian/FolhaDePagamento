using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento
{
    class ListaDePagamentos
    {
        private static List<Pagamento> pagamentos = new List<Pagamento>();

        public static void AddPagamento(Pagamento f)
        {
            pagamentos.Add(f);
        }

        public static List<Pagamento> GetPagamento()
        {
            return pagamentos;
        }

        public static Pagamento SearchPagamento(int ano, int mes)
        {
            foreach (Pagamento p in pagamentos)
            {
                if (p.Ano.Equals(ano) && p.Mes.Equals(mes))
                {
                    return p;
                }
            }
            return null;
        }

        public static Pagamento SearchPagamentoCPF(int ano, int mes, string cpf)
        {
            foreach (Pagamento p in pagamentos)
            {
                if (p.Ano.Equals(ano) && p.Mes.Equals(mes) && p.funcionario.CPF.Equals(cpf))
                {
                    return p;
                }
            }
            return null;
        }
    }
}
