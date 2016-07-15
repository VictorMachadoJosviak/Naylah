using Naylah.Xamarin.Controls.Entrys;
using Naylah.Xamarin.iOS.Renderers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Page), typeof(CustomPageRenderer))]
[assembly: ExportRenderer(typeof(Naylah.Xamarin.Controls.Entrys.FloatLabeledEntry), typeof(JVFloatLabeledEntryRenderer))]
[assembly: ExportRenderer(typeof(EntryBase), typeof(CustomEntryRenderer))]

[assembly: ExportRenderer(typeof(Picker), typeof(PickerRenderer))]

namespace Naylah.SampleApp.iOS.Renderers
{

    public class ExternalDeclarations
    {

    }
}
