using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.Text;
namespace ClassLibrary1

{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Class1 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            FilteredElementCollector collector = new FilteredElementCollector(doc);

            ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_Materials );
            IList<Element> matList = collector.WherePasses(filter).WhereElementIsNotElementType().ToElements();

            StringBuilder result = new StringBuilder ();
            foreach (Element ele in matList)
                {
                result.AppendLine(ele.Category.Name + "t" + ele .Name + "t" +ele.Id);
                }
            MessageBox.Show("tất cả các material trong projert là : \r\n" + result.ToString());
            return Result.Succeeded;

        }


    }
}
