namespace Program
{
    interface FileManager
    {
        public void Create(string username, string password, string fileName);
        public void Create(string username, string password, string fileName, bool read);
        public void Open(string username, string password, string fileName);
    }

    interface authenticator
    {
        public bool authenticated(string username, string password);
    }

    class Oops : authenticator,FileManager
    {
        private string username = "ujjwalkar";
        private string password = "123456";

        private bool auth = false;

        private string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                System.Console.WriteLine(fe);
                decrypted = "";
            }
            return decrypted;
        }

        private string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        public bool authenticated(string username, string password)
        {
            if ((this.username == username) && (this.password == password))
            {
                auth = true;
                return true;
            }
            return false;
        }

        public void Create(string username, string password, string fileName)
        {
            if (auth)
            {
                if (File.Exists(fileName))
                {
                    System.Console.WriteLine("File already exist, write another name for the file...");
                    string file = Console.ReadLine()!;
                    this.Create(username, password, file);
                }
                else
                {
                    using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
                    {
                        System.Console.WriteLine("Write content...");
                        writer.Write(EnryptString(Console.ReadLine()!));
                    }
                }

            }
            else
            {
                System.Console.WriteLine("Authentication Failed");
            }

        }

        public void Create(string username, string password, string fileName, bool read)
        {
            this.Create(username, password, fileName);
            this.auth = true;
            this.Open(username, password, fileName);

        }
        public void Open(string username, string password, string fileName)
        {
            if (auth)
            {
                if (File.Exists(fileName))
                {
                    using (BinaryReader read = new BinaryReader(File.Open(fileName, FileMode.Open)))
                    {
                        Console.WriteLine(DecryptString(read.ReadString()));
                    }
                }
                else
                {
                    System.Console.WriteLine("File does not exist...");
                }
            }
            else
            {
                System.Console.WriteLine("Authentication Failed");
            }
        }

    }
}