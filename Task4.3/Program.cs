var arr = new int[] { 5, 6, 9, 1, 2, 3, 4 };
PrintArr(arr, "Unsorted array");

int temp;

for (int i = 0; i < arr.Length; i++)
{
	for (int j = i + 1; j < arr.Length; j++)
	{
		if (arr[i] > arr[j])
		{
			temp = arr[i];
			arr[i] = arr[j];
			arr[j] = temp;
		}
	}
}

PrintArr(arr, "Sorted array");
int sum = 0;

foreach(var item in arr)
{
	sum += item;
}
Console.WriteLine($"Summa = {sum}");

int[,] array = { { -5, 6, 9, 1, 2, -3 }, { -8, 8, 1, 1, 2, -3 } };

//Делаем проход по каждой строке
for(int i = 0; i < array.GetUpperBound(0) + 1; i++)
{
	for(int j = 0; j < array.GetUpperBound(1) + 1; j++)
    {
		for (int k = 0; k < array.GetUpperBound(1) + 1; k++)
		{
			if (array[i,j] > array[i,k])
			{
				temp = array[i,j];
				array[i,j] = array[i,k];
				array[i, k] = temp;
			}
		}
	}	
}



//Console.WriteLine($"Number of positive values is {numpositive}");

Console.ReadLine();
//////////////////////////////////////////////////////////

void PrintArr(int[] arr, string message)
{
	Console.WriteLine(message);
	foreach (var item in arr)
        Console.Write(item);

    Console.WriteLine();
}

