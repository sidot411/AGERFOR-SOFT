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

        public string CreateDirectory3(string name)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Attribution\" + name+ @"\Payements\";

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

        public string CreateDirectoryPermisLotir(string refprojet, string refprogramme, string numpermislotir)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + refprojet + @"\Programme\" + refprogramme + @"\PermisLotir\" + numpermislotir;

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

        public string CreateDirectoryPermisConstruire(string refprojet, string refprogramme, string numpermisconstruire)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + refprojet + @"\Programme\" + refprogramme + @"\Permis de construire\" + numpermisconstruire;

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

        public string CreateDirectoryPermisDeConstruire(string refprojet, string refprogramme, string numPermisConstruire)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + refprojet + @"\Programme\" + refprogramme + @"\Cahier des charges\" + numPermisConstruire;

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

        public string CreateDirectoryEdd(string refprojet, string refprogramme, string NumEDD)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + refprojet + @"\Programme\" + refprogramme + @"\Edd\" + NumEDD;

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

        public string CreateDirectoryConvention(string refprojet, string refprogramme, string NumDec)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + refprojet + @"\Programme\" + refprogramme + @"\Convention\" + NumDec;

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
