using System;
namespace MyMediaLibrary
{
	public class User
	{
		//both user and email are going to be private values
		private string _name;
		private string _email;

		//constructorr
		public User(string name, string email)
		{
			_name = name;
			_email = email;
		}

		//methods GetName() and GetEmail() are going to return
		//the name and the email
		public string GetName() {
			return _name;
		}

		public string GetEmail() {

			return _email;
		}

	}
}

