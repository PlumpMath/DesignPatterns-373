using Xrm.ReportUtility.Infrastructure.Transformers;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure
{
    public static class DataTransformerCreator
    {
        /*
         * Здесь применяется паттерн Декоратор. 
         * То есть мы добавляем функциональность нашему сервису в соответствии с ранее полученными настойками
         * 
         * Что плохого в коде: для декорирования используются if'ы. 
         * А значит при большем числе настроек, нужно будет не забывать их прописывать здесь.
         * 
         * Изменения:
         * 1. Теперь мы просто пробегаемся по списку с ключами
         * 2. Вызываем метод (Factory Method), который оборачивает service в декоратор, соответствующий параметру arg
         * 
         * Плюсы: не нужно для каждой новой реализации лезть в этот класс и добавлять новый if.
         * 
         * Минусы: приходится хранить в списке строковые ключи, а уже потом по ним использовать тот или иной декоратор.
         * 
         * Пытался применить такое решение для исправления минуса:
         * Создать Dictionary<string, class>, у которого ключом был бы arg, а class - классы реализации функциональности аргументов
         * То есть по ключу словарь должен был бы возвращать новый экземпляр объекта соответствующей функциональности.. 
         * Но я не нашел, как это делается в c#. В Python такой трюк проходит на ура =)
         */
        public static IDataTransformer CreateTransformer(ReportConfig config)
        {
            IDataTransformer service = new DataTransformer(config);

            foreach (var arg in config.ArgsAgregateFunctions)
            {
                service = config.GetServiceTransformer(arg, service);
            }

            return service;
        }
    }
}