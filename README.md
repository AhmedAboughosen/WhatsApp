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



# High-level design

Now let us do a high-level design of our system.

# Architecture
We will be using microservices architecture since it will make it easier to horizontally scale and decouple our services. Each service will have ownership of its own data model. Let's try to divide our system into some core services.

# User Service

This is an HTTP-based service that handles user-related concerns such as authentication and user information.

We have the following tables:

# users

This table will contain a user's information such as name, phoneNumber, and other details.

# Outbox Message

Simply, when your API publishes event messages, it doesn't directly send them. Instead, the messages are persisted in a database table. After that, A job publish events to message broker system in predefined time intervals. Basically The Outbox Pattern provides to publish events reliably.


# API design

CreateAccount(phoneNumber: string): string
VerifyCode(phoneNumber: string,code : string): TokenDto 
setUpAccount(fullName: string,profileImage : bytes): string 
UpdateProfile(fullName: string, dob : string): string 


