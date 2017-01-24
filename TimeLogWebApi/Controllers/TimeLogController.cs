using AutoMapper;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimeLogDataAccess.Entities;
using TimeLogDomain.Interfaces;
using TimeLogWebApi.Models;

namespace TimeLogWebApi.Controllers
{
    public class TimeLogController : ApiController
    {
        ITimeLogService timeLogService;

        public TimeLogController(ITimeLogService _timeLogService)
        {
            this.timeLogService = _timeLogService;
        }

        protected override void Dispose(bool disposing)
        {
            timeLogService.Dispose();
            base.Dispose(disposing);
        }

        [HttpPost]
        public HttpResponseMessage AddTimeLog(TimeLogViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<TimeLog, TimeLogViewModel>());
                var newTimeLog = Mapper.Map<TimeLogViewModel, TimeLog>(model);

                timeLogService.AddTimeLog(newTimeLog);

                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
                return Request.CreateResponse<TimeLogViewModel>(HttpStatusCode.Conflict, model);
        }
    }
}
