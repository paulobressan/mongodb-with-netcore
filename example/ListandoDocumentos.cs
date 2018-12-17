using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace example
{
    public class ListandoDocumentos
    {
        public async void AcessarServidor()
        {
            //Acessando o mongo atravez da classe de conexão
            var conexaoMongoDb = new ConectandoMongodb();
            //Listando todos os livros, como parametro, podemos passa o find nenhum criterio de busca
            //Quando passamos um documento BsonDocument o nosso critério de busca fica vazio
            var listaLivros = (await conexaoMongoDb.Livros.FindAsync(l => l.Titulo.Equals("Sob *"))).ToList();

            foreach (var doc in listaLivros)
            {
                //Imprimindo os documento da coleção livros
                Console.WriteLine(doc.ToJson<Livro>());
            }
        }
    }
}