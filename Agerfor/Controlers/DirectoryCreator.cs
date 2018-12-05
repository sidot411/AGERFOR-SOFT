using System;
using System.IO;
using System.Windows;
namespace Agerfor.Controlers
{
    class DirectoryCreator
    { 
     public string CreateDirectory(string name)
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + name;

        try
        {
            // Determine whether the directory exists.
            if (Directory.Exists(path))
            {
                Console.WriteLine("That path exists already.");
                return "";
            }

            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(path);
            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
        finally
        {
        }

        return path;
    }
        public string CreateDirectory2(string name)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Client\" + name;

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    return "";
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally
            {
            }

            return path;
        }

        public string CreateDirectoryProgramme(string refprojet, string refprogramme)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + refprojet + @"\Programme\" + refprogramme;

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    return "";
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                MessageBox.Show(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally
            {
            }

            return path;
            
        }

        public string CreateDirectoryActe(string refprojet, string refprogramme, string numActe)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + refprojet + @"\Programme\" + refprogramme+ @"\Acte\" +numActe;
           
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    return "";
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally
            {
            }

            return path;

        }
        public void DeleteDirectory(string name)
    {
        string path = Directory.GetCurrentDirectory()+@"\" + name;
        
        try
        {
            Directory.Delete(path, true);
          
            
            Console.WriteLine("The directory was deleted successfully.");
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
}
}
