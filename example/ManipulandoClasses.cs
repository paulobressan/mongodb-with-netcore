using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace example
{
    public class ManipulandoClasses
    {
        public async void AcessarServidor(){
           Livro livro = new Livro(){
               Titulo="Sob a redonda",
               Autor = "Stepahn",
               Ano = 2012,
               Paginas = 679, 
               Assuntos = new List<string>{
                   "Ficção Cientifica",
                   "Terror",
                   "Ação"
               }
           };
            //Acessando o servidor do mongodb

            //string de conexão do mongo
            string stringConexao = "mongodb://localhost:27017";

            //Criando uma instancia do servidor do mongo
            IMongoClient client = new MongoClient(stringConexao);

            //Acesso ao banco de dados, usando o servidor e passando o nome da base que queremos
            //O banco de dados é criado dinamicamente, se o banco não existir automaticamente sera criado
            IMongoDatabase bancoDados = client.GetDatabase("biblioteca");

            //Acesso a coleção, se a coleção não existir sera criada
            //É uma coleção de Livro
            IMongoCollection<Livro> colecao = bancoDados.GetCollection<Livro>("livros");

            //incluindo documento a lista
            await colecao.InsertOneAsync(livro);

            Console.WriteLine("Documento incluido");
        }
    }
}