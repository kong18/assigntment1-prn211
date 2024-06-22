using FStoreBOs.Data;
using System.Dynamic;

namespace FStoreDAOs
{
    public class MemberDao
    {
        private readonly FStoreDBContext _context = null;
        private static MemberDao _instance = null;
        public MemberDao()
        {
            _context = new FStoreDBContext();
        }

        public static MemberDao Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new MemberDao();
                }
                return _instance;
            }
        }

        public Member GetMember(string email, string password)
        {
           return _context.Members.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));   
        }  

    }
}
