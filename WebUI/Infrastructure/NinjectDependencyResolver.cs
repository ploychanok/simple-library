using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Concrete;
using Ninject;
using WebUI.Infrastructure.Abstract;
using WebUI.Infrastructure.Concrete;

namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IBookRepository>().To<EFBookRepository>();
            kernel.Bind<IMemberRepository>().To<EFMemberRepository>();
            kernel.Bind<ILibrarianRepository>().To<EFLibrarianRepository>();
            kernel.Bind<IRecordRepository>().To<EFRecordRepository>();
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}