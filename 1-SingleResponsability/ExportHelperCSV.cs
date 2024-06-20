using System.Collections;
using System.Text;
using Humanizer;

namespace SingleResponsability
{
    public class ExportHelperCSV<T>
    {
        public void Export(IEnumerable<T> collection)
        {
            StringBuilder stringBuilder = new ();
            stringBuilder.AppendLine(string.Join(";", typeof(T).GetProperties().Select(property => property.Name).ToArray()));
            foreach (var obj in collection)
            {
                obj.GetType().GetProperties().ToList().ForEach(property =>
                {
                    var value = property.GetValue(obj);
                    if (value is not String && value is IEnumerable valuesList)
                    {
                        stringBuilder.Append($"{string.Join("|", valuesList.Cast<object>().ToList().Select(x => x))};");
                    }
                    else
                    {
                        stringBuilder.Append($"{value};");
                    }
                });
                stringBuilder.Append("\n");
            }
            System.IO.File.WriteAllText(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{typeof(T).Name.Pluralize()}.csv"), stringBuilder.ToString(), Encoding.Unicode);
        }
    }
}