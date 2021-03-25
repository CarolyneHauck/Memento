using System;
using System.Threading;

namespace memento
{
    // O Originador detém algum estado importante que pode mudar com o tempo. Ele
    // também define um método para salvar o estado dentro de um memento e outro
    // método para restaurar o estado a partir dele.
    class Originator
    {
        // Por uma questão de simplicidade, o estado do originador é armazenado dentro de um
        // única variável.
        private string _state;

        public Originator(string state)
        {
            this._state = state;
            Console.WriteLine("Originador: Meu estado inicial é:" + state);
        }

        public void DoSomething()
        {
            Console.WriteLine("Originador: Estou fazendo algo importante.");
            this._state = this.GenerateRandomString(30);
            Console.WriteLine($"Originador: e meu estado mudou para: {_state}");
        }

        private string GenerateRandomString(int length = 10)
        {
            string allowedSymbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = string.Empty;

            while (length > 0)
            {
                result += allowedSymbols[new Random().Next(0, allowedSymbols.Length)];

                Thread.Sleep(12);

                length--;
            }

            return result;
        }

        // Salva o estado atual dentro do memento.
        public IMemento Save()
        {
            return new ConcreteMemento(this._state);
        }

        // Restaura o estado do Originador a partir de um objeto memento.
        public void Restore(IMemento memento)
        {
            if (!(memento is ConcreteMemento))
            {
                throw new Exception("Classe de memento desconhecida " + memento.ToString());
            }

            this._state = memento.GetState();
            Console.Write($"Originador: Meu estado mudou para {_state}");
        }
    }
}
