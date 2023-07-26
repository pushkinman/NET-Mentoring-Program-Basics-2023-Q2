using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;

namespace BrainstormSessions.Core.Model
{
    public class BrainstormSession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateCreated { get; set; }

        public List<Idea> Ideas { get; } = new List<Idea>();

        private readonly Serilog.ILogger _logger;

        public BrainstormSession()
        {
            _logger = Log.ForContext<BrainstormSession>();
        }

        public void AddIdea(Idea idea)
        {
            Ideas.Add(idea);
            _logger.Debug($"Idea {idea} was added");
        }
    }

    public class Idea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset DateCreated { get; set; }
    }
}
