// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/user_builder.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace WhatsApp.User.Grpc.Protos.UserBuilder {

  /// <summary>Holder for reflection information generated from Protos/user_builder.proto</summary>
  public static partial class UserBuilderReflection {

    #region Descriptor
    /// <summary>File descriptor for Protos/user_builder.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static UserBuilderReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChlQcm90b3MvdXNlcl9idWlsZGVyLnByb3RvEg13aGF0c2FwcC51c2VyGh5n",
            "b29nbGUvcHJvdG9idWYvd3JhcHBlcnMucHJvdG8iJQoHUmVxdWVzdBIMCgRw",
            "YWdlGAEgASgFEgwKBHNpemUYAiABKAUicgoIUmVzcG9uc2USOwoRZXZlbnRO",
            "b3RpZmljYXRpb24YASADKAsyIC53aGF0c2FwcC51c2VyLkV2ZW50Tm90aWZp",
            "Y2F0aW9uEgwKBHBhZ2UYAiABKAUSDAoEc2l6ZRgDIAEoBRINCgVjb3VudBgE",
            "IAEoBSKvAQoRRXZlbnROb3RpZmljYXRpb24SKAoCaWQYASABKAsyHC5nb29n",
            "bGUucHJvdG9idWYuU3RyaW5nVmFsdWUSLwoJZnVsbF9uYW1lGAIgASgLMhwu",
            "Z29vZ2xlLnByb3RvYnVmLlN0cmluZ1ZhbHVlEhQKDGNyZWF0ZWRfZGF0ZRgD",
            "IAEoCRIUCgxwaG9uZV9udW1iZXIYBCABKAkSEwoLcHJvZmlsZV91cmwYBSAB",
            "KAkyRgoLVXNlckhpc3RvcnkSNwoEUmVhZBIWLndoYXRzYXBwLnVzZXIuUmVx",
            "dWVzdBoXLndoYXRzYXBwLnVzZXIuUmVzcG9uc2VCKKoCJVdoYXRzQXBwLlVz",
            "ZXIuR3JwYy5Qcm90b3MuVXNlckJ1aWxkZXJiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Google.Protobuf.WellKnownTypes.WrappersReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::WhatsApp.User.Grpc.Protos.UserBuilder.Request), global::WhatsApp.User.Grpc.Protos.UserBuilder.Request.Parser, new[]{ "Page", "Size" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::WhatsApp.User.Grpc.Protos.UserBuilder.Response), global::WhatsApp.User.Grpc.Protos.UserBuilder.Response.Parser, new[]{ "EventNotification", "Page", "Size", "Count" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::WhatsApp.User.Grpc.Protos.UserBuilder.EventNotification), global::WhatsApp.User.Grpc.Protos.UserBuilder.EventNotification.Parser, new[]{ "Id", "FullName", "CreatedDate", "PhoneNumber", "ProfileUrl" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Request : pb::IMessage<Request>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Request> _parser = new pb::MessageParser<Request>(() => new Request());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Request> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::WhatsApp.User.Grpc.Protos.UserBuilder.UserBuilderReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Request() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Request(Request other) : this() {
      page_ = other.page_;
      size_ = other.size_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Request Clone() {
      return new Request(this);
    }

    /// <summary>Field number for the "page" field.</summary>
    public const int PageFieldNumber = 1;
    private int page_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Page {
      get { return page_; }
      set {
        page_ = value;
      }
    }

    /// <summary>Field number for the "size" field.</summary>
    public const int SizeFieldNumber = 2;
    private int size_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Size {
      get { return size_; }
      set {
        size_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Request);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Request other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Page != other.Page) return false;
      if (Size != other.Size) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Page != 0) hash ^= Page.GetHashCode();
      if (Size != 0) hash ^= Size.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (Page != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Page);
      }
      if (Size != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Size);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (Page != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Page);
      }
      if (Size != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Size);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Page != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Page);
      }
      if (Size != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Size);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Request other) {
      if (other == null) {
        return;
      }
      if (other.Page != 0) {
        Page = other.Page;
      }
      if (other.Size != 0) {
        Size = other.Size;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Page = input.ReadInt32();
            break;
          }
          case 16: {
            Size = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            Page = input.ReadInt32();
            break;
          }
          case 16: {
            Size = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class Response : pb::IMessage<Response>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Response> _parser = new pb::MessageParser<Response>(() => new Response());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Response> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::WhatsApp.User.Grpc.Protos.UserBuilder.UserBuilderReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Response() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Response(Response other) : this() {
      eventNotification_ = other.eventNotification_.Clone();
      page_ = other.page_;
      size_ = other.size_;
      count_ = other.count_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Response Clone() {
      return new Response(this);
    }

    /// <summary>Field number for the "eventNotification" field.</summary>
    public const int EventNotificationFieldNumber = 1;
    private static readonly pb::FieldCodec<global::WhatsApp.User.Grpc.Protos.UserBuilder.EventNotification> _repeated_eventNotification_codec
        = pb::FieldCodec.ForMessage(10, global::WhatsApp.User.Grpc.Protos.UserBuilder.EventNotification.Parser);
    private readonly pbc::RepeatedField<global::WhatsApp.User.Grpc.Protos.UserBuilder.EventNotification> eventNotification_ = new pbc::RepeatedField<global::WhatsApp.User.Grpc.Protos.UserBuilder.EventNotification>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::WhatsApp.User.Grpc.Protos.UserBuilder.EventNotification> EventNotification {
      get { return eventNotification_; }
    }

    /// <summary>Field number for the "page" field.</summary>
    public const int PageFieldNumber = 2;
    private int page_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Page {
      get { return page_; }
      set {
        page_ = value;
      }
    }

    /// <summary>Field number for the "size" field.</summary>
    public const int SizeFieldNumber = 3;
    private int size_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Size {
      get { return size_; }
      set {
        size_ = value;
      }
    }

    /// <summary>Field number for the "count" field.</summary>
    public const int CountFieldNumber = 4;
    private int count_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Count {
      get { return count_; }
      set {
        count_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Response);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Response other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!eventNotification_.Equals(other.eventNotification_)) return false;
      if (Page != other.Page) return false;
      if (Size != other.Size) return false;
      if (Count != other.Count) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= eventNotification_.GetHashCode();
      if (Page != 0) hash ^= Page.GetHashCode();
      if (Size != 0) hash ^= Size.GetHashCode();
      if (Count != 0) hash ^= Count.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      eventNotification_.WriteTo(output, _repeated_eventNotification_codec);
      if (Page != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Page);
      }
      if (Size != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Size);
      }
      if (Count != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Count);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      eventNotification_.WriteTo(ref output, _repeated_eventNotification_codec);
      if (Page != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Page);
      }
      if (Size != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Size);
      }
      if (Count != 0) {
        output.WriteRawTag(32);
        output.WriteInt32(Count);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += eventNotification_.CalculateSize(_repeated_eventNotification_codec);
      if (Page != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Page);
      }
      if (Size != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Size);
      }
      if (Count != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Count);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Response other) {
      if (other == null) {
        return;
      }
      eventNotification_.Add(other.eventNotification_);
      if (other.Page != 0) {
        Page = other.Page;
      }
      if (other.Size != 0) {
        Size = other.Size;
      }
      if (other.Count != 0) {
        Count = other.Count;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            eventNotification_.AddEntriesFrom(input, _repeated_eventNotification_codec);
            break;
          }
          case 16: {
            Page = input.ReadInt32();
            break;
          }
          case 24: {
            Size = input.ReadInt32();
            break;
          }
          case 32: {
            Count = input.ReadInt32();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            eventNotification_.AddEntriesFrom(ref input, _repeated_eventNotification_codec);
            break;
          }
          case 16: {
            Page = input.ReadInt32();
            break;
          }
          case 24: {
            Size = input.ReadInt32();
            break;
          }
          case 32: {
            Count = input.ReadInt32();
            break;
          }
        }
      }
    }
    #endif

  }

  public sealed partial class EventNotification : pb::IMessage<EventNotification>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<EventNotification> _parser = new pb::MessageParser<EventNotification>(() => new EventNotification());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<EventNotification> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::WhatsApp.User.Grpc.Protos.UserBuilder.UserBuilderReflection.Descriptor.MessageTypes[2]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EventNotification() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EventNotification(EventNotification other) : this() {
      Id = other.Id;
      FullName = other.FullName;
      createdDate_ = other.createdDate_;
      phoneNumber_ = other.phoneNumber_;
      profileUrl_ = other.profileUrl_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EventNotification Clone() {
      return new EventNotification(this);
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 1;
    private static readonly pb::FieldCodec<string> _single_id_codec = pb::FieldCodec.ForClassWrapper<string>(10);
    private string id_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Id {
      get { return id_; }
      set {
        id_ = value;
      }
    }


    /// <summary>Field number for the "full_name" field.</summary>
    public const int FullNameFieldNumber = 2;
    private static readonly pb::FieldCodec<string> _single_fullName_codec = pb::FieldCodec.ForClassWrapper<string>(18);
    private string fullName_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string FullName {
      get { return fullName_; }
      set {
        fullName_ = value;
      }
    }


    /// <summary>Field number for the "created_date" field.</summary>
    public const int CreatedDateFieldNumber = 3;
    private string createdDate_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string CreatedDate {
      get { return createdDate_; }
      set {
        createdDate_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "phone_number" field.</summary>
    public const int PhoneNumberFieldNumber = 4;
    private string phoneNumber_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string PhoneNumber {
      get { return phoneNumber_; }
      set {
        phoneNumber_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "profile_url" field.</summary>
    public const int ProfileUrlFieldNumber = 5;
    private string profileUrl_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string ProfileUrl {
      get { return profileUrl_; }
      set {
        profileUrl_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as EventNotification);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(EventNotification other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (FullName != other.FullName) return false;
      if (CreatedDate != other.CreatedDate) return false;
      if (PhoneNumber != other.PhoneNumber) return false;
      if (ProfileUrl != other.ProfileUrl) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (id_ != null) hash ^= Id.GetHashCode();
      if (fullName_ != null) hash ^= FullName.GetHashCode();
      if (CreatedDate.Length != 0) hash ^= CreatedDate.GetHashCode();
      if (PhoneNumber.Length != 0) hash ^= PhoneNumber.GetHashCode();
      if (ProfileUrl.Length != 0) hash ^= ProfileUrl.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (id_ != null) {
        _single_id_codec.WriteTagAndValue(output, Id);
      }
      if (fullName_ != null) {
        _single_fullName_codec.WriteTagAndValue(output, FullName);
      }
      if (CreatedDate.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(CreatedDate);
      }
      if (PhoneNumber.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(PhoneNumber);
      }
      if (ProfileUrl.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(ProfileUrl);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (id_ != null) {
        _single_id_codec.WriteTagAndValue(ref output, Id);
      }
      if (fullName_ != null) {
        _single_fullName_codec.WriteTagAndValue(ref output, FullName);
      }
      if (CreatedDate.Length != 0) {
        output.WriteRawTag(26);
        output.WriteString(CreatedDate);
      }
      if (PhoneNumber.Length != 0) {
        output.WriteRawTag(34);
        output.WriteString(PhoneNumber);
      }
      if (ProfileUrl.Length != 0) {
        output.WriteRawTag(42);
        output.WriteString(ProfileUrl);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (id_ != null) {
        size += _single_id_codec.CalculateSizeWithTag(Id);
      }
      if (fullName_ != null) {
        size += _single_fullName_codec.CalculateSizeWithTag(FullName);
      }
      if (CreatedDate.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(CreatedDate);
      }
      if (PhoneNumber.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(PhoneNumber);
      }
      if (ProfileUrl.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(ProfileUrl);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(EventNotification other) {
      if (other == null) {
        return;
      }
      if (other.id_ != null) {
        if (id_ == null || other.Id != "") {
          Id = other.Id;
        }
      }
      if (other.fullName_ != null) {
        if (fullName_ == null || other.FullName != "") {
          FullName = other.FullName;
        }
      }
      if (other.CreatedDate.Length != 0) {
        CreatedDate = other.CreatedDate;
      }
      if (other.PhoneNumber.Length != 0) {
        PhoneNumber = other.PhoneNumber;
      }
      if (other.ProfileUrl.Length != 0) {
        ProfileUrl = other.ProfileUrl;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            string value = _single_id_codec.Read(input);
            if (id_ == null || value != "") {
              Id = value;
            }
            break;
          }
          case 18: {
            string value = _single_fullName_codec.Read(input);
            if (fullName_ == null || value != "") {
              FullName = value;
            }
            break;
          }
          case 26: {
            CreatedDate = input.ReadString();
            break;
          }
          case 34: {
            PhoneNumber = input.ReadString();
            break;
          }
          case 42: {
            ProfileUrl = input.ReadString();
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 10: {
            string value = _single_id_codec.Read(ref input);
            if (id_ == null || value != "") {
              Id = value;
            }
            break;
          }
          case 18: {
            string value = _single_fullName_codec.Read(ref input);
            if (fullName_ == null || value != "") {
              FullName = value;
            }
            break;
          }
          case 26: {
            CreatedDate = input.ReadString();
            break;
          }
          case 34: {
            PhoneNumber = input.ReadString();
            break;
          }
          case 42: {
            ProfileUrl = input.ReadString();
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
