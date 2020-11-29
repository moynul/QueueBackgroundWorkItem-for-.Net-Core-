
Fire and Forget: In application execute some long running task in the background without affecting the main thread. One classic example is sending mails when we are implementing a sign in module. 
Mostly people will either go for a scheduled job independent of the application or do it in the main thread itself.

In my experience 3 ways we can implements fire and forget 
1.	Enterprise Service Bus
a.	NServiceBus
b.	RabbitMQ
2.	Hangfire 
3.	QueueBackgroundWorkItem
I have worked NServiceBus , Hangfire and QueueBackgroundWorkItem. My opinion is QueueBackgroundWorkItem is the best solution. 


