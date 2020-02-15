using Domain.Enums;
using SharedKernel.Extensions;

namespace Application.DTO
{
    public class ItemDto
    {
        public ItemDto(int id, string key, string description, string smImageUrl = null, string imageUrl = null)
        {
            Id = id;
            Key = key;
            Description = description;
            SmImageUrl = smImageUrl;
            ImageUrl = imageUrl;
        }

        public int Id { get; }
        public string Key { get; }
        public string Description { get; }
        public string ImageUrl { get; }
        public string SmImageUrl { get; }

        public static ItemDto FromEventType(TrackingEventType eventType)
        {
            return new ItemDto((int)eventType,eventType.ToString(),eventType.GetDescription(),
                );
        }
    }
}