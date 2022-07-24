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

    [HttpGet("GetBooks/")]
    public IEnumerable<Books> GetBooks()
    {

        IEnumerable<Books> books = onlineBookRepository.GetBooks();
        return books;

    }
    [HttpGet("GetBooks/{bookID}")]
    public ActionResult<Books> GetBooksByID(int bookID)
    {

        Books books = onlineBookRepository.GetBookByID(bookID);
        return books;

    }
    [HttpPost("InsertBook/")]
    public ActionResult InsertBook(Books book)
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
        return CreatedAtAction(nameof(InsertBook), new { id = book.BookID }, book);
    }
    [HttpPut("UpdateBook/")]
    public ActionResult UpdateBook(Books book)
    {
        try
        {
            if (ModelState.IsValid)
            {
                onlineBookRepository.UpdateBook(book);
                onlineBookRepository.Save();
            }
        }
        catch (DataException /* dex */)
        {
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
        }
        return CreatedAtAction(nameof(UpdateBook), new { id = book.BookID }, book);
    }
    [HttpDelete("DeleteBook/{bookID}")]
    public string DeleteBook(int bookID)
    {
        try
        {
            if (ModelState.IsValid)
            {
                onlineBookRepository.DeleteBook(bookID);
                onlineBookRepository.Save();
            }
        }
        catch (DataException /* dex */)
        {
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
        }
        return "Deleted";
    }
    [HttpPost("InsertBookPage/")]
    public ActionResult InsertBookPage(BookPages bookPage)
    {
        try
        {
            if (ModelState.IsValid)
            {
                onlineBookRepository.InsertBookPage(bookPage);
                onlineBookRepository.Save();
            }
        }
        catch (DataException /* dex */)
        {
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
        }
        return CreatedAtAction(nameof(InsertBookPage), new { id = bookPage.BookPageID }, bookPage);
    }
    [HttpPut("UpdateBookPage/")]
    public ActionResult UpdateBookPage(BookPages bookPage)
    {
        try
        {
            if (ModelState.IsValid)
            {
                onlineBookRepository.UpdateBookPage(bookPage);
                onlineBookRepository.Save();
            }
        }
        catch (DataException /* dex */)
        {
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
        }
        return CreatedAtAction(nameof(UpdateBookPage), new { id = bookPage.BookPageID }, bookPage);
    }
    [HttpDelete("DeleteBookPage/{bookPageID}")]
    public string DeleteBookPage(int bookPageID)
    {
        try
        {
            if (ModelState.IsValid)
            {
                onlineBookRepository.DeleteBookPage(bookPageID);
                onlineBookRepository.Save();
            }
        }
        catch (DataException /* dex */)
        {
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
        }
        return "Deleted";
    }
    [HttpGet("GetUsers/")]
    public IEnumerable<Users> GetUsers()
    {

        IEnumerable<Users> users = onlineBookRepository.GetUsers();
        return users;

    }
    [HttpGet("GetUsers/{userID}")]
    public ActionResult<Users> GetUsersByID(int userID)
    {

        Users users = onlineBookRepository.GetUserByID(userID);
        return users;

    }
    [HttpPost("InsertUser/")]
    public ActionResult InsertUser(Users user)
    {
        try
        {
            if (ModelState.IsValid)
            {
                onlineBookRepository.InsertUser(user);
                onlineBookRepository.Save();
            }
        }
        catch (DataException /* dex */)
        {
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
        }
        return CreatedAtAction(nameof(InsertUser), new { id = user.UserID }, user);
    }
    [HttpPut("UpdateUser/")]
    public ActionResult UpdateUser(Users user)
    {
        try
        {
            if (ModelState.IsValid)
            {
                onlineBookRepository.UpdateUser(user);
                onlineBookRepository.Save();
            }
        }
        catch (DataException /* dex */)
        {
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
        }
        return CreatedAtAction(nameof(UpdateUser), new { id = user.UserID }, user);
    }
    [HttpDelete("DeleteUser/{userID}")]
    public string DeleteUser(int userID)
    {
        try
        {
            if (ModelState.IsValid)
            {
                onlineBookRepository.DeleteUser(userID);
                onlineBookRepository.Save();
            }
        }
        catch (DataException /* dex */)
        {
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
        }
        return "Deleted";
    }
    [HttpPost("InsertUserBook/")]
    public ActionResult InsertUserBook(UserBooks userBook)
    {
        try
        {
            if (ModelState.IsValid)
            {
                onlineBookRepository.InsertUserBook(userBook);
                onlineBookRepository.Save();
            }
        }
        catch (DataException /* dex */)
        {
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
        }
        return CreatedAtAction(nameof(InsertUserBook), new { id = userBook.UserBookID }, userBook);
    }
    [HttpDelete("DeleteUserBook/{userBookID}")]
    public string DeleteUserBook(int userBookID)
    {
        try
        {
            if (ModelState.IsValid)
            {
                onlineBookRepository.DeleteUserBook(userBookID);
                onlineBookRepository.Save();
            }
        }
        catch (DataException /* dex */)
        {
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
        }
        return "Deleted";
    }
    [HttpPost("InsertLoginInfo/")]
    public ActionResult InsertLoginInfo(LoginInfo loginInfo)
    {
        try
        {
            if (ModelState.IsValid)
            {
                onlineBookRepository.InsertLoginInfo(loginInfo);
                onlineBookRepository.Save();
            }
        }
        catch (DataException /* dex */)
        {
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
        }
        return CreatedAtAction(nameof(InsertLoginInfo), new { id = loginInfo.LoginInfoID }, loginInfo);
    }
    [HttpDelete("DeleteLoginInfo/{loginInfoID}")]
    public string DeleteLoginInfo(int loginInfoID)
    {
        try
        {
            if (ModelState.IsValid)
            {
                onlineBookRepository.DeleteUserBook(loginInfoID);
                onlineBookRepository.Save();
            }
        }
        catch (DataException /* dex */)
        {
            //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
            ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
        }
        return "Deleted";
    }
}

