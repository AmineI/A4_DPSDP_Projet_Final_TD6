using System.Collections.Generic;

namespace TD6
{
    public interface IBoard : IReadOnlyList<IVisitableSpace>
    {
        IVisitableSpace GoSpace { get; set; }
        IVisitableSpace JailSpace { get; set; }
        void Add(IVisitableSpace visitableSpace);
        List<S> FindAllSpaces<S>(System.Predicate<S> match) where S : Space;
        int IndexOfSpace(IVisitableSpace searchedSpace);
        void UpdateColorMonopolyState(object sender, OwnerChangeEventArgs eventArgs);
    }
}