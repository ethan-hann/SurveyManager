using static SurveyManager.utility.Enums;

namespace SurveyManager.backend.wrappers
{
    /// <summary>
    /// All classes that are considered to be database wrappers should implement this interface.
    /// </summary>
    public interface IDatabaseWrapper
    {
        /// <summary>
        /// The id (primary key) of the database record.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Define the behaviour for inserting the object's data into the database.
        /// </summary>
        /// <returns>A <see cref="DatabaseError"/> enum representing the result of the method.</returns>
        public DatabaseError Insert();

        /// <summary>
        /// Define the behaviour for updating the object's data in the database.
        /// </summary>
        /// <returns>A <see cref="DatabaseError"/> enum representing the result of the method.</returns>
        public DatabaseError Update();

        /// <summary>
        /// Define the behaviour for deleting the object from the database.
        /// </summary>
        /// <returns>A <see cref="DatabaseError"/> enum representing the result of the method.</returns>
        public DatabaseError Delete();
    }
}
