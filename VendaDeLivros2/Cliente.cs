using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace VendaDeLivros2
{
    
    class Cliente
    {
        MySqlConnection conexao;
        public string dados;
        public string resultados;
        public int i;
        public int contador = 0;
        public string msg;
        DAO dao = new DAO();
        //Declarando vetores
        public int[] codigoCliente;
        public string[] nome;
        public string[] telefone;
        public string[] endereco;
        public string[] login;
        public string[] senha;
        public string[] dataDeNascimento;
        public Boolean flag;


        //Criar metodo inserir

            public Cliente()
            {
            flag = false;

            conexao = new MySqlConnection("server=localhost;DataBase=VendaDeLivros2;Uid=root;Password=;");
            try
            {
                conexao.Open();         // Solicitando entrada ao banco de dados
                Console.WriteLine("Entrei garai!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado irmãozin!\n\n" + e);
                conexao.Close();          //Fechando conexão com o banco de dados
            }//Fim da tentativa de conexão com o banco de dados


        }//Fim cliente
        public void Inserir(string login, string senha, string nome, string endereco, string telefone, string dataDeNascimento)
        {
            

            try
            {
                dados = "('','" + login + "','" + senha + "','" + nome + "','" + endereco + "','" +
                    telefone + "','" + dataDeNascimento + "')";

                resultados = "insert into Cliente(codigoCliente, login, senha, nome, endereco, telefone, dataDeNascimento) values" + dados;

                //Executar o comando resultado no BD
                MySqlCommand sql = new MySqlCommand(resultados, conexao);
                resultados = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultados + " Dados inseridos com sucesso!");
                flag = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Xiiii, algo deu errado :(...Tente novamente mais tarde\n\n" + e);
            }//Fim try e catch
        }//Fim do metodo inserir

        public void PreencherVetor()
        {
            string query = "select * from Cliente"; // Coletando dados do BD

            codigoCliente = new int[100];
            login = new string[100];
            senha = new string[100];
            nome = new string[100];
            endereco = new string[100];
            telefone = new string[100];
            dataDeNascimento = new string[100];

            //Dando valores iniciais a eles
            for(i = 0; i < 100; i++)
            {
                codigoCliente[i] = 0;
                login[i] = "";
                senha[i] = "";
                nome[i] = "";
                telefone[i] = "";
                endereco[i] = "";
                dataDeNascimento[i] = "";
            }//Fim da repetição

            //Criar comandos para coleta
            MySqlCommand coletar = new MySqlCommand(query, conexao);

            //Comando para leros dados do BD
            MySqlDataReader leitura = coletar.ExecuteReader();
            i = 0;
            contador = 0;
            while (leitura.Read())
            {
                codigoCliente[i] = Convert.ToInt32(leitura["codigoCliente"]);
                login[i] = leitura["login"] + "";
                senha[i] = leitura["senha"] + "";
                nome[i] = leitura["nome"] + "";
                telefone[i] = leitura["telefone"] + "";
                endereco[i] = leitura["endereco"] + "";
                dataDeNascimento[i] = leitura["dataDeNascimento"] + "";
                i++;
                contador++;
            }//Fim do While

            //Fechar o DataReader
            leitura.Close();

        }//Fim do preencher vetor

        public string ConsultarTudo()
        {
            //Preencher o vetor
            PreencherVetor();
            
            if (flag == false){
                msg = "";
                for (int i = 0; i < contador; i++)
                {
                    flag = true;
                    msg += "\n\nCódigo: " + codigoCliente[i] + ", Nome: " + nome[i] + ", login: " + login[i] + ", telefone: " + telefone[i] + ", Endereço: " + endereco[i];
                }//Fim do for
            }

            return msg;

        }//Fim do ConsultarTudo

        public string ConsultarNome(int codigo)
        {
            PreencherVetor();
            for(int i=0; i < contador; i++)
            {
                if(codigo == codigoCliente[i])
                {
                    return nome[i];
                }//Fim If
            }//Fim fro

            return "Xiiii....Código não encontrado :(";
        }//Fim ConsultarNome

        public string ConsultarTelefone(int codigo)
        {
            PreencherVetor();
            for(int i=0; i < contador; i++)
            {
                if(codigo == codigoCliente[i])
                {
                    return telefone[i];
                }//Fim if
            }//Fim for

            return "Xiiii....Código não encontrado :(";
        }//Fim ConsultarTelefone

        public string ConsultarLogin(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == codigoCliente[i])
                {
                    return login[i];
                }//Fim if
            }//Fim for

            return "Xiiii....Código não encontrado :(";
        }//Fim ConsultarLogin

        public string ConsultarEndereco(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == codigoCliente[i])
                {
                    return endereco[i];
                }//Fim if
            }//Fim for

            return "Xiiii....Código não encontrado :(";
        }//Fim ConsultarEndereco

        public void Atualizar(string campo2, string novoDado2, int codigo)
        {
            try
            {
                resultados = "update cliente set " + campo2 + " = '" + novoDado2 + "' where codigo = '" + codigo + "'";

                //Executar script no BD
                MySqlCommand sql = new MySqlCommand(resultados, conexao);
                resultados = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Dados atualizados com sucesso! :-)");
            }//Fim try
            catch(Exception e)
            {
                Console.WriteLine("Xiii...algo deu errado :(\n\n\n" + e);
            }//Fim catch
        }//Fim Atualizar

        public void Deletar(int codigo)
        {
            
            resultados = "delete from cliente where codigoCliente = '" + codigo + "'";
              //Executar o comando
            MySqlCommand sql = new MySqlCommand(resultados, conexao);

            resultados = "" + sql.ExecuteNonQuery();
             //Mensagem...
            Console.WriteLine("Dados Excluídos com sucesso!");


        }//Fim deletar


}//Fim da classe

}//Fim do projeto
