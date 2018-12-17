using MongoDB.Driver;
using MongoDB.Bson;

namespace example
{
    //Classe responsavel por definir o contexto da aplicação e se conectar com o banco de dados
    public class ConectandoMongodb
    {
        public const string STRING_DE_CONEXAO = "mongodb://localhost:27017";
        public const string NOME_DA_BASE = "biblioteca";
        public const string NOME_DA_COLECAO = "livros";
        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;


        static ConectandoMongodb()
        {
            //Criando uma instancia do servidor do mongo
            _client = new MongoClient(STRING_DE_CONEXAO);
            //Acesso ao banco de dados, usando o servidor e passando o nome da base que queremos
            //O banco de dados é criado dinamicamente, se o banco não existir automaticamente sera criado
            _database = _client.GetDatabase(NOME_DA_BASE);
        }

        /// <summary>
        /// Retornando o banco de dados ja instanciado e conectado para uso
        /// </summary>
        /// <value></value>
        public IMongoClient Cliente
        {
            get
            {
                return _client;
            }
        }

        //Retornar uma coleção, no caso a coleção livros
        public IMongoCollection<Livro> Livros
        {
            get
            {
                return _database.GetCollection<Livro>(NOME_DA_COLECAO);
            }
        }

        //Retornar uma coleção de biblioteca
        public IMongoCollection<Biblioteca> Bibliotecas
        {
            get{
                return _database.GetCollection<Biblioteca>(nameof(Biblioteca));
            }
        }
    }
}