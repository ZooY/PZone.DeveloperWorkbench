using System.ComponentModel.Composition;
using PZone.DeveloperWorkbench.Plugins.Pages;


namespace PZone.DeveloperWorkbench.Plugins
{
    [Export(typeof(ICommonPlugin))]
    public class AssemblyInfo:ICommonPlugin
    {
        public PluginPage GetMainPage() => new AssemblyInfoPage();
    }
}
