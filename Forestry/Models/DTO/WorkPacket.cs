using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forestry.Models.DTO
{
    public class WorkPacket
    {
        public Int64 WorkRequestId { get; set; }
        public Int64 WorkPacketId { get; set; }
        public string District { get; set; }
        public string Name { get; set; }
        public string CrewClass { get; set; }
        public string Crew { get; set; }
        public string CrewCompleted { get; set; }
        public decimal TotalLaborHours { get; set; }
        public decimal TotalLaborHoursConstruction { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public string ResolutionCode { get; set; }
        public DateTime? CompletionDate { get; set; }

        //public List<WorkPacketHistory> WorkPacketHistories { get; set; }
        //public List<CU> CUs { get; set; }
        //public List<CUAsb> CUAsbs { get; set; }

        public WorkPacket()
        {

        }
    }
}
