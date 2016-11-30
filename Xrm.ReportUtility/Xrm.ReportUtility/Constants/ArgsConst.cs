using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xrm.ReportUtility.Constants
{
    /*
     * Намного приятнее сложить все константы в статический класс :D
     */
    public static class ArgsConst
    {
        // Отображение данных в отчете
        public const string Data = "-data";

        // Ключи соответствующих агрегирующих функций
        public const string VolumeSum = "-volumeSum";
        public const string WeightSum = "-weightSum";
        public const string CostSum = "-costSum";
        public const string CountSum = "-countSum";

        // Добавление столбца
        public const string StartsForHeaderAndRow = "-with";
        public const string WithIndex = "-withIndex";
        public const string WithTotalVolume = "-withTotalVolume";
        public const string WithTotalWeight = "-withTotalWeight";
    }
}
