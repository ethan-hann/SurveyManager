using SurveyManager.backend.wrappers;

namespace SurveyManager.utility
{
    public class DragDropInfo
    {
        public IDatabaseWrapper Wrapper { get; private set; }

        public DragDropInfo(IDatabaseWrapper wrapper)
        {
            Wrapper = wrapper;
        }
    }
}
