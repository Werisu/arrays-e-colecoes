using curso_alura_trabalhando_com_arrays_e_colecoes.account;
using curso_alura_trabalhando_com_arrays_e_colecoes.bytebank.Util;
using System.Collections;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Arrays em C#
//TestaArrayInt();
//TestaBuscarPalavra();

void TestaArrayInt()
{
    int[] idades = new int[5] { 30,40,17,21,18 };

    Console.WriteLine($"Tamanho do Array {idades.Length}");

    int acumulador = 0;
    for (int i = 0; i < idades.Length; i++)
    {
        int idade = idades[i];
        Console.WriteLine($"ínidice [{i}] = {idade}");
        acumulador += idade;
    }

    int media = acumulador / idades.Length;
    Console.WriteLine($"Média de idades = {media}");
}

void TestaBuscarPalavra()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0; i < arrayDePalavras.Length; i++)
    {
        Console.WriteLine($"Digite {i+1}ª Palavra: ");
        arrayDePalavras[i] = Console.ReadLine();
    }

    Console.WriteLine("Digite palavra a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach (string palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada = {busca}");
            break;
        }
    }
}

//Array amostra = Array.CreateInstance(typeof(double), 5);

void TestaArrayDeContasCorrentes()
{
    ListaDeContasCorrentes lista = new ListaDeContasCorrentes();
    lista.Adicionar(new ContaCorrente(874));
    lista.Adicionar(new ContaCorrente(874));
    lista.Adicionar(new ContaCorrente(874));
    lista.Adicionar(new ContaCorrente(874));
    lista.Adicionar(new ContaCorrente(874));
    lista.Adicionar(new ContaCorrente(874));
    var contaDoAndre = new ContaCorrente(963);
    lista.Adicionar(contaDoAndre);
    lista.ExibeLista();
    Console.WriteLine("==========================");
    lista.Remover(contaDoAndre);
    lista.ExibeLista();
}

//TestaArrayDeContasCorrentes();
#endregion

ArrayList _listaDeContas = new ArrayList();

AtendimentoCliente();
void AtendimentoCliente()
{
    char opcao = '0';
    while (opcao != '6')
    {
        Console.Clear();
        Console.WriteLine("================================");
        Console.WriteLine("=== Atendimento           ===");
        Console.WriteLine("===1 - Cadastrar Conta    ===");
        Console.WriteLine("===2 - Lista Conta        ===");
        Console.WriteLine("===3 - Remover Conta      ===");
        Console.WriteLine("===4 - Ordenar Conta      ===");
        Console.WriteLine("===5 - Pesquisar Conta    ===");
        Console.WriteLine("===6 - Sair do Sistema    ===");
        Console.WriteLine("================================");
        Console.WriteLine("\n\n");
        Console.WriteLine("Digite a opção desejada: ");
        opcao = Console.ReadLine()[0];
        switch (opcao)
        {
            case '1': CadastrarConta();
                break;
            case '2': ListarContas();
                break;
            default:
                break;
        }
    }
}

void ListarContas()
{
    Console.Clear();
    Console.WriteLine("================================");
    Console.WriteLine("===     LISTA DE CONTAS      ===");
    Console.WriteLine("================================");
    Console.WriteLine("\n");
    if (_listaDeContas.Count <=0 )
    {
        Console.WriteLine("... Não há contas cadastradas! ...");
        Console.ReadKey();
        return;
    }
    foreach (ContaCorrente item in _listaDeContas)
    {
        Console.WriteLine("=== Dados da Conta ===");
        Console.WriteLine("Número da Conta : "+item.Conta);
        Console.WriteLine("Número da Conta : "+item.Saldo);
        Console.WriteLine("Titular da Conta: "+item.Titular.Nome);
        Console.WriteLine("CPF do Titular  : "+item.Titular.Cpf);
        Console.WriteLine("Profissão do Titular: "+item.Titular.Profissao);
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.ReadKey();
    }
}
void CadastrarConta()
{
    Console.Clear();
    Console.WriteLine("================================");
    Console.WriteLine("===    CADASTRO DE CONTAS    ===");
    Console.WriteLine("================================");
    Console.WriteLine("\n");
    Console.WriteLine("===  Informe dados da conta  ===");
    
    Console.Write("Número da Agência: ");
    int numeroAgencia = int.Parse(Console.ReadLine());

    ContaCorrente conta = new ContaCorrente(numeroAgencia);

    Console.Write("Número da conta: ");
    conta.Conta = Console.ReadLine();

    Console.Write("Informe o saldo inicial: ");
    conta.Saldo = double.Parse(Console.ReadLine());

    Console.Write("Informe nome do Titular: ");
    conta.Titular.Nome = Console.ReadLine();

    Console.Write("Informe CPF do Titular: ");
    conta.Titular.Cpf = Console.ReadLine();

    Console.Write("Informe Profissão do Titular: ");
    conta.Titular.Profissao = Console.ReadLine();

    _listaDeContas.Add(conta);
    Console.WriteLine("... Conta cadastrada com sucesso! ...");
    Console.ReadKey();
}