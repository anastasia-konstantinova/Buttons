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
    public class HideUnhideLinkedModel : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            /*UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            try
            {
                FilteredElementCollector linkedModelsCollector = new FilteredElementCollector(doc);
                ElementCategoryFilter linkedModelFilter = new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks);
                IList<Element> linkedModels = linkedModelsCollector.WherePasses(linkedModelFilter).WhereElementIsNotElementType().ToElements();

                IList<ElementId> ids = new List<ElementId>();

                Element linkedModel = linkedModelsCollector.WherePasses(linkedModelFilter).OfClass(typeof(RevitLinkType)).WhereElementIsNotElementType().FirstOrDefault();

                foreach (Element m in linkedModels)
                {
                    ids.Add(m.Id);
                }
                if (ids.Count == 0)
                {
                    TaskDialog.Show("Warning!", "No linked models in the current doc!");
                    return Result.Cancelled;
                }
                else
                {
                    Category cat = linkedModel.Category;
                    using (Transaction tx = new Transaction(doc))
                    {
                        tx.Start("Hide Linked Model");

                        if (cat.get_Visible(doc.ActiveView) == true)
                        {
                            cat.set_Visible(doc.ActiveView, false);
                            doc.ActiveView.HideElements(ids);
                        }
                        else
                        {
                            cat.set_Visible(doc.ActiveView, true);
                            doc.ActiveView.UnhideElements(ids);
                        }
                        tx.Commit();
                    }
                }
            }
            catch(Exception e)
            {
                message = e.Message;
                return Result.Failed;
            }
            return Result.Succeeded;*/
            UIApplication uiApp = commandData.Application;
            Document doc = uiApp.ActiveUIDocument.Document;

            //find the linked files
            FilteredElementCollector collector = new FilteredElementCollector(doc);
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
            return Autodesk.Revit.UI.Result.Succeeded;
        }
    }
}
