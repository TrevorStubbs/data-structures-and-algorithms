using SubdomainVisits.Classes;
using System;

namespace SubdomainVisits
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cpdomains = { "9001 discuss.leetcode.com" };

            var sub = new SubDomain();

            //var newList = sub.SubDomainVisits(cpdomains);

            //foreach (var item in newList)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine();

            string[] cpdomains2 = { 
                "901 mail.com", 
                "50 yahoo.com", 
                "900 google.mail.com", 
                "5 wiki.org", 
                "5 org", 
                "1 intel.mail.com", 
                "951 com" };

            var list = sub.SubDomainVisits(cpdomains2);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
