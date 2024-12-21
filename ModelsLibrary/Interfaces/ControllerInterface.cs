public interface IController<T>
{
    int Add(T item);
    int Remove(string id);
    void DisplayAll();
}
