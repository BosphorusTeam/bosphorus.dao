using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using Bosphorus.Library.Facade.Loader.Castle.Configurator;

namespace Bosphorus.Library.Dao.Facade.Facade.Base
{
    public partial class FacadeBase<TContainerScope>: Bosphorus.Library.Facade.Core.Facade.Base.ExternalLoadedFacadeBase<TContainerScope, RunTimeFacadeLoader>
        where TContainerScope : FacadeBase<TContainerScope>
    {
        public static TComponent As<TComponent>()
        {
            // TODO: Bu kod daha güzel yazýmalý aslýnda....
            string key = typeof(TComponent).Name;
            return As<TComponent>(key);
        }

        public static TComponent As<TComponent>(string key)
        {
            object component = Container.Resolve(key);
            if (!(component is TComponent))
                throw new NotConvertableComponentException(component, typeof(TComponent));

            return (TComponent)component;
        }
    }

    public class FacadeBase<TContainerScope, TComponentProvider> : FacadeBase<TContainerScope>
        where TContainerScope : FacadeBase<TContainerScope>
        where TComponentProvider : IComponentProvider, new()
    {
        private static TComponentProvider internalComponentProvider;

        static FacadeBase()
        {
            internalComponentProvider = new TComponentProvider();
        }

        protected internal static TComponentProvider InternalComponentProvider
        {
            get { return internalComponentProvider; }
        }
    }

    public class FacadeBase<TContainerScope, TComponentProvider, TComponent>: FacadeBase<TContainerScope, TComponentProvider>
        where TContainerScope : FacadeBase<TContainerScope>
        where TComponentProvider : IComponentProvider, new()
    {
        protected internal static TComponent InternalComponent
        {
            get
            {
                try
                {
                    return InternalComponentProvider.GetComponent<TComponent>();
                }
                 catch (Exception exception)
                {
                    throw new ResolveFailureException(typeof(TComponent), exception);
                }
            }
        }

        public new static TCustomComponent As<TCustomComponent>() where TCustomComponent : TComponent
        {
            object component = InternalComponent;
            if (!(component is TCustomComponent))
                throw new NotConvertableComponentException(component, typeof(TCustomComponent));

            return (TCustomComponent)component;
        }
    }
}
