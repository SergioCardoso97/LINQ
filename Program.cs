// See https://aka.ms/new-console-template for more information
using LINQ;

LinqQueries queries = new LinqQueries();
//Toda la Coleccion
//ImprimirValores(queries.AllColletion());
//Libros despues del 2000
//ImprimirValores(queries.AfterBooks2000());
//Libros con mas de 250 paginas y la palabra "in Action" en su titulo
//ImprimirValores(queries.BooksWithMoreThan250Pages());
//Libros con estatus diferente de null
//Console.WriteLine($"Todos los libros tienen estatus? - {queries.BookWithFieldStatusDiferentNull()}");
//Algunos de los libros fue publicado en 2005
//Console.WriteLine($"Alguno de los libros fue publicado en el 2005? - {queries.BookWithFieldPublishedDate2005()}");
//Libros que contengan en sus categorias la palabra python
//ImprimirValores(queries.CategoryPython());
//Ordenar ascendente libros por la categoria java y por el campo de nombre
//ImprimirValores(queries.CategoryJavaOrderByTitle());
//Ordenar desendente libros que tengan mas de 450 paginas
ImprimirValores(queries.More450PagesOrderByPageCount());
void ImprimirValores(IEnumerable<Book> listaLibros)
{
    Console.WriteLine("{0, -60} | {1, 15} | {2, 15} |\n", "Titulo", "N. Paginas", "Fecha Publicacion");
    foreach (var item in listaLibros)
    {
        Console.WriteLine("{0, -60} | {1, 15} | {2, 15} |", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}