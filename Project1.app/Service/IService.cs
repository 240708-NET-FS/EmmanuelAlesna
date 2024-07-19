namespace Project1.app.Service;

public interface IService<T>
{
    public T GetById(int id);
    public ICollection<T> GetAll();
    public void CreateEntity(T item);
    public void Delete(T item);
    public void Update(T item);

}