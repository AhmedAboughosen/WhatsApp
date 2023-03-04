// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Core.Application.Contracts.Repositories;
// using Core.Domain.Entities;
// using Microsoft.AspNetCore.SignalR;
//
// namespace Infrastructure.Services.BaseService
// {
//    
//     public interface ITweetHub
//     {
//         Task SendTweetToUsers(Guid users,Tweet tweet);
//         
//     }
//
//     public class TweetHub : Hub<ITweetHub>
//     {
//         private readonly IUnitOfWork _unitOfWork;
//
//         public TweetHub(IUnitOfWork unitOfWork)
//         {
//             _unitOfWork = unitOfWork;
//         }
//
//
//         public async Task SendTweetToUsers(Guid user,Tweet tweet)
//         {
//             await Clients.User(user.ToString()).SendTweetToUsers(user,tweet);
//         }
//         
//
//     }
// }