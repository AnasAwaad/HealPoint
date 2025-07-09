using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealPoint.BusinessLogic.DTOs.DoctorSchedule;
public class DoctorOverviewScheduleDto
{
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public List<DoctorOverviewScheduleDetailDto> DoctorScheduleDetails { get; set; } = new List<DoctorOverviewScheduleDetailDto>();
}
