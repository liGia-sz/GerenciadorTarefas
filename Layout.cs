namespace Layout 
{
    class Formatacao
    {
        public static void AplicarCor(string mensagem, ConsoleColor cor)
        {
            // Métodos para adicionar as cores nas mensagens
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }
        
        public static void ImprimirCabecalho(string texto)
        {
            
            // Determina o tamanho do quadro com base no comprimento do texto
            int largura = texto.Length + 4; // 2 espaços extras de cada lado

            // Linha superior
            Console.WriteLine(new string('=', largura));

            // Linha do meio com o texto centralizado
            Console.WriteLine($"= {texto} =");

            // Linha inferior
            Console.WriteLine(new string('=', largura));
}

            
        }
    }