using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ланцюжок_обов_язків
{
    internal class Class1
    {
        public interface IAutoAssemblyHandler
        {
            IAutoAssemblyHandler SetNext(IAutoAssemblyHandler handler);
            string Handle(string request);
        }

        public abstract class AutoAssemblyHandlerBase : IAutoAssemblyHandler
        {
            private IAutoAssemblyHandler _nextHandler;

            public IAutoAssemblyHandler SetNext(IAutoAssemblyHandler handler)
            {
                _nextHandler = handler;
                return handler;
            }

            public virtual string Handle(string request)
            {
                if (_nextHandler != null)
                {
                    return _nextHandler.Handle(request);
                }
                else
                {
                    return null;
                }
            }
        }

        public class BodyAssemblyHandler : AutoAssemblyHandlerBase
        {
            public override string Handle(string request)
            {
                if (request.Contains("Кузов"))
                {
                    return "Кузов зібрано. ";
                }
                else
                {
                    return base.Handle(request);
                }
            }
        }

        public class EngineAssemblyHandler : AutoAssemblyHandlerBase
        {
            public override string Handle(string request)
            {
                if (request.Contains("Двигун"))
                {
                    return "Двигун зібрано. ";
                }
                else
                {
                    return base.Handle(request);
                }
            }
        }

        public class TransmissionAssemblyHandler : AutoAssemblyHandlerBase
        {
            public override string Handle(string request)
            {
                if (request.Contains("Трансмісія"))
                {
                    return "Трансмісія зібрана. ";
                }
                else
                {
                    return base.Handle(request);
                }
            }
        }

        public class AutoAssemblyLine
        {
            private readonly BodyAssemblyHandler _bodyAssemblyHandler = new BodyAssemblyHandler();
            private readonly EngineAssemblyHandler _engineAssemblyHandler = new EngineAssemblyHandler();
            private readonly TransmissionAssemblyHandler _transmissionAssemblyHandler = new TransmissionAssemblyHandler();

            public AutoAssemblyLine()
            {
                _bodyAssemblyHandler.SetNext(_engineAssemblyHandler).SetNext(_transmissionAssemblyHandler);
            }

            public string AssembleAuto(string request)
            {
                return _bodyAssemblyHandler.Handle(request);
            }
        }
    }
}
