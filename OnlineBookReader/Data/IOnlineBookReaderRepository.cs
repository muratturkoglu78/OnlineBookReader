using System;
namespace OnlineBookReader.Data
{
    public interface IOnlineBookReaderRepository
    {
        IEnumerable<Books> GetBooks();
        Books GetBookByID(int bookID);
        void InsertBook(Books book);
        void DeleteBook(int bookID);
        void UpdateBook(Books book);
        void InsertBookPage(BookPages bookpage);
        void DeleteBookPage(int bookPageID);
        void UpdateBookPage(BookPages bookpage);
        IEnumerable<Users> GetUsers();
        Books GetUserByID(int userID);
        void InsertUser(Users user);
        void DeleteUser(int userID);
        void UpdateUser(Users user);
        void InsertUserBook(UserBooks userbook);
        void DeleteUserBook(int userBookID);
        void InsertLoginInfo(LoginInfo loginInfo);
        void DeleteLoginInfo(int loginInfoID);
        void Save();
    }
}
