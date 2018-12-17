using System;
using MongoDB.Bson;
using MongoDB.Driver;
namespace example
{
    public class ListandoDocumentosFiltroClasse
    {
        public async void AcessarServidor()
        {
            //Acessando o mongo atravez da classe de conexão
            var conexaoMongoDb = new ConectandoMongodb();

            //Construtor de filtros
            var construtor = Builders<Livro>.Filter;

            //condição do filtro, o Eq é Equals, então vamos buscar apenasos autores Stepahn
            var condicao = construtor.Eq(x => x.Autor, "Stepahn");

            Console.WriteLine("Filtrando com o construtor de filtros somente os livros com o autor Stepahn");
            //Listando todos os livros, como parametro, podemos passa o find nenhum criterio de busca
            //Quando passamos um documento BsonDocument o nosso critério de busca fica vazio
            var listaLivros = (await conexaoMongoDb.Livros.FindAsync(condicao)).ToList();

            foreach (var doc in listaLivros)
            {
                //Imprimindo os documento da coleção livros
                Console.WriteLine(doc.ToJson<Livro>());
            }

            //BUSCANDO POR > OU IGUAL A UM VALOR
            //Console.WriteLine("Filtrando cuja o ano de publicação seja > ou igual a 1999");
            //Construtor de filtros
            construtor = Builders<Livro>.Filter;

            //condição do filtro, o Gte é maior ou igual
            condicao = construtor.Gte(x => x.Ano, 1999);

            Console.WriteLine("Filtrando livros onde o ano é maior ou igual a 1999");
            //Listando todos os livros, como parametro, podemos passa o find nenhum criterio de busca
            //Quando passamos um documento BsonDocument o nosso critério de busca fica vazio
            listaLivros = (await conexaoMongoDb.Livros.FindAsync(condicao)).ToList();

            foreach (var doc in listaLivros)
            {
                //Imprimindo os documento da coleção livros
                Console.WriteLine(doc.ToJson<Livro>());
            }

            //BUSCANDO POR MAIOR OU IGUAL E QUE TENHA MAIS DE 300 PAGINAS
            construtor = Builders<Livro>.Filter;

            //condição do filtro, o Gte é maior ou igual
            //Livros onde o ano é maior ou igual a 1999 e que tenha a quantidade maior ou igual a 300
            condicao = construtor.Gte(x => x.Ano, 1999) & construtor.Gte(x => x.Paginas, 300);

            Console.WriteLine("Filtrando livros onde o ano é maior ou igual a 1999 e que a quantidade seja maior ou igual a 300");
            //Listando todos os livros, como parametro, podemos passa o find nenhum criterio de busca
            //Quando passamos um documento BsonDocument o nosso critério de busca fica vazio
            listaLivros = (await conexaoMongoDb.Livros.FindAsync(condicao)).ToList();

            foreach (var doc in listaLivros)
            {
                //Imprimindo os documento da coleção livros
                Console.WriteLine(doc.ToJson<Livro>());
            }

            //BUSCANDO POR SUB DOCUMENTOS
            construtor = Builders<Livro>.Filter;

            //condição do filtro, o AnyEq busca dentro dos sub documentos um valor
            //Livros onde o assunto é Ficção Cientifica, ou seja buscar sub documentos
            condicao = construtor.AnyEq(x => x.Assuntos, "Ficção Cientifica");

            Console.WriteLine("Filtrando livros somente de Ficção Cientifica SUB DOCUMENTO DE LIVRO");
            //Listando todos os livros, como parametro, podemos passa o find nenhum criterio de busca
            //Quando passamos um documento BsonDocument o nosso critério de busca fica vazio
            listaLivros = (await conexaoMongoDb.Livros.FindAsync(condicao)).ToList();

            foreach (var doc in listaLivros)
            {
                //Imprimindo os documento da coleção livros
                Console.WriteLine(doc.ToJson<Livro>());
            }
        }
    }
}