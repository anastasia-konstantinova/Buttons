using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisibilityButtons
{
    public partial class ImportForm : System.Windows.Forms.Form
    {
        public UIApplication uiapp;
        public UIDocument uidoc;
        public Autodesk.Revit.ApplicationServices.Application app;
        public Document doc;
        public ImportForm(Document doc)
        {
            this.doc = doc;
            InitializeComponent();
        }

        List<CheckBox> checkBoxesImport = new List<CheckBox>();
        List<RadioButton> checkRadioImport = new List<RadioButton>();

        private void ImportForm_Load(object sender, EventArgs e)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            ICollection<ElementId> elementIdSet = collector
              .OfClass(typeof(ImportInstance)).ToElementIds();

            int i = 0;
            foreach (ElementId elId in elementIdSet)
            {
                Element el = doc.GetElement(elId);
                ElementType eType = doc.GetElement(elId) as ElementType;
                /*CheckBox cb = new CheckBox();
                cb.Text = string.Format("{0}", el.Category.Name);
                cb.AutoSize = true;
                cb.Location = new System.Drawing.Point(10, 10 + i);
                panelImport.Controls.Add(cb);
                i += 20;*/
                RadioButton rb = new RadioButton();
                rb.Text = string.Format("{0}", el.Category.Name);
                rb.AutoSize = true;
                rb.Location = new System.Drawing.Point(10, 10 + i);
                panelImport.Controls.Add(rb);
                i += 20;
                //checkBoxesImport.Add(cb);
                checkRadioImport.Add(rb);
            }
        }

        private void buttonSubmitImport_Click(object sender, EventArgs e)
        {
                IList<ElementId> choosenImports = new List<ElementId>();
                List<string> checkedImports = new List<string>();

                foreach (RadioButton rb in checkRadioImport)
                {
                    if (rb.Checked)
                        checkedImports.Add(rb.Text);
                }

               

                foreach (string import in checkedImports)
                {
                ICollection<ElementId> imports = new FilteredElementCollector(doc).OfClass(typeof(ImportInstance)).ToElementIds();
                foreach (ElementId id in imports)
                    {
                        Element el = doc.GetElement(id);
                        if (import.Contains(el.Category.Name))
                            choosenImports.Add(id);

                    }
                }

                using (Transaction trans = new Transaction(doc, "ImportVisibility"))
                {
                    trans.Start();
                    foreach (ElementId linkedFileId in choosenImports)
                    {

                            if (true == doc.GetElement(linkedFileId).IsHidden(doc.ActiveView))
                            {
                                if (true == doc.GetElement(linkedFileId).CanBeHidden(doc.ActiveView))
                                {
                                    doc.ActiveView.UnhideElements(choosenImports);

                                }
                            }
                            else
                            {
                                doc.ActiveView.HideElements(choosenImports);

                            }


                    }
                    trans.Commit();
                }
                Close();
            }

        private void buttonAllImport_Click(object sender, EventArgs e)
        {
            try
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
                    Close();
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
            catch (Exception ex)
            {
                TaskDialog.Show("Warning!", "Smth was wrong!");
            }
        }
    }
}
