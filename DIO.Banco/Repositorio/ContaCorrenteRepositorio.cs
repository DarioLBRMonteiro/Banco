using DIO.Banco.Classes;
using DIO.Banco.Interface;
using System.Collections.Generic;
using System.Linq;

namespace DIO.Banco.Repositorio
{
    class ContaCorrenteRepositorio:IContaCorrente<ContaCorrente>
    {
        private List<ContaCorrente> listaContaCorrente = new List<ContaCorrente>();

        public void Atualiza(int id, ContaCorrente contaCorrente)
        {
            listaContaCorrente[id] = contaCorrente;
        }

        public void Insere(ContaCorrente contaCorrente)
        {
            listaContaCorrente.Add(contaCorrente);
        }

        public List<ContaCorrente> Lista()
        {
            return listaContaCorrente;
        }

        public int ProximoId()
        {
            return listaContaCorrente.Count();
        }

        public ContaCorrente RetornaPorId(int id)
        {
            return listaContaCorrente[id];
        }
    }
}
