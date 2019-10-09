namespace SharedObjects.Files
{
    public class ImageFile
    {
        public byte[] Contents { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }

        public ImageFile(string FileName, byte[] Contents)
        {
            this.Contents = Contents;
            this.FileName = FileName;
            Extension = System.IO.Path.GetExtension(this.FileName);
        }

        public ImageFile() { }
    }
}
