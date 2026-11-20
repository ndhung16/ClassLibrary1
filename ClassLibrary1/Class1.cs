using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
namespace ClassLibrary1
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            ICollection<ElementId> selectedIds = uidoc.Selection.GetElementIds();
            Autodesk.Revit.UI .TaskDialog.Show("Revit", "Số lượng đối tượng được chọn: " + selectedIds.Count.ToString());
            ICollection<ElementId> selectedWallIds = new List<ElementId>();
            

            ICollection<ElementId> SelectedFloor = new List<ElementId>();

            ICollection<ElementId> SelectedColumn = new List<ElementId>();

            FilteredElementCollector collector = new FilteredElementCollector(uidoc.Document);
            ICollection<Element> elementsColumns = collector.OfClass(typeof(FamilyInstance)).OfCategory(BuiltInCategory.OST_StructuralColumns).ToElements();
            foreach (ElementId id in selectedIds)
            {
                Element elements1 = uidoc.Document.GetElement(id);
                if (elements1 is Wall)
                {
                    selectedWallIds.Add(id);
                }
            }
            // Set the created element set as current select element set.
            uidoc.Selection.SetElementIds(selectedWallIds);
            if (0 != selectedWallIds.Count)
            {
                Autodesk.Revit.UI.TaskDialog.Show("Revit", selectedWallIds.Count.ToString() + " Đối tượng Tường đã được chọn!");
            }
            else
            {
                Autodesk.Revit.UI.TaskDialog.Show("Revit", "Không có đối tượng tường nào được chọn!");
            }
            foreach (ElementId id in selectedIds)
            {
                Element elements1 = uidoc.Document.GetElement(id);
                if (elements1 is Wall)
                {
                    selectedWallIds.Add(id);
                }
                if (elements1 is Floor)
                {
                    SelectedFloor.Add(id);
                }

            }
            foreach (Element colElement in elementsColumns)
            {
                SelectedColumn.Add(colElement.Id);
            }
            // Set the created element set as current select element set.
            uidoc.Selection.SetElementIds(selectedWallIds);
            if (0 != selectedWallIds.Count)
            {
                Autodesk.Revit.UI.TaskDialog.Show("Revit", selectedWallIds.Count.ToString() + " Đối tượng Tường đã được chọn!");
            }
            else
            {
                Autodesk.Revit.UI.TaskDialog.Show("Revit", "Không có đối tượng tường nào được chọn!");
            }
            uidoc.Selection.SetElementIds(SelectedColumn);
            if (0 != elementsColumns.Count)
            {
                Autodesk.Revit.UI.TaskDialog.Show("Revit", elementsColumns.Count.ToString() + " Đối tượng Cột đã được chọn!");
            }
            else
            {
                Autodesk.Revit.UI.TaskDialog.Show("Revit", "Không có đối tượng Cột nào được chọn!");
            }

            return Result.Succeeded;
        }

    }


}
