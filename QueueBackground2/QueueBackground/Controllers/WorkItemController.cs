using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QueueBackground.Models;
using QueueBackground.Queue;

namespace QueueBackground.Controllers
{
    //http://localhost:55823/WorkItem/SendMail
    public class WorkItemController : ControllerBase
    {
        private readonly IUserRepository _CoreDbProvider;
        private IBackgroundTaskQueue queue;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly IConfiguration _configuration;
        MailSenderRepository mailSenderRepository = new MailSenderRepository();

        public WorkItemController(IUserRepository coreDbProvider, IBackgroundTaskQueue queue, IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
        {
            _CoreDbProvider = coreDbProvider;
            this.queue = queue;
            this.serviceScopeFactory = serviceScopeFactory;
            _configuration = configuration;
        }

        public IActionResult SendMail()
        {
            queue.QueueBackgroundWorkItem(async token =>
            {
                await SendMail("Bappy", "bappyist@gmail.com", "880173", "No option", "This is test", serviceScopeFactory);
            });
            return Ok("SMS SEND TO   ");
        }
        private async Task SendMail(string name, string email, string phone, string UserOption, string message, IServiceScopeFactory serviceScopeFactory)
        {
            try
            {
                string to = "bappyist@gmail.com";
                string subject = "Test";

                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetService<CoreDbContext>();
                    IEnumerable<User> userLists = dbContext.Users.ToList();

                    string body = "<p>Hi,<br/> User feedback below</p>";
                    body = body + "<p>User Phone number is : " + phone + "</p>";
                    body = body + "<p>User Phone Email is : " + email + "</p>";
                    body = body + "<p>User selected options is : " + UserOption + "</p>";
                    body = body + "<p>User Message is  : " + message + "</p>";

                    mailSenderRepository.sendMail(body, subject, email, to);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
