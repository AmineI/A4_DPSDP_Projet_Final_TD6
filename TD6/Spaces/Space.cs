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


        //TODO : Certaines cases doivent notifier le propriétaire à l'arret (avec un IObserver)
        //TODO : Certaines doivent déplacer le joueur et lui appliquer l'"état" Prison (case "Allez en prison")
        //TODO : Eventuellement certaines cases bonus (chance, etc)

        public Space(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
