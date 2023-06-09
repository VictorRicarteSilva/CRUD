using System.Data;
using System.Data.SQLite;
namespace ProcessoSeletivo.banco;

public class PessoaRepository
{
    private static SQLiteConnection? Conexao { get; set; }

    public static SQLiteConnection ConexaoBanco()
    {
        Conexao = new SQLiteConnection(
            "Data Source=D:\\CRUD\\ProcessoSeletivo\\ProcessoSeletivo\\banco\\BancoDados.sqlite");
        Conexao.Open();
        return Conexao;
    }

    public static void CriarPessoa(Pessoa pessoa)
    {
        try
        {
            using (var cmd = ConexaoBanco().CreateCommand())
            {
                cmd.CommandText = "INSERT INTO Pessoa (Nome, Email, Telefone) VALUES (@Nome, @Email, @Telefone)";
                cmd.Parameters.AddWithValue("@Nome", pessoa.Nome);
                cmd.Parameters.AddWithValue("@Email", pessoa.Email);
                cmd.Parameters.AddWithValue("@Telefone", pessoa.Telefone);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Novo usuário inserido!");
                Console.WriteLine();
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine("Erro ao inserir usuário!");
            Console.WriteLine(exception);
            throw;
        }
    }

    public static DataTable ListarPessoas()
    {
        SQLiteDataAdapter adaptador;
        DataTable tabela = new DataTable();
        try
        {
            using (var cmd = ConexaoBanco().CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Pessoa";
                adaptador = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                adaptador.Fill(tabela);
                return tabela;
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }

    public static DataTable ObterPessoaPorId(int id)
    {
        SQLiteDataAdapter adaptador;
        DataTable tabela = new DataTable();
        try
        {
            using (var cmd = ConexaoBanco().CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Pessoa WHERE IdPessoa = @IdPessoa";
                cmd.Parameters.AddWithValue("@IdPessoa", id);
                adaptador = new SQLiteDataAdapter(cmd.CommandText, ConexaoBanco());
                adaptador.Fill(tabela);
                return tabela;
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }

    public static void AtualizarPessoa(Pessoa pessoa, int id)
    {
        try
        {
            using (var cmd = ConexaoBanco().CreateCommand())
            {
                cmd.CommandText =
                    "UPDATE Pessoa SET Nome = @NovoNome, Email = @NovoEmail, Telefone = @NovoTelefone WHERE IdPessoa = @id";
                cmd.Parameters.AddWithValue("@NovoNome", pessoa.Nome);
                cmd.Parameters.AddWithValue("@NovoEmail", pessoa.Email);
                cmd.Parameters.AddWithValue("@NovoTelefone", pessoa.Telefone);
                cmd.Parameters.AddWithValue("@NovoTelefone", pessoa.Telefone);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Usuário {pessoa.Nome} foi alterado com sucesso!");
                Console.WriteLine();
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Usuário {pessoa.Nome} não foi alterado!");
            Console.WriteLine(exception);
            throw;
        }
    }

    public static void ExcluirPessoa(int id)
    {
        try
        {
            using (var cmd = ConexaoBanco().CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Pessoa WHERE IdPessoa = @IdPessoa";
                cmd.Parameters.AddWithValue("@IdPessoa", id);
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Usuário foi deletado com sucesso!");
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Usuário foi deletado com sucesso!");
            Console.WriteLine(exception);
            throw;
        }
    }
}
    
    