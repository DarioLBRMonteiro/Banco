using System.Collections.Generic;

namespace DIO.Banco.Interface
{
    public interface IContaCorrente<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Atualiza(int id, T entidade);
        int ProximoId();

    }
}
