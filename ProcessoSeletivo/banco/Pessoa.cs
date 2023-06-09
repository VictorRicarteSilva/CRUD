namespace ProcessoSeletivo.banco;

public class Pessoa
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }

    public Pessoa(string nome, string email, string telefone)
    {
        Nome = nome ?? throw new ArgumentNullException(nameof(nome));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Telefone = telefone ?? throw new ArgumentNullException(nameof(telefone));
    }
}