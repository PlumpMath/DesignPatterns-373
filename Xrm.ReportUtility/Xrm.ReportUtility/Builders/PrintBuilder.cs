using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xrm.ReportUtility.Constants;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Builders
{
    /*
     * Реализация паттерна Builder для вывода результатов на экран
     */
    public class PrintBuilder
    {
        public MandatoryFieldsPrintBuilder SetConfig(ReportConfig config)
        {
            return new MandatoryFieldsPrintBuilder().SetConfig(config);
        }

        public class MandatoryFieldsPrintBuilder
        {
            private HeaderAndRows _headerAndRows;
            private ReportConfig _config;

            public MandatoryFieldsPrintBuilder SetConfig(ReportConfig config)
            {
                _config = config;
                return this;
            }

            public StandartPrintBuilder SetHeaderAndRows(HeaderAndRows headerAndRows)
            {
                _headerAndRows = headerAndRows;
                return new StandartPrintBuilder(_config, _headerAndRows);
            }
        }

        /*
         * Можно для каждого аргумента сделать свой метод обработки,
         * но реализация этих методов будет подобной (проверка на валидность + возвращение результата). 
         * Поэтому решено было выполнить функционал с применением паттерна Фабричный метод
         */
        public class StandartPrintBuilder
        {
            private HeaderAndRows _headerAndRows;
            private readonly ReportConfig _config;
            private bool _isArgDataCalled;

            public StandartPrintBuilder(ReportConfig config, HeaderAndRows headerAndRows)
            {
                _headerAndRows = headerAndRows;
                _config = config;
            }

            public StandartPrintBuilder UpdateTemplateByArg(string arg)
            {
                if (!_config.ArgsAddColumns.Contains(arg) && !_config.Data)
                    return this;

                return UpdateTemplate(arg);
            }

            private StandartPrintBuilder UpdateTemplate(string arg)
            {
                switch (arg)
                {
                    case ArgsConst.Data:
                        {
                            _isArgDataCalled = true;
                            break;
                        }
                    case ArgsConst.WithIndex:
                        {
                            _headerAndRows = new HeaderAndRows()
                            {
                                HeaderRow = "№\t" + _headerAndRows.HeaderRow,
                                RowTemplate = "{0}\t" + _headerAndRows.RowTemplate
                            };
                            break;
                        }
                    case ArgsConst.WithTotalVolume:
                        {
                            _headerAndRows = new HeaderAndRows()
                            {
                                HeaderRow = _headerAndRows.HeaderRow + "\tСуммарный объём",
                                RowTemplate = _headerAndRows.RowTemplate + "\t{6,15}"
                            };
                            break;
                        }
                    case ArgsConst.WithTotalWeight:
                        {
                            _headerAndRows = new HeaderAndRows()
                            {
                                HeaderRow = _headerAndRows.HeaderRow + "\tСуммарный вес",
                                RowTemplate = _headerAndRows.RowTemplate + "\t{7,13}"
                            };
                            break;
                        }
                }
                return this;
            }

            /*
            * Можно сразу выводить на консоль. Тогда извне порядок вывода данных не нарушится
            * если же метод Build будет возвращать строки (внутри собирать через StringBuilder), 
            * то полученные строки пользователь может никогда не вывести,
            * а метод PrintWarning подразумевает, что сразу же после него пойдет вывод данных.
            * 
            * Иного способа вывода на консоль желтого текста (выполнение "хотелки") не обнаружил
            */
            public StandartPrintBuilder BuildHeadersAndRow(Report report)
            {
                PrintWarning();
                Console.WriteLine(_headerAndRows.HeaderRow);

                for (var i = 0; i < report.Data.Length; i++)
                {
                    var dataRow = report.Data[i];
                    Console.WriteLine(_headerAndRows.RowTemplate, i + 1, dataRow.Name, dataRow.Volume, dataRow.Weight, dataRow.Cost, dataRow.Count, dataRow.Volume * dataRow.Count, dataRow.Weight * dataRow.Count);
                }

                Console.WriteLine();
                return this;
            }

            /*
             * Бонус: реализация хотелки с желтым словом Warning, если в агрументах нет ключа -data
             * Если в UpdateTemplate передается ArgsConst.Data, то переменная _isArgDataCalled станет true и 
             * данный метод сразу же завершится. В ином случае будет желтый warning
             */
            private void PrintWarning()
            {
                if (_isArgDataCalled)
                    return;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Warning");
                Console.ResetColor();
            }

            public void BuildInTotal(Report report)
            {
                PrintWarning();
                if (report.Rows != null && report.Rows.Any())
                {
                    Console.WriteLine("Итого:");
                    foreach (var reportRow in report.Rows)
                    {
                        Console.WriteLine($"  {reportRow.Name,-20}\t{reportRow.Value}");
                    }
                }
            }
        }
    }
}
