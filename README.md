# WhatsApp Clone in asp.net core 

Whatsapp is a chat application that provides instant messaging services to its users. It is one of the most used mobile applications on the planet connecting over 2 billion users in 180+ countries. Whatsapp is also available on the web.

# Requirements
Our system should meet the following requirements:

# Functional requirements
1. Should support one-on-one chat.
2. Group chats (max 100 people).
3. Should support file sharing (image, video, etc.).


#  Non-functional requirements
1. High availability with minimal latency.
2. The system should be scalable and efficient.


# tech stack used.

1. Message broker using RabbitMQ
2. microservices architecture.
3. microservices pattern such as (outbox pattern)
4. manage distributed transaction using saga.
5. Firebase Cloud for media.
6. Asp core 6.0
7. API Gateway Pattern.
8. Sql server



# High-level design

Now let us do a high-level design of our system.

# Architecture
We will be using microservices architecture since it will make it easier to horizontally scale and decouple our services. Each service will have ownership of its own data model. Let's try to divide our system into some core services.

# User Service

This is an HTTP-based service that handles user-related concerns such as authentication and user information.

We have the following tables:

1. users

This table will contain a user's information such as name, phoneNumber, and other details.

2. Outbox Message

Simply, when your API publishes event messages, it doesn't directly send them. Instead, the messages are persisted in a database table. After that, A job publish events to message broker system in predefined time intervals. Basically The Outbox Pattern provides to publish events reliably.


3. API design

1. CreateAccount(phoneNumber: string): string
2. VerifyCode(phoneNumber: string,code : string): TokenDto 
3. setUpAccount(fullName: string,profileImage : bytes): string 
4. UpdateProfile(fullName: string, dob : string): string 

# Presence Service

The presence service will keep track of the last seen status of all users. It will be discussed in detail separately.

1. Presence

This table will contain a user's information such as id, last seen.

2. API design

1. CheckIn(id: string): string
2. CheckOut(id: string): string 
3. LastStatus(id: string): string 

# Chat Service
The chat service will use WebSockets and establish connections with the client to handle chat and group message-related functionality. We can also use cache to keep track of all the active connections sort of like sessions which will help us determine if the user is online or not.

# Notification Service

This service will simply send push notifications to the users. It will be discussed in detail separately.

# Media service

This service will handle the media (images, videos, files, etc.) uploads. It will be discussed in detail separately.


