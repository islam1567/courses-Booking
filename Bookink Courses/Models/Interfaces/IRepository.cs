namespace Bookink_Courses.Models.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public List<T> GetAll();
        public T GetById(int id);
        public void AddItem (T entity);
        public void Update (T entity);
        public void Delete (int id);
    }
}
