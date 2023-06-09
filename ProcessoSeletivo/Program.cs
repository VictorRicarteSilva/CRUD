using System.Data;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using ProcessoSeletivo.banco;

while (true)
{
    int menu;
    Console.WriteLine("==//CRUD//==");
    Console.WriteLine("[0] Criar;");
    Console.WriteLine("[1] Listar;");
    Console.WriteLine("[2] Obter por Id;");
    Console.WriteLine("[3] Atualizar;");
    Console.WriteLine("[4] Deletar;");
    Console.WriteLine("[5] Sair;");
    menu = Convert.ToInt32(Console.ReadLine());
    switch (menu)
    {
        case 0:
            Console.WriteLine("Insira os dados: ");
            string nome = Console.ReadLine() ?? throw new ArgumentNullException(nameof(nome));         // {
            string email = Console.ReadLine() ?? throw new ArgumentNullException(nameof(email));       // Lança uma exception caso o usuário não insirar um valor para as strings
            string telefone = Console.ReadLine() ?? throw new ArgumentNullException(nameof(telefone)); // }
            Pessoa pessoa = new Pessoa(nome, email, telefone); // Instancia uma nova pessoa
            PessoaRepository.CriarPessoa(pessoa); // Insere a mesma no banco de dados
            break;
        case 1:
            Console.WriteLine("Lista De Pessoas:");
            DataTable lista = PessoaRepository.ListarPessoas(); // Cria a tabela lista que recebe todas as linhas e colunas da tabela Pessoa
            // Percorre as linhas da tabela
            foreach (DataRow row in lista.Rows)
            {
                // Percorre as colunas da linha atual
                foreach (DataColumn col in lista.Columns)
                {
                    Console.WriteLine($"{col.ColumnName}: {row[col]}");
                }

                Console.WriteLine(); // Linha em branco entre as entradas 
            }
            break;
        case 2:
            Console.Write("Insira o Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            DataTable pessoaPorId = PessoaRepository.ObterPessoaPorId(id); // Cria a tabela que vai receber a linha e as colunas da pessoa definida pelo id
            // Percorre as linhas da tabela
            foreach (DataRow row in pessoaPorId.Rows)
            {
                // Percorre as colunas da linha atual
                foreach (DataColumn col in pessoaPorId.Columns)
                {
                    Console.WriteLine($"{col.ColumnName}: {row[col]}");
                }

                Console.WriteLine(); // Linha em branco entre as entradas de pessoa
            }
            break;
        case 3:
            Console.WriteLine("Qual o Id da pessoa a ter os dados atualizados? ");
            int aux = Convert.ToInt32(Console.ReadLine()); // seleciona a pessoa pelo Id
            Console.WriteLine("Insira os novos dados: ");
            nome = Console.ReadLine() ?? throw new ArgumentNullException(nameof(nome));         // {
            email = Console.ReadLine() ?? throw new ArgumentNullException(nameof(email));       // Lança a exception caso não seja dado valores as variaveis
            telefone = Console.ReadLine() ?? throw new ArgumentNullException(nameof(telefone)); // }
            Pessoa novosDados = new Pessoa(nome, email, telefone); // Instancia as novas informações
            PessoaRepository.AtualizarPessoa(novosDados, aux); // Atualiza no banco de dados
            break;
        case 4:
            Console.Write("Insira o Id: ");
            id = Convert.ToInt32(Console.ReadLine());
            PessoaRepository.ExcluirPessoa(id);
            break;
        case 5:
            Console.WriteLine("Encerrando o programa...");
            return;
        default:
            Console.WriteLine("Opção inválida!");
            continue;
    }
}