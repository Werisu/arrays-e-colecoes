using curso_alura_trabalhando_com_arrays_e_colecoes.account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curso_alura_trabalhando_com_arrays_e_colecoes.bytebank.Util
{
    public class ListaDeContasCorrentes
    {
        private ContaCorrente[] _itens = null;
        private int _proximaPosicao = 0;

        public ListaDeContasCorrentes(int tamanhoIncial = 5)
        {
            _itens = new ContaCorrente[tamanhoIncial];
        }

        public void Adicionar(ContaCorrente item)
        {
            Console.WriteLine($"Adicionando item na posição {_proximaPosicao}");
            VerificarCapacidade(_proximaPosicao + 1);
            item.Depositar(23 + _proximaPosicao + 1);
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        public void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }
            Console.WriteLine("Aumentando a capacidade da lista!");
            ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario];

            for (int i = 0; i < _itens.Length; i++)
            {
                novoArray[i] = _itens[i];
            }

            _itens = novoArray;
        }

        public ContaCorrente MaiorSaldo()
        {
            ContaCorrente conta = null;
            double maiorValor = 0;

            for (int i = 0; i < _itens.Length; i++)
            {
                if (_itens[i] != null)
                {
                    if (!(maiorValor > _itens[i].Saldo))
                    {
                        conta = _itens[i];
                    }
                }
            }

            return conta;
        }

        public void Remover(ContaCorrente conta)
        {
            int indiceItem = -1;
            for (int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente contaAtual = _itens[i];
                if (contaAtual == conta)
                {
                    indiceItem = i;
                    break;
                }
            }

            for (int i = indiceItem; i < _proximaPosicao - 1; i++)
            {
                _itens[i] = _itens[i + 1];
            }
            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        public void ExibeLista()
        {
            for (int i = 0; i < _itens.Length; i++)
            {
                if (_itens[i] != null)
                {
                    var conta = _itens[i];
                    Console.WriteLine($"Indice [{i}] = Conta: {conta.Conta} - Angência: {conta.Numero_agencia}");
                }
            }
        }
    }
}
