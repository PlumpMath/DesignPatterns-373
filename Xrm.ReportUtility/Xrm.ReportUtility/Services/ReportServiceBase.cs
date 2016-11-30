using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xrm.ReportUtility.Constants;
using Xrm.ReportUtility.Infrastructure;
using Xrm.ReportUtility.Infrastructure.Transformers.Abstract;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Services
{
    public abstract class ReportServiceBase : IReportService
    {
        private readonly string[] _args;

        protected ReportServiceBase(string[] args)
        {
            _args = args;
        }

        public Report CreateReport()
        {
            var config = ParseConfig();
            var dataTransformer = DataTransformerCreator.CreateTransformer(config);

            var fileName = _args[0];
            var text = File.ReadAllText(fileName);
            var data = GetDataRows(text);
            return dataTransformer.TransformData(data);
        }

        /*
         * Вообще не нравится реализация, т.к. для каждой новой функциональности нужно будет:
         * 1. Создавать новый класс, реализующий функциональность
         * 2. Добавлять в классе ReportConfig новое булевское поле
         * 3. Проверять на наличие данного ключа во входных аргументах.
         * 4. Не забыть добавить конструкцию if в DataTransformerCreator
         * 
         * Предлагаю: 
         * 1. В ReportConfig создать одно поле - 
         *      public List<string> ArgsAgregateFunctions, в который поместим все агрументы запуска, кроме названия файла и начинающихся с "-with..."
         *      public List<string> ArgsHeaderAndRows, в который поместим все агрументы запуска начинающихся с "-with..."
         *      и фабричный метод GetServiceTransformer, возвращающий service после декорирования
         * 2. В классе DataTransformerCreator пробегаться по списку ArgsAgregateFunctions (см. пункт 1),
         *      вызывать метод GetServiceTransformer для каждого аргумента из списка
         *      
         * То есть теперь нам нужно только в ReportConfig.GetServiceTransformer объявить соответствие реалзиации с ключем
         * 
         * Что не нравится еще: ключи (константы на весь проект) прописаны где-то в коде, что их не быстро найдешь
         * Исправление:
         * 1. Вынести все эти константы в отдельный статический класс с названием ArgsConst
         * 2. Производить обращение к этим ключам через созданный статический класс
         */
        private ReportConfig ParseConfig()
        {
            return new ReportConfig
            {
                Data = _args.Contains(ArgsConst.Data),
                ArgsAgregateFunctions = ReportConfig.TakeArgsWithoutHeaderAndRows(_args),
                ArgsAddColumns = ReportConfig.TakeArgsWithHeaderAndRows(_args)
            };
        }

        protected abstract DataRow[] GetDataRows(string text);
    }
}
