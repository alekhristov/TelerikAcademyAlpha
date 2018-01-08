using System;

namespace _01_BracketsExpressions
{
    public class Stack<T>
    {
        private T[] s;
        private int currentStackIndex;

        public Stack()
        {
            s = new T[4];
            currentStackIndex = 0;
        }

        public void push(T x)
        {
            if (currentStackIndex + 1 >= s.Length)
            {
                //Notice the + 1, to counter the 0 length problem
                Array.Resize(ref s, (s.Length + 1) * 2);
            }

            s[currentStackIndex++] = x;
        }

        public T pop()
        {
            if (currentStackIndex == 0)
                throw new InvalidOperationException("The stack is empty");

            T value = s[--currentStackIndex];
            s[currentStackIndex] = default(T);
            return value;
        }
    }
    class BracketsExpressions
    {
        static void Main(string[] args)
        {
            var expression = Console.ReadLine();
            var stack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack.push(i);
                }
                else if (expression[i] == ')')
                {
                    var startIndex = stack.pop();
                    Console.WriteLine(expression.Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
