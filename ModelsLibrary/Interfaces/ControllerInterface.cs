public interface IController<T>
{
    int Add(T item);
    int Remove(int id);
    void DisplayAll();
}