using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers.Abstract
{
    public abstract class ReportServiceTransformerBase : IDataTransformer
    {
        protected readonly IDataTransformer DataTransformer;
        protected string Name;

        protected ReportServiceTransformerBase(IDataTransformer dataTransformer)
        {
            DataTransformer = dataTransformer;
        }

        public abstract Report TransformData(DataRow[] data);

        public virtual Report UndoTransformData(Report report)
        {
            var newReport = new Report()
            {
                Data = report.Data,
                Config = report.Config,
                Rows = report.Rows
            };

            for (var i = 0; i < newReport.Rows.Count; i++)
            {
                var row = newReport.Rows[i];
                if (row.Name.Equals(Name))
                {
                    newReport.Rows.RemoveAt(i);
                    break;
                }
            }

            return newReport;
        }
    }
}
