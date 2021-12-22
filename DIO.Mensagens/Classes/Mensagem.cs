namespace DIO.Mensagens
{
    public class Mensagem: EntidadeBase
    {
     // Atributos
		private Tema Tema { get; set; }
		private string Titulo { get; set; }
		private string Descricao { get; set; }
        private bool Excluido {get; set;}


        // Métodos
		public Mensagem(int id, Tema tema, string titulo, string descricao)
		{
			this.Id = id;
			this.Tema = tema;
			this.Titulo = titulo;
			this.Descricao = descricao;
            this.Excluido = false;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Tema: " + this.Tema + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}