using System;

namespace DIO.Mensagens
{
    class Program
    {
        static MensagemRepositorio repositorio = new MensagemRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarMensagem();
						break;
					case "2":
						InserirMensagem();
						break;
					case "3":
						AtualizarMensagem();
						break;
					case "4":
						ExcluirMensagem();
						break;
					case "5":
						VisualizarMensagem();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por deixar uma mensagem.");
			Console.ReadLine();
        }

        private static void ExcluirMensagem()
		{
			Console.Write("Digite o id da Mensagem: ");
			int indiceMensagem = int.Parse(Console.WriteLine());

			repositorio.Exclui(indiceMensagem);
		}

        private static void VisualizarMensagem()
		{
			Console.Write("Digite o id da Mensagem: ");
			int indiceMensagem = int.Parse(Console.ReadLine());

			var Mensagem = repositorio.RetornaPorId(indiceMensagem);

			Console.WriteLine(Mensagem);
		}

        private static void AtualizarMensagem()
		{
			Console.Write("Digite o id da Mensagem: ");
			int indiceMensagem = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Tema)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tema), i));
			}
			Console.Write("Digite o Tema entre as opções acima: ");
			int entradaTema = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Mensagem: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite a Descrição da Mensagem: ");
			string entradaDescricao = Console.ReadLine();

			Mensagem atualizaMensagem = new Mensagem(id: indiceMensagem,
										tema: (Tema)entradaTema,
										titulo: entradaTitulo,
										descricao: entradaDescricao);

			repositorio.Atualiza(indiceMensagem, atualizaMensagem);
		}
        private static void ListarMensagem()
		{
			Console.WriteLine("Listar Mensagens");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma mensagem cadastrada.");
				return;
			}

			foreach (var mensagem in lista)
			{
                var excluido = mensagem.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", mensagem.retornaId(), mensagem.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirMensagem()
		{
			Console.WriteLine("Inserir nova mensagem");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Tema)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Tema), i));
			}
			Console.Write("Digite o tema entre as opções acima: ");
			int entradaTema = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Mensagem: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite a Descrição da Mensagem: ");
			string entradaDescricao = Console.ReadLine();

			Mensagem novaMensagem = new Mensagem(id: repositorio.ProximoId(),
                                        tema: (Tema)entradaTema,
                                        titulo: entradaTitulo,
                                        descricao: entradaDescricao);

			repositorio.Insere(novaMensagem);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Lindas mensagens para alegra seu dia!!!Escolha alguma mensagem ou deixe uma mensagem!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar Mensagem");
			Console.WriteLine("2- Inserir nova Mensagem");
			Console.WriteLine("3- Atualizar Mensagem");
			Console.WriteLine("4- Excluir Mensagem");
			Console.WriteLine("5- Visualizar Mensagem");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}