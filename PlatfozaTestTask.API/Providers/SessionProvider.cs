using System.Threading;
using NHibernate;
using PlatfozaTestTask.API.Helpers;

namespace PlatfozaTestTask.API.Providers
{
    public class SessionProvider
    {
        private AsyncLocal<ISession> _session;
        private readonly NHibernateHelper _nHibernateHelper;

        public SessionProvider(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
            _session = new AsyncLocal<ISession>();
        }

        public void OpenSession()
        {
            _session.Value = _nHibernateHelper.OpenSession();
        }
        
        public void CloseSession()
        {
            _session.Value.Close();
        }

        public ISession GetSession()
        {
            return _session.Value;
        }
    }
}