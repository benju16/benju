using benju.Common.Models;
using benju.Functions.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace benju.tests.Helpers
{
    public class TestFactory
    {
        public static TodoEntity GetTodoEntity()
        {
            return new TodoEntity
            {
                ETag = "*",
                PartitionKey = "Todo",
                RowKey = Guid.NewGuid().ToString(),
                CreatedTime = DateTime.UtcNow,
                IsCompleted = false,
                TaskDescription = "Task: kill the humans."
            };
         
        }
        public static DefaultHttpRequest CreateHttpRequest(Guid todoId, Todo todoRequest)
        {
            string request = JsonConvert.SerializeObject(todoRequest);
            return  new DefaultHttpRequest(new DefaultHttpContext())
            {
                Body = GenerateStreamFromString(request),
                Path = $"/{todoId}"

            };
        }

        public static DefaultHttpRequest CreateHttpRequest(Guid todoId)
        {
            return  new DefaultHttpRequest(new DefaultHttpContext())
            {
                Path = $"/{todoId}"
            };
        }

        public static DefaultHttpRequest CreateHttpRequest(Todo todoRequest)
        {
            string request = JsonConvert.SerializeObject(todoRequest);
            return  new DefaultHttpRequest(new DefaultHttpContext())
            {
                Body = GenerateStreamFromString(request),
                

            };
        }
        public static DefaultHttpRequest CreateHttpRequest()
        {
            return new DefaultHttpRequest(new DefaultHttpContext());
        }

        public static Todo GetTodoRequest()
        {
            return new Todo
            {
                CreatedTime = DateTime.UtcNow,
                IsCompleted = false,
                TaskDescription = "Try  to conquer the world"
            };
        }
        public static Stream GenerateStreamFromString(string stringToConvert)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(stringToConvert);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
        public static ILogger CreateLogger(LoggerTypes tyoe = LoggerTypes.Null)
        {
            ILogger logger;
            if (tyoe == LoggerTypes.list)
            {
                logger = new ListLogger();
            }
            else
            {
                logger = NullLoggerFactory.Instance.CreateLogger("Null Loggeer");
            }
            return logger;
        }
    }
}
