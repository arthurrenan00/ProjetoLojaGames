using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoLojaGames.Repositorio;
using MySql.Data.MySqlClient;
using ProjetoLojaGames.Models;

namespace ProjetoLojaGames.Repositorio
{
    public class Acoes
    {
        Conexao con = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        // AÇÕES DO JOGO
        public void CadastrarJogo(Jogo jogo)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbl_Jogo values(@codjogo, @nomejogo, @versaojogo, @desenvolvedor, @generojogo," +
                " @faixaetaria, @plataforma, @anolanc, @sinopse)", con.ConectarBd());
            cmd.Parameters.Add("@codjogo", MySqlDbType.VarChar).Value = jogo.Cod_Jogo;
            cmd.Parameters.Add("@nomejogo", MySqlDbType.VarChar).Value = jogo.Nome_Jogo;
            cmd.Parameters.Add("@versaojogo", MySqlDbType.VarChar).Value = jogo.Versao_Jogo;
            cmd.Parameters.Add("@desenvolvedor", MySqlDbType.VarChar).Value = jogo.Desenvolvedor;
            cmd.Parameters.Add("@generojogo", MySqlDbType.VarChar).Value = jogo.Genero_Jogo;
            cmd.Parameters.Add("@faixaetaria", MySqlDbType.VarChar).Value = jogo.Faixa_Etaria;
            cmd.Parameters.Add("@plataforma", MySqlDbType.VarChar).Value = jogo.Plataforma;
            cmd.Parameters.Add("@anolanc", MySqlDbType.VarChar).Value = jogo.Ano_Lanc;
            cmd.Parameters.Add("@sinopse", MySqlDbType.VarChar).Value = jogo.Sinopse;
            cmd.ExecuteNonQuery();
            con.DesconectarBd();
        }

