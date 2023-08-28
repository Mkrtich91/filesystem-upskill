namespace FileSystem
{
    public static class DirectoryOperations
    {
        public static void DirectoryIsCreatedOrNotValidateDirectory(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                try
                {
                    _ = Directory.CreateDirectory(dirPath);
                    Console.WriteLine($"Directory '{dirPath}' created successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while creating the directory: {ex.Message}");
                    throw;
                }
            }
            else
            {
                Console.WriteLine($"Directory '{dirPath}' already exists.");
            }
        }

        public static void DirectoryIsDeletedOrNotValidateDirectory(string dirPath)
        {
            if (Directory.Exists(dirPath))
            {
                try
                {
                    Directory.Delete(dirPath);
                    Console.WriteLine($"Directory '{dirPath}' deleted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while deleting the directory: {ex.Message}");
                    throw;
                }
            }
            else
            {
                Console.WriteLine($"Directory '{dirPath}' does not exist.");
            }
        }

        public static void DirectoryIsMovedToOtherDirectoryValidateDirectory(string sourceDirPath, string destinationDirPath)
        {
            try
            {
                if (!Directory.Exists(sourceDirPath))
                {
                    Console.WriteLine("Source directory does not exist.");
                    return;
                }

                if (!Directory.Exists(destinationDirPath))
                {
                    _ = Directory.CreateDirectory(destinationDirPath);
                }

                Directory.Move(sourceDirPath, Path.Combine(destinationDirPath, Path.GetFileName(sourceDirPath)));

                if (Directory.Exists(Path.Combine(destinationDirPath, Path.GetFileName(sourceDirPath))))
                {
                    Console.WriteLine("Directory was moved and validated successfully.");
                }
                else
                {
                    Console.WriteLine("Directory move was not successful.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }

        public static void SubDirectoryIsCreatedOrNotValidateSubDirectory(string dirPath, string subDirPath)
        {
            try
            {
                string subDirFullPath = Path.Combine(dirPath, subDirPath);

                if (!Directory.Exists(dirPath))
                {
                    Console.WriteLine("Main directory does not exist.");
                    return;
                }

                if (!Directory.Exists(subDirFullPath))
                {
                    _ = Directory.CreateDirectory(subDirFullPath);
                    Console.WriteLine("Subdirectory created successfully.");
                }
                else
                {
                    Console.WriteLine("Subdirectory already exists.");
                }

                if (Directory.Exists(subDirFullPath))
                {
                    Console.WriteLine("Subdirectory validation successful.");
                }
                else
                {
                    Console.WriteLine("Subdirectory validation failed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }

        public static void DeleteSubDirectoryValidateSubDirectoryDeletedOrNot(string subDirPath)
        {
            try
            {
                if (!Directory.Exists(subDirPath))
                {
                    Console.WriteLine("Subdirectory does not exist.");
                    return;
                }

                Directory.Delete(subDirPath, true);

                if (!Directory.Exists(subDirPath))
                {
                    Console.WriteLine("Subdirectory deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Subdirectory deletion failed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }

        public static void MoveSubDirectoryValidateSubDirMovedOrNot(string sourcePath, string destinationPath)
        {
            try
            {
                if (!Directory.Exists(sourcePath))
                {
                    Console.WriteLine("Source subdirectory does not exist.");
                    return;
                }

                if (!Directory.Exists(destinationPath))
                {
                    _ = Directory.CreateDirectory(destinationPath);
                }

                string subDirName = new DirectoryInfo(sourcePath).Name;

                string newSubDirPath = Path.Combine(destinationPath, subDirName);

                Directory.Move(sourcePath, newSubDirPath);

                if (Directory.Exists(newSubDirPath))
                {
                    Console.WriteLine("Subdirectory moved successfully.");
                }
                else
                {
                    Console.WriteLine("Subdirectory move failed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }
    }
}
