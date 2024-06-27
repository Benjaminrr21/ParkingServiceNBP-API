using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkEasyNBP.Domain.Models.Results
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; } = true;
        public List<string> Errors { get; set; } = new List<string>();
        public T? Data { get; set; }

    }
}
