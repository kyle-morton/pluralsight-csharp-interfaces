
namespace Library
{
    public interface ISaveable
    {
        string Save();
    }

    public interface IVoidSavable
    {
        void Save();
    }

    public interface IPersistable
    {
        string Save();
    }

}
