using System;

namespace webapi6.Entity{
    public record Item{
        public Guid id{get; init;}
        public string Name {get; init;}
        public decimal Price{get; init;}
        public DateTimeOffset CurrentDate{get; init;}
    }
}