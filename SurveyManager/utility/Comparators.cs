using ComponentFactory.Krypton.Ribbon;
using JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid;
using SurveyManager.backend.wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.utility
{
    public class Comparators
    {
        public class CompareRecentJobs : IComparer<KryptonRibbonRecentDoc>
        {
            public int Compare(KryptonRibbonRecentDoc x, KryptonRibbonRecentDoc y)
            {
                DateTime xD = DateTime.Parse(x.ExtraText);
                DateTime yD = DateTime.Parse(y.ExtraText);
                return xD.CompareTo(yD);
            }
        }

        public class CompareOutlookGridRows : IComparer<OutlookGridRow>
        {
            public int Compare(OutlookGridRow x, OutlookGridRow y)
            {
                IDatabaseWrapper xObj = x.Tag as IDatabaseWrapper;
                IDatabaseWrapper yObj = y.Tag as IDatabaseWrapper;

                if (xObj == null || yObj == null)
                    return 0;

                if (xObj.ID > yObj.ID)
                    return 1;
                else if (xObj.ID < yObj.ID)
                    return -1;
                else
                    return 0;
            }
        }
    }
}
