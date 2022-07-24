using System.Data;
using Microsoft.AspNetCore.Mvc;
using OnlineBookReader.Data;

namespace OnlineBookReader.Controllers;

[ApiController]
[Route("[controller]")]
public class OnlineBookReaderController : ControllerBase
{
    private readonly ILogger<OnlineBookReaderController> _logger;

    private IOnlineBookReaderRepository onlineBookRepository;

    public OnlineBookReaderController(ILogger<OnlineBookReaderController> logger)
    {
        _logger = logger;
        onlineBookRepository = new OnlineBookReaderRepository(new OnlineBookReaderContext());
    }

    [HttpGet]
    public IEnumerable<Books> GetBooks()
    {

        IEnumerable<Books> books = onlineBookRepository.GetBooks();
        return books;

    }
    [HttpGet("{bookID}")]
    public ActionResult<Books> GetBooksByID(int bookID)
    {

        Books books = onlineBookRepository.GetBookByID(bookID);
        return books;

    }
    [HttpPost]
    public ActionResult Create(Books book)
    {
        try
        {
            if (ModelState.IsValid)
            {
                onlineBookRepository.InsertBook(book);
                onlineBookRepository.Save();
            }
        }
        catch (DataException /* dex */)
        {
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
        }
        return CreatedAtAction(nameof(Create), new { id = book.BookID }, book);
    }
}

