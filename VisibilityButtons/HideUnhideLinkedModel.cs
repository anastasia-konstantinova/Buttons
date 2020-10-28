#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion

namespace VisibilityButtons
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class HideUnhideLinkedModel : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            //find the linked files
            /*FilteredElementCollector collector = new FilteredElementCollector(doc);
            ICollection<ElementId> elementIdSet =
              collector
              .OfCategory(BuiltInCategory.OST_RvtLinks)
              .OfClass(typeof(RevitLinkType))
              .ToElementIds();

            using (Transaction trans = new Transaction(doc, "LinkedFileVisibility"))
            {
                trans.Start();
                foreach (ElementId linkedFileId in elementIdSet)
                {
                    if (linkedFileId != null)
                    {
                        if (true == doc.GetElement(linkedFileId).IsHidden(doc.ActiveView))
                        {
                            if (true == doc.GetElement(linkedFileId).CanBeHidden(doc.ActiveView))
                            {
                                doc.ActiveView.UnhideElements(elementIdSet);
                            }
                        }
                        else
                        {
                            doc.ActiveView.HideElements(elementIdSet);
                        }
                    }
                }
                trans.Commit();
            }
            return Autodesk.Revit.UI.Result.Succeeded;*/
            using (LinkedForm thisForm = new LinkedForm(doc))
            {
                thisForm.ShowDialog();
            }

            return Result.Succeeded;
        }
    }
}
