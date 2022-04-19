using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace VendaDeLivros2
{
    class DAO
    {
        //Variaveis
        MySqlConnection conexao;

        public int i;

        public string dadosDoLivro;
        public string resultado;

        public int[] isbn;
        public string[] titulo;
        public string[] ano;
        public string[] valor;
        public int[] quantidade;
        public int contador = 0;
        public string msg;
        public int guardar = 0;
        public int codLivro = 0;
        public Boolean flag;


        public DAO()
        {
            flag = false;
            conexao = new MySqlConnection("server=localhost;DataBase=VendaDeLivros2;Uid=root;Password=;");
            try
            {
                conexao.Open(); //Solicitando entrada ao BD
                Console.WriteLine("Dados carregados com sucesso!");
            }
            catch(Exception e)
            {
                Console.WriteLine("Xiiii, algo deu errado :(...Tente novamente mais tarde\n\n" + e);
                conexao.Close(); //Fechando conexão com BD
            }//Fim da tentativa de conexão com o BD
        }//Fim do construtor

        public void Inserir(string titulo, string ano, string valor, int quantidade)
        {
            try
            {
                dadosDoLivro = "('', '" + titulo + "','" + ano + "','" + valor + "','" + quantidade + "')";
                resultado = "Insert into Estoque(isbn, titulo, ano, valor, quantidade) values" + dadosDoLivro;



                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + "Dados inseridos!");

                flag = false;

            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!" + e);
            }//Fim do catch
        }//Fim do Inserir



        public void PreencherVetor()
        {
            string querry = "select * from Estoque";



            isbn = new int[100];
            titulo = new string[100];
            ano = new string[100];
            valor = new string[100];
            quantidade = new int[100];



            for (i = 0; i < 100; i++)
            {
                isbn[i] = 0;
                titulo[i] = "";
                ano[i] = "";
                valor[i] = "";
                quantidade[i] = 0;
            }//Fim do for



            MySqlCommand coletar = new MySqlCommand(querry, conexao);

            MySqlDataReader leitura = coletar.ExecuteReader();



            i = 0;



            while (leitura.Read()) 
            {
                isbn[i] = Convert.ToInt32(leitura["Isbn"]);
                titulo[i] = leitura["titulo"] + "";
                ano[i] = leitura["ano"] + "";
                valor[i] = leitura["valor"] + "";
                quantidade[i] = Convert.ToInt32(leitura["quantidade"]);
                i++;
                contador++;
            }//Fim do while
            leitura.Close();



        }//Fim do PreencherVetor



        public string ConsultarTudo()
        {
            PreencherVetor();
            if (flag == false)
            {
                msg = "";
                for (int i = 0; i < contador; i++)
                {
                    flag = true;
                    msg += "\n\nIsbn: " + isbn[i] + ", Titulo: " + titulo[i] + ", Ano: " + ano[i] + ", Valor: " + valor[i] + ", Quantidade: " + quantidade[i];
                }//fim do for
                
            }
                return msg;

        }//Fim do consultarTudo
        public string ConsultarTitulo(int isbn2)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++) 
            {
                if (isbn2 == isbn[i]) 
                {
                    return titulo[i];
                }
            }//fim do for
            return "Titulo não encontrado!";
        }//fim do consultarLivro



        public string ConsultarAno(int isbn2)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++) 
            {
                if (isbn2 == isbn[i]) 
                {
                    return ano[i];
                }
            }//fim do for
            return "Ano não encontrado!";
        }//fim do consultarLivro



        public string ConsultarValor(int isbn2)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++) 
            {
                if (isbn2 == isbn[i]) 
                {
                    return valor[i];
                }
            }//fim do for
            return ("Valor não encontrado!");
        }//fim do consultarLivro




        public int ConsultarQuantidade(int isbn2)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++) 
            {
                if (isbn2 == isbn[i]) 
                {
                    return quantidade[i];
                }
            }//fim do for
            return Convert.ToInt32("Quantidade não encontrada!");
        }//fim do consultarLivro



        public void Atualizar(string campo, string novoDado, int codigo)
        {
            try
            {
                resultado = "update Estoque set " + campo + " = '" + novoDado + "'where isbn = '" + codigo + "'";
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Dado Atualizado com sucesso!");
            }



            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado TRIKAS!" + e);
            }
        }//Fim do atualizar



        public void Deletar(int codigo2)
        {
            resultado = "delete from Estoque where isbn = '" + codigo2 + "'";



            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();



            Console.WriteLine("Dados excluidos com sucesso!");
        }//Fim do deletar



        public void Compra()
        {
            
            Console.WriteLine("Digite o isbn do livro");
            codLivro = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Deseja comprar o Livro? Digite 1 para Sim, 0 para Não");
            guardar = Convert.ToInt32(Console.ReadLine());
            if (guardar == 1)
            {
                Console.WriteLine("\nCompra efetuada! Sua compra chegará no endereço cadastrado, se precisar tirar alguma duvida entre em contato com a gente VendaDeLivros@vdl.com");
            }
            else
            {

                Console.WriteLine("\nCompra CANCELADA!");
              
            }//Fim else

        }//Fim metodo compra



    }//Fim da classe
}//fim do projeto   
    