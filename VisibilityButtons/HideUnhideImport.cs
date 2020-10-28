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
    public class HideUnhideImport : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            /*try
            {
                FilteredElementCollector col = new FilteredElementCollector(doc).OfClass(typeof(ImportInstance));
                IList<Element> imports = col.WhereElementIsNotElementType().ToElements();
                IList<ElementId> ids = new List<ElementId>();
                Element import = col.WhereElementIsNotElementType().FirstOrDefault();

                foreach (Element i in imports)
                {
                    ids.Add(i.Id);
                }
                if (ids.Count == 0)
                {
                    TaskDialog.Show("Warning!", "No imports in the current doc!");
                    return Result.Cancelled;
                }
                else
                {
                    Category cat = import.Category;

                    using (Transaction tx = new Transaction(doc))
                    {
                        tx.Start("Hide Imports");

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
            catch (Exception e)
            {
                message = e.Message;
                return Result.Failed;
            }

            return Result.Succeeded;*/
            using (ImportForm thisForm = new ImportForm(doc))
            {
                thisForm.ShowDialog();
            }

            return Result.Succeeded;
        }
    }
}
