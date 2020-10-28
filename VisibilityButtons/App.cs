#region Namespaces
using System;
using System.Collections.Generic;
using System.Reflection;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
#endregion

namespace VisibilityButtons
{
    class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            a.CreateRibbonTab("Visibility");

            string path = Assembly.GetExecutingAssembly().Location;

            PushButtonData pushButtonHideLinkedModel = new PushButtonData("Button1", "Linked Model", path, "VisibilityButtons.HideUnhideLinkedModel");
            RibbonPanel panel1 = a.CreateRibbonPanel("Visibility", "Hide/Unhide");
            pushButtonHideLinkedModel.ToolTip = "Click to Hide or Unhide Linked Models in the active view.";
            PushButtonData pushButtonHideImport = new PushButtonData("Button2", "Import Instance", path, "VisibilityButtons.HideUnhideImport");
            pushButtonHideImport.ToolTip = "Click to Hide or Unhide Import Instances in the active view.";

            panel1.AddItem(pushButtonHideLinkedModel);
            panel1.AddSeparator();
            panel1.AddItem(pushButtonHideImport);
            
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
