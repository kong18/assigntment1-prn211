using FStoreBOs.Data;
using FStoreDAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FStoreRepository
{
    public class MemberRepository : IMemberRepo
    {
        public Member GetMember(string email, string password) => MemberDao.Instance.GetMember(email, password);
        
            
        
    }
}
