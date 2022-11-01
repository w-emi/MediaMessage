///I, Wanaemi Immanuella Amaegbe, 000785864 certify that this material is my original worl. No other person's work has been used without due acknowledgement.
///Author: Wanaemi Immanuella Amaegbe, 000785864
///Date created: 01-11-2022
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3A
{
    class Program
    {
        Media[] media = new Media[100]; //array with type Media
        int userInput; //user's input
        string title; //the media search string
        int mediaAmount = 0; //amount of media in the array

        /// <summary>
        /// Method to read the data from the text file
        /// </summary>
        public void ReadData()
        {
            //FileStream selects a file that has the name called file and transfers it to read the file line after line by the stream reader media Data
            FileStream file = new FileStream("data.txt", FileMode.Open, FileAccess.Read);
            StreamReader dataOfMedia = new StreamReader(file);
            string line;
            string summary;
            while((line= dataOfMedia.ReadLine()) != null)
            {
                string[] myData = line.Split('|');

                if (myData[0].Equals("BOOK"))
                {
                    summary = dataOfMedia.ReadLine();
                    mediaAmount++;
                    try
                    {
                        media[mediaAmount] = new Book((myData[1]), int.Parse(myData[2]), (myData[3]), summary);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                } else if ((myData[0].Equals("SONG")))
                {
                    mediaAmount++;
                    try
                    {
                        media[mediaAmount] = new Song((myData[1]), Convert.ToInt32(myData[2]), (myData[3]), (myData[4]));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                } else if (myData[0].Equals("MOVIE"))
                {
                    summary = dataOfMedia.ReadLine();
                    mediaAmount++;
                    try
                    {
                        media[mediaAmount] = new Movie((myData[1]), int.Parse(myData[2]), (myData[3]), summary);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }
            file.Close(); //closes the filestream
            dataOfMedia.Close(); //closes the streamreader
            Array.Resize(ref media, mediaAmount); //resizes the media array
        }
        /// <summary>
        /// Method to show a menu to the user
        /// </summary>
        public void Menu()
        {
            Console.WriteLine("1. List all Books");
            Console.WriteLine("2. List all Movies");
            Console.WriteLine("3. List all Songs");
            Console.WriteLine("4. List all Media");
            Console.WriteLine("5. Search All Media by Title");
            Console.WriteLine("");
            Console.WriteLine("6. EXIT");
        }

        /// <summary>
        /// Method to accept user's input and validate it
        /// </summary>
        public void InputValidation()
        {
            Console.WriteLine("Please select one of the following: ");
            var continueLoop = true;
            do
            {
                try
                {
                    userInput = int.Parse(Console.ReadLine());
                    continueLoop = false;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("Invalid entry! Please Try Again");
                    Menu();
                }
            } while (continueLoop);
        }

        /// <summary>
        /// Method to show corresponding user choice
        /// </summary>
        void Display()
        {
            Menu();
            InputValidation();
            while (userInput != 6)
            {
                //prints out all books if 1 is selected
                if (userInput == 1)
                {
                    foreach(Media m in media)
                    {
                        if(m is Book)
                        {
                            Book book = m as Book;
                            Console.WriteLine(book);
                        }
                    }
                    Menu();
                    InputValidation();
                }
                //prints out all movies if 2 is selected
                else if(userInput == 2)
                {
                    foreach (Media m in media)
                    {
                        if (m is Movie)
                        {
                            Movie movie = m as Movie;
                            Console.WriteLine(movie);
                        }
                    }
                    Menu();
                    InputValidation();
                }
                //prints out all songs if 3 is selected
                else if (userInput == 3)
                {
                    foreach (Media m in media)
                    {
                        if (m is Song)
                        {
                            Song song = m as Song;
                            Console.WriteLine(song);
                        }
                    }
                    Menu();
                    InputValidation();
                }
                //prints out all media if 4 is selected
                else if(userInput == 4)
                {
                    foreach(Media m in media)
                    {
                        Console.WriteLine(m);
                    }
                    Menu();
                    InputValidation();
                }
                //to search all media by the title
                else if(userInput == 5)
                {
                    var continueLoop = true;
                    do
                    {
                        try
                        {
                            Console.WriteLine("Enter a media title: ");
                            title = Console.ReadLine();
                            continueLoop = false;
                        }
                        catch (FormatException fe)
                        {
                            Console.WriteLine("Invalid search! Enter a string");
                        }
                    } while (continueLoop);

                    //prints out media if found and decrypted if the media is IEncryptable
                    foreach(Media m in media)
                    {
                        try
                        {
                            if (m.Search(title))
                            {
                                Console.WriteLine(m);
                                if(m is IEncryptable)
                                {
                                    IEncryptable encryptable = m as IEncryptable;
                                    Console.WriteLine(encryptable.Decrypt());
                                }
                            }
                        } catch(Exception e)
                        {

                        }
                    }
                    Menu();
                    InputValidation();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please Try Again!");
                    Menu();
                    InputValidation();
                }
            }
        }

        /// <summary>
        /// The main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Program program = new Program();
            program.ReadData();
            program.Display();
            Console.ReadLine();
        }
    }
}
