using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;//Imports para conexão com o banco de dados
using MySql.Data.MySqlClient;//Imports para realizar comandos no banco

namespace BancoDeDadosTI13N
{
    class DAO
    {
        MySqlConnection conexao;
        public string dados;
        public string resultado;
        // declara
        public int[] cod;
        public string[] nome;
        public string[] telefone;
        public string[] endereco;
        public int i;
        public string msg;
        public int contador = 0;
        //Contrutor
        public DAO(string nomeDoBancoDeDados)
        {
            conexao = new MySqlConnection("server=localhost;DataBase=" + nomeDoBancoDeDados + ";Uid=root;Password=;");
            try
            {
                conexao.Open();//Solicitando a entrada ao banco de dados
                Console.WriteLine("Entrei!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);
                conexao.Close();//Fechando a conexão com banco de dados
            }//fim da tentativa de conexão com o banco de dados
        }//fim do construtor

        //Criar o método INSERIR
        public void Inserir(string nome, string telefone, string endereco)
        {
            try
            {
                dados = "('','" + nome + "','" + telefone + "','" + endereco + "')";
                resultado = "Insert into Pessoa(codigo, nome, telefone, endereco) values" + dados;
                //Executar o comando resultado no banco de dados
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine(resultado + " Linha(s) Afetada(s)!");

            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu errado!\n\n" + e);

            }//fim do catch
        }//fim do método inserir


        public void PreencherVetor()
        {
            string query = "select * from pessoa";
            cod = new int[100];
            nome = new string[100];
            telefone = new string[100];
            endereco = new string[100];


            for ( i = 0; i < 100; i++)
            {
                cod[i] = 0;
                nome[i] = "";
                telefone[i] = "";
                endereco[i] = "";

            }//FIM DA REPETIÇÃO


        //CRIAR COMANDO

        MySqlCommand coletar = new MySqlCommand(query,conexao);
        //usar comando lendo os dados do banco
        MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0;
            while(leitura.Read())
            {
                cod[i] = Convert.ToInt32(leitura["codigo"]);
                nome[i] = leitura["nome"] + "";
                telefone[i] = leitura["telefone"] + "";
                endereco[i] = leitura["endereco"] + "";
                i++;
                contador++;
            }//Fim do while

            //FECHAR O DATAREADER
            leitura.Close();

        }//FIM DO PREECHER VETOR

        public string ConsultarTudo()
        {
            //PREECHER O VETOR
            PreencherVetor();
            msg = "";
            for(int i = 0; i < contador; i++)
            {
                msg += "\n\ncodigo:" + cod[i] + "Nome: " + nome[i] + ",Telefone" + telefone[i] + ", Endereço:" + endereco[i];
            }//FIM DO FOR
            return msg;

        }//FIM DO CONSULTAR TUDO
        public string ConsultarNome(int codigo)
        {
            PreencherVetor();
            for(int i=0; i < contador; i++)
            {
                if(codigo == cod[i])
                {
                    return nome[i];
                }
            }//FIM  DO FOR
            return "codigo não encotrada!";
        }// FIM DO CONSULTARNOME
        public string ConsultarTelefone(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return telefone[i];
                }
            }//FIM  DO FOR
            return "codigo não encotrada!";
        }// FIM DO CONSULTARTELEFONE
        public string ConsultarEndereco(int codigo)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (codigo == cod[i])
                {
                    return endereco[i];
                }
            }//FIM  DO FOR
            return "codigo não encotrada!";
        }// FIM DO CONSULTARENDERECO
        public void Atualizar(string campo, string novoDado, int codigo)
        {
            try
            {
                resultado = "update pessoa set " + campo + " = '" + novoDado + "' where codigo ='" + codigo + "'";
                // EXECULTAR O SCRIPT
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                Console.WriteLine("Dado Atualizado com Sucesso!");

            }
            catch (Exception e)
            {
                Console.WriteLine("Algo deu Errado!" + e);
            }
        }//FIM DO ATUALIZAR
        public void Deletar(int codigo)
        {
            resultado = "delete from pessoa where codigo = '" + codigo + "'";
            // EXECULTAR O COMANDO
            MySqlCommand Sql = new MySqlCommand(resultado, conexao);
            resultado = "" + Sql.ExecuteNonQuery();
            //MENSAGEM
            Console.WriteLine("Dados Excluido com Sucesso!");

        }// FIM DO DELETAR
    }//fim da classe
}//fim do projeto