        public Jogo ListarCodJogo(int cod)
        {
            var comando = String.Format("select * from tbl_Jogo where Cod_Jogo = {0}", cod);
            MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBd());
            var DadosJogo = cmd.ExecuteReader();
            return ListCodJogo(DadosJogo).FirstOrDefault();
        }

        public List<Jogo> ListCodJogo(MySqlDataReader dt)
        {
            var AltAl = new List<Jogo>();
            while (dt.Read())
            {
                var AlTemp = new Jogo()
                {
                    Cod_Jogo = int.Parse(dt["codjogo"].ToString()),
                    Nome_Jogo = dt["nomejogo"].ToString(),
                    Versao_Jogo = dt["versaojogo"].ToString(),
                    Desenvolvedor = dt["desenvolvedor"].ToString(),
                    Genero_Jogo = dt["generojogo"].ToString(),
                    Faixa_Etaria = dt["faixaetaria"].ToString(),
                    Plataforma = dt["plataforma"].ToString(),
                    Ano_Lanc = int.Parse(dt["anolanc"].ToString()),
                    Sinopse = dt["sinopse"].ToString()
                };
                AltAl.Add(AlTemp);
            }

            dt.Close();
            return AltAl;
        }

        public List<Jogo> ListarJogo()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbl_Jogo", con.ConectarBd());
            var DadosJogos = cmd.ExecuteReader();
            return ListarTodosJogos(DadosJogos);
        }

        public List<Jogo> ListarTodosJogos(MySqlDataReader dt)
        {
            var TodosJogos = new List<Jogo>();
            while (dt.Read())
            {
                var JogoTemp = new Jogo()
                {
                    Cod_Jogo = int.Parse(dt["codjogo"].ToString()),
                    Nome_Jogo = dt["nomejogo"].ToString(),
                    Versao_Jogo = dt["versaojogo"].ToString(),
                    Desenvolvedor = dt["desenvolvedor"].ToString(),
                    Genero_Jogo = dt["generojogo"].ToString(),
                    Faixa_Etaria = dt["faixaetaria"].ToString(),
                    Plataforma = dt["plataforma"].ToString(),
                    Ano_Lanc = int.Parse(dt["anolanc"].ToString()),
                    Sinopse = dt["sinopse"].ToString()
                };
                TodosJogos.Add(JogoTemp);
            }
            dt.Close();
            return TodosJogos;
        }
        //

        //AÇÕES DO CLIENTE
        public void CadastrarCliente(Cliente cliente)
        {
            string data_sistema = Convert.ToDateTime(cliente.DtNasc_Cli).ToString("yyyy-MM-dd");
            MySqlCommand cmd = new MySqlCommand("insert into tbl_Cliente values(@nomecli, @cpfcli, @dtnasccli, @emailcli, @cellcli," +
                " @endecli)", con.ConectarBd());
            cmd.Parameters.Add("@nomecli", MySqlDbType.VarChar).Value = cliente.Nome_Cli;
            cmd.Parameters.Add("@cpfcli", MySqlDbType.VarChar).Value = cliente.Cpf_Cli;
            cmd.Parameters.Add("@dtnasccli", MySqlDbType.DateTime).Value = data_sistema;
            cmd.Parameters.Add("@emailcli", MySqlDbType.VarChar).Value = cliente.Email_Cli;
            cmd.Parameters.Add("@cellcli", MySqlDbType.VarChar).Value = cliente.Cell_Cli;
            cmd.Parameters.Add("@endecli", MySqlDbType.VarChar).Value = cliente.Ende_Cli;
            cmd.ExecuteNonQuery();
            con.DesconectarBd();
        }

        public Cliente ListarCodCli(int cod)
        {
            var comando = String.Format("select * from tbl_Cliente where Cpf_Cli = {0}", cod);
            MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBd());
            var DadosCliente = cmd.ExecuteReader();
            return ListCodCliente(DadosCliente).FirstOrDefault();
        }

        public List<Cliente> ListCodCliente(MySqlDataReader dt)
        {
            var AltAl = new List<Cliente>();
            while (dt.Read())
            {
                var AlTemp = new Cliente()
                {
                    Nome_Cli = dt["nomecli"].ToString(),
                    Cpf_Cli = dt["cpfcli"].ToString(),
                    DtNasc_Cli = DateTime.Parse(dt["dtnasccli"].ToString()),
                    Email_Cli = dt["emailcli"].ToString(),
                    Cell_Cli = dt["cellcli"].ToString(),
                    Ende_Cli = dt["endecli"].ToString(),
                };
                AltAl.Add(AlTemp);
            }

            dt.Close();
            return AltAl;
        }

        public List<Cliente> ListarCliente()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbl_Cliente", con.ConectarBd());
            var DadosCliente = cmd.ExecuteReader();
            return ListarTodosClientes(DadosCliente);
        }

        public List<Cliente> ListarTodosClientes(MySqlDataReader dt)
        {
            var TodosClientes = new List<Cliente>();
            while (dt.Read())
            {
                var ClienteTemp = new Cliente()
                {
                    Nome_Cli = dt["nomecli"].ToString(),
                    Cpf_Cli = dt["cpfcli"].ToString(),
                    DtNasc_Cli = DateTime.Parse(dt["dtnasccli"].ToString()),
                    Email_Cli = dt["emailcli"].ToString(),
                    Cell_Cli = dt["cellcli"].ToString(),
                    Ende_Cli = dt["endecli"].ToString(),
                };
                TodosClientes.Add(ClienteTemp);
            }
            dt.Close();
            return TodosClientes;
        }

        //

        //AÇÕES DO FUNCIONARIO

        public void CadastrarFunc(Funcionario func)
        {
            string data_sistema = Convert.ToDateTime(func.DtNasc_Func).ToString("yyyy-MM-dd");
            MySqlCommand cmd = new MySqlCommand("insert into tbl_Func values(@codfunc, @nomefunc, @cpffunc, @rgfunc, @dtnascfunc," +
                " @endefunc, @cellfunc, @emailfunc, @cargofunc)", con.ConectarBd());
            cmd.Parameters.Add("@codfunc", MySqlDbType.VarChar).Value = func.Cod_Func;
            cmd.Parameters.Add("@nomefunc", MySqlDbType.VarChar).Value = func.Nome_Func;
            cmd.Parameters.Add("@cpffunc", MySqlDbType.VarChar).Value = func.Cpf_Func;
            cmd.Parameters.Add("@rgfunc", MySqlDbType.VarChar).Value = func.Rg_Func;
            cmd.Parameters.Add("@dtnascfunc", MySqlDbType.DateTime).Value = data_sistema;
            cmd.Parameters.Add("@endefunc", MySqlDbType.VarChar).Value = func.Ende_Func;
            cmd.Parameters.Add("@cellfunc", MySqlDbType.VarChar).Value = func.Cell_Func;
            cmd.Parameters.Add("@emailfunc", MySqlDbType.VarChar).Value = func.Email_Func;
            cmd.Parameters.Add("@cargofunc", MySqlDbType.VarChar).Value = func.Cargo;
            cmd.ExecuteNonQuery();
            con.DesconectarBd();
        }

        public Funcionario ListarCodFunc(int cod)
        {
            var comando = String.Format("select * from tbl_Func where Cod_Func = {0}", cod);
            MySqlCommand cmd = new MySqlCommand(comando, con.ConectarBd());
            var DadosFunc = cmd.ExecuteReader();
            return ListCodFunc(DadosFunc).FirstOrDefault();
        }

        public List<Funcionario> ListCodFunc(MySqlDataReader dt)
        {
            var AltAl = new List<Funcionario>();
            while (dt.Read())
            {
                var AlTemp = new Funcionario()
                {
                    Cod_Func = int.Parse(dt["codfunc"].ToString()),
                    Nome_Func = dt["nomefunc"].ToString(),
                    Cpf_Func = dt["cpffunc"].ToString(),
                    Rg_Func = dt["rgfunc"].ToString(),
                    DtNasc_Func = DateTime.Parse(dt["dtnascfunc"].ToString()),
                    Ende_Func = dt["endefunc"].ToString(),
                    Cell_Func = dt["cellfunc"].ToString(),
                    Email_Func = dt["emailfunc"].ToString(),
                    Cargo = dt["cargofunc"].ToString(),
                };
                AltAl.Add(AlTemp);
            }

            dt.Close();
            return AltAl;
        }

        public List<Funcionario> ListarFuncionario()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbl_Func", con.ConectarBd());
            var DadosFunc = cmd.ExecuteReader();
            return ListarTodosFuncs(DadosFunc);
        }

        public List<Funcionario> ListarTodosFuncs(MySqlDataReader dt)
        {
            var TodosFuncs = new List<Funcionario>();
            while (dt.Read())
            {
                var FuncTemp = new Funcionario()
                {
                    Cod_Func = int.Parse(dt["codfunc"].ToString()),
                    Nome_Func = dt["nomefunc"].ToString(),
                    Cpf_Func = dt["cpffunc"].ToString(),
                    Rg_Func = dt["rgfunc"].ToString(),
                    DtNasc_Func = DateTime.Parse(dt["dtnascfunc"].ToString()),
                    Ende_Func = dt["endefunc"].ToString(),
                    Cell_Func = dt["cellfunc"].ToString(),
                    Email_Func = dt["emailfunc"].ToString(),
                    Cargo = dt["cargofunc"].ToString(),
                };
                TodosFuncs.Add(FuncTemp);
            }
            dt.Close();
            return TodosFuncs;
        }

    }
}