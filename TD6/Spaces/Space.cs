using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public abstract class Space
    {
        //Auto-property : Can be publicly accessed but can only be set in the constructor. Id and name never changes so it is fine to use them.
        public string Id { get; }
        public string Name { get; }



        public Space(string id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
