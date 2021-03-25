using System;
namespace memento
{
    // A interface Memento fornece uma maneira de recuperar os metadados do memento,
    // tais como data de criação ou nome. Entretanto, não expõe a
    // Estado do originador.
    public interface IMemento
    {
        string GetName();

        string GetState();

        DateTime GetDate();
    }

    // A Concrete Memento contém a infra-estrutura para o armazenamento do
    // Estado do originador.
    class ConcreteMemento : IMemento
    {
        private string _state;

        private DateTime _date;

        public ConcreteMemento(string state)
        {
            this._state = state;
            this._date = DateTime.Now;
        }

        // O Originador usa este método quando restaura seu estado.
        public string GetState()
        {
            return this._state;
        }

        // O resto dos métodos são utilizados pelo Cuidador para exibir
        // metadados.
        public string GetName()
        {
            return $"{this._date} / ({this._state.Substring(0, 9)})...";
        }

        public DateTime GetDate()
        {
            return this._date;
        }
    }
}
