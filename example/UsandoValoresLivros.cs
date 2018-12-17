using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

namespace example
{
    public class UsandoValoresLivros
    {
        public async void AcessarServidor()
        {
            Livro livro = new Livro()
            {
                Titulo = "Star Wars Ultimate",
                Autor = "George Lucas",
                Ano = 2010,
                Paginas = 245,
                Assuntos = new List<string>{
                   "Ficção Cientifica",
                   "Ação"
               }
            };
            Livro livro2 = new Livro()
            {
                Titulo = "Cangaceiro JavaScript",
                Autor = "Flavio Almeida",
                Ano = 2010,
                Paginas = 245,
                Assuntos = new List<string>{
                   "Didatico"
               }
            };

            Livro livro3 = new Livro()
            {
                Titulo = "CSharp",
                Autor = "Paulo Bressan",
                Ano = 2010,
                Paginas = 245,
                Assuntos = new List<string>{
                   "Didatico"
               }
            };

            //Acessando o mongo atravez da classe de conexão
            var conexaoMongoDb = new ConectandoMongodb();
            await conexaoMongoDb.Livros.InsertManyAsync(new List<Livro>{
                livro, livro2, livro3
            });
        }
    }
}