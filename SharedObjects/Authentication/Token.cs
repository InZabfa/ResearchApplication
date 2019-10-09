using System;

namespace SharedObjects.Authentication
{
    public class Token
    {
        public Token() { }

        public Token(string Token, int id)
        {
            this.TokenValue = Token;
            ExpiryDate = DateTime.Now.AddDays(1);
            UserID = id;
        }
        public Token(string Token, int id, DateTime expiry)
        {
            this.TokenValue = Token;
            ExpiryDate = expiry;
            UserID = id;
        }

        public string TokenValue { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int UserID { get; set; }
    }
}