using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.utility.Filtering
{
    public class TextSearchFilter
    {
        public TextSearchFilter(ICollectionView filteredView, KryptonTextBox textBox)
        {
            string filterText = "";

            filteredView.Filter = delegate (object obj)
            {
                if (string.IsNullOrEmpty(filterText))
                    return true;

                string str = obj as string;
                if (string.IsNullOrEmpty(str))
                    return false;

                int index = str.IndexOf(filterText, 0, StringComparison.InvariantCultureIgnoreCase);
                return index > -1;
            };

            textBox.TextChanged += delegate
            {
                filterText = textBox.Text;
                filteredView.Refresh();
            };
        }
    }
}
