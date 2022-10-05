using System;

namespace webapi6.Entity{
    public record record1{
        public Guid id{get; init;}
        public string Name {get; init;}
        public decimal Price{get; init;}
        public DateTimeOffset CurrentDate{get; init;}
    }
}