using System.Linq;
using Xrm.ReportUtility.Infrastructure.Transformers.Abstract;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    public class CostSumReportTransformer : ReportServiceTransformerBase
    {

        public CostSumReportTransformer(IDataTransformer dataTransformer) : base(dataTransformer)
        {
            Name = "Суммарная стоимость";
        }

        public override Report TransformData(DataRow[] data)
        {
            var report = DataTransformer.TransformData(data);

            report.Rows.Add(new ReportRow
            {
                Name = base.Name,
                Value = data.Sum(i => i.Cost * i.Count)
            });

            return report;
        }
    }
}
