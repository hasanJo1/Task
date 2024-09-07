using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Dtos
{
    public class AssignEmployeeToProjectDTO
    {
        public int EmployeeId { get; set; }
        public List<int> ProjectIds { get; set; }
    }
}
