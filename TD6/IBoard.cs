namespace TD6
{
    public interface IBoard
    {
        IVisitableSpace this[int key] { get; }
        int Count { get; }
        void Add(IVisitableSpace visitableSpace);
        System.Collections.Generic.List<S> FindAllSpaces<S>(System.Predicate<S> match) where S : Space;
        int IndexOfSpace(IVisitableSpace searchedSpace);
    }
}