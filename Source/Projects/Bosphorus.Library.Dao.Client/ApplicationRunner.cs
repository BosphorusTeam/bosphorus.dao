using System.Windows.Forms;
using Bosphorus.Container.Castle.Facade;
using Bosphorus.Container.Castle.Registration;

namespace Bosphorus.Dao.Client
{
    public static class ApplicationRunner
    {
        public static void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ClientForm clientForm = IoC<WorkingDirectoryAssemblyProvider>.Resolve<ClientForm>();
            Application.Run(clientForm);
        }
    }
}
