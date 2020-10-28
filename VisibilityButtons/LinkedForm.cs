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
    public partial class LinkedForm : System.Windows.Forms.Form
    {
        public UIApplication uiapp;
        public UIDocument uidoc;
        public Autodesk.Revit.ApplicationServices.Application app;
        public Document doc;
        public LinkedForm(Document doc)
        {
            this.doc = doc;
            InitializeComponent();
        }

        List<CheckBox> checkBoxesLinked = new List<CheckBox>();
        List<RadioButton> checkRadioLinked = new List<RadioButton>();
        private void LinkedForm_Load(object sender, EventArgs e)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            ICollection<ElementId> elementIdSet = collector.OfCategory(BuiltInCategory.OST_RvtLinks)
              .OfClass(typeof(RevitLinkType)).ToElementIds();

            int i = 0;
            foreach (ElementId elId in elementIdSet)
            {
                Element el = doc.GetElement(elId);
                /*CheckBox cb = new CheckBox();
                cb.Text = string.Format("{0}", el.Name);
                cb.AutoSize = true;
                cb.Location = new System.Drawing.Point(10, 10 + i);
                panelLinked.Controls.Add(cb);
                i += 20;
                */
                RadioButton rb = new RadioButton();
                rb.Text = string.Format("{0}", el.Name);
                rb.AutoSize = true;
                rb.Location = new System.Drawing.Point(10, 10 + i);
                panelLinked.Controls.Add(rb);
                i += 20;
                checkRadioLinked.Add(rb);
            }
        }

        private void submitButtonLink_Click(object sender, EventArgs e)
        {

            try
            {
                IList<ElementId> choosenModels = new List<ElementId>();
                List<string> checkedModels = new List<string>();

                foreach (RadioButton rb in checkRadioLinked)
                {
                    if (rb.Checked)
                        checkedModels.Add(rb.Text);
                }


                foreach (string model in checkedModels)
                {
                    ICollection<ElementId> models = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_RvtLinks).
                        OfClass(typeof(RevitLinkType)).ToElementIds();

                    foreach (ElementId id in models)
                    {
                        Element el = doc.GetElement(id);
                        if (model.Contains(el.Name))
                            choosenModels.Add(id);

                    }
                }

                using (Transaction trans = new Transaction(doc, "LinkedFileVisibility"))
                {
                    trans.Start();
                    foreach (ElementId linkedFileId in choosenModels)
                    {
                        Element elem = doc.GetElement(linkedFileId);
                        if (linkedFileId != null)
                        {
                            if (true == doc.GetElement(linkedFileId).IsHidden(doc.ActiveView))
                            {
                                if (true == doc.GetElement(linkedFileId).CanBeHidden(doc.ActiveView))
                                {
                                    doc.ActiveView.UnhideElements(choosenModels);

                                }
                            }
                            else
                            {
                                doc.ActiveView.HideElements(choosenModels);

                            }

                        }
                    }
                    trans.Commit();
                }
                Close();
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Warning!", "Smth was wrong!");
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelLinked_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonAllLinked_Click(object sender, EventArgs e)
        {
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
        }
    }
}
