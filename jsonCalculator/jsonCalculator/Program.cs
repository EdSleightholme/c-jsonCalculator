/*
Author: Ed Sleightholme
Last Updated:19/07/2018
Purpose: Is a basic calculator. Tests class Calucator
  
 
 
Future 
1.Add better automated testing
2.Add use of backets
3.Add more advanced mathmatical processes(sin,cosine,tan,square root etc)
4.Add more options in processing calucations(more ways of + for example)
*/
using System;
using System.IO;
namespace jsonCalculator
{
    class Program
    {
        //Takes a file path and returns a string
        static string FileReader(String filePath)
        {
            var r = new StreamReader(filePath);
            var myJson = r.ReadToEnd();
            r.Close();
            return (myJson);
        }

        static void Main(string[] args)
        {
            //test to see if basic plus works
            Calculator test = new Calculator("ExampleTestFiles/example1.json", "answers/answer1.json");
            string temp = FileReader("answers/answer1.json");
            Console.WriteLine("example1.json");
            Console.WriteLine(temp);
            if (temp != "2")
            {
                Console.WriteLine("FAIL");
            }
            else
            {
                Console.WriteLine("PASS");
            }
            //test to see if deciaml loading words
            test = new Calculator("ExampleTestFiles/example2.json", "answers/answer2.json");
            temp = FileReader("answers/answer2.json");
            Console.WriteLine("example2.json");
            Console.WriteLine(temp);
            if (temp != "2.4")
            {
                Console.WriteLine("FAIL");
            }
            else
            {
                Console.WriteLine("PASS");
            }
            //see if basic subtraction works
            test = new Calculator("ExampleTestFiles/example3.json", "answers/answer3.json");
            temp = FileReader("answers/answer3.json");
            Console.WriteLine("example3.json");
            Console.WriteLine(temp);
            if (temp != "-0.4")
            {
                Console.WriteLine("FAIL");
            }
            else
            {
                Console.WriteLine("PASS");
            }
            //see if basic multiplying works
            test = new Calculator("ExampleTestFiles/example4.json", "answers/answer4.json");
            temp = FileReader("answers/answer4.json");
            Console.WriteLine("example4.json");
            Console.WriteLine(temp);
            if (temp != "7")
            {
                Console.WriteLine("FAIL");
            }
            else
            {
                Console.WriteLine("PASS");
            }
            //see if basic divivsion works
            test = new Calculator("ExampleTestFiles/example5.json", "answers/answer5.json");
            temp = FileReader("answers/answer5.json");
            Console.WriteLine("example5.json");
            Console.WriteLine(temp);
            if (temp != "0.5")
            {
                Console.WriteLine("FAIL");
            }
            else
            {
                Console.WriteLine("PASS");
            }
            //see if using negative numbers works
            test = new Calculator("ExampleTestFiles/example6.json", "answers/answer6.json");
            temp = FileReader("answers/answer6.json");
            Console.WriteLine("example6.json");
            Console.WriteLine(temp);
            if (temp != "-127.5")
            {
                Console.WriteLine("FAIL");
            }
            else
            {
                Console.WriteLine("PASS");
            }
            //see if order of calcuation works
            test = new Calculator("ExampleTestFiles/example7.json", "answers/answer7.json");
            temp = FileReader("answers/answer7.json");
            Console.WriteLine("example7.json");
            Console.WriteLine(temp);
            if (temp != "-102.5")
            {
                Console.WriteLine("FAIL");
            }
            else
            {
                Console.WriteLine("PASS");
            }

            //see if basic indices works
            test = new Calculator("ExampleTestFiles/example8.json", "answers/answer8.json");
            temp = FileReader("answers/answer8.json");
            Console.WriteLine("example8.json");
            Console.WriteLine(temp);
            if (temp != "27")
            {
                Console.WriteLine("FAIL");
            }
            else
            {
                Console.WriteLine("PASS");
            }
            //see if using invalid number causes custom error
            try
            {
                Console.WriteLine("example9.json");
                test = new Calculator("ExampleTestFiles/example9.json", "answers/answer9.json");
                temp = FileReader("answers/answer9.json");
                Console.WriteLine(temp);
                Console.WriteLine("FAIL");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("PASS");
            }
            //see if using invalid symbol/number causes custom error
            try
            {
                Console.WriteLine("example10.json");
                test = new Calculator("ExampleTestFiles/example10.json", "answers/answer10.json");
                temp = FileReader("answers/answer10.json");
                Console.WriteLine(temp);
                Console.WriteLine("FAIL");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("PASS");
            }
            //see if alternative symbol use works
            test = new Calculator("ExampleTestFiles/example11.json", "answers/answer11.json");
            temp = FileReader("answers/answer11.json");
            Console.WriteLine("example11.json");
            Console.WriteLine(temp);
            if (temp != "-97.5")
            {
                Console.WriteLine("FAIL");
            }
            else
            {
                Console.WriteLine("PASS");
            }

            //see error caused by a maths error
            Console.WriteLine("example12.json");
            test = new Calculator("ExampleTestFiles/example12.json", "answers/answer12.json");
            temp = FileReader("answers/answer12.json");
            Console.WriteLine(temp);
            Console.WriteLine("PASS");


            Console.ReadLine();
        }
    }
}
