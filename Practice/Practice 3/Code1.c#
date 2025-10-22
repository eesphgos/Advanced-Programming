using System;

class Program
{
    static void Main()
    {
        string txt = File.ReadAllText("path.txt");


        string[] line = File.ReadAllLines("path.txt");
        Console.WriteLine("Number of lines :"+line.Length);

        int sumstar = 0;
        for (int i = 0; i < line.Length; i++)
        {
            string[] stars = line[i].Split();

            sumstar += stars.Length - 1; 
        }
        Console.WriteLine("Number of stars :" + sumstar);

        char[] digit = txt.ToCharArray();

        int sumdigit = 0;
        int vovelsund = 0;
        for(int i = 0; i < digit.Length; i++)
        {
            if (char.IsDigit(digit[i]))
            {
                sumdigit++;
            }
            if (digit[i] == 'a' || digit[i] == 'o' || digit[i] == 'e' || digit[i] == 'u' || digit[i] == 'i' || digit[i] == 'A' || digit[i] == 'O' || digit[i] == 'E' || digit[i] == 'U' || digit[i] == 'I')
            {
                vovelsund++;
            }
        }
        Console.WriteLine("Number of digits :" + sumdigit);
        Console.WriteLine("Number of vowel sound :" + vovelsund);
  

        int WordWithPO = 0;
        int gymcounter = 0;
        string[] words = txt.Split();
        for (int i = 0; i < words.Length; i++)
        {   

            char[] word = words[i].ToCharArray();
            if (word.Length == 0) { continue; }


            if ((word[0] == 'p' || word[0] == 'P') && (word[word.Length - 1] == 'E' || word[word.Length - 1] == 'e'))
            {

                WordWithPO++;
            }
            for (int j = 0; j < word.Length-1; j++)
            {
                if ((word[j] == 'g' || word[j] == 'G')&& (word[j + 1] == 'y' || word[j + 1] == 'Y')&& (word[j + 2] == 'm' || word[j + 2] == 'M'))
                {
                    gymcounter++;
                }
            }

        }


        Console.WriteLine("Number of word with p start and e end :" + WordWithPO);
        Console.WriteLine("Number of word \"gym\" in text :" + gymcounter);

        char[] text = txt.ToCharArray();
        for(int i = 0; i < text.Length; i++)
        {
            if (text[i]==' ')
            {
                text[i] = '*';
            }
        };
        string finaltxt = string.Join("", text);
        
        File.WriteAllText("path.txt",finaltxt);
    }
}
//Going to the gym regularly helps improve strength and endurance.
//Many people visit the gym to lift weights and build muscle.
//A well-equipped gym provides the perfect environment for both cardio and resistant training.
