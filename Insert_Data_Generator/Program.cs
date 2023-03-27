using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insert_Data_Generator
{
    class Program
    {
        static void To_console_and_file(String s, StreamWriter w)
        {
            Console.WriteLine(s);
            w.Write(s);
            w.Write("\n");

        }
            static void Main(string[] args)
        {
            string copywrite = "/*Copyright statement \n" +
                "	 FILE:	Alien_DB_Creation_Script.sql \n " +
                "	DATE:	2023-03-24 \n" +
                "AUTHORS:	Steven Sanchez, Keren Luzindya, Jonathan Beck\n" +

                "DESCRIPTION: \n" +

                "A sql script for inserting  data for our group project \n" +

                "\n" +
                "Modification History \n" +
                "Date modified - Who did it - what was modified \n" +

                "2023-03-24	Jonathan Beck		Initial Creation*/\n";



            Console.WriteLine("What is the file name ?");
            String file = Console.ReadLine();
            StreamWriter WriteBuddy = new StreamWriter("c:\\csharp\\" + file + "sql.txt");
            StreamReader SqlBuddy = new StreamReader("c:\\csharp\\" + file + ".txt");

            string ln;
            char[] separator = { '\t' };
            WriteBuddy.Write(copywrite);
            //WriteBuddy.Write("drop database if exists " + file + ";\n");
            //WriteBuddy.Write("Create Database " + file + ";\n");
            // WriteBuddy.Write("use " + file + ";\n");
            int counter = 0;
            int GrandCount = 0;
            String Paren = "";
            String output;
            List<string> types = new List<string>();
            List<string> columnNames = new List<string>();
            String leftQuote = "\'";
            String rightQuote = "\'";

            while ((ln = SqlBuddy.ReadLine()) != null)
            {
                string[] parts;
                parts = ln.Split(separator);
                if (GrandCount == 0) {
                    output = "USE " + parts[1] + ";\n" ;
                    To_console_and_file(output, WriteBuddy);
                }
                if (GrandCount == 1) {
                    output = "Insert into " + parts[1]+" (";
                    To_console_and_file(output, WriteBuddy);
                }
                if (GrandCount == 2)
                {
                    for (int i = 0; i < parts.Length; i++)
                    {
                        types.Add(parts[i]);
                    }
                }
                if (GrandCount == 3) {
                    String Part2;
                    for (int i = 0; i < parts.Length-1; i++)
                    {
                        if (i > 0) {
                            Console.Write(", ");
                            WriteBuddy.Write(", ");
                        }
                        columnNames.Add(parts[i]);
                        Console.WriteLine(parts[i]);
                        WriteBuddy.Write(parts[i]+"\n");
                        
                    }
                    Console.WriteLine(")");
                    WriteBuddy.Write(")\n");
                    Console.WriteLine("Values");
                    WriteBuddy.Write("Values \n");
                }
                if (GrandCount > 3) {
                    Console.Write("(");
                    WriteBuddy.Write("(");
                    for (int i = 0; i < parts.Length-1; i++) {

                        Console.Write(leftQuote);
                        WriteBuddy.Write(leftQuote);
                        Console.Write(parts[i]);
                        WriteBuddy.Write(parts[i]);

                        Console.Write(rightQuote);
                        WriteBuddy.Write(rightQuote);
                        if (i < parts.Length - 2) {
                            Console.Write(",");
                            WriteBuddy.Write(",");
                        }
                    }
                    Console.WriteLine(")");
                    WriteBuddy.Write("),\n");
                }


               
                


                //WriteBuddy.Write(")\n;");
                GrandCount++;
            }
            Console.ReadLine();
            SqlBuddy.Close();
            WriteBuddy.Close();
            // var lines = File.ReadAllLines("c:\\csharp\\" + file + "sql.txt");
            // File.WriteAllLines("c:\\csharp\\" + file + "sql.txt", lines.Take(lines.Length - 4).ToArray());
        }
        
    }
}


