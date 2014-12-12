using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrackingTheCodingInterview.Chapter1;

namespace CrackingTheCodingInterview.Chapter1.Tests
{
	[TestClass]
	public class Question001_2_Test
	{
		[TestMethod]
		public void ReverseInPlace_EvenLengthString_Reverses()
		{
			char[] input = "abcd".ToCharArray();
			Question001_2.ReverseInPlace(ref input);
            string actual = new string(input);
			Assert.AreEqual(actual, "dcba");
		}
		
		[TestMethod]
		public void ReverseInPlace_OddLengthString_Reverses()
		{
			char[] input = "abcde".ToCharArray();
			Question001_2.ReverseInPlace(ref input);
			string actual = new string(input);
			Assert.AreEqual(actual, "edcba");
		}
		
		[TestMethod]
		public void Reverse_EvenLengthString_Revereses()
		{
			string actual = Question001_2.Reverse("abcd");
			Assert.AreEqual(actual, "dcba");
		}
		
		[TestMethod]
		public void Reverse_OddLengthString_Revereses()
		{
			string actual = Question001_2.Reverse("abcde");
			Assert.AreEqual(actual, "edcba");
		}
	}
}