using System;

namespace memento
{

    class Program
    {
        static void Main(string[] args)
        {
            // Código do cliente.
            Originator originator = new Originator("Teste-teste-teste.");
            Caretaker caretaker = new Caretaker(originator);

            caretaker.Backup(); //Salvando o estado atual no memento.
            originator.DoSomething(); //Fazendo algo importante e mudando de estado.

            caretaker.Backup(); //Salvando um novo estado atual no memento.
            originator.DoSomething(); //Fazendo algo importante e mudando de estado.

            caretaker.Backup(); //Salvando um novo estado atual no memento.

            Console.WriteLine();
            caretaker.ShowHistory(); //Mostrando todos os estados salvos.

            Console.WriteLine("\nClient: Agora vamos voltar ao estado anterior!\n");
            caretaker.Undo();

            Console.WriteLine("\n\nClient: e vamos voltar mais uma vez\n");
            caretaker.Undo();

            Console.WriteLine("\n\nClient: e vamos voltar mais uma vez\n");
            caretaker.Undo();

            Console.WriteLine();
        }
    }

}
