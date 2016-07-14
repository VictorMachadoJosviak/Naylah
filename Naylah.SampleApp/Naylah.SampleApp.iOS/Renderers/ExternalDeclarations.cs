using Naylah.Xamarin.Controls.Entrys;
using Naylah.Xamarin.iOS.Renderers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Page), typeof(CustomPageRenderer))]
[assembly: ExportRenderer(typeof(EntryBase), typeof(JVFloatLabeledEntryRenderer))]

namespace Naylah.SampleApp.iOS.Renderers
{

    public class ExternalDeclarations
    {
    }
}
