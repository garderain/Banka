using System;
namespace Banka
{
	public class DuplicateOibException: Exception
	{
		public DuplicateOibException(string message) : base(message)
		{

		}
	}

	public class MalformedOibException: Exception
	{
		public MalformedOibException(string message): base(message)
		{

		}
	}
}

