
Menu();

static void Menu()
{
    Console.Clear();
    Console.WriteLine("Escolha uma opção");
    Console.WriteLine("1 - Abrir arquivo");
    Console.WriteLine("2 - Criar novo arquivo");
    Console.WriteLine("0 - Sair");
    short op = short.Parse(Console.ReadLine());

    switch (op)
    {
        case 0: System.Environment.Exit(0); break;
        case 1: Abrir(); break;
        case 2: Editar(); break;
        default: Menu(); break;
    }
}

static void Abrir()
{
Console.Clear();
Console.WriteLine("Qual o caminho do arquivo?");
string path = Console.ReadLine();

using (var arquivo = new StreamReader(path))
{
    string texto = arquivo.ReadToEnd();
    Console.WriteLine(texto);
}
Console.WriteLine("");
Console.ReadLine();
Menu();
}

static void Editar()
{
    Console.Clear();
    Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
    Console.WriteLine("----------------");
    string texto = "";

    do
    {
        texto += Console.ReadLine();
        texto += Environment.NewLine;
    }
    while (Console.ReadKey().Key != ConsoleKey.Escape);

    Salvar(texto);
}

static void Salvar(string texto)
{
    Console.Clear();
    Console.WriteLine("Qual caminho para salvar o arquivo?");
    var path = Console.ReadLine();

    using var arquivo = new StreamWriter(path);
    {
        arquivo.Write(texto);
    }

    Console.WriteLine($"Arquivo {path} salvo com sucesso");
    Console.ReadLine();
    Menu();
}