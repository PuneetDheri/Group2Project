using System;
namespace MyMediaLibrary
{
	//AUTHOR: JULIUS
	//gets the method of name
	//property and constructor

	public class User
	{
		//both user are going to be private value
		private string _name;
	

		//constructor
		public User(string name)
		{
			_name = name;
			
		}

		//methods GetName() are going to return the value
		//the name and the methods
		public string GetName() {
			return _name;
		}

		

	}
}

