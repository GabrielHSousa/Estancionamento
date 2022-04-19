using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BancoDeDadosTI13N
{
    class Menu
    {
        DAO dao;
        public int opcao;
        public Menu()
        {
            opcao = 0;
            dao = new DAO("BancoDeDadosTI13N");
        }//End Constructor.


        //Menu!
        public void MostrarOpcoes()
        {
            Console.WriteLine("\n\nEscolha uma das opções abaixo: \n\n" +
            "\n1. Cadastrar" +
            "\n2. Consultar Tudo" +
            "\n3. Consultar Individual" +
            "\n4. Atualizar" +
            "\n5. Excluir");

            opcao = Convert.ToInt32(Console.ReadLine());
        }//End Menu.



        public void Executar() 
        {
            do

            {
                MostrarOpcoes(); //Mostrando o menu para o cliente/usuário

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Informe seu nome: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("\nInforme seu telefone: ");
                        string telefone = Console.ReadLine();
                        Console.WriteLine("\nInforme seu endereço: ");
                        string endereco = Console.ReadLine();
                        //Executar o método inserir
                        dao.Inserir(nome, telefone, endereco);
                        break;
                    case 2:
                        //CONSULTAR OS DADOS 
                        Console.WriteLine(dao.ConsultarTudo());
                        break;
                    case 3:
                        // CONSULTAR INDIVIDUAL
                        Console.WriteLine("Informe o codigo que deseja Consultar");
                        int codigo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Nome:" + dao.ConsultarNome(codigo) + "\nTelefone:" + dao.ConsultarTelefone(codigo) + "\nEndereço:" + dao.ConsultarEndereco(codigo));
                        break;
                    case 4:
                        // ATUALIZAR
                        Console.WriteLine("Qual tabela deseja atualizar?");
                        string campo = Console.ReadLine();
                        Console.WriteLine("Qual o novo dado?");
                        string novoDado = Console.ReadLine();
                        Console.WriteLine("Qual o codigo da pessoa que deseja atualizar?");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        dao.Atualizar(campo, novoDado, codigo);
                        break;
                    case 5:
                        //DELETAR
                        Console.WriteLine("Informe o codigo que deseja deletar");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        //USAR O METODO DA CLASSE DAO
                        dao.Deletar(codigo);
                        break;
                    case 0:
                        Console.WriteLine("Obrigado!");
                        break;
                    default:
                        Console.WriteLine("Codigo digitado não válido!");
                        break;
                }// End Switch Case.
            } while (opcao != 0);
        }//End Method.
    }//FIM DA CLASSE
}//FIM DO POGRAMA