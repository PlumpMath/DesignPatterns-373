using System;
using System.Collections.Generic;
using System.Linq;
using Xrm.ReportUtility.Constants;
using Xrm.ReportUtility.Infrastructure.Transformers;
using Xrm.ReportUtility.Infrastructure.Transformers.Abstract;
using Xrm.ReportUtility.Interfaces;

namespace Xrm.ReportUtility.Models
{
    public class ReportConfig
    {
        public bool Data { get; set; }

        public List<string> ArgsAgregateFunctions;
        public List<string> ArgsAddColumns;

        public ReportServiceTransformerBase GetServiceTransformer(string arg, IDataTransformer service)
        {
            switch (arg)
            {
                case ArgsConst.Data:
                    return new WithDataReportTransformer(service);
                case ArgsConst.VolumeSum:
                    return new VolumeSumReportTransformer(service);
                case ArgsConst.WeightSum:
                    return new WeightSumReportTransfomer(service);
                case ArgsConst.CostSum:
                    return new CostSumReportTransformer(service);
                case ArgsConst.CountSum:
                    return new CountSumReportTransformer(service);
                default:
                    throw new NotSupportedException("This arg not supported");
            }
        }

        // Skip, т.к. первый элемент - название файла. Он нам не нужен. Будем считать его обязательным параметром
        public static List<string> TakeArgsWithoutHeaderAndRows(string[] args)
        {
            return new List<string>(
                args
                    .Skip(1)
                    .Where(x => !x.StartsWith(ArgsConst.StartsForHeaderAndRow)));
        }

        public static List<string> TakeArgsWithHeaderAndRows(string[] args)
        {
            return new List<string>(
                args
                    .Skip(1)
                    .Where(x => x.StartsWith(ArgsConst.StartsForHeaderAndRow)));
        }
    }
}
