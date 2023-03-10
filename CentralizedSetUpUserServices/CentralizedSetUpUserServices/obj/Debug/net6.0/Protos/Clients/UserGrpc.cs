// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/Clients/user.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace WhatsApp.Create.Grpc.Protos.User {
  public static partial class User
  {
    static readonly string __ServiceName = "whatsapp.user.User";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::WhatsApp.Create.Grpc.Protos.User.CreateAccountRequest> __Marshaller_whatsapp_user_CreateAccountRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::WhatsApp.Create.Grpc.Protos.User.CreateAccountRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::WhatsApp.Create.Grpc.Protos.User.CreateAccountResponse> __Marshaller_whatsapp_user_CreateAccountResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::WhatsApp.Create.Grpc.Protos.User.CreateAccountResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::WhatsApp.Create.Grpc.Protos.User.VerifyCodeRequest> __Marshaller_whatsapp_user_VerifyCodeRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::WhatsApp.Create.Grpc.Protos.User.VerifyCodeRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::WhatsApp.Create.Grpc.Protos.User.VerifyCodeResponse> __Marshaller_whatsapp_user_VerifyCodeResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::WhatsApp.Create.Grpc.Protos.User.VerifyCodeResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::WhatsApp.Create.Grpc.Protos.User.UpdateProfileRequest> __Marshaller_whatsapp_user_UpdateProfileRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::WhatsApp.Create.Grpc.Protos.User.UpdateProfileRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::WhatsApp.Create.Grpc.Protos.User.MessageResponse> __Marshaller_whatsapp_user_MessageResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::WhatsApp.Create.Grpc.Protos.User.MessageResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::WhatsApp.Create.Grpc.Protos.User.SetUpAccountRequest> __Marshaller_whatsapp_user_SetUpAccountRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::WhatsApp.Create.Grpc.Protos.User.SetUpAccountRequest.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::WhatsApp.Create.Grpc.Protos.User.CreateAccountRequest, global::WhatsApp.Create.Grpc.Protos.User.CreateAccountResponse> __Method_CreateAccount = new grpc::Method<global::WhatsApp.Create.Grpc.Protos.User.CreateAccountRequest, global::WhatsApp.Create.Grpc.Protos.User.CreateAccountResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CreateAccount",
        __Marshaller_whatsapp_user_CreateAccountRequest,
        __Marshaller_whatsapp_user_CreateAccountResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::WhatsApp.Create.Grpc.Protos.User.VerifyCodeRequest, global::WhatsApp.Create.Grpc.Protos.User.VerifyCodeResponse> __Method_VerifyCode = new grpc::Method<global::WhatsApp.Create.Grpc.Protos.User.VerifyCodeRequest, global::WhatsApp.Create.Grpc.Protos.User.VerifyCodeResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "VerifyCode",
        __Marshaller_whatsapp_user_VerifyCodeRequest,
        __Marshaller_whatsapp_user_VerifyCodeResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::WhatsApp.Create.Grpc.Protos.User.UpdateProfileRequest, global::WhatsApp.Create.Grpc.Protos.User.MessageResponse> __Method_UpdateProfile = new grpc::Method<global::WhatsApp.Create.Grpc.Protos.User.UpdateProfileRequest, global::WhatsApp.Create.Grpc.Protos.User.MessageResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateProfile",
        __Marshaller_whatsapp_user_UpdateProfileRequest,
        __Marshaller_whatsapp_user_MessageResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::WhatsApp.Create.Grpc.Protos.User.SetUpAccountRequest, global::WhatsApp.Create.Grpc.Protos.User.MessageResponse> __Method_SetUpAccount = new grpc::Method<global::WhatsApp.Create.Grpc.Protos.User.SetUpAccountRequest, global::WhatsApp.Create.Grpc.Protos.User.MessageResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "SetUpAccount",
        __Marshaller_whatsapp_user_SetUpAccountRequest,
        __Marshaller_whatsapp_user_MessageResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::WhatsApp.Create.Grpc.Protos.User.UserReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for User</summary>
    public partial class UserClient : grpc::ClientBase<UserClient>
    {
      /// <summary>Creates a new client for User</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public UserClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for User that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public UserClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected UserClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected UserClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::WhatsApp.Create.Grpc.Protos.User.CreateAccountResponse CreateAccount(global::WhatsApp.Create.Grpc.Protos.User.CreateAccountRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateAccount(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::WhatsApp.Create.Grpc.Protos.User.CreateAccountResponse CreateAccount(global::WhatsApp.Create.Grpc.Protos.User.CreateAccountRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CreateAccount, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::WhatsApp.Create.Grpc.Protos.User.CreateAccountResponse> CreateAccountAsync(global::WhatsApp.Create.Grpc.Protos.User.CreateAccountRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CreateAccountAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::WhatsApp.Create.Grpc.Protos.User.CreateAccountResponse> CreateAccountAsync(global::WhatsApp.Create.Grpc.Protos.User.CreateAccountRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CreateAccount, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::WhatsApp.Create.Grpc.Protos.User.VerifyCodeResponse VerifyCode(global::WhatsApp.Create.Grpc.Protos.User.VerifyCodeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return VerifyCode(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::WhatsApp.Create.Grpc.Protos.User.VerifyCodeResponse VerifyCode(global::WhatsApp.Create.Grpc.Protos.User.VerifyCodeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_VerifyCode, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::WhatsApp.Create.Grpc.Protos.User.VerifyCodeResponse> VerifyCodeAsync(global::WhatsApp.Create.Grpc.Protos.User.VerifyCodeRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return VerifyCodeAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::WhatsApp.Create.Grpc.Protos.User.VerifyCodeResponse> VerifyCodeAsync(global::WhatsApp.Create.Grpc.Protos.User.VerifyCodeRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_VerifyCode, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::WhatsApp.Create.Grpc.Protos.User.MessageResponse UpdateProfile(global::WhatsApp.Create.Grpc.Protos.User.UpdateProfileRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateProfile(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::WhatsApp.Create.Grpc.Protos.User.MessageResponse UpdateProfile(global::WhatsApp.Create.Grpc.Protos.User.UpdateProfileRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UpdateProfile, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::WhatsApp.Create.Grpc.Protos.User.MessageResponse> UpdateProfileAsync(global::WhatsApp.Create.Grpc.Protos.User.UpdateProfileRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UpdateProfileAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::WhatsApp.Create.Grpc.Protos.User.MessageResponse> UpdateProfileAsync(global::WhatsApp.Create.Grpc.Protos.User.UpdateProfileRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UpdateProfile, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::WhatsApp.Create.Grpc.Protos.User.MessageResponse SetUpAccount(global::WhatsApp.Create.Grpc.Protos.User.SetUpAccountRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SetUpAccount(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::WhatsApp.Create.Grpc.Protos.User.MessageResponse SetUpAccount(global::WhatsApp.Create.Grpc.Protos.User.SetUpAccountRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_SetUpAccount, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::WhatsApp.Create.Grpc.Protos.User.MessageResponse> SetUpAccountAsync(global::WhatsApp.Create.Grpc.Protos.User.SetUpAccountRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return SetUpAccountAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::WhatsApp.Create.Grpc.Protos.User.MessageResponse> SetUpAccountAsync(global::WhatsApp.Create.Grpc.Protos.User.SetUpAccountRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_SetUpAccount, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override UserClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new UserClient(configuration);
      }
    }

  }
}
#endregion
