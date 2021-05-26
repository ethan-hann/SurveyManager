using SurveyManager.backend.wrappers;

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
