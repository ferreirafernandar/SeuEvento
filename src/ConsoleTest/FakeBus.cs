//using System;
//using SeuEvento.Domain.Core.Bus;
//using SeuEvento.Domain.Core.Commands;
//using SeuEvento.Domain.Core.Events;
//using SeuEvento.Domain.Core.Notifications;
//using SeuEvento.Domain.Eventos.Commands;
//using SeuEvento.Domain.Eventos.Events;

//namespace ConsoleTest
//{
//    public class FakeBus : IBus
//    {
//        public void RaiseEvent<T>(T theEvent) where T : Event
//        {
//            Publish(theEvent);
//        }

//        public void SendCommand<T>(T theCommand) where T : Command
//        {
//            Console.ForegroundColor = ConsoleColor.Yellow;
//            Console.WriteLine($"Comando {theCommand.MessageType} Lançado");
//            Publish(theCommand);
//        }

//        private static void Publish<T>(T message) where T : Message
//        {
//            var msgType = message.MessageType;

//            if (msgType.Equals("DomainNotification"))
//            {
//                var obj = new DomainNotificationHandler();
//                ((IDomainNotificationHandler<T>)obj).Handle(message);
//            }

//            if (msgType.Equals("RegistrarEventoCommand") ||
//                msgType.Equals("AtualizarEventoCommand") ||
//                msgType.Equals("ExcluirEventoCommand"))
//            {
//                var obj = new EventoCommandHandler(new FakeEventoRepository(), new FakeUow(), new FakeBus(), new DomainNotificationHandler());
//                ((IHandler<T>)obj).Handle(message);
//            }

//            if (msgType.Equals("EventoRegistradoEvent") ||
//                msgType.Equals("EventoAtualizadoEvent") ||
//                msgType.Equals("EventoExcluidoEvent"))
//            {
//                var obj = new EventoEventHandler();
//                ((IHandler<T>)obj).Handle(message);
//            }
//        }
//    }
//}