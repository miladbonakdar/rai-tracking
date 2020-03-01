using Domain.Enums;
using SharedKernel;
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

        public static ItemDto FromEventType(TrackingEventType eventType) =>
            new ItemDto((int)eventType,eventType.ToString(),eventType.GetDescription(),
                EventImageUrlResolver.Resolve(eventType.ToString(),true),
                EventImageUrlResolver.Resolve(eventType.ToString()));
        public static ItemDto FromCommandType(CommandType commandType) =>
            new ItemDto((int)commandType,commandType.ToString(),commandType.GetDescription(),
                EventImageUrlResolver.Resolve(commandType.ToString(),true),
                EventImageUrlResolver.Resolve(commandType.ToString()));
    }
}