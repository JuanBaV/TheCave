using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using System.Threading.Tasks;

namespace BLL
{
    public class SessionManager
    {
        
        public string username;

        

        public  SessionManager currentSession;
        public  SessionManager CheckSession
        {
            get
            {
                return currentSession;
            }
            
        }

        public void CreateSession(string username)
        {
            currentSession = new SessionManager();
           
            currentSession.username = username;
        }

        public SessionManager() { }
    }
}
