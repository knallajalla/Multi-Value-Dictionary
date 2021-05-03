using System;
using System.Collections.Generic;
using System.Linq;

namespace Multi_Value_Dictionary
{
    class Program
    {
        static readonly MyDictionary<string, string> dictionary = new();

        public static void Main()
        {
            Console.WriteLine("This is a Multi-Value Dictionary Application which supports following case-sensitive commands ADD, ALLMEMBERS, CLEAR, ITEMS, KEYEXISTS, KEYS, MEMBERS, REMOVE, REMOVEALL, VALUEEXISTS");
            string inputCommand;

            do
            {
                inputCommand = Console.ReadLine();
                ExecuteSwitch(inputCommand);
            } while (inputCommand != "EXIT");
        }

        public static void ExecuteSwitch(string inputCommand)
        {
            int i = 1;
            string key;
            List<string> keyList = new();
            List<string> valueList = new();
            switch (IdentifyCommand(inputCommand))
            {
                case nameof(Commands.ADD):
                    dictionary.Add(Retrievekey(inputCommand), Retrievevalue(inputCommand));
                    return;

                case nameof(Commands.ALLMEMBERS):
                    List<string> dictionaryValues = dictionary.Values.SelectMany(x => x).ToList();
                    if (dictionaryValues.Count == 0)
                    {
                        Console.WriteLine("(empty set)");
                    }
                    else
                    {
                        foreach (var item in dictionaryValues)
                        {
                            Console.WriteLine(i + ") " + item);
                            i++;
                        }
                    }
                    return;

                case nameof(Commands.CLEAR):
                    dictionary.Clear();
                    Console.WriteLine(") Cleared");
                    return;

                case nameof(Commands.ITEMS):
                    keyList = new List<string>(dictionary.Keys);
                    if (keyList.Count == 0)
                    {
                        Console.WriteLine("(empty set)");
                    }
                    {
                        foreach (var item in keyList)
                        {
                            dictionary.TryGetValue(item, out valueList);
                            foreach (var valueItem in valueList)
                            {
                                Console.WriteLine(i + ") " + item + ": " + valueItem);
                                i++;
                            }
                        }
                    }
                    return;

                case nameof(Commands.KEYEXISTS):
                    if (dictionary.ContainsKey(Retrievekey(inputCommand)))
                    {
                        Console.WriteLine(") true");
                    }
                    else
                    {
                        Console.WriteLine(") false");
                    }
                    return;

                case nameof(Commands.KEYS):
                    keyList = new List<string>(dictionary.Keys);
                    if (keyList.Count == 0)
                    {
                        Console.WriteLine("(empty set)");
                    }
                    {
                        foreach (var item in keyList)
                        {
                            Console.WriteLine(i + ") " + item);
                            i++;
                        }
                    }
                    return;

                case nameof(Commands.MEMBERS):
                    key = Retrievekey(inputCommand);
                    if (dictionary.ContainsKey(key))
                    {
                        dictionary.TryGetValue(key, out valueList);
                    }
                    else
                    {
                        Console.WriteLine(") ERROR, key does not exist");
                        return;
                    }
                    foreach (var item in valueList)
                    {
                        Console.WriteLine(i + ") " + item);
                        i++;
                    }
                    return;

                case nameof(Commands.REMOVE):
                    dictionary.Remove(Retrievekey(inputCommand), Retrievevalue(inputCommand));
                    return;

                case nameof(Commands.REMOVEALL):
                    dictionary.RemoveAll(Retrievekey(inputCommand));
                    return;

                case nameof(Commands.VALUEEXISTS):
                    if (dictionary.Contains(Retrievekey(inputCommand), Retrievevalue(inputCommand)))
                    {
                        Console.WriteLine(") true");
                    }
                    else
                    {
                        Console.WriteLine(") false");
                    }
                    return;

                default:
                    break;
            }
        }

        public static string IdentifyCommand(string command)
        {
            if (command.Contains(" "))
            {
                return command.Substring(0, command.IndexOf(" ")).Trim();
            }
            else
            {
                return command;
            }
        }

        public static string Retrievekey(string inputcommand)
        {
            var retrieveKeyValue = inputcommand[(inputcommand.IndexOf(" ") + 1)..].Trim();

            if (retrieveKeyValue.Contains(" "))
            {
                return retrieveKeyValue.Substring(0, retrieveKeyValue.IndexOf(" ")).Trim();
            }
            else
            {
                return retrieveKeyValue;
            }
        }

        public static string Retrievevalue(string inputcommand)
        {
            var retrieveKeyValue = inputcommand[(inputcommand.IndexOf(" ") + 1)..].Trim();

            if (retrieveKeyValue.Contains(" "))
            {
                return retrieveKeyValue[(retrieveKeyValue.IndexOf(" ") + 1)..];
            }
            else
            {
                return retrieveKeyValue;
            }
        }
    }
}