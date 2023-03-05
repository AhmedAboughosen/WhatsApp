// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/Client/media.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Web.Gateway.Proto.Media {
  public static partial class Media
  {
    static readonly string __ServiceName = "whatsapp.media.Media";

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
    static readonly grpc::Marshaller<global::Web.Gateway.Proto.Media.UploadProfileImageRequest> __Marshaller_whatsapp_media_UploadProfileImageRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Web.Gateway.Proto.Media.UploadProfileImageRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Web.Gateway.Proto.Media.UploadProfileImageReply> __Marshaller_whatsapp_media_UploadProfileImageReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Web.Gateway.Proto.Media.UploadProfileImageReply.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Web.Gateway.Proto.Media.UploadChatFileRequest> __Marshaller_whatsapp_media_UploadChatFileRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Web.Gateway.Proto.Media.UploadChatFileRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Web.Gateway.Proto.Media.UploadChatFileReply> __Marshaller_whatsapp_media_UploadChatFileReply = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Web.Gateway.Proto.Media.UploadChatFileReply.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Web.Gateway.Proto.Media.UploadProfileImageRequest, global::Web.Gateway.Proto.Media.UploadProfileImageReply> __Method_UploadProfileImage = new grpc::Method<global::Web.Gateway.Proto.Media.UploadProfileImageRequest, global::Web.Gateway.Proto.Media.UploadProfileImageReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UploadProfileImage",
        __Marshaller_whatsapp_media_UploadProfileImageRequest,
        __Marshaller_whatsapp_media_UploadProfileImageReply);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Web.Gateway.Proto.Media.UploadChatFileRequest, global::Web.Gateway.Proto.Media.UploadChatFileReply> __Method_UploadChatFile = new grpc::Method<global::Web.Gateway.Proto.Media.UploadChatFileRequest, global::Web.Gateway.Proto.Media.UploadChatFileReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UploadChatFile",
        __Marshaller_whatsapp_media_UploadChatFileRequest,
        __Marshaller_whatsapp_media_UploadChatFileReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Web.Gateway.Proto.Media.MediaReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for Media</summary>
    public partial class MediaClient : grpc::ClientBase<MediaClient>
    {
      /// <summary>Creates a new client for Media</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public MediaClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Media that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public MediaClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected MediaClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected MediaClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Web.Gateway.Proto.Media.UploadProfileImageReply UploadProfileImage(global::Web.Gateway.Proto.Media.UploadProfileImageRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UploadProfileImage(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Web.Gateway.Proto.Media.UploadProfileImageReply UploadProfileImage(global::Web.Gateway.Proto.Media.UploadProfileImageRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UploadProfileImage, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Web.Gateway.Proto.Media.UploadProfileImageReply> UploadProfileImageAsync(global::Web.Gateway.Proto.Media.UploadProfileImageRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UploadProfileImageAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Web.Gateway.Proto.Media.UploadProfileImageReply> UploadProfileImageAsync(global::Web.Gateway.Proto.Media.UploadProfileImageRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UploadProfileImage, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Web.Gateway.Proto.Media.UploadChatFileReply UploadChatFile(global::Web.Gateway.Proto.Media.UploadChatFileRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UploadChatFile(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::Web.Gateway.Proto.Media.UploadChatFileReply UploadChatFile(global::Web.Gateway.Proto.Media.UploadChatFileRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UploadChatFile, null, options, request);
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Web.Gateway.Proto.Media.UploadChatFileReply> UploadChatFileAsync(global::Web.Gateway.Proto.Media.UploadChatFileRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UploadChatFileAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual grpc::AsyncUnaryCall<global::Web.Gateway.Proto.Media.UploadChatFileReply> UploadChatFileAsync(global::Web.Gateway.Proto.Media.UploadChatFileRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UploadChatFile, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      protected override MediaClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new MediaClient(configuration);
      }
    }

  }
}
#endregion
