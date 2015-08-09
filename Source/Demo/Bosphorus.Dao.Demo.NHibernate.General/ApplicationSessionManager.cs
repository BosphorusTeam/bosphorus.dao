using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bosphorus.BootStapper.Program;
using Bosphorus.Dao.Core.Session.Provider;
using Bosphorus.Dao.Core.Session.Repository;

namespace Bosphorus.Dao.Demo.NHibernate.General
{
    public class ApplicationSessionManager
    {
        private readonly ISessionProvider sessionProvider;

        public ApplicationSessionManager(IApplicationListener applicationListener, ISessionProvider sessionProvider)
        {
            this.sessionProvider = sessionProvider;
            applicationListener.AfterStarted += ApplicationListenerOnAfterStarted;
            applicationListener.AfterFinished += ApplicationListenerOnAfterFinished;
        }

        private void ApplicationListenerOnAfterStarted(object sender, EventArgs eventArgs)
        {
            sessionProvider.Open(SessionScope.Application);
        }

        private void ApplicationListenerOnAfterFinished(object sender, EventArgs eventArgs)
        {
            sessionProvider.Close(SessionScope.Application);
        }
    }
}
