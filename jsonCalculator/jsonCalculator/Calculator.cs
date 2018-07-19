/*
Author: Ed Sleightholme
Last Updated:19/07/2018
Purpose: Is a basic calculator. That takes in a json file containing a calcuation. Then creates a 
json file with answer calcauated from path given
  
 
Future Plans
1.Add better automated testing
2.Add use of backets
3.Add more advanced mathmatical processes(sin,cosine,tan etc)
4.Add more options in processing calucations(more ways of + for example)
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace jsonCalculator
{
    class Calculator
    {
        // Constuctor that takes a filepath and does a calcuation on file recived and 
        //produces a file using the outpath containing the answer
        public Calculator(string filePath, string outputpath)
        {
            //load in json file
            string jsonFile = FileReader(filePath);
            //convert json file in to standised format
            List<string> listOperations = StripStringToStandisedList(jsonFile);

            if (listOperations[0] == "-")
            {
                //if start symbol is - change first number to negative and change symbol to a +
                listOperations[0] = "+";
                Double tempVal = 0;
                Double.TryParse(listOperations[1], out tempVal);
                listOperations[1] = (-tempVal).ToString();
            }
            else if (listOperations[0] == "+")
            {
                // nothing needed to be done
            }
            else
            {
                throw new System.ArgumentException("Json file given first symbol is not valid (must be  plus,sub,+,-)");
            }
            //do all indices operations
            listOperations = DealWithIndicesCalucations(listOperations);
            //do all divide operations
            listOperations = DealWithDivCalucations(listOperations);
            //do all multiply operations
            listOperations = DealWithMultiCalucations(listOperations);
            //do all plus operations
            listOperations = DealWithPlusCalucations(listOperations);
            //do all subtraction operations
            listOperations = DealWithSubCalucations(listOperations);

            //get answer
            string answer = listOperations[1];
            //write answer to json file
            FileWriter(outputpath, answer);
        }
        //Deals with Indices calucations in a standised calcaulation list 
        private List<string> DealWithIndicesCalucations(List<string> listOperations)
        {
            List<string> toReturn = new List<string>();
            int count = 0;
            bool skip = false;
            //loop though calcuation string
            foreach (string command in listOperations)
            {
                //find ^ symbol then preform indices operation on numbers on either side of symbol 
                if (command == @"^" && count != 0 && count != listOperations.Capacity)
                {
                    //convert string to doubles
                    Double.TryParse(listOperations[count - 1], out double prefix);
                    Double.TryParse(listOperations[count + 1], out double suffix);
                    toReturn.RemoveAt(toReturn.Count - 1);//remove unneeded number
                    toReturn.Add((Math.Pow(prefix, suffix).ToString()));
                    skip = true;//miss next number
                }
                else if (skip == false)
                {
                    toReturn.Add(listOperations[count]);
                }
                else
                {
                    skip = false;//skip adding a number
                }
                count = count + 1;
            }

            return toReturn;
        }
        //Deals with Division calucations in a standised calcaulation list 
        private List<string> DealWithDivCalucations(List<string> listOperations)
        {
            List<string> toReturn = new List<string>();
            int count = 0;
            bool skip = false;
            //loop though calcuation string
            foreach (string command in listOperations)
            {
                //find / symbol and preform calucation on numbers on either side of it 
                if (command == @"/" && count != 0 && count != listOperations.Capacity)
                {
                    //convert string to doubles
                    Double.TryParse(listOperations[count - 1], out double prefix);
                    Double.TryParse(listOperations[count + 1], out double suffix);
                    toReturn.RemoveAt(toReturn.Count - 1);//remove unneeded number
                    toReturn.Add((prefix / suffix).ToString());
                    skip = true;//miss next number
                }
                else if (skip == false)
                {
                    toReturn.Add(listOperations[count]);
                }
                else
                {
                    skip = false; //skips number
                }
                count = count + 1;
            }

            return toReturn;
        }
        //Deals with multiply calucations in a standised calcaulation list 
        private List<string> DealWithMultiCalucations(List<string> listOperations)
        {
            List<string> toReturn = new List<string>();
            int count = 0;
            bool skip = false;
            //loop though command string
            foreach (string command in listOperations)
            {
                //find * symbol and preform calucation on numbers on either side of it 
                if (command == "*" && count != 0 && count != listOperations.Capacity)
                {
                    //convert string to double
                    Double.TryParse(listOperations[count - 1], out double prefix);
                    Double.TryParse(listOperations[count + 1], out double suffix);
                    toReturn.RemoveAt(toReturn.Count - 1);
                    toReturn.Add((prefix * suffix).ToString());
                    skip = true;
                }
                else if (skip == false)
                {
                    toReturn.Add(listOperations[count]);
                }
                else
                {
                    skip = false;
                }
                count = count + 1;
            }

            return toReturn;
        }
        //Deals with subtaction calucations in a standised calcaulation list 
        private List<string> DealWithSubCalucations(List<string> listOperations)
        {
            List<string> toReturn = new List<string>();
            int count = 0;
            bool skip = false;
            //loop though list operations
            foreach (string command in listOperations)
            {
                //find command - and perfrom operation on numbers either side
                if (command == "-" && count != 0 && count != listOperations.Capacity)
                {
                    Double.TryParse(listOperations[count - 1], out double prefix);
                    Double.TryParse(listOperations[count + 1], out double suffix);
                    toReturn.RemoveAt(toReturn.Count - 1);
                    toReturn.Add((prefix - suffix).ToString());
                    skip = true;
                }
                else if (skip == false)
                {
                    toReturn.Add(listOperations[count]);
                }
                else
                {
                    skip = false;
                }
                count = count + 1;
            }

            return toReturn;
        }
        //Deals with addition calucations in a standised calcaulation list 
        private List<string> DealWithPlusCalucations(List<string> listOperations)
        {
            List<string> toReturn = new List<string>();
            int count = 0;
            bool skip = false;
            //loop though list of operations
            foreach (string command in listOperations)
            {
                //at + operation add numbers either side together
                if (command == "+" && count != 0 && count != listOperations.Capacity)
                {
                    Double.TryParse(listOperations[count - 1], out double prefix);
                    Double.TryParse(listOperations[count + 1], out double suffix);
                    toReturn.RemoveAt(toReturn.Count - 1);
                    toReturn.Add((prefix + suffix).ToString());
                    skip = true;
                }
                else if (skip == false)
                {
                    toReturn.Add(listOperations[count]);
                }
                else
                {
                    skip = false;
                }
                count = count + 1;
            }

            return toReturn;
        }

        private List<string> StripStringToStandisedList(String fileToProcess)
        {
            //trim down to operation number pairs
            string pattern = @"([^a-zA-Z0-9.\/\*\-\+\^])";
            //remove all unnessaacry text
            var splitJson = Regex.Replace(fileToProcess, pattern, " ");
            //cut down blank space
            splitJson = Regex.Replace(splitJson, "  ", " ");
            //make a list on spaces
            string[] words = splitJson.Split(' ');

            List<string> toReturn = new List<string>();
            List<string> typeCommand = new List<string>();
            int count = 0;
            foreach (var word in words)
            {
                //switch statment??
                if (word == "")
                {

                }//add a number
                else if (Regex.IsMatch(word, @"^-?[0-9]\d*(\.\d+)?$") || Regex.IsMatch(word, @"^-?[0-9]\d*(\.\d+)?$"))
                {
                    toReturn.Add(word);
                    typeCommand.Add("number");
                }//look for plus symbols
                else if ("plus" == word || "+" == word)
                {
                    toReturn.Add("+");
                    typeCommand.Add("symbol");
                }//look for suntraction symbols
                else if ("sub" == word || "-" == word)
                {
                    toReturn.Add("-");
                    typeCommand.Add("symbol");
                }//look for multiply symbols
                else if ("mult" == word || "*" == word)
                {
                    toReturn.Add("*");
                    typeCommand.Add("symbol");
                }//look for divide symbols
                else if ("div" == word || "/" == word)
                {
                    toReturn.Add("/");
                    typeCommand.Add("symbol");
                }//look for incies symbols
                else if ("indices" == word || "^" == word)
                {
                    toReturn.Add("^");
                    typeCommand.Add("symbol");
                }
                else //if dont reconize symbol throw error
                {
                    throw new System.ArgumentException("Json file given contains unrecognized symbol (" + word + ") " +
                        "Error at line " + ((count / 2) + 1) + " in json file", "original");
                }
                count += 1;
            }
            //check order operations is correct. Must be symbol number loop
            count = 0;
            foreach (string command in typeCommand)
            {
                if (0 == count % 2)
                {
                    if (command != "symbol")
                    {
                        throw new System.ArgumentException("Json file given is not in correct format. " +
                            "Expected to be symbol,number ordering. Error at number location line " +
                            ((count / 2) + 1).ToString() + " in json file", "original");
                    }
                }
                else
                {
                    if (command != "number")
                    {
                        throw new System.ArgumentException("Json file given is not in correct format. " +
                            "Expected to be symbol,number ordering. Error at symbol location line " +
                            ((count / 2) + 1).ToString() + " in json file", "original");
                    }
                }
                count++;
            }
            return toReturn;
        }
        //Takes a file path and returns a string
        private string FileReader(String filePath)
        {
            var r = new StreamReader(filePath);
            var myJson = r.ReadToEnd();
            r.Close();
            return (myJson);
        }
        //Takes a file path and writes a file there
        private void FileWriter(String filePath, String toWrite)
        {
            var w = new StreamWriter(filePath);
            w.Write(toWrite);
            w.Close();
        }

    }
}
