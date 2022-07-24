using OnlineBookReader;


using (var context = new OnlineBookReaderContext())
{
    var books = context.Books.ToList();
}