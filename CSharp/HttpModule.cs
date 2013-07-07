using System.Collections.Generic;
using CruiseControl.Models;
using Nancy;
using Nancy.IO;
using Newtonsoft.Json;
using System;

namespace CruiseControl
{
	public class HttpModule : NancyModule
	{
        public static Commander _commander;

		public HttpModule()
		{
			Get["/"] = x => "Nancy";
			Post["/Command"] = x =>
				{
					var postData = ParseRequestBody(Request.Body);
					return ProcessCommand(postData);
				};

            _commander = new Commander();
		}

		public string ParseRequestBody(RequestStream requestBody)
		{
			var length = int.Parse(requestBody.Length.ToString());
			var bytes = new byte[length];
			requestBody.Read(bytes, 0, length);

			return System.Text.Encoding.UTF8.GetString(bytes);
		}

		public string ProcessCommand(string parameters)
		{
			// Process the status
            _commander.GetBoardStatus(JsonConvert.DeserializeObject<BoardStatus>(parameters));
            
			// Create commands to do
            return JsonConvert.SerializeObject(_commander.GiveCommands());
		}

	}
}