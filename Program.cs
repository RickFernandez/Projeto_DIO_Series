namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        VizualizarSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = obterOpcaoUsuario();
            }
            
            Console.WriteLine("DIO Séries agradece por utilizar o nosos serviço.");
            Console.WriteLine();
        }

        private static string obterOpcaoUsuario()
        {
            Console.WriteLine("==============================");
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine();
            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Vizualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine("==============================");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Séries disponíveis:");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                Console.WriteLine();
                return;
            }
            else
            {
                foreach (var serie in lista)
                {
                    var excluido = serie.retornaExcluido();

                    Console.WriteLine("#ID {0}: {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "- *EXCLUÍDO*" : ""));
                    Console.WriteLine();
                }
            }

        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }   

            Console.WriteLine();
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Digite o Ano de início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);

            repositorio.Insere(novaSerie);
            Console.WriteLine();
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine();
            
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }   

            Console.WriteLine();
            Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Digite o Ano de início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao,
                                        ano: entradaAno);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
            Console.WriteLine();
        }

        private static void VizualizarSerie()
        {
            Console.WriteLine("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
            Console.WriteLine();
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }
    }
}