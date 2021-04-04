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
                op = TrataNumeroInteiro("Informe a opção");
                Console.Clear();
                switch (op)
                {
                    case 1:
                        Funcionario f = new Funcionario();
                        Console.WriteLine("\t\tNovo funcionario");
                        f.CPF = TrataString("CPF");
                        if(ListaFuncionarios.SearchFuncionario(f.CPF) == null)
                        {
                            f.Nome = TrataString("Nome");
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
                                F.Mes = TrataNumeroInteiro("Mes");
                                F.Ano = TrataNumeroInteiro("Ano");
                                if (ListaDePagamentos.SearchPagamentoCPF(F.Ano, F.Mes, cpf) == null )
                                {
                                    F.Numero_horas = TrataNumeroInteiro("Numero de horas");
                                    F.Valor = TrataNumeroDouble("Valor da hora");
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
                            int m = TrataNumeroInteiro("Insira o mes");
                            int a = TrataNumeroInteiro("Insira o ano");
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
                        int mes = TrataNumeroInteiro("Insira o mes");
                        int ano = TrataNumeroInteiro("Insira o ano");
                        foreach (Pagamento p in ListaDePagamentos.GetPagamento())
                        {
                            if(p.Ano.Equals(ano) && p.Mes.Equals(mes))
                            {
                                Console.WriteLine("Nome: " + p.funcionario.Nome);
                                Console.WriteLine("Salario liquido: " + p.GetSalarioLiquido());
                                total += p.GetSalarioLiquido();
                            }
                        }
                        Console.WriteLine("Total: " + total);
                        break;
                    case 5:
                        Console.WriteLine("Saindo do programa\nAte mais!");
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
        static int TrataNumeroInteiro(string s)
        {
            int n = 0;
            try
            {
                Console.WriteLine(s + ":");
                n = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Deve-se inserir um " + s +"!!");
                while (n.Equals(0))
                {
                    n = TrataNumeroInteiro(s);
                }
            }
            return n;
        }
        static double TrataNumeroDouble(string s)
        {
            double n = 0.0;
            try
            {
                Console.WriteLine(s + ":");
                n = double.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Deve-se inserir um " + s +"!!");
                while (n.Equals(0))
                {
                    n = TrataNumeroDouble(s);
                }
            }
            return n;
        }
        static string TrataString(string s)
        {
            string n = "";
            Console.WriteLine(s + ":");
            n = Console.ReadLine();
            if (n.Equals(""))
            {
                Console.WriteLine("Deve-se inserir um " + s +"!!");
                while (n.Equals(""))
                {
                    n = TrataString(s);
                }
            }
            return n;
        }
    }
}
