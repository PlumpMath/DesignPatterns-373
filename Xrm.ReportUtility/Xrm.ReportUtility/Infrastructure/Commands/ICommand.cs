using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Commands
{
    public interface ICommand
    {
        void Execute(DataRow[] data);
        void Undo(Report report);
    }
}
