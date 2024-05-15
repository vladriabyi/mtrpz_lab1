using System;
using System.IO;

class Program
{
    static string text =@"";
    static string path = "", name = "";
    
    static void Main()
    {
        try
        {
            AskForFile(ref text, ref path, ref name);
            CheckParag(ref text);
            ChangeText();
            CheckIncluded(text);
            AddHTMLStructure(ref text);
            CreateHTML(text, path, name);
            Console.WriteLine("Файл створено!");
            Console.ReadKey();
        }
        catch(Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex);
            Console.ReadKey();
        }
    }

    static void AskForFile(ref string text, ref string path, ref string name)
    {
        Console.WriteLine("Зазначте шлях до текстового файлу\nНаприклад: \"C:\\Documents\\file.md\"");
        string filePath = Console.ReadLine();
        if (Path.GetExtension(filePath) == ".md")
        {
            if (File.Exists(filePath))
            {
                text = File.ReadAllText(filePath);
                path = Path.GetDirectoryName(filePath) + "\\";
                name = Path.GetFileNameWithoutExtension(filePath);
            }
            else
            {
                Console.WriteLine("Файл не знайдено, спробуйте ще раз.");
                AskForFile(ref text, ref path, ref name);
            }
        }
        else
        {
            Console.WriteLine("Слід використати файл з розширенням .md. Спробуйте ще раз.");
            AskForFile(ref text, ref path, ref name);
        }
    }

    static void ChangeText()
    {
        for (int i = 0; i < text.Length; i++)
        {
            CheckItalic(ref text, i);
            CheckBold(ref text, i);
            CheckPref(ref text, ref i);
            CheckMono(ref text, i);
        }
    }
