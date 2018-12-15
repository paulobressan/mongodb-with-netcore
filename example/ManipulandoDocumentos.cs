using MongoDB.Bson;

namespace example
{
    public class ManipulandoDocumentos
    {
        public BsonDocument CriarDocumentoMongo(){
            //Criar um objeto json com BSon
            var doc = new BsonDocument{
                {"Titulo","Guerra dos Tronos"}
            };
            //O BSon é dinamico e podemos adicionar novos atributos
            doc.Add("Autor", "George");
            doc.Add("Ano", 1999);
            doc.Add("Paginas", 856);

            //Criando uma lista de subDocumentos 
            var assuntoArray = new BsonArray();
            assuntoArray.Add("Fantasia");
            assuntoArray.Add("Ação");

            //Adicionando uma lista de subdocumento a um documento
            doc.Add("Assunto", assuntoArray);

            return doc;
        }
    }
}