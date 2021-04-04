using System;

namespace FolhaDePagamento
{
    class Program
    {
        static void Main(string[] args)
        {
            int op;
            bool leuDados = false;
            do
            {
                Console.WriteLine("### MENU ###");
                Console.WriteLine("1 – Cadastro de funcionários");
                Console.WriteLine("2 – Cadastro da folha");
                Console.WriteLine("3 – Consultar folha");
                Console.WriteLine("4 – Listar folhas");
                Console.WriteLine("5 – Sair");
                Console.WriteLine("Informe a opção: ");
                op = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (op)
                {
                    case 1:
                        Funcionario f = new Funcionario();
                        Console.WriteLine("Novo funcionario:");
                        Console.WriteLine("CPF:");
                        f.CPF = Console.ReadLine();
                        if(ListaFuncionarios.SearchFuncionario(f.CPF) == null)
                        {

                            Console.WriteLine("Nome:");
                            f.Nome = Console.ReadLine();
                            try
                            {
                                ListaFuncionarios.AddFuncionario(f);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Ocorreu o erro " + e);
                                break;
                            }
                            finally
                            {
                                Console.WriteLine("\nFuncionario adicionado com sucesso!!!");
                                leuDados = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Usuario ja cadastrado");
                        }
                        break;
                    case 2:
                        Console.Clear();
                        if (leuDados)
                        {
                            Console.WriteLine("\nCadastrado de folha:\n\n");
                            Console.WriteLine("Insira o cpf do funcionario:");
                            string cpf = Console.ReadLine();
                            Funcionario funcionario = ListaFuncionarios.SearchFuncionario(cpf);
                            if (funcionario != null)
                            {
                                Pagamento F = new Pagamento();
                                Console.WriteLine("Novo folha:");
                                Console.WriteLine("Mes:");
                                F.Mes = int.Parse(Console.ReadLine());
                                Console.WriteLine("Ano:");
                                F.Ano = int.Parse(Console.ReadLine());
                                if (ListaDePagamentos.SearchPagamentoCPF(F.Ano, F.Mes, cpf) == null )
                                {
                                    Console.WriteLine("Numero de horas:");
                                    F.Numero_horas = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Valor da hora:");
                                    F.Valor = int.Parse(Console.ReadLine());
                                    F.funcionario = funcionario;
                                    ListaDePagamentos.AddPagamento(F);
                                }
                                else
                                {
                                    Console.WriteLine("Dia ou mes ja cadastrados");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Nenhum funcionario cadastrado...");
                            }
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Insira o cpf do funcionario:");
                        string c = Console.ReadLine();
                        if(ListaFuncionarios.SearchFuncionario(c) != null)
                        {
                            Console.WriteLine("Insira o mes:");
                            int m = int.Parse(Console.ReadLine());
                            Console.WriteLine("Insira o ano:");
                            int a = int.Parse(Console.ReadLine());
                            Pagamento p = ListaDePagamentos.SearchPagamento(a, m);
                            if (p != null)
                            {
                                Console.WriteLine("Nome: " + p.funcionario.Nome);
                                Console.WriteLine("Salario bruto: " + p.GetSalarioBruto());
                                Console.WriteLine("IR: " + p.GetIR());
                                Console.WriteLine("INSS: " + p.GetINSS());
                                Console.WriteLine("FGTS: " + p.GetFGTS());
                                Console.WriteLine("Salario Liquido: " + p.GetSalarioLiquido());
                            }
                            else
                            {
                                Console.WriteLine("Dia ou mes inexistente...");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Funcionario inexistente...");
                        }
                        break;
                    case 4:
                        double total = 0.0;
                        Console.Clear();
                        Console.WriteLine("Insira o mes:");
                        int mes = int.Parse(Console.ReadLine());
                        Console.WriteLine("Insira o ano:");
                        int ano = int.Parse(Console.ReadLine());
                        foreach(Pagamento p in ListaDePagamentos.GetPagamento())
                        {
                            if(p.Ano.Equals(ano) && p.Mes.Equals(mes))
                            {
                                Console.WriteLine("Nome: " + p.funcionario.Nome);
                                total += p.GetSalarioLiquido();
                                Console.WriteLine("Salario liquido: " + p.GetSalarioLiquido());
                            }
                        }
                        Console.WriteLine("Total: " + total);
                        break;
                    case 5:

                        break;
                    default:
                        Console.WriteLine("Numero incorreto\nInsira outro!!");
                        break;
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();

            } while (op != 5);
        }
    }
}
