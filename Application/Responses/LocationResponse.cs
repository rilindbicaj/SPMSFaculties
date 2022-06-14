using MongoDB.Bson;

namespace Application.Responses
{
    public class LocationResponse
    {
        public ObjectId LocationId { get; set; }

        public string LocationName { get; set; }

    }
}