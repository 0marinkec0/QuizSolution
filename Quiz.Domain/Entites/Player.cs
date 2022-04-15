using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Domain.Entites
{
    public class Player : BaseEntity
    {
        public string UserName { get; set; }
        public int HighScore { get; set; }
    }
}
