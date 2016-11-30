﻿using System.Linq;
using Xrm.ReportUtility.Infrastructure.Transformers.Abstract;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Transformers
{
    public class VolumeSumReportTransformer : ReportServiceTransformerBase
    {
        public VolumeSumReportTransformer(IDataTransformer reportService) : base(reportService)
        {
            Name = "Суммарный объём";
        }

        public override Report TransformData(DataRow[] data)
        {
            var report = DataTransformer.TransformData(data);

            report.Rows.Add(new ReportRow
            {
                Name = base.Name,
                Value = data.Sum(i => i.Volume * i.Count)
            });

            return report;
        }
    }
}
