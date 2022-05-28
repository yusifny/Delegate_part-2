using System;
using IEntity_interface.Interface;

namespace IEntity_interface.Models
{
	public class Book :IEntity
	{
		public string Name { get; set; }
		public string AuthorName { get; set; }
		public int PageCount { get; set; }
		public bool IsDeleted { get; set; } = false;

		public int Id { get; }
		private static int _id;

		public void ShowInfo()
		{
			Console.WriteLine($"Name:{Name}\nAuthorName:{AuthorName}\nPageCount:{PageCount}\nIsDeleted:{IsDeleted}");
		}

		public Book(string name, string authorName, int pageCount)
		{
			_id++;
			Id = _id;
			Name = name;
			AuthorName = authorName;
			PageCount = pageCount;
		}

	}
}

