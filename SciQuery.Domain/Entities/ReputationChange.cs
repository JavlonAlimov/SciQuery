using SciQuery.Domain.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciQuery.Domain.Entities;

public class ReputationChange
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int ChangeAmount { get; set; }
    public string Reason { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
