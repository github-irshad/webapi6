namespace webapi6.Dtos{
     public record record1Dto{
        public Guid id{get; init;}
        public string Name {get; init;}
        public decimal Price{get; init;}
        public DateTimeOffset CurrentDate{get; init;}
    }
}