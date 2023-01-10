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
//ImprimirValores(queries.More450PagesOrderByPageCount());
//Tomar los primeros 3 libros de categoria java con año de publicacion mas reciente
//ImprimirValores(queries.OperatorTakeFirstBooks());
//Tomalos el tercer y cuarto libro que tengan mas de 400 paginas
//ImprimirValores(queries.OperatorSkipBooks());
//Tomar el titulo y el page count de los 3 primeros libros de la coleccion
//ImprimirValores(queries.AllColletion());
//Numero de libros que contienen entre 200 y 500 paginas
//Console.WriteLine("Numero de libros que contienen entre 200 y 500 paginas: " + queries.OperadorCount());
//Imprime la menor fecha de publicacion de toda la coleccion
//Console.WriteLine("La fecha minima de publicacion es: "+ queries.OperadorMin().ToShortDateString());
//Imprime el maximo numero de paginas de un libro
//Console.WriteLine("El maximo numero de paginas es: "+ queries.OperadorMax());
//Libro con menor numero de paginas mayor a cero
//ImprimirValoresSingular(queries.OperadorMinBy());
//Libro conla fecha 
//ImprimirValoresSingular(queries.OperadorMaxBy());
//Suma de la cantidad de paginas de todos los libros que tengan entre 0 y 500 paginas
//Console.WriteLine("La cantidad de paginas entre 0 y 500 es: " + queries.OperadorSum());
//Titulos de los libros publicados despues del 2015
//Console.WriteLine("Titulos de los libros publicados despues del 2015 es: " + queries.OperadorAgregate());
//Promedio de los tittulos de los libros
//Console.WriteLine("Promedio caracteres de los titulos: " + queries.PromedioCaracteresTitulo());
//Promedio de paginas de los libros
//Console.WriteLine("Promedio del numero de paginas: " + queries.PromedioNumeroPaginas());
//Libros publicadoes despues del 2000 agrupados por año
//ImprimirGrupo(queries.OperadorGroupBy());
//Consultar libros de acuerdo a la letra que pases en su inicial
//ImprimirLookUp(queries.OperadorLookUp(), 'B');
//Libros filtrados por numero de pagina y fecha de publicacion con JOIN
ImprimirValores(queries.OperadorJoin());

void ImprimirValores(IEnumerable<Book> listaLibros)
{
    Console.WriteLine("{0, -60} | {1, 15} | {2, 15} |\n", "Titulo", "N. Paginas", "Fecha Publicacion");
    foreach (var item in listaLibros)
    {
        Console.WriteLine("{0, -60} | {1, 15} | {2, 15} |", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
void ImprimirValoresSingular(Book listaLibros)
{
    Console.WriteLine("{0, -60} | {1, 15} | {2, 15} |\n", "Titulo", "N. Paginas", "Fecha Publicacion");
    Console.WriteLine("{0, -60} | {1, 15} | {2, 15} |", listaLibros.Title, listaLibros.PageCount, listaLibros.PublishedDate.ToShortDateString());
}

void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> listadoLibros)
{
    foreach (var grupo in listadoLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key }");
        Console.WriteLine("{0, -60} | {1, 15} | {2, 15} |\n", "Titulo", "N. Paginas", "Fecha Publicacion");
        foreach (var item in grupo)
        {
            Console.WriteLine("{0, -60} | {1, 15} | {2, 15} |", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        }
    }
}

void ImprimirLookUp(ILookup<char, Book> listadoLibros, char letra)
{
    // foreach (var grupo in listadoLibros)
    // {
    //     Console.WriteLine("");
    //     Console.WriteLine($"Grupo: { grupo.Key }");
        Console.WriteLine("{0, -60} | {1, 15} | {2, 15} |\n", "Titulo", "N. Paginas", "Fecha Publicacion");
        foreach (var item in listadoLibros[letra])
        {
            Console.WriteLine("{0, -60} | {1, 15} | {2, 15} |", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        }
    //}
}