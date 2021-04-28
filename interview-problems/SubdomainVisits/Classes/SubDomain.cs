using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubdomainVisits.Classes
{
    class SubDomain
    {
        public IList<string> SubDomainVisits(string[] CPDomains)
        {
            var dictAndList = GenerateDictAndList(CPDomains);
            var outputList = CreateCountPairedSubdomainList(dictAndList);

            return outputList;
        }

        private List<string> SplitDomainIntoSubDomains(string subdomains)
        {
            var subDomainList = new List<string>();

            subDomainList.Add(subdomains);
            var dotCount = subdomains.Count(x => x == '.');

            for (int i = 0; i < dotCount; i++)
            {
                var splitSub = subdomains.Split('.', 2);
                if (splitSub[1] != null)
                {
                    subDomainList.Add(splitSub[1]);
                    subdomains = splitSub[1];
                }
            }

            return subDomainList;
        }

        private Tuple<Dictionary<string, int>, List<string>> GenerateDictAndList(string[] CPDomains)
        {
            Dictionary<string, int> domainCountDict = new Dictionary<string, int>();
            List<string> keyList = new List<string>();

            foreach (var domain in CPDomains)
            {
                var splitAtSpace = domain.Split(" ");
                var splitDomains = SplitDomainIntoSubDomains(splitAtSpace[1]);
                var domainCount = Int32.Parse(splitAtSpace[0]);

                foreach (var subDomain in splitDomains)
                {
                    if (!domainCountDict.ContainsKey(subDomain))
                    {
                        domainCountDict.Add(subDomain, 0);
                        keyList.Add(subDomain);
                    }

                    var oldValue = domainCountDict[subDomain];
                    var newValue = oldValue + domainCount;
                    domainCountDict[subDomain] = newValue;
                }
            }

            Tuple<Dictionary<string, int>, List<string>> output = new Tuple<Dictionary<string, int>, List<string>>(domainCountDict, keyList);

            return output;
        }

        private IList<string> CreateCountPairedSubdomainList(Tuple<Dictionary<string, int>, List<string>> dictAndList)
        {
            var outputList = new List<string>();

            for (int i = 0; i < dictAndList.Item2.Count; i++)
            {
                outputList.Add($"{dictAndList.Item1[dictAndList.Item2[i]]} {dictAndList.Item2[i]}");
            }

            return outputList;
        }
    }
}
