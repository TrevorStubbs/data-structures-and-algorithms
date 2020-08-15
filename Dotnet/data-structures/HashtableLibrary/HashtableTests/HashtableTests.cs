using System;
using Xunit;
using HashtableLibrary;

namespace HashtableTests
{
    public class HashtableTests
    {
        [Fact]
        public void CanAddItemToHasTable()
        {
            Hashtable<int> table = new Hashtable<int>(100);

            table.Add("Trevor", 38);

            Assert.NotNull(table);
        }

        [Fact]
        public void CanGetValue()
        {
            Hashtable<int> table = new Hashtable<int>(100);

            table.Add("Trevor", 38);
            table.Add("Sharina", 41);
            table.Add("Gwen", 40);

            var returnFromMethod = table.Get("Gwen");

            Assert.NotNull(table);
            Assert.Equal(40, returnFromMethod);            
        }

        [Fact]
        public void CanFindContainedValue()
        {
            Hashtable<int> table = new Hashtable<int>(100);

            table.Add("Trevor", 38);
            table.Add("Sharina", 41);
            table.Add("Gwen", 40);

            var contains = table.Contains("Gwen");

            Assert.True(contains);
        }

        [Fact]
        public void CanReturnNullForAKeyThatDoesNotExsist()
        {
            Hashtable<int> table = new Hashtable<int>(100);

            table.Add("Trevor", 38);
            table.Add("Sharina", 41);
            table.Add("Gwen", 40);

            var returnFromMethod = table.Get("Razzle");

            Assert.Null(returnFromMethod);
        }
    }
}
