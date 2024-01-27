using System.Net.NetworkInformation;

namespace Mod9FinPractice
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
              MyException ex = new MyException(); 
              ArgumentNullException argumentNullException = new ArgumentNullException();
              DriveNotFoundException driveNotFoundException = new DriveNotFoundException();
              FormatException formatException = new FormatException();
              OverflowException overflowException = new OverflowException();
              Exception[] exceptions = new Exception[5] { ex, argumentNullException, driveNotFoundException, formatException, overflowException };

              foreach (Exception exception in exceptions) 
              {
                  try
                  {
                      if (exception is MyException)
                      {
                          throw ex;
                      }
                      if (exception is OverflowException)
                      {
                          throw overflowException;
                      }
                      if (exception is FormatException)
                      {
                          throw formatException;
                      }
                      if (exception is ArgumentNullException)
                      {
                          throw argumentNullException;
                      }
                      if (exception is DriveNotFoundException)
                      {
                          throw driveNotFoundException;
                      }
                  }
                  catch
                  {
                      Console.WriteLine(exception.Message);
                  }
              }
            /**************************************************************************************************/
            Console.WriteLine("===================================================================================");

            NumberReader reader = new NumberReader();
            reader.NumberEnteredEvent += Sort;
            while (true)
            {
                try
                {
                    reader.Read();
                }
                catch (MyException)
                {
                    Console.WriteLine("Введено некорректное значение");
                }
            }

        }

        static void Sort(int number)
        {
            switch (number)
            {
                case 1:
                {
                        string[] arr = new string[5] { "Иванов", "Петров", "Сидоров", "Башмаков", "Алексеев" };
                        Console.WriteLine("До сортировки:");
                        foreach (string s in arr)
                        {
                            Console.WriteLine(s);
                        }
                        Console.WriteLine();
                        for (int i = 0; i < arr.Length; i++)
                        {
                            for(int j = 0; j < arr.Length - 1; j++)
                            {
                                if (needToReOrderFromA(arr[j], arr[j+1]))
                                {
                                    string s = arr[j];
                                    arr[j] = arr[j+1];
                                    arr[j+1] = s;
                                }
                            }
                        }
                        Console.WriteLine("После сортировки:");
                        foreach (string s in arr)
                        {
                            Console.WriteLine(s);
                        }
                        break;
                }
                case 2:
                {
                        string[] arr = new string[5] { "Иванов", "Петров", "Сидоров", "Башмаков", "Алексеев" };
                        Console.WriteLine("До сортировки:");
                        foreach (string s in arr)
                        {
                            Console.WriteLine(s);
                        }
                        Console.WriteLine();
                        for (int i = 0; i < arr.Length; i++)
                        {
                            for (int j = 0; j < arr.Length - 1; j++)
                            {
                                if (needToReOrder(arr[j], arr[j + 1]))
                                {
                                    string s = arr[j];
                                    arr[j] = arr[j + 1];
                                    arr[j + 1] = s;
                                }
                            }
                        }
                        Console.WriteLine("После сортировки:");
                        foreach (string s in arr)
                        {
                            Console.WriteLine(s);
                        }
                        break;
                }
                
                
            }
        }

        protected static bool needToReOrderFromA(string s1, string s2) 
        {
            for (int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++)
            {
                if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return false;
                if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return true;
            }
            return false;
        }

        protected static bool needToReOrder(string s1, string s2)
        {
            for(int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++)
            {
                if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return true;
                if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return false;
            }
            return false;
        }
    }

    class MyException : Exception
    {
        public MyException()
        {
            Data.Add("Дата исключения:", DateTime.Now);
            HelpLink = "www.Google.com";
        }
    }

    class NumberReader
    {
        public delegate void NumberEnteredDelegate(int value);
        public event NumberEnteredDelegate NumberEnteredEvent;
        public void Read()
        {
            Console.WriteLine("Для сортировки фамилий от А до Я введите 1, для сортировки фамилий от Я до А введите 2");
            int number;
            bool result = int.TryParse(Console.ReadLine(), out number);
            if (result == false || number != 1 && number != 2)
            {
                throw new MyException();
            }
            else
            NumberEntered(number);
        }

        protected virtual void NumberEntered(int number)
        {
            NumberEnteredEvent?.Invoke(number);
        }
        
    }
}
