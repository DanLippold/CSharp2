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
		public HttpModule()
		{
			Get["/"] = x => "Nancy";
			Post["/Command"] = x =>
				{
					var postData = ParseRequestBody(Request.Body);
					return ProcessCommand(postData);
				};

            if(Session["Commander"] == null)
                Session["Commander"] = new Commander();
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
            var commander = (Commander)Session["Commander"];

            commander.GetBoardStatus(JsonConvert.DeserializeObject<BoardStatus>(parameters));

            var commands = commander.GiveCommands();

            Session["Commander"] = commander;

			// Create commands to do
            return JsonConvert.SerializeObject(commands);
		}

	}
}