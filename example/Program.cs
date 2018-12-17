using System;

namespace example
{
    class Program
    {
        static void Main(string[] args)
        {
            // var manipulandoDocumentos = new ManipulandoDocumentos();
            // Console.WriteLine(manipulandoDocumentos.CriarDocumentoMongo());
            new ManipulandoBiblioteca().AcessarServidor();
            Console.ReadKey();
        }
    }
}
