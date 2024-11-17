namespace MyTrip.Entities
{
    public interface IDataContex
    {
        public List<User> Users { get; set; }
        public void LoadData();
        public bool SaveData();
    }
}
