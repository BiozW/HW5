using System;

class Program
{
    static void Main(string[] args)
    {
        string product_name;
        char texta_z = 'A';
        int number0_9 = 0;

        int m = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, string> productList = new Dictionary<string, string>();
        do
        {
            product_name = Console.ReadLine();

            if (product_name.ToLower() != "stop")
            {
                string product_id = GenerateProductID(texta_z, number0_9, m, n);
                productList.Add(product_id, product_name);
                Console.WriteLine(product_id);
                
                number0_9++;
                if (number0_9 > 9)
                {
                    number0_9 = 0;
                    texta_z++;
                    if(texta_z > 'Z')
                    {
                        texta_z = 'A';
                    }
                }
            }
        } 
        while (product_name.ToLower() != "stop");

        string searchID = Console.ReadLine();

        if (productList.ContainsKey(searchID))
        {
            string foundProductName = productList[searchID];
            Console.WriteLine(foundProductName);
        }
        else
        {
            Console.WriteLine("Product not found!");
        }
    }

    // Method to generate the product code
    static string GenerateProductID(char a_z, int num0_9, int charStage, int digitStage)
    {
        string id = a_z.ToString();
        id += num0_9.ToString().PadLeft(digitStage, '0');
        return id;
    }
}