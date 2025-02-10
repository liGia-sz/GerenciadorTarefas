using System;

namespace Gerenciador
{
    class GerenciadorDeTarefas
    {
       public static string ObterTarefa();

        while (true)
        {
            Console.WriteLine ("\n--- Gerenciador de Tarefas ---\n1. Adicionar Tarefa\n2. Listar Tarefas\n3. Remover Tarefa\n4. Sair");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Write("Digite a descrição da tarefa: ");
                    string tarefa = Console.ReadLine();
                    gerenciador.AdicionarTarefa(tarefa);
                    break;

                case "2":
                    gerenciador.ListarTarefas();
                    break;

                case "3":
                    Console.Write("Digite o ID da tarefa que deseja remover: ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        gerenciador.RemoverTarefa(index);
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida.");
                    }
                    break;

                case "4":
                    Console.WriteLine("Saindo do programa...");
                    return;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
