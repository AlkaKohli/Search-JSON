using System;
using System.ComponentModel;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;


namespace SearchJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" \t ---- Welcome to ZENDESK search ---- \n");

            // Retrieve JSON data from all files
            string filePath = Environment.CurrentDirectory;
            string fileNameUsers = "users.json", fileNameTickets = "tickets.json", fileNameOrganizations = "Organizations.json";

            string rawJsonUsers = File.ReadAllText(Path.Combine(filePath, fileNameUsers));
            string rawJsonTickets = File.ReadAllText(Path.Combine(filePath, fileNameTickets));
            string rawJsonOrganizations = File.ReadAllText(Path.Combine(filePath, fileNameOrganizations));

            while (true)
            {
                Console.WriteLine("\nSelect the search option \n");
                Console.WriteLine("  - Press 1 to search required records of USERS ");
                Console.WriteLine("  - Press 2 to search required records of TICKETS ");
                Console.WriteLine("  - Press 3 to search required records of ORGANIZATIONS");
                Console.WriteLine("  - Type 'quit' to EXIT \n");
                string searchCriteria = Console.ReadLine();
                searchCriteria = searchCriteria.Trim();      // discard any white spaces 

                switch (searchCriteria)
                {
                    case "1":
                        {
                            // Search Users
                            Search<User>(rawJsonUsers, searchCriteria);
                        }
                        break;

                    case "2":
                        {
                            // Search Tickets
                            Search<Ticket>(rawJsonTickets, searchCriteria);
                        }
                        break;

                    case "3":
                        {
                            // Search Organizations
                            Search<Organization>(rawJsonOrganizations, searchCriteria);
                        }
                        break;

                    case "quit":
                        {
                            return;
                        }

                    default:
                        Console.WriteLine("\n INCORRECT OPTION");
                        break;
                }
            }
        }

        static void Search<T>(string rawJson, string searchType)
        {
            // Convert to C# Class typed obj
            List<T> JsonData = JsonHelper.ToClass<T>(rawJson);

            if (JsonData != null && JsonData.Count > 0)
            {
                //displaying the properties only if valid data exists in file

                Console.WriteLine("Following are the searchable fields  :");

                //get all the properties of the class(json) 
                StringBuilder sb = new StringBuilder();
                System.Type type = JsonData[0].GetType();
                System.Reflection.PropertyInfo[] pi = type.GetProperties();       // Include information for each property
                if (pi.Length > 0)
                {
                    foreach (System.Reflection.PropertyInfo p in pi)
                    {
                        sb.Append("\n " + p.Name.ToString());
                    }
                    Console.WriteLine(sb);
                }

                string propertyName, propertyVal;
                Console.WriteLine(" \n Enter the SEARCH field - ");
                propertyName = Console.ReadLine();
                propertyName = propertyName.Trim(); //discard any white spaces

                //check if valid property..fetches value if relevant else throws exception
                var val = JsonData.ElementAt(0).GetType().GetProperty(propertyName);

                Console.WriteLine("\n Enter the field value - ");
                propertyVal = Console.ReadLine();

                int iMatchingRecords = 0;       //maintains the count of matching records
                try
                {
                    foreach (T userObject in JsonData)
                    {
                        Object response = userObject.GetType().GetProperty(propertyName).GetValue(userObject, null);

                        if (response != null)
                        {
                            // for properties of type list ... valid search value will be entering any one item of the list
                            if (response is IList<string>
                            && response.GetType().IsGenericType
                            && response.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>)))
                            {
                                List<string> valList = (response as IEnumerable<string>).Cast<string>().ToList();
                                foreach (var item in valList)
                                {
                                    if (item.ToString().IndexOf(propertyVal, StringComparison.CurrentCultureIgnoreCase) != -1)
                                    {
                                        iMatchingRecords++;
                                        Console.WriteLine();
                                        Console.WriteLine(userObject.ToString());
                                        break;      //even if one of the value matches display and exit the loop
                                    }
                                }

                            }

                            //for properties 
                            // else if (response.ToString().ToUpper() == propertyVal.ToUpper())
                            else if (response.ToString().IndexOf(propertyVal, StringComparison.CurrentCultureIgnoreCase) != -1)
                            {
                                iMatchingRecords++;
                                Console.WriteLine();
                                Console.WriteLine(userObject.ToString());
                            }
                        }
                    }
                }
                catch (NullReferenceException e)
                {
                    iMatchingRecords = -1;
                    Console.WriteLine("\t INVALID FIELD - ");// + e.Message);
                    return;
                }
                catch (System.Reflection.AmbiguousMatchException e)
                {
                    iMatchingRecords = -1;
                    Console.WriteLine("\t Multiple properties with same name ");// + e.Message);
                    return;
                }

                if (iMatchingRecords > 0)
                {
                    Console.WriteLine(" \t" + iMatchingRecords + " MATCHING RECORDS DISPLAYED \n");
                    Console.WriteLine("_______________________________________________________________________");
                }
                else if (iMatchingRecords == 0)
                {
                    Console.WriteLine("\t" + " NO MATCHING RECORDS FOUND \n");
                    Console.WriteLine("_______________________________________________________________________");
                }
            }

        }
    }
}