using SharedObjects.Accounts;
using SharedObjects.Authentication;

namespace KidsApp.Data
{
    public class LoggedInData
    {
        private Token Token;
        private User user;

        public Token GetToken() => Token;

        public User GetUser() => user;

        public void SetUser(User user)
        {
            this.user = user;
        }

        public void SetToken(Token token)
        {
            Token = token;
        }
    }
}
