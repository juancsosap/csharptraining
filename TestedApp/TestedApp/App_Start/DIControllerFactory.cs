using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestedApp.Models;
using TestedApp.Models.DAO;

namespace TestedApp.App_Start
{
    public class DIControllerFactory : DefaultControllerFactory
    {
        private IKernel kernel;

        public DIControllerFactory()
        {
            kernel = new StandardKernel();
            AddBindings();
        }
      
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController) kernel.Get(controllerType);
        }

        private void AddBindings()
        {
            kernel.Bind<IDAO<Person>>().To<DAOEF<Person, AppDBContext>>();
        }


    }
}