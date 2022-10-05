namespace webapi6.Dtos{
     public record ItemDto{
        public Guid id{get; init;}
        public string Name {get; init;}
        public decimal Price{get; init;}
        public DateTimeOffset CurrentDate{get; init;}
    }
}