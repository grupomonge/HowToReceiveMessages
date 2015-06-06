using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToReceiveMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = string.Empty;
            string topic = string.Empty;
            string subscription = string.Empty;
            Console.WriteLine("Ingrese el connection String");
            connectionString = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del topico");
            topic = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre de la suscripcion");
            subscription = Console.ReadLine();
            var receiver = new Gmg.Common.WindowsServiceBus.Orchestrator.Receiver<ListaPrecio>(connectionString);
            receiver.PrepareSubscription(topic, subscription);
            //En la siguiente linea; listaPrecio es una variable de tipo ListaPrecio
            //la cual implementa la interface IMessage (es requisito obligatorio que todos 
            // mensajes a ser recibidos implementen IMessage)
            Console.WriteLine("Esperando mensajes.....");
            receiver.PrepareSuscriptionReceiver((ListaPrecio listaPrecio) =>
            {
                //Aqui se debe de escribir la logica para procesar el mensaje recibido
                Console.WriteLine("Se recibio un nuevo mensaje");
                listaPrecio.Detalle.ToList().ForEach(d => {
                    Console.WriteLine(string.Format("SKU={0}, Contado={1}, Credito={2}", d.Sku, d.PrecioContado, d.PrecioCredito));
                });
                //Una vez completado el procesamiento del mensaje se debe marcar como completo
                receiver.Complete(listaPrecio);
            });
            Console.ReadKey();
        }
    }
}
