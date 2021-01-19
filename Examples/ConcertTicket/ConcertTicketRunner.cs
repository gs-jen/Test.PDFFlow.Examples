﻿using ConcertTicketData.Model;
using Gehtsoft.PDFFlow.Builder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace ConcertTicket
{
    public static class ConcertTicketRunner
    {
        public static DocumentBuilder Run()
        {

            string ticketJsonFile = CheckFile(Path.Combine("Content", "ticket-data.json"));
            string ticketJsonContent = File.ReadAllText(ticketJsonFile);
            TicketData ticketData =
               JsonConvert.DeserializeObject<TicketData>(ticketJsonContent);

            string JsonFile = CheckFile(Path.Combine("Content", "data.json"));
            string JsonContent = File.ReadAllText(JsonFile);

            ConcertData concertData =
               JsonConvert.DeserializeObject<ConcertData>(JsonContent);

            ConcertTicketBuilder ConcertTicketBuilder = 
                new ConcertTicketBuilder();

           ConcertTicketBuilder.TicketData = ticketData;
           ConcertTicketBuilder.ConcertData = concertData;

           return ConcertTicketBuilder.Build();
        }

        private static string CheckFile(string file)
        {
            if (!File.Exists(file))
            {
                throw new IOException("File not found: " + Path.GetFullPath(file));
            }
            return file;
        }
    }
}