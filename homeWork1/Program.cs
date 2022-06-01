using System;

namespace homeWork1
{
    public class Program
    {   
        public static void Main(string[] args) {
            Console.WriteLine("-------------------First Question-------------------");
            String even = "";
            Console.Write("Please input 'n' value : ");
            int.TryParse(Console.ReadLine(), out int n);

            for(int i=0; i<n; i++) {
                Console.Write($"Please input {i} number : ");
                int.TryParse(Console.ReadLine(), out int m);
                if(m%2==0) {
                    even += Convert.ToString(m) + " ";
                }
                
            }
            Console.WriteLine(even + "\n");

            Console.WriteLine("-------------------Second Question-------------------");
            Console.Write("Please input 'k' value : ");
            int.TryParse(Console.ReadLine(), out int k);
            Console.Write("Please input 'o' value : ");
            int.TryParse(Console.ReadLine(), out int o);
            String divisible = "";

            for(int i=0; i<k; i++) {
                Console.Write($"Please input {i} number : ");
                int.TryParse(Console.ReadLine(), out int j);
                if(j==o || j%o==0) {
                    divisible += Convert.ToString(j) + " ";
                }
                         
            }
            Console.WriteLine(divisible + "\n");   

            Console.WriteLine("-------------------Third Question-------------------");
            Console.WriteLine("Please input a value");
            int.TryParse(Console.ReadLine(), out int a);
            String[] arr = new String[a];
            for(int i=0; i<a; i++) {
                Console.Write("Please input a string : ");
                arr[i] = (Console.ReadLine());
            }
            
            foreach (String item in arr.Reverse())
            {
                Console.Write(item + " ");
            }
            
            Console.WriteLine("\n-------------------Third Question-------------------");

            Console.WriteLine("Please input a sentence");
            String sentence = Console.ReadLine();
            sentence = sentence.Replace(" ","");
            Console.WriteLine(sentence.Length);
        }   
    }
}