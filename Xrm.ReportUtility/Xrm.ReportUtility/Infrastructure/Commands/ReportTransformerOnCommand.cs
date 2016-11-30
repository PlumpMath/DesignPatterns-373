using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xrm.ReportUtility.Infrastructure.Transformers.Abstract;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Commands
{
    /*
     * Дл реализации "хотелки" возможности убирать из отчета столбцы был использован паттерн Command
     * 
     * Плюсы: мы ослабляем связь между объектами
     */
    class ReportTransformerOnCommand : ICommand
    {
        private readonly ReportServiceTransformerBase _service;

        public ReportTransformerOnCommand(ReportServiceTransformerBase service)
        {
            _service = service;
        }

        public void Execute(DataRow[] data)
        {
            _service.TransformData(data);
        }

        public void Undo(Report report)
        {
            _service.UndoTransformData(report);
        }
    }
}
