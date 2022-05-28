using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Custom_Exceptions.Exceptions;

namespace IEntity_interface.Models
{
	public class Library
	{
		public int BookLimit { get; set; }
		public int Id { get; }
		private static int _id;
		private List<Book> _books;

		public Library()
		{
			_id++;
			Id = _id;
			_books = new List<Book>();
		}
		public void AddBook(Book book)
		{
			if (_books.Exists(b => b.Name == book.Name && b.IsDeleted == false))
				throw new AlreadyExistsException("");

			if (_books.Count < BookLimit)
			{
				_books.Add(book);
				return;
			}

			throw new CapacityLimitException("");

		}
		public Book GetBookById(int? id)
		{
			if (id == null)
			{
				throw new NullReferenceException("");
			}

			Book book = _books.Find(b => b.Id == id && b.IsDeleted == false);
			if (book == null)
			{
				throw new NotFoundException("");

			}

			return book;
		}

		public List<Book> GetAllBook()
		{
			List<Book> booksCopy = new List<Book>();
			booksCopy.AddRange(_books);

			return booksCopy;
		}

		public void DeleteBookById(int? id)
		{
			if (id == null)
				throw new NullReferenceException("");

			Book book = _books.Find(b => b.Id == id && b.IsDeleted == false);
			if (book == null)
				throw new NotFoundException("");
			book.IsDeleted = true;
		}

		public void EditBookName(int? id, string name)
		{
			if (id == null || string.IsNullOrWhiteSpace(name))
				throw new NullReferenceException("");

			Book book = _books.Find(b => b.Id == id && b.IsDeleted == false);
			if (book == null)
				throw new NotFoundException("");

			book.Name = name;
		}

		public List<Book> FilterByPageCount(int minPageCount, int maxPageCount)
		{
			return _books.FindAll(b => b.PageCount >= minPageCount && b.PageCount <= maxPageCount && b.IsDeleted == false);
		}

	}
}

    