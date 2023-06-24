using System;
using System.Data;

namespace Data.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreadAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
