using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace example
{
    public class AcessandoMongoDb
    {
        public async void AcessarServidor()
        {
            var documento = new ManipulandoDocumentos().CriarDocumentoMongo();

            //Acessando o servidor do mongodb

            //string de conexão do mongo
            string stringConexao = "mongodb://localhost:27017";

            //Criando uma instancia do servidor do mongo
            IMongoClient client = new MongoClient(stringConexao);

            //Acesso ao banco de dados, usando o servidor e passando o nome da base que queremos
            //O banco de dados é criado dinamicamente, se o banco não existir automaticamente sera criado
            IMongoDatabase bancoDados = client.GetDatabase("biblioteca");

            //Acesso a coleção, se a coleção não existir sera criada
            //É uma coleção de BsonDocument que é o documento.
            IMongoCollection<BsonDocument> colecao = bancoDados.GetCollection<BsonDocument>("livros");

            //incluindo documento a lista
            await colecao.InsertOneAsync(documento);

            Console.WriteLine("Documento incluido");
        }
    }
}