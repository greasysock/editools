using System;
using System.IO;
using EdiEngine;
using EdiEngine.Runtime;

namespace editools
{
    class Program
    {
        static void Main(string[] args)
        {
            TextReader tIn = Console.In;
            String ediData = tIn.ReadLine();

            EdiDataReader r = new EdiDataReader();
            EdiBatch ediBatch = r.FromString(ediData);

            //control whether you need to accept all transaction or report error if such.
            AckBuilderSettings ackSettings = new AckBuilderSettings(AckValidationErrorBehavour.AcceptAll, false, 100, 200);
            var ack = new AckBuilder(ackSettings);

            //create FA object structure
            EdiBatch ackBatch = ack.GetnerateAcknowledgment(ediBatch);
            string data = ack.WriteToString(ediBatch);
            Console.WriteLine(data);
        }
    }
}
