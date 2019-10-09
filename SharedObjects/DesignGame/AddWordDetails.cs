namespace SharedObjects.DesignGame
{
    public class AddWordDetails
    {
        public string Word { get; set; }
        public byte[] Contents { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string Token { get; set; }
        public int UserID { get; set; }
        public int Difficulty { get; set; }
    }
}
