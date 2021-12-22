using System;
using System.Collections.Generic;
using DIO.Mensagens.Interfaces;

namespace DIO.Mensagens

{
    public class MensagemRepositorio : IRepositorio<Mensagem>
    {
       private List<Mensagem> listaMensagem = new List<Mensagem>();

        public void Atualiza(int id, Mensagem objeto)
        {
            listaMensagem[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaMensagem[id].Excluir();
        }

        public void Insere(Mensagem objeto)
        {
            listaMensagem.Add(objeto);
        }

        public List<Mensagem> Lista()
        {
            return listaMensagem;
        }

        public int ProximoId()
        {
           return listaMensagem.Count;
        }

        public Mensagem RetornaPorId(int id)
        {
           return listaMensagem[id];
        }
    }
}