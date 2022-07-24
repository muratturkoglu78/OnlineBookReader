using System;
using Microsoft.EntityFrameworkCore;

namespace OnlineBookReader.Data
{
    public class OnlineBookReaderRepository : IOnlineBookReaderRepository
    {
        private OnlineBookReaderContext context;

        public OnlineBookReaderRepository(OnlineBookReaderContext context)
        {
            this.context = context;
        }

        public IEnumerable<Books> GetBooks()
        {
            var books = context.Books.ToList();
            foreach (var book in books)
            {
                context.BookPages.Where(e => e.BookID == book.BookID).ToList();
            }
            return books;
        }

        public Books GetBookByID(int bookID)
        {
            var book = context.Books.Find(bookID);
            context.BookPages.Where(e => e.BookID == bookID).ToList();

            return book;
        }

        public void InsertBook(Books book)
        {
            context.Books.Add(book);
        }

        public void DeleteBook(int bookID)
        {
            Books book = context.Books.Find(bookID);
            context.Books.Remove(book);
        }

        public void UpdateBook(Books book)
        {
            context.Entry(book).State = EntityState.Modified;
        }

        public void InsertUserBook(UserBooks userbook)
        {
            context.UserBooks.Add(userbook);
        }

        public void DeleteUserBook(int userBookID)
        {
            UserBooks userbook = context.UserBooks.Find(userBookID);
            context.UserBooks.Remove(userbook);
        }

        public void InsertLoginInfo(LoginInfo loginInfo)
        {
            context.LoginInfo.Add(loginInfo);
        }

        public void DeleteLoginInfo(int loginInfoID)
        {
            LoginInfo loginInfo = context.LoginInfo.Find(loginInfoID);
            context.LoginInfo.Remove(loginInfo);
        }

        public void InsertBookPage(BookPages bookpage)
        {
            context.BookPages.Add(bookpage);
        }

        public void DeleteBookPage(int bookPageID)
        {
            BookPages bookpage = context.BookPages.Find(bookPageID);
            context.BookPages.Remove(bookpage);
        }

        public void UpdateBookPage(BookPages bookpage)
        {
            context.Entry(bookpage).State = EntityState.Modified;
        }

        public IEnumerable<Users> GetUsers()
        {
            var users = context.Users.ToList();
            foreach (var user in users)
            {
                context.UserBooks.Where(e => e.UserID == user.UserID).ToList();
            }
            return users;
        }

        public Books GetUserByID(int userID)
        {
            var user = context.Books.Find(userID);
            context.UserBooks.Where(e => e.UserID == userID).ToList();

            return user;
        }

        public void InsertUser(Users user)
        {
            context.Users.Add(user);
        }

        public void DeleteUser(int userID)
        {
            Users user = context.Users.Find(userID);
            context.Users.Remove(user);
        }

        public void UpdateUser(Users user)
        {
            context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}



