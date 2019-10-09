namespace SharedObjects.DesignGame
{
    public class Difficulty
    {
        public Difficulty(int id, string dificultyname)
        {
            ID = id;
            Name = dificultyname;
        }

        public Difficulty() { }

        public int ID { get; set; }
        public string Name { get; set; }
    }
}
