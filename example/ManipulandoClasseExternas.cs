using System.Collections.Generic;

namespace example
{
    public class ManipulandoClasseExternas
    {
        public async void AcessarServidor()
        {
            Livro livro = new Livro()
            {
                Titulo = "Star Wars Legends",
                Autor = "George Lucas",
                Ano = 2010,
                Paginas = 245,
                Assuntos = new List<string>{
                   "Ficção Cientifica",
                   "Ação"
               }
            };

            //Acessando o mongo atravez da classe de conexão
            var conexaoMongoDb = new ConectandoMongodb();
            await conexaoMongoDb.Livros.InsertOneAsync(livro);
        }
    }
}