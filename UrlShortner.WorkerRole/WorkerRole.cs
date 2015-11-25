using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using Microsoft.Owin.Hosting;
using Microsoft.WindowsAzure.ServiceRuntime;
using UrlShortner.WorkerRole.App;

namespace UrlShortner.WorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        private IDisposable _app = null;

        public override bool OnStart()
        {
            ServicePointManager.DefaultConnectionLimit = 12;

            RoleInstanceEndpoint endPoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["EndPoint1"];

            // string.Format alternative.
            string baseUri = $"{endPoint.Protocol}://{endPoint.IPEndpoint}";

            Trace.TraceInformation($"Starting OWIN at: {baseUri}", "Information");

            this._app = WebApp.Start<Startup>(new StartOptions(url: baseUri));

            return base.OnStart();
        }
        
        public override void Run()
        {
            // if overriden, this function should never return.
            // if it returns, then the worker role will call Stop and cleanup actions.

            Trace.TraceInformation("Worker role entry point called", "Information");

            while (true)
            {
                Thread.Sleep(10000);
                Trace.TraceInformation("Working", "Infromation");
            }

        }

        public override void OnStop()
        {
            // new way of null check
            this._app?.Dispose();

            base.OnStop();
        }
    }
}
