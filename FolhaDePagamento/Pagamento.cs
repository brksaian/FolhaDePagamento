using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolhaDePagamento
{
    class Pagamento
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int Numero_horas { get; set; }
        public double Valor { get; set; }
        public Funcionario funcionario { get; set; }
        
        public double GetSalarioBruto()
        {
            return Numero_horas * Valor;
        }

        public double GetIR()
        {
            double salario = Numero_horas * Valor;
            if(salario < 1372.81)
            {
                return 0.0;
            }
            else
            {
                if(salario < 2743.25)
                {
                    return salario * 0.15 + 205.92;
                }
                else
                {
                    return salario * 0.275 + 548.82;
                }
            }
        }

        public double GetINSS()
        {
            double salario = Numero_horas * Valor;
            if(salario < 868.29)
            {
                return salario*0.08;
            }
            else
            {
                if(salario > 2894.28)
                {
                    return 318.37;
                }
                else
                {
                    if(salario < 1447.14)
                    {
                        return salario * 0.09;
                    }
                    else
                    {
                        return salario * 0.11;
                    }
                }
            }
        }

        public double GetFGTS()
        {
            return Numero_horas * Valor * 0.08;
        }
        
        public double GetSalarioLiquido()
        {
            var salario = GetSalarioBruto();
            var fgts = GetFGTS();
            var ir = GetIR();
            return salario - ir - fgts;
        }
        public Pagamento() { }
    }
}
