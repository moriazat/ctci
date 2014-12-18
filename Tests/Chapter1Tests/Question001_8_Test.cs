using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrackingTheCodingInterview.Chapter1.Tests
{
	[TestClass]
	public class Question001_8_Test
	{
		[TestMethod]
		public void IsRotation_NullStrings_ReturnsFalse()
		{
			bool actual = Question001_8.IsRotation(null, null);
			
			Assert.IsFalse(actual);
		}
		
		[TestMethod]
		public void IsRotation_NotEquallyLongStrings_ReturnsFalse()
		{
			bool actual = Question001_8.IsRotation("MyName", "YourName");
			
			Assert.IsFalse(actual);
		}
		
		[TestMethod]
		public void IsRotation_EquallyLongNonRotationStrings_ReturnsFalse()
		{
			bool actual = Question001_8.IsRotation("staff", "stuff");
			
			Assert.IsFalse(actual);
		}
		
		[TestMethod]
		public void IsRotaton_RotatedStrings_ReturnsTrue()
		{
			bool actual = Question001_8.IsRotation("tapwater", "watertap");
			
			Assert.IsTrue(actual);
		}
	}
}