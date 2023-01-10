using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace LINQ
{
    public class LinqQueries
    {
        private List<Book> librosColletion = new List<Book>();
        public LinqQueries()
        {
            using(StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                List<Book>? Books = JsonSerializer.Deserialize<List<Book>>(json, new JsonSerializerOptions(){PropertyNameCaseInsensitive = true});
                if (Books != null)
                {
                    librosColletion = Books;
                }
            }
        }
        public IEnumerable<Book> AllColletion()
        {
            return this.librosColletion;
        }
        public IEnumerable<Book> AfterBooks2000()
        {
            //extension method
            //return librosColletion.Where(x => x.PublishedDate.Year > 2000);
            //query expresion
            return from l in librosColletion where l.PublishedDate.Year > 2000 select l;
        }
        public IEnumerable<Book> BooksWithMoreThan250Pages()
        {
            //extension method
            //return librosColletion.Where(x => x.PageCount > 250 && x.Title.Contains("in Action"));
            //query expresion
            return from l in librosColletion where l.PageCount > 250 && l.Title.Contains("in Action") select l;
        }
        public bool BookWithFieldStatusDiferentNull()
        {
            return librosColletion.All(x => x.Status != string.Empty);
        }
        public bool BookWithFieldPublishedDate2005()
        {
            return librosColletion.Any(x => x.PublishedDate.Year == 2005 );
        }
        public IEnumerable<Book> CategoryPython()
        {
            //extension method
            //return librosColletion.Where(x => x.Categories.Contains("Python"));
            //query expresio
            return from l in librosColletion where l.Categories.Contains("Python") select l;
        }
        public IEnumerable<Book> CategoryJavaOrderByTitle()
        {
            //extension method
            //return librosColletion.Where(x => x.Categories.Contains("Java")).OrderBy(x => x.Title);
            //query expresion
            return from l in librosColletion where l.Categories.Contains("Java") orderby l.Title select l;
        }
         public IEnumerable<Book> More450PagesOrderByPageCount()
        {
            //extension method
            //return librosColletion.Where(x => x.PageCount > 450).OrderByDescending(x => x.PageCount);
            //query expresion
            return from l in librosColletion where l.PageCount > 450 orderby l.PageCount descending select l;
        }
        public IEnumerable<Book> OperatorTakeFirstBooks()
        {
            //extension method
            //return librosColletion.Where(x => x.Categories.Contains("Java")).OrderByDescending(x => x.PublishedDate).Take(3);
            //query expresion
            return (from l in librosColletion where l.Categories.Contains("Java") orderby l.PublishedDate descending select l).Take(3);
        }
        public IEnumerable<Book> OperatorSkipBooks()
        {
            //extension method
            //return librosColletion.Where(x => x.PageCount > 400).OrderByDescending(x => x.PageCount).Take(4).Skip(2);
            //query expresion
            return (from l in librosColletion where l.PageCount > 400 orderby l.PageCount descending select l).Take(4).Skip(2);
        }
        public IEnumerable<Book> OperatorSelect()
        {
            return librosColletion.Take(3).Select(x => new Book(){Title= x.Title, PageCount= x.PageCount});
        }
        public int OperadorCount()
        {
            //extension method
            //return librosColletion.Count(x => x.PageCount >= 200 && x.PageCount <=500);
            //query expresion
            return (from l in librosColletion where l.PageCount >= 200 && l.PageCount <=500 select l).Count();
        }
        public DateTime OperadorMin()
        {
            return librosColletion.Min(x => x.PublishedDate);
        }
        public int OperadorMax()
        {
            return librosColletion.Max(x => x.PageCount);
        }
        public Book OperadorMinBy()
        {
            return librosColletion.Where(x => x.PageCount > 0).MinBy(x => x.PageCount);
        }
        public Book OperadorMaxBy()
        {
            return librosColletion.MaxBy(x => x.PublishedDate);
        }
        public int OperadorSum()
        {
            return librosColletion.Where(x => x.PageCount >= 0 && x.PageCount <= 500).Sum(x => x.PageCount);
        }
        public string OperadorAgregate()
        {
            return librosColletion.Where(x => x.PublishedDate.Year >= 2015).Aggregate("", (TitulosLibros, next) => {
                if (TitulosLibros != string.Empty)
                {
                    TitulosLibros += "-" + next.Title;
                }
                else
                {
                    TitulosLibros +=  next.Title;
                }
                return TitulosLibros;
            });
        }
        public double PromedioCaracteresTitulo()
        {
            return librosColletion.Average(x => x.Title.Length);
        }
        public double PromedioNumeroPaginas()
        {
            return librosColletion.Where(x => x.PageCount > 0).Average(x => x.PageCount);
        }
        public IEnumerable<IGrouping<int,Book>> OperadorGroupBy()
        {
            return librosColletion.Where(x => x.PublishedDate.Year > 2000).OrderBy(x => x.PublishedDate).GroupBy(x => x.PublishedDate.Year);
        }
        public ILookup<char, Book> OperadorLookUp()
        {
            return librosColletion.ToLookup(x => x.Title[0], x => x);
        }
        public IEnumerable<Book> OperadorJoin()
        {
            var mas500 = librosColletion.Where(x => x.PageCount > 500);
            var despues2005 = librosColletion.Where(x => x.PublishedDate.Year > 2005);
            return mas500.Join(despues2005, p => p.Title, x => x.Title, (p, x) => p);
        }
    }    
}