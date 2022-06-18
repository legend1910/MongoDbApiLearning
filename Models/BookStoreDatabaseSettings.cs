namespace MongoDbApiLearning.Models
{
    /// <summary>
    /// This Class is used to store the appsettings.Json files bookstoredatabasesettings
    /// property values.
    /// The JSON and C# Property names are named identically to ease the mapping process
    /// </summary>
    public class BookStoreDatabaseSettings : IBookstoreDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
