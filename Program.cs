
using System.Text.RegularExpressions;

namespace AVtomat
{
    internal class Program
    {
       static Regex zeroReg = new Regex("^0");
       static Regex oneReg = new Regex("^1");
       static Regex S0Reg = new Regex("^S0");
       static Regex A1Reg = new Regex("^A1");
       static Regex A0Reg = new Regex("^A0");
       static Regex B0Reg = new Regex("^B0");
            
        static void Main(string[] args)
        {
            while (true)
            {
                string extenssion = EnterLine();
                if (IsBelong(extenssion))
                {
                    Console.WriteLine("Слово принадлежит алфавиту");
                }
                else
                {
                    Console.WriteLine("Слово не принадлежит алфавиту");
                }
            }
        }

        static string EnterLine()
        {
            Regex inputReg = new Regex("^[01]+$");

            Console.WriteLine("Enter word: ");
            var input = Console.ReadLine();

            while (!inputReg.IsMatch(input))
            {
                Console.WriteLine("Try again: ");
                input = Console.ReadLine();
            }

            return input;
        }

        static bool IsBelong(string mainExtenssion)
        {
            var returnFlag = false;
            if (zeroReg.IsMatch(mainExtenssion) || oneReg.IsMatch(mainExtenssion))
            {
                var extenssion = new string(mainExtenssion);

                extenssion = extenssion.Remove(0, 1);
                extenssion = "S" + extenssion;
                if (extenssion == "S")
                    return true;

                returnFlag =  IsBelong(extenssion);

                if (returnFlag) return true;


                extenssion = extenssion.Remove(0, 1);
                extenssion = "A" + extenssion;

                return IsBelong(extenssion);
            }
            else if (A1Reg.IsMatch(mainExtenssion))
            {
                var extenssion = new string(mainExtenssion);

                extenssion = extenssion.Remove(0, 2);
                extenssion = "S" + extenssion;
                if (extenssion == "S")
                    return true;

                returnFlag = IsBelong(extenssion);

                if (returnFlag) return true;

                extenssion = extenssion.Remove(0, 1);
                extenssion = "A" + extenssion;

                return IsBelong(extenssion);
            }
            else if(S0Reg.IsMatch(mainExtenssion))
            {
                var extenssion = new string(mainExtenssion);

                extenssion = extenssion.Remove(0, 2);
                extenssion = "S" + extenssion;
                if (extenssion == "S")
                    return true;

                return IsBelong(extenssion);
            }
            else if (B0Reg.IsMatch(mainExtenssion))
            {
                var extenssion = new string(mainExtenssion);

                extenssion = extenssion.Remove(0, 2);
                extenssion = "A" + extenssion;

                return IsBelong(extenssion);
            }
            else if (A0Reg.IsMatch(mainExtenssion))
            {
                var extenssion = new string(mainExtenssion);

                extenssion = extenssion.Remove(0, 2);
                extenssion = "B" + extenssion;

                return IsBelong(extenssion);
            }
            return false;
        }
    }
}