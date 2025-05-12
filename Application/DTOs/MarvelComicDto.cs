using System;
using System.Collections.Generic;

namespace Application.DTOs
{
    public class MarvelComicDto
    {
        public int Id { get; set; }
        public int DigitalId { get; set; }
        public string Title { get; set; }
        public int IssueNumber { get; set; }
        public string VariantDescription { get; set; }
        public string Description { get; set; }
        public DateTime? Modified { get; set; }
        public string Isbn { get; set; }
        public string Upc { get; set; }
        public string DiamondCode { get; set; }
        public string Ean { get; set; }
        public string Issn { get; set; }
        public string Format { get; set; }
        public int PageCount { get; set; }
        public List<TextObjectDto> TextObjects { get; set; } = new List<TextObjectDto>();
        public string ResourceUri { get; set; }
        public List<UrlDto> Urls { get; set; } = new List<UrlDto>();
        public SeriesDto Series { get; set; }
        public List<VariantDto> Variants { get; set; } = new List<VariantDto>();
        public List<CollectionDto> Collections { get; set; } = new List<CollectionDto>();
        public List<CollectedIssueDto> CollectedIssues { get; set; } = new List<CollectedIssueDto>();
        public List<DateDto> Dates { get; set; } = new List<DateDto>();
        public List<PriceDto> Prices { get; set; } = new List<PriceDto>();
        public ThumbnailDto Thumbnail { get; set; }
        public List<ImageDto> Images { get; set; } = new List<ImageDto>();
        public CreatorListDto Creators { get; set; }
        public CharacterListDto Characters { get; set; }
        public StoryListDto Stories { get; set; }
        public EventListDto Events { get; set; }
    }

    public class UrlDto
    {
        public string Type { get; set; }
        public string Url { get; set; }
    }

    public class TextObjectDto
    {
        public string Type { get; set; }
        public string Language { get; set; }
        public string Text { get; set; }
    }

    public class SeriesDto
    {
        public string ResourceUri { get; set; }
        public string Name { get; set; }
    }

    public class VariantDto
    {
        public string ResourceUri { get; set; }
        public string Name { get; set; }
    }

    public class CollectionDto
    {
        public string ResourceUri { get; set; }
        public string Name { get; set; }
    }

    public class CollectedIssueDto
    {
        public string ResourceUri { get; set; }
        public string Name { get; set; }
    }

    public class DateDto
    {
        public string Type { get; set; }
        public DateTime? Date { get; set; }
    }

    public class PriceDto
    {
        public string Type { get; set; }
        public decimal Price { get; set; }
    }

    public class ThumbnailDto
    {
        public string Path { get; set; }
        public string Extension { get; set; }
    }

    public class ImageDto
    {
        public string Path { get; set; }
        public string Extension { get; set; }
    }

    public class CreatorListDto
    {
        public int Available { get; set; }
        public string CollectionUri { get; set; }
        public List<CreatorDto> Items { get; set; } = new List<CreatorDto>();
        public int Returned { get; set; }
    }

    public class CreatorDto
    {
        public string ResourceUri { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }

    public class CharacterListDto
    {
        public int Available { get; set; }
        public string CollectionUri { get; set; }
        public List<CharacterDto> Items { get; set; } = new List<CharacterDto>();
        public int Returned { get; set; }
    }

    public class CharacterDto
    {
        public string ResourceUri { get; set; }
        public string Name { get; set; }
    }

    public class StoryListDto
    {
        public int Available { get; set; }
        public string CollectionUri { get; set; }
        public List<StoryDto> Items { get; set; } = new List<StoryDto>();
        public int Returned { get; set; }
    }

    public class StoryDto
    {
        public string ResourceUri { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class EventListDto
    {
        public int Available { get; set; }
        public string CollectionUri { get; set; }
        public List<EventDto> Items { get; set; } = new List<EventDto>();
        public int Returned { get; set; }
    }

    public class EventDto
    {
        public string ResourceUri { get; set; }
        public string Name { get; set; }
    }
}
