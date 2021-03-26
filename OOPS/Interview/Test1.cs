namespace OOPS.Test1
{
    public class Test1
    {
        public bool CheckPalindrome1(string input)
        {
            bool IsOddLength = true;

            char[] arr = input.ToCharArray();

            if (arr.Length % 2 != 1)
                IsOddLength = false;

            int mid_Value = ((arr.Length / 2));
            char[] temp = new char[mid_Value];

            for (int i = 0; i < mid_Value; i++)
                temp[i] = arr[i];

            int k = 0;

            if (IsOddLength)
            {
                for (int j = arr.Length - 1; j > mid_Value + 1; j--)
                {
                    if (temp[k] == arr[j])
                    {
                        k++;
                        continue;
                    }
                    else
                        return false;
                }
            }
            else
            {
                for (int j = arr.Length - 1; j > mid_Value - 1; j--)
                {
                    if (temp[k] == arr[j])
                    {
                        k++;
                        continue;
                    }
                    else
                        return false;
                }
            }

            return true;
        }

        public bool CheckPalindrome2(string input)
        {
            string[] arr = input.Split(new char[] { ' ' });

            if (arr.Length % 2 != 1)
            {
                return false;
            }

            int mid_Value = ((arr.Length / 2));

            string[] temp = new string[mid_Value];

            for (int i = 0; i < mid_Value; i++)
            {
                temp[i] = arr[i];
            }

            int k = 0;
            for (int j = arr.Length - 1; j > mid_Value + 1; j--)
            {
                if (temp[k] == arr[j])
                {
                    k++;
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class Client
    {
        public static void Execute()
        {
            Test1 test1 = new Test1();
            bool result0 = test1.CheckPalindrome1("anna");
            bool result1 = test1.CheckPalindrome1("nitin");
            bool result2 = test1.CheckPalindrome2("this is bob is this");   // this sentence may be considered as palendrome or may not be, based on below string
            bool result3 = test1.CheckPalindrome1("this is bob si siht");
        }
    }
}
