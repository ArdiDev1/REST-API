namespace BackendApi.Data
{
    public class ComputerRepository
    {
        DataContextEF _efcore;

        public ComputerRepository(DataContextEF efcore)
        {
            _efcore = efcore;
        }

        public bool SaveChanges()
        {
            return _efcore.SaveChanges() > 0;
        }

        public void AddEntity<T>(T entityToAdd)
        {
            if(entityToAdd == null)
                return;

            _efcore.Add(entityToAdd);
        }
    }
}
