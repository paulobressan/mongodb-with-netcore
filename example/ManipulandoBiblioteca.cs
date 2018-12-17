using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace example
{
    public class ManipulandoBiblioteca
    {
        public async void AcessarServidor()
        {
            Console.WriteLine("Manipulando Bibliotecas");
            var conection = new ConectandoMongodb();

            var construtorFiltrosLivro = Builders<Livro>.Filter;

            var condicao = construtorFiltrosLivro.Gte(l => l.Ano, 1999);

            Console.WriteLine("Consultando livros");
            var livros = (IEnumerable<Livro>)await conection.Livros.FindAsync<Livro>(condicao);

            var biblioteca = new Biblioteca
            {
                Nome = "Da Esquina",
                Endereço = "Rua Padre Anchieta",
                Livros = livros
            };

            Console.WriteLine("Inserindo biblioteca");
            await conection.Bibliotecas.InsertOneAsync(biblioteca);

            Console.WriteLine("Consultando biblioteca");
            var listaBiblioteca = (IList<Biblioteca>)await conection.Bibliotecas.FindAsync<Biblioteca>(new BsonDocument());

            foreach (var doc in listaBiblioteca)
            {
                Console.WriteLine(doc.ToJson<Biblioteca>());
            }
        }
    }
}