using System;
using System.Linq;
using System.Text;
using Xrm.ReportUtility.Builders;
using Xrm.ReportUtility.Constants;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility
{
    public static class Program
    {
        // "Files/table.txt" -data -weightSum -costSum -withIndex -withTotalVolume
        public static void Main(string[] args)
        {
            var service = GetReportService(args);

            var report = service.CreateReport();

            Console.OutputEncoding = Encoding.Unicode;
            PrintReport(report);

            Console.WriteLine("");
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }

        /*
         * Этот метод реализует паттерн Factory Method
         * 
         * Плюсы: Позволяет без жесткой привязки к классам порождать объекты в зависимости от переданного параметра
         */
        private static IReportService GetReportService(string[] args)
        {
            var filename = args[0];
            var extension = filename.Split('.').LastOrDefault();

            switch (extension)
            {
                case "txt":
                    return new TxtReportService(args);
                case "csv":
                    return new CsvReportService(args);
                case "xlsx":
                    return new XlsxReportService(args);
                default:
                    throw new NotSupportedException("This extension not supported");
            }
        }

        /*
         * Что не нравится: 
         * Специфичное для каждого из аргументов поведение при выводе данных на печать описано в этом месте,
         *      а не в самих классах. То есть если мы захотим добавить новую функциональность, 
         *      нам нужно будет помимо всего прочего (см. ReportServiceBase, первый блок с цифрами), еще и здесь 
         *      добавлять какие-то данные
         *      
         * Что хочется:
         * 0. Создать класс HeaderAndRows с полями 
         *      string headerRow;
         *      string rowTemplate;
         *     
         *      В этом месте вместо объявления headerRow и rowTemplate, использовать созданный выше класс 
         *      
         * 1. Создать builder - PrintBuilder, чтобы он осуществлял вывод на консоль необходимых данных
         *      
         * Почему захотелось использовать паттерн Builder:
         * 0. Данная реализация очень похожа на применение паттерна Builder (но режет глаза)
         * 1. Каждое из поведений накладыватся независимо от других
         * 2. (непрофессионально, но) Хочется все это запихнуть в метод Build :D
         */
        private static void PrintReport(Report report)
        {
            var headerAndRows = new HeaderAndRows()
            {
                HeaderRow = "Наименование\tОбъём упаковки\tМасса упаковки\tСтоимость\tКоличество",
                RowTemplate = "{1,12}\t{2,14}\t{3,14}\t{4,9}\t{5,10}"
            };

            var builder = new PrintBuilder()
                .SetConfig(report.Config)
                .SetHeaderAndRows(headerAndRows);

            if (report.Config.Data && report.Data != null && report.Data.Any())
            {
                if (report.Config.Data)
                    builder.UpdateTemplateByArg(ArgsConst.Data);

                foreach (var arg in report.Config.ArgsAddColumns)
                {
                    builder.UpdateTemplateByArg(arg);
                }

                builder.BuildHeadersAndRow(report);
                Console.ReadLine();
            }

            builder.BuildInTotal(report);
        }
    }
}