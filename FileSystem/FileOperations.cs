[assembly: CLSCompliant(false)]

namespace FileSystem
{
    public static class FileOperations
    {
        public static void CreatingFileAndReturnFilePath(string filePath)
        {
            try
            {
                using StreamWriter sw = File.CreateText(filePath);
                sw.WriteLine("Hello, this is some content.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }

        public static void WriteTextToFileReadAppendedText(string filePath, string msgToWrite)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(msgToWrite);
                }

                using StreamReader reader = File.OpenText(filePath);
                string line;
#pragma warning disable CS8600
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
#pragma warning restore CS8600
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }

        public static string ReadingFileContentAndValidateText(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                return string.Join(Environment.NewLine, lines);
            }
            catch (Exception ex)
            {
                return "An error occurred: " + ex.Message;
                throw;
            }
        }

        public static void MoveFileFromOneFolderToNewFolderAndValidateFile(string filePath, string destinationPath)
        {
            try
            {
#pragma warning disable CS8604
                _ = Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
#pragma warning restore CS8604

                File.Move(filePath, destinationPath);

                if (File.Exists(destinationPath))
                {
                    Console.WriteLine("File moved successfully and exists at the destination.");
                }
                else
                {
                    Console.WriteLine("File was not moved successfully or does not exist at the destination.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }

        public static void CopyFileFromOneFolderToNewFolder(string filePath, string destinationPath)
        {
            try
            {
#pragma warning disable CS8604
                _ = Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
#pragma warning restore CS8604

                File.Copy(filePath, destinationPath, true);

                if (File.Exists(destinationPath))
                {
                    Console.WriteLine("File copied successfully and exists at the destination.");
                }
                else
                {
                    Console.WriteLine("File was not copied successfully or does not exist at the destination.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }

        public static void DeleteFileAndValidateFileExistOrNot(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File does not exist.");
                    return;
                }

                File.Delete(filePath);

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File deleted and validation succeeded.");
                }
                else
                {
                    Console.WriteLine("File deleted, but validation failed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
