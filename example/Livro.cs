using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace example
{
    public class Livro
    {
        //Estamos anotando o Id para ele ser do tipo ObjectId
        //[BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public int Paginas { get; set; }
        public IEnumerable<string> Assuntos { get; set; }
    }
}