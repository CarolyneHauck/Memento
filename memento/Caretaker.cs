using System;
using System.Collections.Generic;
using System.Linq;

namespace memento
{
    // O Cuidador não depende da classe Concrete Memento. Portanto, ele
    // não tem acesso ao estado do originador, armazenado dentro do memento.
    class Caretaker
    {
        private List<IMemento> _mementos = new List<IMemento>();

        private Originator _originator = null;

        public Caretaker(Originator originator)
        {
            this._originator = originator;
        }

        public void Backup()
        {
            Console.WriteLine("\nCuidador: Salvando o estado do Originador...");
            this._mementos.Add(this._originator.Save());
        }

        public void Undo()
        {
            if (this._mementos.Count == 0)
            {
                return;
            }

            var memento = this._mementos.Last();
            this._mementos.Remove(memento);

            Console.WriteLine("Cuidador: Restaurando o estado para: " + memento.GetName());

            try
            {
                this._originator.Restore(memento);
            }
            catch (Exception)
            {
                this.Undo();
            }
        }

        public void ShowHistory()
        {
            Console.WriteLine("Cuidador: Aqui está a lista de mementos:");

            foreach (var memento in this._mementos)
            {
                Console.WriteLine(memento.GetName());
            }
        }
    }
}
