using CRM.LAB3.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace CRM.LAB3.Integration.AddToQueue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var contact = ReadData();
            var count = contact.Count();
            var firstname = contact.ElementAt(0).Firstname;
        }

        public static IEnumerable<Contact> ReadData()
        {
            var basedir = Directory.GetCurrentDirectory();
            var contacts = JArray.Parse(File.ReadAllText($"{basedir}\\data.json"));
            return contacts.Select(d => new Contact() {
                Firstname = d["firstname"].ToString(),
                Lastname = d["lastname"].ToString(),
                Email = d["email"].ToString(),
                Title = d["title"].ToString(),
                IsMale = d["gender"].ToString().Equals("Male")
            }).Take(10000);
        }
    }

    
}
