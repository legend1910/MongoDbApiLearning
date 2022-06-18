using MongoDB.Bson.Serialization.Attributes;

namespace DocsLearning.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }// This Id Property is required for the CLR to map the object to MongoDB Collection
        //[BsonId] Annotation is to make this property the document's  primary Key
        //[ObjectID] is to allow passing parameter as type string instead if an objectID structure . MongoDb handles the conversion from string to ObjectID
        [BsonElement("Name")]
        //The Attribute value of Name represents the property name in the MongoDB Collection
        public string BookName { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
    }
}
