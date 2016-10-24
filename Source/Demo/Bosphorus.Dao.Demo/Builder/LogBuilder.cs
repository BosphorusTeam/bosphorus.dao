using System;
using Bosphorus.Dao.Demo.Common.Log;

namespace Bosphorus.Dao.Demo.Builder
{
    public class LogBuilder: AbstractBuilder<LogModel, LogBuilder>
    {
        public static LogBuilder Default
        {
            get { return Empty.WithMessage("HostBounded Log Message"); }
        }

        public LogBuilder WithId(Guid id)
        {
            model.Id = id;
            return this;
        }

        public LogBuilder WithMessage(string message)
        {
            model.Message = message;
            return this;
        }
    }
}
