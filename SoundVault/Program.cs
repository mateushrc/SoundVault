// Sound Vault
string mensagemDeBoasVindas = "Boas vindas ao Sound Vault";
//List<string> listaDasMusicas = new List<string> { "welcome and goodbye", "Where Is My Mind?"};  
Dictionary<string, List<int>> musicasRegistradas = new Dictionary<string, List<int>>();
musicasRegistradas.Add("Where Is My Mind?", new List<int> { 10, 9, 8});
musicasRegistradas.Add("welcome and goodbye", new List<int> { 10 });

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░██╗░░░██╗░█████╗░██╗░░░██╗██╗░░░░░████████╗
██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗██║░░░██║██╔══██╗██║░░░██║██║░░░░░╚══██╔══╝
╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║╚██╗░██╔╝███████║██║░░░██║██║░░░░░░░░██║░░░
░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║░╚████╔╝░██╔══██║██║░░░██║██║░░░░░░░░██║░░░
██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝░░╚██╔╝░░██║░░██║╚██████╔╝███████╗░░░██║░░░
╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░░░░╚═╝░░░╚═╝░░╚═╝░╚═════╝░╚══════╝░░░╚═╝░░░
");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma música");
    Console.WriteLine("Digite 2 para mostrar todas as músicas");
    Console.WriteLine("Digite 3 para avaliar uma música");
    Console.WriteLine("Digite 4 para exibir a média de uma música");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarMusica();
            break;
        case 2:
            MostrarMusicasRegistradas();
            break;
        case 3:
            AvaliarUmaMusica();
            break;
        case 4:
            ExibirMedia();
            break;
        case -1:
            Console.WriteLine("\nTchau tchau :)");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarMusica()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das musicas");
    Console.Write("Digite o nome da musica que deseja registrar: ");
    string nomeDaMusica = Console.ReadLine()!;
    musicasRegistradas.Add(nomeDaMusica, new List<int>());
    Console.WriteLine($"\nA música {nomeDaMusica} foi registrada com sucesso!");
    Thread.Sleep(4000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarMusicasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as musicas registradas na nossa aplicação");

    //for (int i = 0; i < listaDasMusicas.Count; i++)
    //{
    //Console.WriteLine($"Música: {listaDasMusicas[i]}");
    //}

    foreach (string musica in musicasRegistradas.Keys)
    {
        Console.WriteLine($"Música: {musica}");
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();

}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaMusica()
{
    //digite qual música deseja avaliar
    // se a música existir no dicionario >> atribuir uma nota
    // senão, volta ao menu principal

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar música");
    Console.Write("Digite o nome da música que deseja avaliar: ");
    string nomeDaMusica = Console.ReadLine()!;
    if (musicasRegistradas.ContainsKey(nomeDaMusica))
    {
        Console.Write($"\nQual a nota que a música {nomeDaMusica} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        musicasRegistradas[nomeDaMusica].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a música {nomeDaMusica}");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA música {nomeDaMusica} não foi encontrada!");
        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }

}

void ExibirMedia()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir média da música");
    Console.Write("Digite o nome da música que deseja exibir a média: ");
    string nomeDaMusica = Console.ReadLine()!;
    if (musicasRegistradas.ContainsKey(nomeDaMusica))
    {
        List<int> notasDaMusica = musicasRegistradas[nomeDaMusica];
        Console.WriteLine($"\nA média da música {nomeDaMusica} é {notasDaMusica.Average()}.");
        Console.WriteLine("\nDigite uma tecla para votar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();

    }
    else
    {
        Console.WriteLine($"\nA música {nomeDaMusica} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

ExibirOpcoesDoMenu();