using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendaDeLivros2
{
    class Menu
    {
        public int opcao;
        DAO dao;
        Cliente cliente;

        public Menu()//Construtor
        {
            opcao = 0;
            dao = new DAO();
            cliente = new Cliente();
            
            

        }//Fim do construtor

        public void MostrarOpcoes()
        {
            Console.WriteLine("\n\n Escolha uma das opções abaixo: \n\n" +
                "\n1. Cadastrar Novo cliente" +
                "\n2. Cadastrar Novo livro" +
                "\n3. Consultar Todos os livros" +
                "\n4. Consultar todos os clientes" +
                "\n5. Consultar Individualmente os livros" +
                "\n6. Consultar Individualmente os clientes" +
                "\n7. Atualizar livro" +
                "\n8. Atualizar cliente" +
                "\n9. Deletar cliente" +
                "\n10. Deletar livro" +
                "\n11. **EFETUAR COMPRA COM ISBN DO LIVRO**" +
                "\n0. Sair");
            opcao = Convert.ToInt32(Console.ReadLine());
        }//Fim do metodo

        public void Executar()
        {
            do
            {
                MostrarOpcoes(); // Mostrar menu ao usuario


                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Informe seu nome: ");
                        string nome = Console.ReadLine();

                        Console.WriteLine("\nInforme seu telefone: ");
                        string telefone = Console.ReadLine();

                        Console.WriteLine("\nInforme seu endereço: ");
                        string endereco = Console.ReadLine();

                        Console.WriteLine("Informe seu novo login: ");
                        string login = Console.ReadLine();

                        Console.WriteLine("\nInforme sua nova senha: ");
                        string senha = Console.ReadLine();

                        Console.WriteLine("\nInforme sua data de nascimento dd/mm/aaaa: ");
                        string dataDeNascimento = Console.ReadLine();

                        //executar metodo inserir
                        cliente.Inserir(nome, telefone, endereco, login, senha, dataDeNascimento);
                        break;


                    case 2:

                        Console.WriteLine("\nInforme o titulo do livro: ");
                        string titulo = Console.ReadLine();

                        Console.WriteLine("\nano do livro: ");
                        string ano = Console.ReadLine();

                        Console.WriteLine("Informe o valor do livro: ");
                        string valor = Console.ReadLine();

                        Console.WriteLine("\nInforme a quantidade deste livro no estoque: ");
                        int quantidade = Convert.ToInt32(Console.ReadLine());

                        dao.Inserir(titulo, ano, valor, quantidade);
                        break;


                    case 3:
                        Console.WriteLine(dao.ConsultarTudo());
                        break;


                    case 4:
                        Console.WriteLine(cliente.ConsultarTudo());
                        break;

                    case 5:
                        Console.WriteLine("Informe o isbn que deseja consultar: ");
                        int isbn2 = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Titulo: " + dao.ConsultarTitulo(isbn2) +
                            "\nAno: " + dao.ConsultarAno(isbn2) +
                            "\nValor: " + dao.ConsultarValor(isbn2) + 
                            "\nQuantidade: " + dao.ConsultarQuantidade(isbn2));
                        break;


                    case 6:
                        Console.WriteLine("Informe o codigo do cliente que deseja consultar: ");
                        int codigo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Nome: " + cliente.ConsultarNome(codigo) +
                            "\nTelefone: " + cliente.ConsultarTelefone(codigo) +
                            "\nLogin: " + cliente.ConsultarLogin(codigo) +
                            "\nSenha: " + "******"+
                            "\nEndereço: " + cliente.ConsultarEndereco(codigo));
                        break;


                    case 7:
                        Console.WriteLine("Qual campo deseja atualizar? ");
                        string campo = Console.ReadLine();
                        Console.WriteLine("Qual o novo dado? ");
                        string novoDado = Console.ReadLine();
                        Console.WriteLine("Qual isbn do livro deseja atualizar? ");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        dao.Atualizar(campo, novoDado, codigo);
                        break;


                    case 8:
                        Console.WriteLine("Qual campo deseja atualizar? ");
                        string campo2 = Console.ReadLine();
                        Console.WriteLine("Qual o novo dado? ");
                        string novoDado2 = Console.ReadLine();
                        Console.WriteLine("Qual código da pessoa que deseja atualizar? ");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        cliente.Atualizar(campo2, novoDado2, codigo);
                        break;


                    case 9:
                        Console.WriteLine("Digite o codigo do cliente que deseja Excluir");
                        codigo = Convert.ToInt32(Console.ReadLine());

                        cliente.Deletar(codigo);
                        break;

                    case 10:
                        
                        Console.WriteLine("Digite o isbn do livro que deseja Excluir");
                        int codigo2 = Convert.ToInt32(Console.ReadLine());
                        
                        dao.Deletar(codigo2);
                        break;

                    case 11:
                        dao.Compra();
                        break;
                    case 0:
                        Console.WriteLine("\nObrigado!");
                        break;

                    default:
                        Console.WriteLine("\nDigite uma opção valida!");
                        break;

                }//Fim do switch_case



            } while (opcao != 0);


        }//Fim Executar

    }//Fim da classe
}//Fim do projeto
