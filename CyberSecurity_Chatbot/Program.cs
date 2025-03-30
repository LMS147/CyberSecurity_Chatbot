using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using System.Threading;

namespace Cybersecurity_Chatbot
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // Play voice greeting
            TypingEffect("Initializing Cybersecurity Awareness Bot...");
            Thread greetingThread = new Thread(PlayVoiceGreeting);
            greetingThread.Start();
            DisplayASCIIArt();
            greetingThread.Join();


            // Continue with the rest of the program
            GreetUser();
            StartChatbot();
        }

        // Plays the voice greeting if the file exists
        private static void PlayVoiceGreeting()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");


            if (!System.IO.File.Exists(filePath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                TypingEffect($"Error: The file '{filePath}' was not found.");
                Console.ResetColor();
                return;
            }
            try
            {
                SoundPlayer player = new SoundPlayer(filePath);
                player.PlaySync(); // Plays the audio file synchronously
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                TypingEffect($"Error playing voice greeting: {ex.Message}");
                Console.ResetColor();
            }
        }


        // Displays an ASCII art logo with slow reveal effect
        private static void DisplayASCIIArt()
        {
            string asciiArt = @"
     ██████╗ ██╗   ██╗███████╗██╗  ██╗███████╗██████╗ 
    ██╔═══██╗██║   ██║██╔════╝██║ ██╔╝██╔════╝██╔══██╗
    ██║   ██║██║   ██║███████╗█████╔╝ █████╗  ██████╔╝
    ██║   ██║██║   ██║╚════██║██╔═██╗ ██╔══╝  ██╔══██╗
    ╚██████╔╝╚██████╔╝███████║██║  ██╗███████╗██║  ██║
     ╚═════╝  ╚═════╝ ╚══════╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝
    ";
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (char c in asciiArt)
            {
                Console.Write(c);
                Thread.Sleep(10); // Slow reveal effect
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        // Greets the user and asks for their name.
        private static void GreetUser()
        {
            TypingEffect("\nHello! Welcome to the Cybersecurity Awareness Bot, your virtual assistant for digital safety and best practices.");
            TypingEffect("\nMay I have your name, please? ");
            string userName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userName))
            {
                TypingEffect("\nIt seems you did not provide a name. I will refer to you as 'Friend'.");
                userName = "Friend";
            }

            TypingEffect($"\nPleased to meet you, {userName}. How can I assist you with cybersecurity concerns today?");
        }

        // Starts the chatbot session, where the bot responds to user questions.
        private static void StartChatbot()
        {
            while (true)
            {
                TypingEffect("\nPlease enter your cybersecurity-related question (type 'exit' to terminate the session): ");
                string userInput = Console.ReadLine().Trim().ToLower();

                if (userInput == "exit")
                {
                    TypingEffect("Thank you for using the Cybersecurity Awareness Bot. Stay informed and practice safe online habits!");
                    break;
                }

                string response = GetResponse(userInput);
                TypingEffect(response);
            }
        }

        // Retrieves a response based on the user's input.
        private static string GetResponse(string input)
        {
            switch (input)
            {
                case "how are you?":
                    return "As an AI-powered program, I do not experience emotions. However, I am fully operational and ready to assist you with cybersecurity inquiries.";
                case "what is your purpose?":
                    return "My primary objective is to provide guidance on cybersecurity best practices, ensuring users stay informed about digital threats and safety measures.";
                case "what topics can i ask you about?":
                    return "You may ask me about password security, phishing scams, safe browsing practices, malware prevention, and other cybersecurity-related topics.";
                case "how can i create a strong password?":
                    return "A strong password should be at least 12-16 characters long, include a mix of uppercase and lowercase letters, numbers, and special symbols. Avoid using easily guessed words or personal information. Consider using a password manager to generate and store secure passwords.";
                case "what is phishing and how can i avoid it?":
                    return "Phishing is a cyberattack where malicious actors impersonate legitimate entities to steal sensitive information, such as passwords or credit card details. To avoid phishing, never click on suspicious links, verify email senders, and enable two-factor authentication (2FA) for added security.";
                case "how can i browse the internet safely?":
                    return "To browse safely, always keep your browser and security software updated, avoid clicking on unverified links, use strong passwords for online accounts, and be cautious when sharing personal information on unfamiliar websites.";
                case "how can i prevent malware infections?":
                    return "To prevent malware infections, install and regularly update reputable antivirus software, avoid downloading files from untrusted sources, enable automatic system updates, and exercise caution when opening email attachments or clicking on links from unknown senders.";
                default:
                    return "I'm sorry, but I do not have information on that specific topic. Could you rephrase your question or ask about cybersecurity-related topics?";
            }
        }

        // Adds a visual divider between sections of the output
        private static void AddDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            TypingEffect(new string('=', Console.WindowWidth - 1));
            Console.ResetColor();
        }

        // Simulates a typing effect for text output.
        private static void TypingEffect(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(50); // Simulate typing delay
            }
            Console.WriteLine();
        }


    }
}
