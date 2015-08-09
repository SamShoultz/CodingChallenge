using System;

namespace CodingChallenge.FamilyTree
{
    public class Solution
    {
        public string GetBirthMonth(Person person, string descendantName)
        {
            string month = "";
            // Check to see if the person passed in is the top "node"
            if (string.Compare(person.Name, descendantName) == 0)
            {
                month = person.Birthday.ToString("MMMM");
            }
            // search through each node of the tree to find any possible match
            else
            {
                foreach (Person _curDesendent in person.Descendants)
                {
                    month = person.Descendants.Find(x => x.Name.Equals(descendantName)) != null ? person.Descendants.Find(x => x.Name.Equals(descendantName)).Birthday.ToString("MMMM") : GetBirthMonth(_curDesendent, descendantName);
                }
            }
            // method will return empty string when no records are found, usually you would want to "throw" an error / exception to properly notify
            // the calling application that a patient does not exist.
            return month;
        }
    }
}