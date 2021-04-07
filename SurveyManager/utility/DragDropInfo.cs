using SurveyManager.backend.wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.utility
{
    public class DragDropInfo
    {
        public DatabaseWrapper Wrapper { get; private set; }

        public DragDropInfo(DatabaseWrapper wrapper)
        {
            Wrapper = wrapper;
        }
    }
}
