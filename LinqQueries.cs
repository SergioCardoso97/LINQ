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
    }    
}