
char[] digits = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

List<string> permutations = new();
List<double> pandigitals = new();

GetPer(digits);

//Code to go through all permutations moving the multiplication between all the combination and adding all cases in which the multiplication equals the rest of the digits
foreach(string permutation in permutations)
{
    for(int i = 1; i < digits.Length-3; i++)
    {
        for(int j = 1; j < digits.Length - i - 1; j++)
        {
            if(Convert.ToDouble(permutation.Substring(0,i)) * Convert.ToDouble(permutation.Substring(i,j)) == Convert.ToDouble(permutation.Substring(i + j)))
            {
                pandigitals.Add(Convert.ToDouble(permutation.Substring(i + j)));
            }
        }
    }
}

// Removing duplicates and adding all distinct pandigital results
double sum = 0;
foreach(double value in pandigitals.Distinct())
    sum = sum + value;
Console.WriteLine("The sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital is: " + sum);

// All the permutation code go from https://stackoverflow.com/questions/756055/listing-all-permutations-of-a-string-integer

void Swap(ref char a, ref char b)
{
    if (a == b) return;

    var temp = a;
    a = b;
    b = temp;
}

void GetPer(char[] list)
{
    int x = list.Length - 1;
    GetPermute(list, 0, x);
}

void GetPermute(char[] list, int k, int m)
{
    if (k == m)
    {
        permutations.Add(new string(list));
    }
    else
        for (int i = k; i <= m; i++)
        {
            Swap(ref list[k], ref list[i]);
            GetPermute(list, k + 1, m);
            Swap(ref list[k], ref list[i]);
        }
}