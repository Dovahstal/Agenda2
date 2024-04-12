using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Agenda2.Agenda2DB;


//namespace Agenda2.Service.DAO
//{ 
//    class DAO_calendrier
//    {
//        static void Main(string[] args)
//        {
//            //chemin vers le fichier json des identifiants
//            string cheminVersFichierJson = "C:\\Users\\SLAB71\\source\\repos\\Dovahstal\\Agenda2\\Ressources\\Identifiants Agenda Long.json";

//            //initialisation de l'authentification
//            GoogleCredential credential;
//            using (var stream = new System.IO.FileStream(cheminVersFichierJson, System.IO.FileMode.Open, System.IO.FileAccess.Read))
//            {
//                credential = GoogleCredential.FromStream(stream)
//                    .CreateScoped(CalendarService.Scope.Calendar);
//            }

//            // Création du service Google Calendar
//            var service = new CalendarService(new BaseClientService.Initializer()
//            {
//                HttpClientInitializer = credential,
//                ApplicationName = "Application Agenda",
//            });

//            // Récupération des événements à venir
//            EventsResource.ListRequest request = service.Events.List("primary");
//            request.TimeMin = DateTime.Now;
//            request.ShowDeleted = false;
//            request.SingleEvents = true;
//            request.MaxResults = 10;
//            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

//            // Exécution de la requête
//            Events events = request.Execute();
//            Console.WriteLine("Événements à venir :");
//            if (events.Items != null && events.Items.Count > 0)
//            {
//                foreach (var eventItem in events.Items)
//                {
//                    string when = eventItem.Start.DateTime.ToString();
//                    if (string.IsNullOrEmpty(when))
//                    {
//                        when = eventItem.Start.Date;
//                    }
//                    Console.WriteLine($"{eventItem.Summary} (Début : {when})");
//                }
//            }
//            else
//            {
//                Console.WriteLine("Aucun événement à venir trouvé.");
//            }
//            Console.ReadLine();
//        }
//    }
//}
