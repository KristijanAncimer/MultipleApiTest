using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class SetCollectionName : Attribute
    {
        public string CollectionName { get; }
        public SetCollectionName(string collectionName)
        {
            CollectionName=collectionName;
        }
    }
}
