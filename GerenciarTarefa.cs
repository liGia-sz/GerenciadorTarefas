namespace GerenciarTarefa
{
    class Opcoes
    {
        public class GerenciadorTarefas
        {
            private List<Tarefa> tarefas = new List<Tarefa>();
            private int proximoId = 1;

            public void AdicionarTarefa(string descricao)
            {
                Tarefa novaTarefa = new Tarefa(proximoId, descricao);
                tarefas.Add(novaTarefa);
                proximoId++;
                Layout.Formatacao.AplicarCor($"Tarefa '{descricao}' adicionada com sucesso!", ConsoleColor.Green);
            }

            public void ListarTarefas()
            {
                if (tarefas.Count == 0)
                {
                     Layout.Formatacao.AplicarCor("Não há tarefas para listar.", ConsoleColor.DarkYellow);
                }
                else
                {
                    Console.WriteLine("Tarefas:");
                    foreach (var tarefa in tarefas)
                    {
                         Layout.Formatacao.AplicarCor($"ID: {tarefa.Id} - {tarefa.Descricao} - {(tarefa.Concluida ? "Concluída" : "Pendente")}", ConsoleColor.Yellow);
                    }
                }
            }

            public void ConcluirTarefa(int id)
            {
                var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
                if (tarefa != null)
                {
                    tarefa.Concluir();
                     Layout.Formatacao.AplicarCor($"Tarefa {id} concluída com sucesso!", ConsoleColor.Green);
                }
                else
                {
                    Console.WriteLine("Tarefa não encontrada.");
                }
            }

            public void RemoverTarefa(int id)
            {
                var tarefa = tarefas.FirstOrDefault(t => t.Id == id);
                if (tarefa != null)
                {
                    tarefas.Remove(tarefa);
                     Layout.Formatacao.AplicarCor($"Tarefa {id} removida com sucesso!", ConsoleColor.DarkRed);
                }
                else
                {
                     Layout.Formatacao.AplicarCor("Tarefa não encontrada.", ConsoleColor.Red);
                }
            }
        }

        public static void GerenciarOpcoes()
        {
            GerenciadorTarefas gerenciador = new GerenciadorTarefas();
            while (true)
            {
                Layout.Formatacao.AplicarCor("1 - Adicionar tarefa", ConsoleColor.Yellow);
                Layout.Formatacao.AplicarCor("2 - Listar tarefas", ConsoleColor.Yellow);
                Layout.Formatacao.AplicarCor("3 - Concluir tarefa", ConsoleColor.Yellow);
                Layout.Formatacao.AplicarCor("4 - Remover tarefa", ConsoleColor.Yellow);
                Layout.Formatacao.AplicarCor("0 - Sair", ConsoleColor.Yellow);
                Layout.Formatacao.AplicarCor("Escolha uma opção: ", ConsoleColor.Yellow);

                if (!int.TryParse(Console.ReadLine(), out int opcao))
                {
                     Layout.Formatacao.AplicarCor("Valor inválido! Tente novamente.", ConsoleColor.Red);
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite a descrição da tarefa: ");
                        string descricao = Console.ReadLine();
                        gerenciador.AdicionarTarefa(descricao);
                        break;
                    case 2:
                        gerenciador.ListarTarefas();
                        break;
                    case 3:
                        Console.Write("Digite o ID da tarefa que deseja concluir: ");
                        if (int.TryParse(Console.ReadLine(), out int idConcluir))
                        {
                            gerenciador.ConcluirTarefa(idConcluir);
                        }
                        else
                        {
                             Layout.Formatacao.AplicarCor("Entrada inválida.", ConsoleColor.Red);
                        }
                        break;
                    case 4:
                        Console.Write("Digite o ID da tarefa que deseja remover: ");
                        if (int.TryParse(Console.ReadLine(), out int idRemover))
                        {
                            gerenciador.RemoverTarefa(idRemover);
                        }
                        else
                        {
                             Layout.Formatacao.AplicarCor("Entrada inválida.", ConsoleColor.Red);
                        }
                        break;
                    case 0:
                         Layout.Formatacao.AplicarCor("Saindo do programa...", ConsoleColor.DarkRed);
                        return;
                    default:
                         Layout.Formatacao.AplicarCor("Opção inválida. Tente novamente.", ConsoleColor.Red);
                        break;
                }
            }
        }
    }

    public class Tarefa
    {
        public int Id { get; }
        public string Descricao { get; }
        public bool Concluida { get; private set; }

        public Tarefa(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
            Concluida = false;
        }

        public void Concluir()
        {
            Concluida = true;
        }
    }
}
