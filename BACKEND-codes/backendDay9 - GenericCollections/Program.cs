namespace backendDay9___GenericCollections
{
    internal class Program
    {
        public class InputHelper
        {
            public static int CheckMenu(string prompt) //method pang check if tama ba yung operation na pinili
            {
                int value = 0;
                bool valid = false;
                do
                {
                    try
                    {
                        Console.WriteLine(prompt);
                        string input = Console.ReadLine();

                        if (!int.TryParse(input, out value) || value < 1 || value > 7)
                        {
                            throw new ArgumentException("Invalid operation. Must be between 1 and 7");
                        }

                        valid = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                } while (!valid);

                return value;
            }
            public static string CheckString(string prompt) //check kung empty space ba
            {
                bool valid = false;
                string value = "";

                do
                {
                    try
                    {
                        Console.WriteLine(prompt);
                        value = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(value))
                        {
                            throw new ArgumentException("Invalid input. It cannot be empty.");
                        }
                        
                        valid = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                } while (!valid);

                return value;
            }


            public static string ConfirmationInput(string prompt)
            {
                Console.WriteLine(prompt);
                string value = Console.ReadLine().Trim().ToLower();
                while (value != "yes" && value != "no")
                {
                    Console.WriteLine($"Invalid input.{prompt}");
                    value = Console.ReadLine().Trim().ToLower();
                }

                return value;
            }
        }


        public class TextEditor
        {
            public static void AddText(Stack<string> history, Stack<string> redo)
            {
                string useAgain;
                do
                {
                    string text = InputHelper.CheckString("Enter text to add: ");
                    history.Push(text);
                    redo.Clear();
                    Console.WriteLine($"Text '{text}' added to history.");

                    useAgain = InputHelper.ConfirmationInput("Add another? ('yes' / 'no'): ");
                } while (useAgain == "yes");
            }

            public static void UndoText(Stack<string> history, Stack<string> redo)
            {
                if (history.Count > 0)
                {
                    string last = history.Pop();
                    redo.Push(last);
                    Console.WriteLine($"Undo successful: '{last}' was removed.");
                }
                else
                {
                    Console.WriteLine("Nothing to undo.");
                }
            }

            public static void RedoText(Stack<string> history, Stack<string> redo)
            {
                if(redo.Count > 0)
                {
                    string last = redo.Pop();
                    history.Push(last);
                    Console.WriteLine($"Redo successful: '{last}' was restored.");
                }
                else
                {
                    Console.WriteLine("Nothing to redo.");
                }
            }

            public static void DeleteText(Stack<string> history, List<string> deleted)
            {
                if (history.Count == 0)
                {
                    Console.WriteLine("History is empty. Nothing to delete.");
                    return;
                }

                //coversion from stack to list
                var historyList = history.Reverse().ToList();

                Console.WriteLine("Select the number of the text you want to delete:");
                for (int i = 0; i < historyList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {historyList[i]}");
                }

                int choice = 0;
                bool valid = false;
                do
                {
                    Console.Write("Enter number to delete: ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out choice) && choice >= 1 && choice <= historyList.Count)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please enter a valid number.");
                    }
                } while (!valid);

                string toDelete = historyList[choice - 1];
                deleted.Add(toDelete);
                Console.WriteLine($"Deleted: '{toDelete}'");

                // Rebuild the history stack excluding the deleted item
                history.Clear();
                foreach (var item in historyList.Where((val, idx) => idx != choice - 1).Reverse())
                {
                    history.Push(item);
                }
            }


            public static void ShowDeletedTexts(List<string> deleted)
            {
                if (deleted.Count == 0)
                {
                    Console.WriteLine("No deleted texts.");
                    return;
                }

                Console.WriteLine("Deleted Texts:");
                foreach (var item in deleted)
                {
                    Console.WriteLine($"- {item}");
                }
            }
            public static void DisplayHistory(Stack<string> history)
            {
                if (history.Count > 0)
                {
                    Console.WriteLine("Current History:");
                    foreach (var text in history.Reverse()) 
                    {
                        Console.WriteLine($"- {text}");
                    }
                }
                else
                {
                    Console.WriteLine("History is empty.");
                }
            }
        }

        static void Main(string[] args)
        {
            Stack<String> history = new Stack <String>();
            Stack<String> redo = new Stack<String>();
            List<string> deleted = new List<string>();

        string useAgain = "no";
            int operation;

            do
            {
                Console.WriteLine("--------\t Text Editor System \t--------");
                Console.WriteLine("1. Add New Text");
                Console.WriteLine("2. Undo Last Change");
                Console.WriteLine("3. Redo Last Change");
                Console.WriteLine("4. Delete a Text");
                Console.WriteLine("5. Display Deleted Texts");
                Console.WriteLine("6. Display History");
                Console.WriteLine("7. Exit");

                operation = InputHelper.CheckMenu("Please select an operation (1 - 7): ");


                switch (operation)
                {
                    case 1://add
                        TextEditor.AddText(history, redo);
                        break;
                    case 2://undo
                        TextEditor.UndoText(history, redo);
                        break;
                    case 3:
                        TextEditor.RedoText(history, redo);
                        break;
                    case 4://delete text
                        TextEditor.DeleteText(history, deleted);
                        break;
                    case 5:
                        TextEditor.ShowDeletedTexts(deleted);
                        break;
                    case 6:
                        TextEditor.DisplayHistory(history);
                        break;
                    case 7:
                        useAgain = InputHelper.ConfirmationInput("Are you sure you want to exit? ('yes' / 'no'): ");
                        break;
                    default:
                        Console.WriteLine("Invalid operation selected. Please try again.");
                        break;
                }

                useAgain = InputHelper.ConfirmationInput("Do you want to perform another operation?('yes' / 'no'): ");

            } while (useAgain == "yes");
        }
    }
}
