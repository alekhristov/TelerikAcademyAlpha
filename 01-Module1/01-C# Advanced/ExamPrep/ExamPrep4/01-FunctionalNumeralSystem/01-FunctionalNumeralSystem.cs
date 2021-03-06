﻿using System;
using System.Linq;
using System.Numerics;

namespace _01_FunctionalNumeralSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            input = input
                .Replace("standardml", "9")
                .Replace("commonlisp", "D")
                .Replace("mercury", "C")
                .Replace("clojure", "7")
                .Replace("erlang", "8")
                .Replace("scheme", "E")
                .Replace("racket", "A")
                .Replace("haskell", "1")
                .Replace("ocaml", "0")
                .Replace("scala", "2")
                .Replace("curry", "F")
                .Replace("f#", "3")
                .Replace("lisp", "4")
                .Replace("rust", "5")
                .Replace("ml", "6")
                .Replace("elm", "B");

            var numbers = input.Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

            BigInteger product = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNum = Convert.ToInt64(numbers[i], 16);
                product *= currentNum;
            }
            Console.WriteLine(product);
        }
    }
}
