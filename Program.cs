namespace Program
{
    class Project
    {
        public static string fileName()
        {
            System.Console.Write("Enter the name of the file :");
            return Console.ReadLine()!;
        }
        public static void Main()
        {
            Oops o = new Oops();
            System.Console.Write("Username : ");
            string username = Console.ReadLine()!;

            System.Console.Write("Password : ");
            string password = Console.ReadLine()!;



            if (o.authenticated(username, password))
            {
                System.Console.Write("Enter\n 1. Create\n 2. Read\n 3. Create and Read\nEnter Input: ");
                string n = Console.ReadLine()!;

                switch (n)
                {
                    case "1": o.Create(username, password, fileName()); break;
                    case "2": o.Open(username, password, fileName()); break;
                    case "3": o.Create(username, password, fileName(), true); break;
                    default : System.Console.WriteLine("Invalid input..."); break;
                    
                }
            }
            else
            {
                System.Console.WriteLine("Authentication Failed...");
            }


        }

    }
}