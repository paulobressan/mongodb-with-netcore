using System.Collections.Generic;
using MongoDB.Bson;

namespace example
{
    public class Biblioteca
    {
        public ObjectId Id { get; set; }
        public string Nome { get; set; }
        public string Endereço { get; set; }
        public IEnumerable<Livro> Livros { get; set; }
    }
}