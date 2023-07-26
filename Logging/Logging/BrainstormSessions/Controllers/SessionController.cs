﻿using System.Threading.Tasks;
using BrainstormSessions.Api;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace BrainstormSessions.Controllers
{
    public class SessionController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;
        private readonly Serilog.ILogger _logger;

        public SessionController(IBrainstormSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
            _logger = Log.ForContext<IdeasController>();
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(actionName: nameof(Index),
                    controllerName: "Home");
            }

            var session = await _sessionRepository.GetByIdAsync(id.Value);
            if (session == null)
            {
                return Content("Session not found.");
            }

            var viewModel = new StormSessionViewModel()
            {
                DateCreated = session.DateCreated,
                Name = session.Name,
                Id = session.Id
            };

            _logger.Information("StormSessionViewModel created");

            return View(viewModel);
        }
    }
}
