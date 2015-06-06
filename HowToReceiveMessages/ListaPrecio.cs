using Gmg.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToReceiveMessages
{
    public class ListaPrecio : IMessage
    {
        public string Action {get;set;}
        public string MessageId{get;set;}
        public IDictionary<string, string> MessageProperties{get;set;}
        public SerializeMode MessageSerializationMode{get;set;}
        public string MessageSessionId{get;set;}
        public MessageStatus MessageStatus{get;set;}

        public IEnumerable<ListaPrecioDetalle> Detalle { get; set; }
    }
}
