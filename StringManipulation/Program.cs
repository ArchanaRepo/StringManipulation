using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace StringManipulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string message = "I am living in India";
            //Reverse the string
            string reverseString = "";
            for(int i=message.Length-1; i>=0; i--) 
            {
                reverseString = reverseString + message[i];
            }
            Console.WriteLine(reverseString);

            //print all characters  and their count
            var result = CountCharactersInString(message);
            foreach(KeyValuePair<char,int> pair in result) 
            {
                Console.WriteLine($"character : {pair.Key} and occurance: {pair.Value}");
            }

            //print only repeated characters
            foreach (KeyValuePair<char, int> pair in result)
            {
                if (pair.Value > 1)
                {
                    Console.WriteLine($"character : {pair.Key} and occurance: {pair.Value}");
                }
            }

          
            //replace i char by @ and return string
            string s = "My name is Archana Bangar";
            var r = ReplaceCharacter(s, 'A','@');
            Console.WriteLine(r);

            //count no of perticular char in string
            string str = "Hello My N@me is @rch@n@ B@ng@r";
            var count = CountNoOfCharInString(str, '@');
            Console.WriteLine($" @ present  {count} times in {str}");

            string s1 = "My Name Is Archana";
            string s2 = "My Name Is Archana";
            var c = AreAnagram(s1, s2);
            Console.WriteLine($"{s1} and {s2} are Anagram string : {c}");


            //check for palindrom string
            string str2 = "RadaR";
            var palindrom = IsStringPalindrom(str2);
            Console.WriteLine($" string {str2} is palindrom : {palindrom}");

            //Append Occurance and char
            string appstr = "aaaabccdde";
            var output= AppendCharAndOccurance(appstr);
            Console.WriteLine($" updated string for {appstr} is {output}");

            //Print  Longest Substring in string
            string str11 = "My Name Is Archna Bangarr and my son name is vivan gupta";
            output = FindLongestSubString(str11);
            Console.WriteLine($"Longest Substring in {str11} is {output} ");



            Console.ReadLine();


        }

       static string FindLongestSubString(string inputString)
        {
            string[] stringArray = inputString.Split(' ');
            int index = 0;
            int maxLength = 0;
            for(int i=0;i<stringArray.Length; i++) 
            {
                Console.WriteLine(stringArray[i]);
                if (stringArray[i].Length >= maxLength) 
                { maxLength = stringArray[i].Length;
                    index = i;
                }
            
            }
            return stringArray[index];


        }


        static string AppendCharAndOccurance(String str)
        {
            string newString = "";
             Dictionary<char,int> dict=new Dictionary<char,int>();
            foreach(char c in str)
            {
                if(dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            foreach(KeyValuePair<char,int> pair in dict)
            {
                newString=newString+pair.Key+pair.Value;
            }
            return newString;

        }

        static bool IsStringPalindrom(string input)
        {
            string cleanedInput = new string(input.ToLower().Where(c => Char.IsLetterOrDigit(c)).ToArray());
            int left = 0;
            int right = cleanedInput.Length - 1;
            while(left<right)
            {
                if (cleanedInput[left] != cleanedInput[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;

        }

        static bool AreAnagram(string str1,string str2)
        {
            Dictionary<char,int> dict1 = new Dictionary<char,int>();
            Dictionary<char,int> dict2= new Dictionary<char,int>();

            foreach(char c in str1)
            {
                if(dict1.ContainsKey(c))
                {
                    dict1[c]++;
                }
                else
                {
                    dict1.Add(c, 1);
                }
            }
            foreach (char c in str2)
            {
                if (dict2.ContainsKey(c))
                {
                    dict2[c]++;
                }
                else
                {
                    dict2.Add(c, 1);
                }
            }

            //compare size
            if(dict1.Count !=dict2.Count)
            {
                return false;
            }

            //compare two dictionary
            foreach( KeyValuePair<char,int> pair in dict1)
            {
                var key=pair.Key;
                var value=pair.Value;
                if(!dict2.ContainsKey(key) || dict2[key]!=value) 
                {
                    return false;
                }
                
            }
            return true;

        }

        public  static int CountNoOfCharInString(string s, char ch)
        {
            string[] array = s.Split(ch);
            return array.Length - 1;
        }

        public static string ReplaceCharacter(String input, char charToBeReplaced , char newCharacter)
        {
            string newString = "";
            foreach(char c in input)
            {
                char x;

                if(c== charToBeReplaced)
                {
                    x = newCharacter;
                    newString = newString + x;
                }
                else
                {
                    x = c;
                    newString = newString + x;
                }
              
            }
            return newString;

        }

        public static Dictionary<char,int> CountCharactersInString(string input)
        {
            Dictionary<char,int> charOccurance = new Dictionary<char,int>();
           
            foreach(char character in input) 
            { 
                if(char.IsLetterOrDigit(character))
                {
                    if(charOccurance.ContainsKey(character))
                    {
                        charOccurance[character]++;
                    }
                    else
                    {
                        charOccurance.Add(character, 1);
                    }
                }
            
            }

            return charOccurance;
        }

    }
}
