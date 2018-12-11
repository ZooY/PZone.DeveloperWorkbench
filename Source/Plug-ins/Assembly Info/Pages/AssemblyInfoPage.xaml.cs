using System;
using System.IO;
using System.Reflection;
using System.Windows;
using Microsoft.Win32;

namespace PZone.DeveloperWorkbench.Plugins.Pages
{
    /// <summary>
    /// Interaction logic for AssemblyInfoPage.xaml
    /// </summary>
    public partial class AssemblyInfoPage : PluginPage
    {
        public AssemblyInfoPage()
        {
            InitializeComponent();
            Result.Text = "";
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog { Filter = "Assembly|*.dll" };
            if (dialog.ShowDialog() == true)
            {
                var assemblyLocation = dialog.FileName;
                GetAssemblyInfo(assemblyLocation);
            }
        }


        private void GetAssemblyInfo(string assemblyLocation)
        {
            var fileName = Path.GetFileName(assemblyLocation);
            var assembly = Assembly.LoadFile(assemblyLocation);
            Result.Text += $@"{fileName}
    Full name ..... {assembly.FullName}
    Location ...... {assembly.Location}" + Environment.NewLine + Environment.NewLine;
        }


        private void PluginPage_Drop(object sender, DragEventArgs e)
        {
if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Note that you can have more than one file.
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files == null)
                    return;
                foreach (var file in files)
                {
                    GetAssemblyInfo(file);
                }
            }
        }
    }
}
