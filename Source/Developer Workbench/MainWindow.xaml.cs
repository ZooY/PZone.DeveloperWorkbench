using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Windows;


namespace PZone.DeveloperWorkbench
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [ImportMany(typeof(ICommonPlugin))]
        public IEnumerable<ICommonPlugin> CommonPlugins;


        public MainWindow()
        {
            InitializeComponent();

            var catalog = new AggregateCatalog();

            var pluginsFolder = Directory.GetCurrentDirectory();
            catalog.Catalogs.Add(new DirectoryCatalog(pluginsFolder));

            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);

            AssemblyInfoControl.Content = CommonPlugins.First().GetMainPage();
        }
    }
}
