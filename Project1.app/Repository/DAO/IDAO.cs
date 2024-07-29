namespace Project1.app.Repository.DAO;

public interface IDAO<T>
{
    public void Create(params string[] item);
    public T GetById(int id);
    public ICollection<T> GetAll();
    public void Update(T newItem);
    public void Delete(T item);
}